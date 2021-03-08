
using BibleStudyBWAUI.Base.ScriptureSelectorBL.Methods;
using BibleStudyBWAUI.Base.ScriptureSelectorBL.Models;
using BibleStudyBWAUI.ViewModels;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.DropDowns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BibleStudyBWAUI.Base
{
    public class ScriptureSelectorBase: ComponentBase
    {
        //Hidden fields
        [Parameter]
        public string tblId { get; set; }

        [Inject]
        public HttpClient Http { get; set; }

        //Initialize Bible Verification
        BibleSelectorMethods bibleMethods = new BibleSelectorMethods();
        List<string> bookList = new List<string>();

        public ScripturesViewModel scriptures = new ScripturesViewModel();

        //Book Selection
        public bool enableSelectBook = true;

        public class BookListMapping
        {
            public string Name { get; set; }
            public string ID { get; set; }
        }

        public List<BookListMapping> bibleBooks= new List<BookListMapping>();

        //Chapter Selection
        public bool enableSelectChapter = false;

        public class SelectedChapter
        {
            public int ChapterNumber { get; set; }
            public string ID { get; set; }
        }

        public List<SelectedChapter> bibleChapters = new List<SelectedChapter>();

        //Verse Selection
        public bool enableSelectVerse = false;
        public class SelectedVerse
        {
            public int VerseNumber { get; set; }
            public string ID { get; set; }
        }

        public List<SelectedVerse> bibleVerses = new List<SelectedVerse>();

        protected override void OnInitialized()
        {
            
            bookList = bibleMethods.BibleBookList;
            int i = 1;
            foreach (var item in bookList)
            {
                BookListMapping book = new BookListMapping
                {
                    ID = i.ToString(),
                    Name = item

                };
                bibleBooks.Add(book);
                i++;
            }

            base.OnInitialized();
        }

        protected void OnSelectedBook()
        {
            var chapterList = bibleMethods.GetNumberOfChapters(scriptures.Book);
            int i = 1;
            foreach (var item in chapterList)
            {
                SelectedChapter chapter = new SelectedChapter
                {
                    ID=i.ToString(),
                    ChapterNumber = item
                };
                bibleChapters.Add(chapter);
                i++;
            }
            enableSelectBook = false;
            enableSelectChapter = true;
        }

        public void OnSelectedChapter()
        {
            var chapter = Int32.Parse(scriptures.Chapter);
            var verseList = bibleMethods.GetNumberofVerses(scriptures.Book, chapter);

            int i = 1;
            foreach (var item in verseList)
            {
                SelectedVerse verse = new SelectedVerse
                {
                    ID = i.ToString(),
                    VerseNumber = item
                };
                bibleVerses.Add(verse);
                i++;
            }
            enableSelectBook = false;
            enableSelectChapter = false;
            enableSelectVerse = true;
        }

        public void OnSelectedVerse()
        {
            enableSelectBook = false;
            enableSelectChapter = false;
            enableSelectVerse = false;
        }



        protected async Task SubmitScripture()
        {
            scriptures.Scripture = $"{scriptures.Book} {scriptures.Chapter}:{scriptures.Verse}";
            var response = await Http.PostAsJsonAsync<ScripturesViewModel>("https://localhost:5001/api/scrpitures/", scriptures);

            //Navigate back to main page

        }

    }
}
