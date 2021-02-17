using BibleStudyDataAccessLibrary.DataAccess;
using BibleStudyDataAccessLibrary.Models;
using System;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var entryDailyBibleReading = new DailyBibleReading()
            {
                DateRead = new DateTime(2021, 2, 11),
                LessonLearnedDescription = "This is a sample insert test of a daily Bible Reading.",
                ScriptureEndPoint = "Genesis 2",
                ScriptureStartPoint="Genesis 1"
            };
            
           


        }
    }
}
