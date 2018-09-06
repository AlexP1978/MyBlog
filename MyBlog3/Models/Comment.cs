using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog3.Models
{
    public class Comment
    {
        // Id comments
        public int Id { get; set; }
        // Id article
        public int ArticleId { get; set; }
        // date comments
        public DateTime DataComment { get; set; }
        //Author comment
        public string Author { get; set; }
        // Body comment
        public string Comments { get; set; }

    }
}