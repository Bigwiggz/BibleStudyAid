using BibleStudyInfoAPI.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleStudyInfoAPI.Validators
{
    public class DocumentsValidator:AbstractValidator<DocumentsDTO>
    {
        public DocumentsValidator()
        {
            //Document Name
            RuleFor(M => M.DocumentName)
                .Cascade(CascadeMode.Stop)
                .Length(1, 256).WithMessage("The name of the document must be between 1 and 256 characters length.");

            //Document Type
            RuleFor(M=>M.DocumentType)
                .Cascade(CascadeMode.Stop)
                .Length(1, 256).WithMessage("The document type must be between 1 and 256 characters length.");

            //Document Size
            RuleFor(M => M.Document.Length)
                .Cascade(CascadeMode.Stop)
                .LessThan(268435456).WithMessage("The file size must be less than 256 MB.");

            //Document Description
            RuleFor(M => M.DocumentDescription)
                .Cascade(CascadeMode.Stop)
                .Length(0, 1000).WithMessage("The document description must be less than 1,000 characters.");
        }
    }
}
