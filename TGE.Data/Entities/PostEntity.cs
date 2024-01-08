using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TGE.Data.Entities
{
    public class PostEntity
    {
        [Key]
        public int Id {get; set;}

        [Required, ForeignKey(nameof(Author))]
        public int AuthorId {get; set;}
        public UserEntity Author {get; set;} = null!;

        [Required, MinLength(1), MaxLength(100)]
        public string Title {get; set;} = string.Empty;

        [Required, MinLength(1), MaxLength(128)]
        public string Text {get; set;} = string.Empty;

        public List<CommentEntity> Comments {get; set;} = new();
    }
}