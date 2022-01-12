namespace BibleStudyAidMVC.ViewModels
{

    public class BibleTextAPIViewModel
    {
        public string reference { get; set; }
        public Vers[] verses { get; set; }
        public string text { get; set; }
        public string translation_id { get; set; }
        public string translation_name { get; set; }
        public string translation_note { get; set; }
    }

    public class Vers
    {
        public string book_id { get; set; }
        public string book_name { get; set; }
        public int chapter { get; set; }
        public int verse { get; set; }
        public string text { get; set; }
        }

    
}
