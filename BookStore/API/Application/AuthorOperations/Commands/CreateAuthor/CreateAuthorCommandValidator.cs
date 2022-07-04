using FluentValidation;

namespace API.Application.AuthorOperations.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(x => x.Model.FirstName).NotEmpty().MinimumLength(4);
            RuleFor(x => x.Model.LastName).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Model.BirthDate).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}