using HtmlTemplateBuilder.Components.Abstract;
using Html.Builders;
using Html.Styles;

namespace Html.Components.Table
{
    /// <summary>
    /// A Html Table Data
    /// </summary>
    public class Td : HtmlComponent
    {
        /// <inheritdoc/>
        private protected override HtmlTagBuilder TagBuilder { get; set; } = new("td");

        private void NumberStyle(object data, CssClass style)
        {
            if (data is int || data is float || data is double || data is decimal)
            {
                style.Important = true;
                style.TextAlign = TextAlign.right;
            }
        }

        /// <summary>
        /// Receives a Data convertable with ToString()
        /// </summary>
        /// <param name="data"></param>
        /// <param name="style"></param>
        /// <param name="autoFormatData"></param>
        public Td(object data, CssClass? style = null, bool autoFormatData = false)
        {
            if (autoFormatData)
            {
                style ??= new();
                NumberStyle(data, style);
            }

            if(style != null)
                AddStyle(style);

            TagBuilder.InnerHtml = data.ToString();
            htmlString = TagBuilder.UnencodedHtmlString;
        }
        
    }
}
