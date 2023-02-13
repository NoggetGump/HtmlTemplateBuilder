using Html.Components.Abstract;
using Html.Styles;
using System.Web.Mvc;

namespace Html.Components.Table
{
    /// <summary>
    /// A Html Table Row
    /// </summary>
    public class Tr : HtmlComponent
    {
        /// <inheritdoc/>
        private protected override TagBuilder TagBuilder { get; set; } = new("tr");

        /// <summary>
        /// Count of Ths
        /// </summary>
        public int ThCount { get; }

        /// <summary>
        /// Count of Tds
        /// </summary>
        public int TdCount { get; }

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
                AddOrUpdateStyle(style);

            ThCount = 0;
            TdCount = 0;
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
        }
    }
}
