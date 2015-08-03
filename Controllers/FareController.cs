using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Host.Models;

namespace Host.Controllers
{
    [Route("api/[controller]/[action]")]
    public class FareController : Controller
    {
        private HostContext _context;

        public FareController(HostContext context)
        {
            _context = context;
        }
        [HttpPost]
        public Object addRoute([FromBody] Route ruta)
        {
                _context.Route.Add(ruta);
                _context.SaveChanges();
                return ruta;
        }
        public Object addFareClass([FromBody] FareClass fare)
        {
                _context.FareClass.Add(fare);
                _context.SaveChanges();
                return fare;
        }
        public Object linkRouteFareClass([FromBody] RouteFareClassList RFCL)
        {
                                /*
                var MaxBlogId = db.Blogs.Max(x => x.Id);

                Blog NewBlog = new Blog();
                NewBlog.Name = "Testblog #" + MaxBlogId.ToString();

                Post FirstPost = new Post() { Comment = "Test" };
                Post SecondPost = new Post() { Comment = "blog" };



                NewBlog.Posts = new List<Post>() { FirstPost, SecondPost };

                db.Blogs.Add(NewBlog);
                db.Posts.Add(FirstPost);
                db.Posts.Add(SecondPost);
                
                _context.SaveChanges();
                */
                _context.RouteFareClassList.Add(RFCL);
                _context.SaveChanges();
                return RFCL;
        }
        
        [HttpGet]
        public Object getBlogs()
        {
           /*
           var AllBlogs = db.Blogs.ToList();
           foreach (var Blog in AllBlogs)
               Blog.Posts = new List<Post>(from x in db.Posts where x.BlogId == Blog.Id select x);
           return AllBlogs;
           */
           return true;
        }
    }
}