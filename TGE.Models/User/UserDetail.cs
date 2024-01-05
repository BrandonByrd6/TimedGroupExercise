using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TGE.Models.User
{
    public class UserDetail
    {
        public int Id {get; set;}
        public string Email {get; set;} = null!;
        public string FirstName {get; set;} = null!;
        public string LastName {get; set;} = null!;
    }
}