using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog3.Models;
using System.Data.Entity;
using System.IO;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace MyBlog3.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        ArticleContext db = new ArticleContext();
        public ActionResult Index(int page = 1)
        {
            // получаем из бд все объекты Article
            IEnumerable<Article> articles = db.Articles;
            int pageSize = 3; // количество объектов на страницу
            IEnumerable<Article> articlesPerPages = articles.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = articles.Count() };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Articles = articlesPerPages };
            // возвращаем представление
            return View(ivm);
        }

        [HttpGet]
        public ActionResult More(int id)
        {
            ViewBag.ArticleId = id;
            var dtarticle = db.Articles.FirstOrDefault(p => p.Id == id);
            ViewBag.Name = dtarticle.Name;
            ViewBag.FullBody = dtarticle.FullBody;
            // получаем из бд все объекты Article
            IEnumerable<Comment> comments = db.Comments.Where(v => v.ArticleId == id).ToList();
            // передаем все объекты в динамическое свойство Articles в ViewBag
            ViewBag.Comments = comments;
            return View();
        }

        [HttpPost]
        public string More(Comment comment)
        {
            // добавляем информацию о статье
            comment.DataComment = DateTime.Now;
            db.Comments.Add(comment);
            // сохраняем в бд все изменения
            //db.Entry(dtcomment).State = EntityState.Modified;
            db.SaveChanges();
            return "Спасибо, за комментарий!";
        }

        [HttpGet]
        public ActionResult Adds()
        {
            ViewBag.Name = "Добавление статьи";
            // передаем все объекты в динамическое свойство Articles в ViewBag
            return View();
        }

        [HttpPost]
        public string Adds(Article article)
        {
            // добавляем статью в базу данных
            article.DataTxt = DateTime.Now;
            article.Author = User.Identity.Name;
            db.Articles.Add(article);
            // сохраняем в бд все изменения
            //db.Entry(dtcomment).State = EntityState.Modified;
            db.SaveChanges();
            return "Статья добавлена.";
        }

        [HttpGet]
        public ActionResult Editing(int id)
        {
            ViewBag.ArticleId = id;
            var dtarticle = db.Articles.FirstOrDefault(p => p.Id == id);
            ViewBag.Name = dtarticle.Name;
            ViewBag.FullBody = dtarticle.FullBody;

            return View();
        }

        [HttpPost]
        public string Editing(Article article)
        {
            // редактируем статью
            article.DataTxt = DateTime.Now;
            if ( article.Author == null ) article.Author = User.Identity.Name;
            //db.Articles.Add(article);
            // сохраняем в бд все изменения
            db.Entry(article).State = EntityState.Modified;
            db.SaveChanges();
            return "Статья изменена.";
        }

        [HttpGet]
        public string Deleting(Article article)
        {
            // удаляем статью
            db.Entry(article).State = EntityState.Deleted;
            db.SaveChanges();
            // сохраняем в бд все изменения
            //db.SaveChanges();
            return "Статья удалена.";
        }

        public ActionResult About()
        {
            ViewBag.Message = "Страница описания вашего приложения.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Ваша страница контактов.";

            return View();
        }
    }
}