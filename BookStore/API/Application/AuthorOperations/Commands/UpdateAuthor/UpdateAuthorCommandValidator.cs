using FluentValidation;

namespace API.Application.AuthorOperations.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(x => x.Model.FirstName).MinimumLength(4).When(x => x.Model.FirstName != string.Empty);
            RuleFor(x => x.Model.LastName).MinimumLength(4).When(x => x.Model.LastName != string.Empty);
            RuleFor(x => x.Model.BirthDate).LessThan(DateTime.Now).When(x => x.Model.BirthDate.ToString() != string.Empty);
        }
    }
}