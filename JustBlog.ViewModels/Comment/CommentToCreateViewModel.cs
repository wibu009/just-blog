using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.ViewModels.Comment
{
    public class CommentToCreateViewModel
    {
        public int PostId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Comment header must be required")]
        public string CommentHeader { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name must be required")]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username must be required")]
        [RegularExpression(@"\w+@\w+(\.\w+)+", ErrorMessage = "Invalid email")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Comment text must be required")]
        public string CommentText { get; set; }
    }
}
