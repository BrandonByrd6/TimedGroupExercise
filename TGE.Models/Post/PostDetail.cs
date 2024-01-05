using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TGE.Models.Post
{
    public class PostDetail
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Text { get; set; } = String.Empty;
    }
}