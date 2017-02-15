using System;
using System.Text;
using System.Web.Mvc;
using SportsStore.WebUI.Models;
using System.Collections.Generic;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
                                                PagingInfo pagingInfo,
                                                Func<int, string> pageUrl)
        {

            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString PagedProductGrid(this HtmlHelper html,
                                                    PagingInfo pagingInfo, 
                                                    IEnumerable<Product> products)
        {
            StringBuilder result = new StringBuilder();

           var gridProduct = products.OrderBy(p => p.ProductID)
                .Skip((pagingInfo.CurrentPage - 1) * pagingInfo.ItemsPerPage)
                .Take(pagingInfo.ItemsPerPage);

            foreach (var products in gridProduct)
            {
                TagBuilder h2 = new TagBuilder("h2");
                TagBuilder p = new TagBuilder("p");

                h2.InnerHtml = products.Name + " (" + products.Category + ")";
                p.InnerHtml = products.Description;

                TagBuilder div = new TagBuilder("div");
                div.InnerHtml = h2.ToString() + p.ToString();
                div.AddCssClass("well");

                TagBuilder br = new TagBuilder("br");
                result.Append(div.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}