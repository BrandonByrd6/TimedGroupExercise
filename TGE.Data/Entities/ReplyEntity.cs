using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TGE.Data.Entities
{
    public class ReplyEntity
    {
        [Key]
        public int Id {get; set;}

        [Required, MinLength(1), MaxLength(100)]
        public string Text {get; set;} = string.Empty;

        [ForeignKey(nameof(Parent)), Required]
        public int ParentId {get; set;}
        public CommentEntity Parent {get; set;} = null!;

        [ForeignKey(nameof(Author)), Required]
        public int AuthorId {get; set;}
        public UserEntity Author {get; set;} = null!;

    }
}