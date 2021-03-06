
using BibleStudyBWAUI.Base.ScriptureSelectorBL.Methods;
using BibleStudyBWAUI.Base.ScriptureSelectorBL.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleStudyBWAUI.Base
{
    public class ScriptureSelectorBase: ComponentBase
    {
        BibleSelectorMethods bibleMethods = new BibleSelectorMethods();

        List<string> bookList = new List<string>();

        public class BookListMapping
        {
            public string Name { get; set; }
            public string ID { get; set; }
        }

        public List<BookListMapping> bibleBooks= new List<BookListMapping>();

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
    }
}
