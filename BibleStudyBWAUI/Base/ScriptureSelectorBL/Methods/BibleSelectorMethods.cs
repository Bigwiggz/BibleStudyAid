using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Reflection;
using BibleStudyBWAUI.Base.ScriptureSelectorBL.Models;
using System.Threading.Tasks;

namespace BibleStudyBWAUI.Base.ScriptureSelectorBL.Methods
{
    public class BibleSelectorMethods
    {
        private readonly BibleBook[] bibleBookInfo;

        public List<string> BibleBookList { get; set; }
        public BibleCitation BibleCitation { get; set; }

        public BibleSelectorMethods()
        {
            bibleBookInfo = LoadBibleTextValidation();
            BibleBookList = GetBibleBookNameList(bibleBookInfo);

        }

        //This method loads the Bible Text Verse validation into an object
        private BibleBook[] LoadBibleTextValidation()
        {
            string textBible;
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "BibleStudyBWAUI.Base.ScriptureSelectorBL.Input.BibleTextVerse.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                textBible = reader.ReadToEnd();
            }
            

            var BibleBookInfo = JsonConvert.DeserializeObject<BibleBook[]>(textBible);

            return BibleBookInfo;
        }

        //This function is to get the number of books
        private List<string> GetBibleBookNameList(BibleBook[] bibleBookList)
        {
            List<string> bookList = new List<string>();

            foreach (var item in bibleBookList)
            {
                bookList.Add(item.name);
            }
            return bookList;
        }

        //This function will give the max number of chapters when a book name is selected
        public List<int> GetNumberOfChapters(string BookName)
        {
            //Get the correct Book index
            bool IsWrongSelectedBook = true;
            int i = 0;
            int bookIndex;
            int numberOfChapters = 0;
            do
            {
                if (bibleBookInfo[i].name == BookName)
                {
                    bookIndex = i;
                    numberOfChapters = bibleBookInfo[i].chapters.Length;
                    IsWrongSelectedBook = false;
                }
                i++;
            } while (IsWrongSelectedBook);

            //Initialize the Chapter List
            List<int> chapterList = new List<int>();

            //Add Values to Chapter List
            for (int j = 0; j < numberOfChapters; j++)
            {
                chapterList.Add(j + 1);
            }

            return chapterList;
        }

        //This is the method to load the number of verses
        public List<int> GetNumberofVerses(string BookName, int chapter)
        {
            int indexedChapter = chapter - 1;

            //Get the correct Book index
            bool IsWrongSelectedBook = true;
            int i = 0;
            int bookIndex;
            int verseAmount = 0;
            do
            {
                if (bibleBookInfo[i].name == BookName)
                {
                    bookIndex = i;
                    verseAmount = bibleBookInfo[i].chapters[indexedChapter];
                    IsWrongSelectedBook = false;
                }
                i++;
            } while (IsWrongSelectedBook);

            //Initialize the Chapter List
            List<int> verseList = new List<int>();

            //Add Values to Chapter List
            for (int j = 0; j < verseAmount; j++)
            {
                verseList.Add(j + 1);
            }

            return verseList;
        }

    }
}
