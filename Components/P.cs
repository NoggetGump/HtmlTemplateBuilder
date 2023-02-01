using HtmlTemplateBuilder.Components.Abstract;
using Html.Builders;
using Html.Styles;

namespace Html.Components
{
    /// <summary>
    /// Parágrafo HTML (p)Content(/p)
    /// </summary>
    public class P : HtmlComponent
    {
        private protected override HtmlTagBuilder TagBuilder { get; set; } = new("p");

        /// <summary>
        /// Construtor Padrão
        /// </summary>
        /// <param name="content"></param>
        /// <param name="style"></param>
        public P(string content, CssClass? style = null)
        {
            TagBuilder.InnerHtml =content;
            
            if(style!=null)
                AddStyle(style);

            htmlString = TagBuilder.UnencodedHtmlString;
        }
    }
}
