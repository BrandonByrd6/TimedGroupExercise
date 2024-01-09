using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TGE.Models.Reply
{
    public class ReplyDetail
    {
        public int Id {get; set;}
        public int ParentId {get; set;}
        public string Text {get; set;} = string.Empty;
    }
}