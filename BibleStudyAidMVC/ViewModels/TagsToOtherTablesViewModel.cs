namespace BibleStudyAidMVC.ViewModels
{
    public class TagsToOtherTablesViewModel
    {
        public int Id { get; set; }
        public int TagsId { get; set; }
        public string FKTableIdandName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
