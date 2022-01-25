using BibleStudyAidMVC.ViewModels;
using BibleStudyDataAccessLibrary.Models;

namespace BibleStudyAidMVC.Extensions
{
    public interface IDocumentMigration
    {
        void DeleteSingleFile(Documents model);
        Task<(byte[] fileBytes, string contentType, string fileName)> DownloadMultipleFilesAsync(List<Documents> model);
        Task UpdateSingleFile(DocumentsViewModel viewModel, Documents model);
        Task UploadMultipleFilesAysnc(List<DocumentsViewModel> viewModel, List<Documents> model);
    }
}