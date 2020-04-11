using articleApp.Data.OtherModels;
using FluentValidation;

namespace articleApp.Business.Validator
{
    public class ArticleRequestModelValidator : AbstractValidator<ArticleRequestModel>
    {
        public ArticleRequestModelValidator()
        {
            RuleFor(model => model.UserId).NotEmpty().WithMessage("UserId boş geçilemez.");
            RuleFor(model => model.CategoryId).NotEmpty().WithMessage("KategoriId boş geçilemez.");

            RuleFor(model => model.MainTitle).NotEmpty().WithMessage("MainTitle boş geçilemez.");
            RuleFor(model => model.MainTitle).MaximumLength(50).WithMessage("MainTitle 50 karakterden fazla olamaz.");

            RuleFor(model => model.Title).NotEmpty().WithMessage("Title boş geçilemez.");
            RuleFor(model => model.Title).MaximumLength(100).WithMessage("Title 100 karakterden fazla olamaz.");

            RuleFor(model => model.Description).NotEmpty().WithMessage("Description boş geçilemez.");
            RuleFor(model => model.Description).MaximumLength(250).WithMessage("Description 250 karakterden fazla olamaz.");
        }
    }
}