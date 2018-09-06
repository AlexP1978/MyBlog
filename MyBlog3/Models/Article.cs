using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog3.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string ShortBody { get; set; }
        public string FullBody { get; set; }
        public DateTime DataTxt { get; set; }
        public string Category { get; set; }
        //public string Comments { get; set; }
        //public DateTime DataComment { get; set; }
        //public string AuthorComments { get; set; }
    }
}