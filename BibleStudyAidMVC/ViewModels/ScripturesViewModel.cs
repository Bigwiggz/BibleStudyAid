namespace BibleStudyAidMVC.ViewModels
{
    public class ScripturesViewModel
    {
        public int Id { get; set; }
        public string Scripture { get; set; }
        public string Book { get; set; }
        public string Chapter { get; set; }
        public string Verse { get; set; }
        public Guid UniqueId { get; set; }
        public string FKTableIdandName { get; set; }
        public string Description { get; set; }
        public string ScriptureText { get; set; }
        public bool IsDeleted { get; set; }
    }
}
