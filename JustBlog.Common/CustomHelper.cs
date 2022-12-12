using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Text.Encodings.Web;

namespace JustBlog.Common
{
    public static class CustomHelper
    {
        public static IHtmlContent TagLink(this IHtmlHelper helper, string name, string slug)
        {
            return helper.Raw($"<a href=\"/tag/{slug}\" style=\"margin-right:5px;\"><i class=\"fa fa-tag\" aria-hidden=\"true\"></i><span class=\"badge rounded-0 text-black\"> {name}</span></a>");
        }

        public static IHtmlContent CategoryLink(this IHtmlHelper helper, string name, string slug)
        {
            return helper.Raw($"<a class=\"dropdown-item p-0\" href=\"/category/{slug}\">{name}</a>");
        }

        public static IHtmlContent PostLink(this IHtmlHelper helper, string title, int year, int month, string slug)
        {
            return helper.ActionLink(title, "Details", "Post", new
            {
                year,
                month,
                slug
            });
        }
    }
}
