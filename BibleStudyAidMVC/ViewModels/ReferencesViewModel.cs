namespace BibleStudyAidMVC.ViewModels
{
    public class ReferencesViewModel
    {
        public int Id { get; set; }
        public string FKTableIdandName { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}
