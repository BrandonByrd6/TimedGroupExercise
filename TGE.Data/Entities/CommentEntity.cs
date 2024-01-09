using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using TGE.Data.Entites;

namespace TGE.Data.Entities
{
    public class CommentEntity
    {
        [Key]
        public int Id {get; set;}

        [Required, MinLength(1), MaxLength(100)]
        public string Text {get; set;} = string.Empty;

        [ForeignKey(nameof(Author)), Required]
        public int AuthorId {get; set;}
        public UserEntity Author {get; set;} = null!;
        
        [ForeignKey(nameof(Post)), Required]
        public int PostId {get; set;}
        public PostEntity Post {get; set;} = null!;
        
        public List<ReplyEntity> Replies {get; set;} = new();
    }
}

