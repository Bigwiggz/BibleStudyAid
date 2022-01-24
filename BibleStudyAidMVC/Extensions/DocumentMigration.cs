
using BibleStudyAidMVC.ViewModels;
using BibleStudyDataAccessLibrary.Models;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.AspNetCore.Mvc;

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

            if(model.Count > 0)
            {
                foreach (var viewModelDocument in viewModel)
                {
                    var viewModelDocumentGUID = new Guid();
                    var uniqueFileName = $"{ viewModelDocumentGUID.ToString()}_{viewModelDocument.Document.FileName}";
                    for (int i = 0; i < model.Count; i++)
                    {
                        model[i].ContentType = viewModelDocument.Document.ContentType;
                        model[i].UniqueGUIDId = viewModelDocumentGUID;
                        model[i].UniqueFileName = $"{ viewModelDocumentGUID.ToString()}_{viewModelDocument.Document.FileName}";
                        model[i].FileName = viewModelDocument.Document.FileName;
                        model[i].Name = viewModelDocument.Document.Name;
                        model[i].ContentSize = viewModelDocument.Document.Length;
                        model[i].ContentDisposition = viewModelDocument.Document.ContentDisposition;
                    }

                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await viewModelDocument.Document.CopyToAsync(stream);
                        await stream.FlushAsync();
                    }

                }
            }
            else
            {
                //TODO: Finish this error
                throw;
            }
        }

        public async Task<byte[]> DownloadMultipleFilesAsync(List<DocumentsViewModel> viewModel, List<Documents> model)
        {
            byte[] fileBytes;
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, _configuration.GetSection("FileBlobStorage")["FolderName"]);
            if(model.Count == 1)
            {
                string filePath=Path.Combine(uploadsFolder, model[0].UniqueFileName); 
                fileBytes=await File.ReadAllBytesAsync(filePath);
            }
            else
            {
                fileBytes= await ZipMultipleFilesAsync(model, uploadsFolder);
            }
            return fileBytes;
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

        private async Task<byte[]> ZipMultipleFilesAsync(List<Documents> model, string folderpath , int zipCompressionLevel=9)
        {
            var outputMemStream=new MemoryStream();
            using(ZipOutputStream zipOutputStream=new ZipOutputStream(outputMemStream))
            {
                zipOutputStream.SetLevel(zipCompressionLevel);

                byte[] buffer = new byte[4096];

                foreach (var document in model)
                {
                    string filePath = Path.Combine(folderpath, document.FileName);

                    var entry=new ZipEntry(filePath);

                    entry.DateTime = DateTime.UtcNow;
                    zipOutputStream.PutNextEntry(entry);

                    using(FileStream fileStream = File.OpenRead(filePath))
                    {
                        int sourceBytes;
                        do
                        {
                            sourceBytes = fileStream.Read(buffer, 0, buffer.Length);
                            zipOutputStream.Write(buffer, 0, sourceBytes);
                        } while (sourceBytes > 0);
                    }
                    zipOutputStream.Finish();
                    zipOutputStream.Close();
                }
                byte[] resultFileBytes=outputMemStream.ToBuffer();
                long fileLength = outputMemStream.Length;
                
                return resultFileBytes;
            }
        }
    }
}
