using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustBlog.Core.Entities;

namespace JustBlog.ViewModels.Post
{
    public class PostAdminViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UrlSlug { get; set; }

        public bool Published { get; set; }

        public int ViewCount { get; set; }
        public int RateCount { get; set; }
        public int TotalRate { get; set; }
        public decimal Rate => TotalRate / RateCount;

        public DateTime PostedOn { get; set; }
        public DateTime? Modified { get; set; }
        public string Category { get; set; }

    }
}
