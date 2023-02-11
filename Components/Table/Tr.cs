using HtmlTemplateBuilder.Components.Abstract;
using Html.Builders;
using Html.Styles;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Html.Components.Table
{
    /// <summary>
    /// A Html Table Row
    /// </summary>
    public class Tr :HtmlComponent
    {
        /// <inheritdoc/>
        private protected override HtmlTagBuilder TagBuilder { get; set; } = new("tr");

        /// <summary>
        /// Count of Ths
        /// </summary>
        public int ThCount { get; }

        /// <summary>
        /// Receives the Collection of Table Header (HtmlTh)
        /// Or Receives the Collection of Table Data (HtmlTd)
        /// Creates empty Tr if neither is passed
        /// </summary>
        /// <param name="ths"></param>
        /// <param name="tds"></param>
        /// <param name="style"></param>
        public Tr(IEnumerable<Th>? ths = null, IEnumerable<Td>? tds = null, CssClass? style = null)
        {
            if (style != null)
                AddStyle(style);

            ThCount = 0;
            string innerText = string.Empty;
            if (tds != null)
            {
                innerText = string.Join("", tds.Select(td => td.HtmlString));
            }
            else if (ths != null)
            {
                ThCount = ths.Count();
                innerText = string.Join("", ths.Select(th => th.HtmlString));
            }

            TagBuilder.InnerHtml = innerText;
            htmlString = TagBuilder.UnencodedHtmlString;
        }
    }
}
