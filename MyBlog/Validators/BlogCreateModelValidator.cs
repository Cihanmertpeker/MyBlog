﻿
using FluentValidation;
using MyBlogMVC.Models;

namespace BlogApp.Validators
{
    public class BlogCreateModelValidator : AbstractValidator<BlogCreateModel>
    {
        public BlogCreateModelValidator()
        {
            
            this.RuleFor(x=>x.Title).NotEmpty();
            this.RuleFor(x=>x.ShortDescription).NotEmpty();
            this.RuleFor(x=>x.Description).NotEmpty();

            this.RuleFor(x => x.Image).NotNull();

            this.RuleFor(x => x.Image).Custom((file, context) =>
            {
                if(file?.ContentType != "image/png" && file?.ContentType != "image/jpeg")
                {
                    context.AddFailure(new FluentValidation.Results.ValidationFailure
                    {
                        PropertyName = "Image",
                        ErrorMessage = "Desteklenmeyen biçimde dosya gönderdiniz, sadece image/png | image/jpeg - fv"
                    });
                }


            });
        }
    }
}
