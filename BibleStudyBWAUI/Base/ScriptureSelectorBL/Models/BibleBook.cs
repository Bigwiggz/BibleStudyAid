namespace BibleStudyBWAUI.Base.ScriptureSelectorBL.Models
{
    public class BibleBook
    {
        public string name { get; set; }
        public string osisId { get; set; }
        public string abbr { get; set; }
        public string ord { get; set; }
        public string testament { get; set; }
        public int[] chapters { get; set; }
    }

}
