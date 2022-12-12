using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.ViewModels.Tag
{
    public class TagToUpdateViewModel
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name of tag must be required")]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Url slug of tag must be required")]
        public string UrlSlug { get; set; }
        [StringLength(1024, ErrorMessage = "Description must not be longer than 1024 characters")]
        public string Description { get; set; }
    }
}
