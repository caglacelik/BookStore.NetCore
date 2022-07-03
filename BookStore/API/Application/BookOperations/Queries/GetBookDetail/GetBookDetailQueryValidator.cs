using FluentValidation;

namespace API.Application.BookOperations.GetBookDetail
{
    public class GetBookDetailQueryValidator : AbstractValidator<GetBookDetailQuery>
    {
        public GetBookDetailQueryValidator()
        {
            RuleFor(x => x.BookId).GreaterThan(0);
        }
    }
}