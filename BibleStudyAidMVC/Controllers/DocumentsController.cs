using AutoMapper;
using BibleStudyAidMVC.Extensions;
using BibleStudyAidMVC.ViewModels;
using BibleStudyDataAccessLibrary.DataAccess;
using BibleStudyDataAccessLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibleStudyAidMVC.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly IDocumentsData _documentsData;
        private readonly ILogger<Documents> _logger;
        private readonly IMapper _mapper;
        private readonly IDocumentMigration _documentMigration;

        public DocumentsController(IDocumentsData documentsData, ILogger<Documents> logger, IMapper mapper, IDocumentMigration documentMigration)
        {
            _documentsData = documentsData;
            _logger = logger;
            _mapper = mapper;
            _documentMigration = documentMigration;
        }
        // GET DOWNLOAD CONTROLLER
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DownloadAsync(int[] IdList)
        {
            if(IdList.Length>0)
            {
                var documentsList= new List<Documents>();
                
                foreach(var Id in IdList)
                {   
                    var documentModel=await _documentsData.GetByIdAsync(Id);
                    documentsList.add(documentModel);
                }
                
                var fileResult= await _documentMigration.DownloadMultipleFilesAsync(documentsList);
                
                return File(fileResult.fileBytes,fileResult.contentType,fileResult.fileName);
            }
            
            return NotFound();
        }
        // GET: DocumentsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DocumentsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DocumentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DocumentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadAsync([Bind("FKTableIdandName","Document")] DocumentsUpload documentsUploadViewModelList)
        {
            try
            {
                var viewModelList = new List<DocumentsViewModel>();

                foreach (var document in documentsUploadViewModelList.Document)
                {
                   var newDoc = new DocumentsViewModel
                   {
                       FKTableIdandName=documentsUploadViewModelList.FKTableIdandName,
                       Document=document
                   };
                    viewModelList.Add(newDoc);
                }
                
                var modelList = _mapper.Map<List<Documents>>(viewModelList);
                await _documentMigration.UploadMultipleFilesAysnc(viewModelList, modelList);

                foreach (var model in modelList)
                {
                    var Id =await _documentsData.InsertAsync(model);
                }
                return Redirect(HttpContext.Request.Headers["Referer"]);
            }
            catch
            {
                return View();
            }
        }

        // GET: DocumentsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DocumentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync([Bind("Id","FKTableIdandName","Document")] DocumentsViewModel viewModel)
        {
            try
            {
                var model= await _documentsData.GetByIdAsync(Id);
                await _documentMigration.UpdateSingleFile(viewModel,model);
                var updatedId=await_documentsData.UpdateAsync(model);
                return Redirect(HttpContext.Request.Headers["Referer"]);
            }
            catch
            {
                return View();
            }
        }

        // GET: DocumentsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DocumentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var model=await _documents.Data.GetByIdAsync(Id);
                var deletedId= await _documentsData.DeleteByIdAsync(Id);
                await _documentMigration.DeleteSingleFile(model);
                return Redirect(HttpContext.Request.Headers["Referer"]);
            }
            catch
            {
                return View();
            }
        }
    }
}
