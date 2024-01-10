using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TGE.Models.Comment
{
    public class CommentDetail
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Text { get; set; } = String.Empty;
    }
}