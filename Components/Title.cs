using HtmlTemplateBuilder.Components.Abstract;
using Html.Builders;
using Html.Styles;

namespace Html.Components
{
    /// <summary>
    /// Título da Página Html (title)content(/title)
    /// </summary>
    public class Title : HtmlComponent
    {
        ///<inheritdoc/>
        private protected override HtmlTagBuilder TagBuilder { get; set; } = new("title");

        /// <summary>
        /// Construtor Padrão
        /// </summary>
        /// <param name="content"></param>
        /// <param name="style"></param>
        public Title(string content, CssClass? style = null)
        {
            AddStyle(style);
            TagBuilder.InnerHtml = content;
            htmlString = TagBuilder.UnencodedHtmlString;
        }
    }
}
