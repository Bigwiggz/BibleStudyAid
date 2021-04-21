using BibleStudyInfoAPI.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibleStudyInfoAPI.Validators.ScriptureValidatorExtensions;

namespace BibleStudyInfoAPI.Validators
{
    public class ScripturesValidator: AbstractValidator<ScripturesDTO>
    {
        public ScripturesValidator()
        {
            //Verified Book
            RuleFor(M => M.Book)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Please select a Bible Book")
                .Must(BeVerifiedBibleBook).WithMessage("This Bible Book {} does not exist.");

            //Verified Verse
            RuleFor(M => M.Verse)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Please select a Bible verse")
                .Must(BeVerifiedVerse).WithMessage("This verse does not exist.");

            //Verified Chapter
            RuleFor(M => M.Chapter)
                .Cascade(CascadeMode.Stop);
        }

        //Ref scripture validation lists
        ScriptureValidatorExtension scriptureValidationLists = new ScriptureValidatorExtension();


        //Verified Book
        protected bool BeVerifiedBibleBook(string bookEntered)
        {
            bool isVerifiedBook = false;
            isVerifiedBook = scriptureValidationLists.books.Any(book => book == bookEntered);
            return isVerifiedBook;
        }

        //Verified Chapter
        protected bool BeVerifiedChapter(string chapterEntered, string bookEntered)
        {
            bool isVerifiedChapter = false;
            if (chapterEntered != null && int.Parse(chapterEntered) < 150)
            {
                isVerifiedChapter = true;
            }
            else if (chapterEntered == null && scriptureValidationLists.singleChapterBooks.Any(book => book == bookEntered))
            {
                isVerifiedChapter = true;
            }

            return isVerifiedChapter;
        }

        //Verified Verse
        protected bool BeVerifiedVerse(string chapterEntered)
        {
            bool isVerifiedVerse = false;
            if (int.Parse(chapterEntered) < 176)
            {
                isVerifiedVerse = true;
            }
            return isVerifiedVerse;
        }
    }
}
