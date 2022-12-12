using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace JustBlog.Core.Entities
{
    public class Post
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        public string ShortDescription { get; set; }
        public string PostContent { get; set; }
        
        public string UrlSlug { get; set; }

        public bool Published { get; set; }

        public int ViewCount { get; set; }
        public int RateCount { get; set; }
        public int TotalRate { get; set; }
        [NotMapped]
        public decimal Rate => RateCount > 0 ? TotalRate / RateCount : 0;

        public DateTime PostedOn { get; set; }
        public DateTime? Modified { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<PostTagMap> PostTagMaps { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
