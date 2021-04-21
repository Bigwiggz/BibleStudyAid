using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleStudyInfoAPI.Validators.ScriptureValidatorExtensions
{
    public class ScriptureValidatorExtension
    {
        //Verified Book
        public bool BeVerifiedBibleBook(string bookEntered)
        {
            bool isVerifiedBook = false;
            isVerifiedBook = books.Any(book => book == bookEntered);
            return isVerifiedBook;
        }

        //Verified Chapter
        public bool BeVerifiedChapter(string chapterEntered, string bookEntered)
        {
            bool isVerifiedChapter = false;
            if(chapterEntered!=null && int.Parse(chapterEntered)<150)
            {
                isVerifiedChapter = true;
            }
            else if(chapterEntered==null && singleChapterBooks.Any(book=>book==bookEntered))
            {
                isVerifiedChapter = true;
            }

            return isVerifiedChapter;
        }

        //Verified Verse
        public bool BeVerifiedVerse(string chapterEntered)
        {
            bool isVerifiedVerse = false;
            if (int.Parse(chapterEntered)<176)
            {
                isVerifiedVerse = true;
            }
            return isVerifiedVerse;
        }

        //List of Bible books without chapters
        string[] singleChapterBooks = new string[]
        {
            "Philemon",
            "2 John",
            "3 John",
            "Jude"
        };

        //List of Bible Books
        string[] books = new string[]
        {
            "Genesis",
            "Exodus",
            "Leviticus",
            "Numbers",
            "Deuteronomy",
            "Joshua",
            "Judges",
            "Ruth",
            "1 Samuel",
            "2 Samuel",
            "1 Kings",
            "2 Kings",
            "1 Chronicles",
            "2 Chronicles",
            "Ezra",
            "Nehemiah",
            "Esther",
            "Job",
            "Psalm",
            "Proverbs",
            "Ecclesiastes",
            "Song of Solomon",
            "Isaiah",
            "Jeremiah",
            "Lamentations",
            "Ezekiel",
            "Daniel",
            "Hosea",
            "Joel",
            "Amos",
            "Obadiah",
            "Jonah",
            "Micah",
            "Nahum",
            "Habakkuk",
            "Zephaniah",
            "Haggai",
            "Zechariah",
            "Malachi",
            "Matthew",
            "Mark",
            "Luke",
            "John",
            "Acts",
            "Romans",
            "1 Corinthians",
            "2 Corinthians",
            "Galatians",
            "Ephesians",
            "Philippians",
            "Colossians",
            "1 Thessalonians",
            "2 Thessalonians",
            "1 Timothy",
            "2 Timothy",
            "Titus",
            "Philemon",
            "Hebrews",
            "James",
            "1 Peter",
            "2 Peter",
            "1 John",
            "2 John",
            "3 John",
            "Jude",
            "Revelation"
        };


    }
}
