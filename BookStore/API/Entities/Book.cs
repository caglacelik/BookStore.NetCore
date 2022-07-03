using System.ComponentModel.DataAnnotations.Schema;
using API.Entities;

namespace API
{
    public class Book
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}