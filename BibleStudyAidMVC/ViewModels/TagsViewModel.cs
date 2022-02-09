
namespace BibleStudyAidMVC.ViewModels
{
    public class TagsViewModel
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public string TagDescription { get; set; }
        public string TagColor { get; set; }
        public string TagTextColor { get; set; }
        public DateTime TagCreatedDate { get; }
        public bool IsDeleted { get; set; }
    }
}
