using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// using TGE.Data.Entities;
    //! havent set reference yet

namespace TGE.Models.User
{
    public class UserDetail
    {
        public int Id {get; set;}
        public string Email {get; set;} = null!;
        public string FirstName {get; set;} = null!;
        public string LastName {get; set;} = null!;
        public string UserName {get; set;} = null!;
        
        // public List<PostEntity> posts {get; set;} = new();
    }
}