using BibleStudyDataAccessLibrary.Models;

namespace BibleStudyAidMVC.ViewModels
{
    public class SpiritualGemsAllViewModel:SpiritualGemsViewModel
    {
        public List<References> ReferencesList { get; set; }
        public List<ScripturesViewModel> ScripturesList { get; set; }
        public List<Tags> Tags { get; set; }
        public List<Documents> DocumentsList { get; set; }
        public List<IFormFile> DocumentFiles { get; set; }
    }
}
