using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TGE.Models.Reply
{
    public class ReplyCreate
    {
        [Required]
        public int ParentId {get; set;}

        [Required]
        [MinLength(1, ErrorMessage = "{0} must be at least {1} characters long")] 
        [MaxLength(100, ErrorMessage = "{0} must be no more than 100 characters long")]
        public string Text {get; set;} = string.Empty;
        public int AuthorId {get; set;}
    }
}