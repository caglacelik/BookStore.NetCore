using FluentValidation;

namespace API.BookOperations.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(x => x.BookId).GreaterThan(0);
        }
    }
}
