using Humanizer;

namespace BibleStudyAidMVC.ViewModels
{
    public class ReferencesViewModel
    {
        public int Id { get; set; }
        public string FKTableIdandName { get; set; }
        public string ReferenceIsFrom
        {
            get { return FKTableIdandName.Substring(FKTableIdandName.IndexOf("tbl")+3).Humanize(LetterCasing.Title); }
        }
        public string Reference { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}
