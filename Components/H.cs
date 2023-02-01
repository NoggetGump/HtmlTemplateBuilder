using HtmlTemplateBuilder.Components.Abstract;
using Html.Builders;
using Html.Styles;

namespace Html.Components
{
    /// <summary>
    /// Título HTML (hn)(/hn)
    /// N = relevance, Greater Relevance 1 ~ 6 Smaller Relevance
    /// </summary>
    public class H : HtmlComponent
    {
        /// <inheritdoc/>
        private protected override HtmlTagBuilder TagBuilder { get; set; }

        /// <summary>
        /// Construtor Padrão
        /// </summary>
        /// <param name="content"></param>
        /// <param name="relevance"></param>
        /// <param name="style"></param>
        public H(string content, int relevance, CssClass? style = null)
        {
            TagBuilder = new($"h{relevance}")
            {
                InnerHtml = content
            };

            if (style != null)
                AddStyle(style);

            htmlString = TagBuilder.UnencodedHtmlString;
        }
    }
}
