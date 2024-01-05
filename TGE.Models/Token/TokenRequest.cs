using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TGE.Models.Token
{
    public class TokenRequest
    {
        [Required]
        public string Email {get; set;} = string.Empty;

        [Required]
        public string Password {get; set;} = string.Empty;
    }
}