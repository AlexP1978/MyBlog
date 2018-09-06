using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog3.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
    }
}