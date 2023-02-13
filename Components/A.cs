using Html.Components.Abstract;
using Html.Styles;
using System.Web.Mvc;

namespace Html.Components
{
    /// <summary>
    /// A HtmlComponent (a)(\a)
    /// </summary>
    public class A : HtmlComponent
    {
        private protected override TagBuilder TagBuilder { get; set; } = new("a");

        /// <summary>
        /// Construtor Padrão
        /// </summary>
        /// <param name="content"></param>
        /// <param name="link"></param>
        /// <param name="style"></param>
        public A(string content, string link, CssClass? style = null)
        {
            TagBuilder.InnerHtml = content;
            TagBuilder.MergeAttribute("href", link);

            if (style != null)
                AddOrUpdateStyle(style);
        }
    }
}
