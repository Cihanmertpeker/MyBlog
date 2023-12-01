using FluentValidation;
using MyBlogMVC.Models;

namespace MyBlogMVC.Validators
{
    public class UserLoginModelvalidator: AbstractValidator<UserLoginModel>
    {
        public UserLoginModelvalidator()
        {
            this.RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
            this.RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş geçilemez");
        }
    }
}
