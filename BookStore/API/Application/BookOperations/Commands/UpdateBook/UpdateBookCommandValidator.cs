using FluentValidation;

namespace API.Application.BookOperations.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(x => x.BookId).GreaterThan(0);
            RuleFor(x => x.Model.GenreId).GreaterThan(0).IsInEnum();
            RuleFor(x => x.Model.Title).NotEmpty().MinimumLength(2);
        }
    }
}