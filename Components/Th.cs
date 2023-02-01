using HtmlTemplateBuilder.Components.Abstract;
using Html.Builders;
using Html.Styles;

namespace Html.Components
{
    /// <summary>
    /// A Html Table Header
    /// </summary>
    public class Th : HtmlComponent
    {
        private protected override HtmlTagBuilder TagBuilder { get; set; } = new ("th");

        /// <summary>
        /// Receives a Header
        /// </summary>
        /// <param name="header"></param>
        /// <param name="style"></param>
        public Th(string header, CssClass? style = null)
        {
            if(style !=null)
                AddStyle(style);

            TagBuilder.InnerHtml = header;
            htmlString = TagBuilder.UnencodedHtmlString;
        }
    }
}
