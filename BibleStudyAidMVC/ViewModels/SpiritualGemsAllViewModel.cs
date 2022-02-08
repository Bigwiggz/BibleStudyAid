using BibleStudyDataAccessLibrary.Models;

namespace BibleStudyAidMVC.ViewModels
{
    public class SpiritualGemsAllViewModel:SpiritualGemsViewModel
    {
        public List<References> ReferencesList { get; set; }=new List<References>();
        public List<ScripturesViewModel> ScripturesList { get; set; }=new List<ScripturesViewModel>();
        public List<Tags> Tags { get; set; } = new List<Tags>();
        public List<Documents> DocumentsList { get; set; } = new List<Documents>();
        public List<IFormFile> DocumentFiles { get; set; }=new List<IFormFile>();
    }
}
