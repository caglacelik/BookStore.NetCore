using API.Application.AuthorOperations.GetAuthorDetail;
using FluentValidation;

namespace API.Application.GenreOperations.GetGenreDetail
{
    public class GetAuthorDetailQueryValidator : AbstractValidator<GetAuthorDetailQuery>
    {
        public GetAuthorDetailQueryValidator()
        {
            RuleFor(x => x.AuthorId).GreaterThan(0);
        }
    }
}