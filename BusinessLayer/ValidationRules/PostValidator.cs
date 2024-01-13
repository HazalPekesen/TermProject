using EntityLayer.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PostValidator : AbstractValidator<Post>
    {
        public PostValidator() 
        {
            RuleFor(x => x.Text).NotEmpty().WithMessage("Post içeriğini boş geçemezsiniz.");
        }
    }
}
