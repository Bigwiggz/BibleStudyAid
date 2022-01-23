
using BibleStudyAidMVC.ViewModels;
using BibleStudyDataAccessLibrary.Models;

namespace BibleStudyAidMVC.Extensions
{
    public class DocumentMigration
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;

        public DocumentMigration(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }

        public async Task UploadMultipleFilesAysnc(List<DocumentsViewModel> viewModel, List<Documents> model)
        {   //TODO: Setup a production and develop environment for blob storage
            //TODO: Figure out how to sanitize documents before uploading them
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, _configuration.GetSection("FileBlobStorage")["FolderName"]);
            foreach (var viewModelDocument in viewModel)
            {
                var viewModelDocumentGUID = new Guid();
                var uniqueFileName= $"{ viewModelDocumentGUID.ToString()}_{viewModelDocument.Document.FileName}";

                foreach (var document in model)
                {
                    document.ContentType = viewModelDocument.Document.ContentType;
                    document.UniqueGUIDId = viewModelDocumentGUID;
                    document.UniqueFileName = $"{ viewModelDocumentGUID.ToString()}_{viewModelDocument.Document.FileName}";
                    document.FileName = viewModelDocument.Document.FileName;
                    document.Name=viewModelDocument.Document.Name;
                    document.ContentSize = viewModelDocument.Document.Length;
                    document.ContentDisposition = viewModelDocument.Document.ContentDisposition;
                }
                string filePath=Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await viewModelDocument.Document.CopyToAsync(stream);
                    await stream.FlushAsync();
                }
                
            }
        }

        public async Task DownloadMultipleFilesAsync(List<DocumentsViewModel> viewModel, List<Documents> model)
        {
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, _configuration.GetSection("FileBlobStorage")["FolderName"]);
        }
    }
}
