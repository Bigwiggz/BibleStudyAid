
using BibleStudyBWAUI.Base.ScriptureSelectorBL.Methods;
using BibleStudyBWAUI.Base.ScriptureSelectorBL.Models;
using BibleStudyBWAUI.ViewModels;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.DropDowns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleStudyBWAUI.Base
{
    public class ScriptureSelectorBase: ComponentBase
    {
        //Hidden fields
        [Parameter]
        public string tblId { get; set; }

        //Initialize Bible Verification
        BibleSelectorMethods bibleMethods = new BibleSelectorMethods();
        List<string> bookList = new List<string>();
        public BibleCitation citation = new BibleCitation
        {
            BibleBook = null,
            BibleChapter=null,
            BibleVerse=null
        };

        //Book Selection
        public string _selectedBook;
        public bool enableSelectBook = true;

        public class BookListMapping
        {
            public string Name { get; set; }
            public string ID { get; set; }
        }

        public List<BookListMapping> bibleBooks= new List<BookListMapping>();

        //Chapter Selection
        public int _selectedChapter;
        public bool enableSelectChapter = false;

        public class SelectedChapter
        {
            public int ChapterNumber { get; set; }
            public string ID { get; set; }
        }

        public List<SelectedChapter> bibleChapters = new List<SelectedChapter>();

        //Verse Selection
        public int _selectedVerse;
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
            var chapterList = bibleMethods.GetNumberOfChapters(_selectedBook);
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
            citation.BibleBook = _selectedBook;
            enableSelectBook = false;
            enableSelectChapter = true;
        }

        public void OnSelectedChapter()
        {
            var verseList = bibleMethods.GetNumberofVerses(_selectedBook, _selectedChapter);

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
            citation.BibleChapter = _selectedChapter;
            enableSelectBook = false;
            enableSelectChapter = false;
            enableSelectVerse = true;
        }

        public void OnSelectedVerse()
        {
            citation.BibleVerse = _selectedVerse;
            enableSelectBook = false;
            enableSelectChapter = false;
            enableSelectVerse = false;
        }

        public ScripturesViewModel scriptures = new ScripturesViewModel
        {
            FKTableIdandName = tblId,
            Scripture=$"{} {}:{}"
        };

        protected async Task SubmitScripture()
        {

            var response = await Http.PostAsJsonAsync<ScripturesViewModel>("https://localhost:5001/api/dailybiblereading/", scriptures);

            //Navigate back to main page

        }

    }
}
