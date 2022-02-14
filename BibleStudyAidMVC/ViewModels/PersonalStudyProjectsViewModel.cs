namespace BibleStudyAidMVC.ViewModels
{
    public class PersonalStudyProjectsViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; }
        public string PersonalStudyTitle { get; set; }
        public string PersonalStudyQuestionAssignment { get; set; }
        public DateTime DateFinished { get; set; }
        public string BaseScripture { get; set; }
        public string PKIdtblPersonalStudyProjects { get; set; }
        public bool IsDeleted { get; set; }
    }
}
