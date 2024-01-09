using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TGE.Data.Entities;

public class CommentEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey(nameof(Author))]
    public int AuthorId { get; set; }
    public UserEntity Author {get; set; } = null;

    [Required]
    [ForeignKey(nameof(Post))]
    public int PostId {get; set;}

    public PostEntity Post {get; set;} = null;


    [Required, MinLength(1), MaxLength(128)]
    public string Text { get; set; } = String.Empty;
}
