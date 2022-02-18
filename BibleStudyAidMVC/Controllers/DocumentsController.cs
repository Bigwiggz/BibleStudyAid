using AutoMapper;
using BibleStudyAidMVC.Extensions;
using BibleStudyAidMVC.ViewModels;
using BibleStudyDataAccessLibrary.DataAccess;
using BibleStudyDataAccessLibrary.HelperMethods;
using BibleStudyDataAccessLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BibleStudyAidMVC.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly IDocumentsData _documentsData;
        private readonly ILogger<Documents> _logger;
        private readonly IMapper _mapper;
        private readonly IDocumentMigration _documentMigration;
        private readonly IDataAccessHelperMethods _dataAccessHelperMethods;

        public DocumentsController(IDocumentsData documentsData, ILogger<Documents> logger, IMapper mapper, IDocumentMigration documentMigration, IDataAccessHelperMethods dataAccessHelperMethods)
        {
            _documentsData = documentsData;
            _logger = logger;
            _mapper = mapper;
            _documentMigration = documentMigration;
            _dataAccessHelperMethods = dataAccessHelperMethods;
        }
        // GET DOWNLOAD CONTROLLER
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DownloadAsync(string downloadIdString)
        {
            var IdListInfo=JsonSerializer.Deserialize<List<int>>(downloadIdString);
            if(IdListInfo.Count>0)
            {
                var documentsList= new List<Documents>();
                
                foreach(var Id in IdListInfo)
                {   
                    var documentModel=await _documentsData.GetByIdAsync(Id);
                    documentsList.Add(documentModel);
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
                var model= await _documentsData.GetByIdAsync(viewModel.Id);
                await _documentMigration.UpdateSingleFile(viewModel,model);
                var updatedId=await _documentsData.UpdateAsync(model);
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
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            try
            {
                var model=await _documentsData.GetByIdAsync(Id);
                var deletedId= await _documentsData.DeleteAsync(Id);
                _documentMigration.DeleteSingleFile(model);
                return Redirect(HttpContext.Request.Headers["Referer"]);
            }
            catch
            {
                return View();
            }
        }

        //Test Download
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DownloadTestAsync(string downloadIdString)
        {
            var Id = 1;
            var Id2 = 2;
            var documentsList = new List<Documents>();
            var documentModel = await _documentsData.GetByIdAsync(Id);
            documentsList.Add(documentModel);
            var documentModel2 = await _documentsData.GetByIdAsync(Id2);
            documentsList.Add(documentModel2);
            var fileResult = await _documentMigration.DownloadMultipleFilesAsync(documentsList);
            return File(fileResult.fileBytes, fileResult.contentType, fileResult.fileName);
            
        }

        //POST PrimaryProjectEdit to Primary Table
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PrimaryProjectEdit(string foreignKey)
        {
            try
            {
                var topLevelTableSelectorModel = await _dataAccessHelperMethods.SelectTopLevelTableGivenForiegnKey(foreignKey);
                return RedirectToAction("Edit", topLevelTableSelectorModel.ControllerName, topLevelTableSelectorModel.Id);
            }
            catch
            {
                return View();
            }
        }
    }
}
