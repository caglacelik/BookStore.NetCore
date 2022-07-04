using API.Application.AuthorOperations.CreateAuthor;
using API.Application.AuthorOperations.DeleteAuthor;
using API.Application.AuthorOperations.DeleteGAuthor;
using API.Application.AuthorOperations.GetAuthorDetail;
using API.Application.AuthorOperations.GetAuthors;
using API.Application.AuthorOperations.UpdateAuthor;
using API.Application.GenreOperations.GetGenreDetail;
using API.DB;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using static API.Application.AuthorOperations.CreateAuthor.CreateAuthorCommand;
using static API.Application.AuthorOperations.UpdateAuthor.UpdateAuthorCommand;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class AuthorController : ControllerBase
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public AuthorController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetGenres()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_context, _mapper);
            return Ok(query.Handle());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context, _mapper);
            query.AuthorId = id;
            GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
            validator.ValidateAndThrow(query);
            return Ok(query.Handle());
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorViewModel newAuthor)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
            command.Model = newAuthor;
            CreateAuthorCommandValidator validatior = new CreateAuthorCommandValidator();
            validatior.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorViewModel updateAuthor)
        {

            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.AuthorId = id;
            command.Model = updateAuthor;
            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {

            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.AuthorId = id;
            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }

}
