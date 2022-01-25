
using BibleStudyAidMVC.ViewModels;
using BibleStudyDataAccessLibrary.Models;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.AspNetCore.Mvc;

namespace BibleStudyAidMVC.Extensions
{
    public class DocumentMigration : IDocumentMigration
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;

        public DocumentMigration(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }

        public async Task UpdateSingleFile(DocumentsViewModel viewModel, Documents model)
        {
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, _configuration.GetSection("FileBlobStorage")["FolderName"]);
            
            var viewModelDocumentGUID = Guid.NewGuid();
            var uniqueFileName = $"{viewModelDocumentGUID.ToString()}_{viewModel[i].Document.FileName}";
            string filePath = Path.Combine(uploadsFolder, model.uniqueFileName);
            
            if(File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            
            // Create a new file path
            filePath = Path.Combine(uploadsFolder, uniqueFileName);
            
            model.Id=viewModel.Id;
            model.FKTableIdandName=viewModel.FKTableIdandName;
            model.ContentType = viewModel.Document.ContentType;
            model.UniqueGUIDId = viewModelDocumentGUID;
            model.UniqueFileName = uniqueFileName;
            model.FileName = viewModel.Document.FileName;
            model.Name = viewModel.Document.Name;
            model.ContentSize = viewModel.Document.Length;
            model.ContentDisposition = viewModel.Document.ContentDisposition;

            
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await viewModel.Document.CopyToAsync(stream);
                await stream.FlushAsync();
            }
        }

        public void DeleteSingleFile(Documents model)
        {
            //TODO: add public async Task DeleteSingleFile(Documents model)
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, _configuration.GetSection("FileBlobStorage")["FolderName"]);
            string filePath = Path.Combine(uploadsFolder, model.UniqueFileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public async Task UploadMultipleFilesAysnc(List<DocumentsViewModel> viewModel, List<Documents> model)
        {   //TODO: Setup a production and develop environment for blob storage
            //TODO: Figure out how to sanitize documents before uploading them
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, _configuration.GetSection("FileBlobStorage")["FolderName"]);

            if (model.Count > 0)
            {
                for (int i = 0; i < viewModel.Count; i++)
                {
                    var viewModelDocumentGUID = Guid.NewGuid();
                    var uniqueFileName = $"{viewModelDocumentGUID.ToString()}_{viewModel[i].Document.FileName}";
                    
                    model[i].FKTableIdandName=viewModel[i].FKTableIdandName;
                    model[i].ContentType = viewModel[i].Document.ContentType;
                    model[i].UniqueGUIDId = viewModelDocumentGUID;
                    model[i].UniqueFileName = uniqueFileName;
                    model[i].FileName = viewModel[i].Document.FileName;
                    model[i].Name = viewModel[i].Document.Name;
                    model[i].ContentSize = viewModel[i].Document.Length;
                    model[i].ContentDisposition = viewModel[i].Document.ContentDisposition;

                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await viewModel[i].Document.CopyToAsync(stream);
                        await stream.FlushAsync();
                    }

                }
            }
        }

        public async Task<(byte[] fileBytes, string contentType, string fileName)> DownloadMultipleFilesAsync(List<Documents> model)
        {
            byte[] fileBytes;
            string contentType = "application/octet-stream";
            string fileName = "";
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, _configuration.GetSection("FileBlobStorage")["FolderName"]);
            if (model.Count == 1)
            {
                string filePath = Path.Combine(uploadsFolder, model[0].UniqueFileName);
                fileBytes = await File.ReadAllBytesAsync(filePath);
                contentType = model[0].ContentType;
                fileName = model[0].FileName;
            }
            else
            {
                fileBytes = await ZipMultipleFilesAsync(model, uploadsFolder);
                var myUniqueFileName = string.Format($"ZipFile_{DateTime.Now.Ticks}.zip");
                fileName = myUniqueFileName;
            }
            return (fileBytes, contentType, fileName);
            //https://www.youtube.com/watch?v=DuAXUbxGcVc
            //https://ourcodeworld.com/articles/read/629/how-to-create-and-extract-zip-files-compress-and-decompress-zip-with-sharpziplib-with-csharp-in-winforms

            /*
             * //Build the File Path.
                string path = Path.Combine(this.Environment.WebRootPath, "Files/") + fileName;
 
                //Read the File data into Byte Array.
                byte[] bytes = System.IO.File.ReadAllBytes(path);
 
                //Send the File to Download.
                return File(bytes, "application/octet-stream", fileName);
             */
        }

        private async Task<byte[]> ZipMultipleFilesAsync(List<Documents> model, string folderpath, int zipCompressionLevel = 9)
        {
            var outputMemStream = new MemoryStream();
            using (ZipOutputStream zipOutputStream = new ZipOutputStream(outputMemStream))
            {
                zipOutputStream.SetLevel(zipCompressionLevel);

                byte[] buffer = new byte[4096];

                foreach (var document in model)
                {
                    string filePath = Path.Combine(folderpath, document.FileName);

                    var entry = new ZipEntry(filePath);

                    entry.DateTime = DateTime.UtcNow;
                    zipOutputStream.PutNextEntry(entry);

                    using (FileStream fileStream = File.OpenRead(filePath))
                    {
                        int sourceBytes;
                        do
                        {
                            sourceBytes = await fileStream.ReadAsync(buffer, 0, buffer.Length);
                            await zipOutputStream.WriteAsync(buffer, 0, sourceBytes);
                        } while (sourceBytes > 0);
                    }
                    zipOutputStream.Finish();
                    zipOutputStream.Close();
                }
                byte[] resultFileBytes = outputMemStream.GetBuffer();
                long fileLength = outputMemStream.Length;

                return resultFileBytes;
            }
        }
    }
}
