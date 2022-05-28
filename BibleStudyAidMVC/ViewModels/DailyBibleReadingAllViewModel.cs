using BibleStudyDataAccessLibrary.Models;

namespace BibleStudyAidMVC.ViewModels
{
    public class DailyBibleReadingAllViewModel:DailyBibleReadingViewModel
    {
        public List<References> ReferencesList { get; set; } = new List<References>();
        public List<Scriptures> ScripturesList { get; set; }=new List<Scriptures> ();
        public List<Tags> Tags { get; set; }= new List<Tags>();
        public List<Documents> DocumentsList { get; set; }=new List<Documents>();
        public List<IFormFile> DocumentFiles { get; set; } = new List<IFormFile>();
        public string WorldMapItems { get; set; }
        public string BibleText { get; set; }
    }
}
