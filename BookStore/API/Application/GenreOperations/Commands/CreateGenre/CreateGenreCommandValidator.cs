using API.Application.BookOperations.CreateBook;
using API.Application.GenreOperations.GetGenreDetail;
using FluentValidation;

namespace API.Application.GenreOperations.CreateGenre
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty().MinimumLength(4);
        }
    }
}