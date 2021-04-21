using BibleStudyInfoAPI.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleStudyInfoAPI.Validators
{
    public class ScripturesValidator: AbstractValidator<ScripturesDTO>
    {
        public ScripturesValidator()
        {
            //
        }
    }
}
