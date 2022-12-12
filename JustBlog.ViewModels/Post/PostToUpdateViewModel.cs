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
    public class PostToUpdateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title must be required")]
        public string Title { get; set; }

        [StringLength(1024)]
        [Column("Short Description")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Post content must be required")]
        [Column("Post Content")]
        public string PostContent { get; set; }

        [Required(ErrorMessage = "Url slug must be required")]
        public string UrlSlug { get; set; }

        public bool Published { get; set; }

        public int ViewCount { get; set; }
        public int RateCount { get; set; }
        public int TotalRate { get; set; }

        [Column("Posted On")]
        [Required(ErrorMessage = "Posted on must be required")]
        public DateTime PostedOn { get; set; }
        public int CategoryId { get; set; }
        public IList<int> TagIds { get; set; }
    }
}
