using JustBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.ViewModels.Post
{
    public class PostToCreateViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Title must be required")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Url slug must be required")]
        public string UrlSlug { get; set; }

        [StringLength(1024, ErrorMessage = "Short description must not be longer than 1024 characters")]
        public string ShortDescription { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Post content must be required")]
        public string PostContent { get; set; }

        public bool Published { get; set; }
        public int CategoryId { get; set; }
        public List<int> TagIds { get; set; } = new List<int>();
    }
}
