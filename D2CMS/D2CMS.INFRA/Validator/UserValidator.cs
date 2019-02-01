using FluentValidation;
using D2CMS.CORE.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace D2CMS.INFRA.Validator
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Firstname).Length(0, 50).WithMessage("First Name cannot be more than 100 characters");
        }
    }
}
