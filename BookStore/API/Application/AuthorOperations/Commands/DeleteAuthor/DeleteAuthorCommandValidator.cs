using API.Application.AuthorOperations.DeleteAuthor;
using FluentValidation;

namespace API.Application.AuthorOperations.DeleteGAuthor
{
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator()
        {
            RuleFor(x => x.AuthorId).GreaterThan(0);
        }
    }
}