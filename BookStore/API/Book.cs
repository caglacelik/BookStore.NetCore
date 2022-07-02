using System.ComponentModel.DataAnnotations.Schema;

namespace API;

public class Book
{
    //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Title { get; set; }

    public int GenreId { get; set; }

    public int PageCount { get; set; }
    public DateTime PublishDate { get; set; }
}
