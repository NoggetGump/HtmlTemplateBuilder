using HtmlTemplateBuilder.Components.Abstract;
using Html.Builders;
using Html.Styles;

namespace Html.Components
{
    /// <summary>
    /// A HtmlComponent (a)(\a)
    /// </summary>
    public class A : HtmlComponent
    {
        private protected override HtmlTagBuilder TagBuilder { get; set; } = new("a");

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
                AddStyle(style);

            htmlString = TagBuilder.UnencodedHtmlString;
        }
    }
}
