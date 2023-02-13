using Html.Components.Abstract;
using System.Web.Mvc;

namespace Html.Components
{
    /// <summary>
    /// Html Head Component - "Main" head of HTML
    /// </summary>
    public class Head : HtmlComponent
    {
        /// <inheritdoc/>
        private protected override TagBuilder TagBuilder { get; set; } = new("head");

        /// <summary>
        /// Construtor padrão com parâmetros mínimos
        /// </summary>
        /// <param name="title"></param>
        /// <param name="h"></param>
        /// <param name="style"></param>
        public Head(Title? title = null, H? h = null, Style? style = null)
        {
            var innerText = string.Empty;
            innerText += title?.HtmlString ?? string.Empty;
            innerText += h?.HtmlString ?? string.Empty;
            innerText += style?.HtmlString ?? string.Empty;

            TagBuilder.InnerHtml = innerText;
        }
    }
}
