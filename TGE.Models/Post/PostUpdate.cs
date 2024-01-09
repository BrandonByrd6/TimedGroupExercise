using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TGE.Models.Post
{
    public class PostUpdate
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "{0} must be at least {1} character long.")]
        [MaxLength(100, ErrorMessage = "{0} must be no longer than {1} characters.")]
        public string Title { get; set; } = String.Empty;

        [Required]
        [MinLength(1, ErrorMessage = "{0} must be at least {1} character long.")]
        [MaxLength(128, ErrorMessage = "{0} must be no longer than {1} characters.")]
        public string Text { get; set; } = String.Empty;
    }
}