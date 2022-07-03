using API.Entities;
using AutoMapper;
using static API.Application.BookOperations.CreateBook.CreateBookCommand;
using static API.Application.BookOperations.GetBookDetail.GetBookDetailQuery;
using static API.Application.BookOperations.GetBooks.GetBooksQuery;
using static API.Application.GenreOperations.CreateGenre.CreateGenreCommand;
using static API.Application.GenreOperations.GetGenreDetail.GetGenreDetailQuery;
using static API.Application.GenreOperations.GetGenres.GetGenresQuery;
using static API.Application.GenreOperations.UpdateGenre.UpdateGenreCommand;

namespace API.Common
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CreateBookViewModel, Book>().ReverseMap();
            CreateMap<Book, BookDetailViewModel>()
            .ForMember(x => x.Genre, s => s.MapFrom(a => a.Genre.Name)).ReverseMap();
            CreateMap<Book, BookViewModel>()
            .ForMember(x => x.Genre, s => s.MapFrom(a => a.Genre.Name)).ReverseMap();
            CreateMap<Genre, GenreViewModel>().ReverseMap();
            CreateMap<Genre, GenreDetailViewModel>();
            CreateMap<Genre, UpdateGenreViewModel>();
            CreateMap<CreateGenreViewModel, Genre>();

        }
    }
}

