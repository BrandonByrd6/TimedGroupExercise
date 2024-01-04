using System.ComponentModel.DataAnnotations;

namespace TGE.Data.Entites;

public class PostEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int AuthorId { get; set; }
    public UserEntity Author {get; set; } = null;

    [Required, MinLength(1), MaxLength(100)]
    public string Title { get; set; } = String.Empty;

    [Required, MinLength(1), MaxLength(128)]
    public string Text { get; set; } = String.Empty;

    /*
        TODO:
            Comments and Likes virtuals
    */
}
