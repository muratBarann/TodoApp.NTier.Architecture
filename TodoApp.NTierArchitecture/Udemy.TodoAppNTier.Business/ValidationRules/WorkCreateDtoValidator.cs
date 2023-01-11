using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.TodoAppNTier.Dtos.WorkDtos;

namespace Udemy.TodoAppNTier.Business.ValidationRules
{
    public class WorkCreateDtoValidator : AbstractValidator<WorkCreateDto>
    {
        public WorkCreateDtoValidator()
        {
            RuleFor(x => x.Definition).NotEmpty().WithMessage("Definition is required").Must(NotBeMurat).WithMessage("Murat not be Work!");
        }

        private bool NotBeMurat(string arg)
        {
            return arg != "Murat" && arg != "murat";
        }
    }
}
