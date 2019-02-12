using EXAMSYSTEM.CORE.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EXAMSYSTEM.INFRA.Validator
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Username).NotNull().WithMessage("Username is required");
        }
    }
}
