using JustBlog.Core.Entities;
using JustBlog.ViewModels.Category;
using JustBlog.ViewModels.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.ViewModels.Post
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UrlSlug { get; set; }
        public DateTime PostedOn { get; set; }
        public decimal Rate { get; set; }
        public int ViewCount { get; set; }
        public string ShortDescription { get; set; }
        public IList<TagViewModel> Tags { get; set; }
        public CategoryViewModel Category { get; set; }
    }
}
