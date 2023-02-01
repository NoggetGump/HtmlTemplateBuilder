using Html.Builders;
using Html.EstruturasAuxiliares;
using Html.Styles;
using HtmlTemplateBuilder.Components.Abstract;

namespace Html.Components
{
    /// <summary>
    /// Represents a Html Table (table)(/table)
    /// </summary>
    public class Table : HtmlComponent
    {
        internal Tr Headers = null!;
        internal IEnumerable<Tr> DataRows = Enumerable.Empty<Tr>();

        /// <inheritdoc/>
        private protected override HtmlTagBuilder TagBuilder { get; set; } = new("table");

        /// <summary>
        /// Constructor that adds a Style to it's Html Tag - doesn`t update HtmlString.
        /// Supposidely to be used only by TableBuilder.
        /// </summary>
        /// <param name="style"></param>
        internal Table(CssClass? style = null) { if (style != null) AddStyle(style); }

        /// <summary>
        /// Constructor that receives an already filled HtmlTable- updates HtmlString
        /// Supposidely to be used only by TableBuilder.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="style"></param>
        public Table(DataHolderTable table, CssClass? style = null)
        {
            if (style != null)
                AddStyle(style);

            Headers = new Tr(table.Headers.Select(_ => new Th(_)));

            foreach (object[] values in table.Values)
            {
                IEnumerable<Td> tds = values.Select(str => new Td(str, autoFormatData: table.AutoFormatData));
                DataRows = DataRows.Append(new(tds: tds));
            }

            UpdateTagAndHtmlString();
        }

        internal void UpdateTagAndHtmlString()
        {
            TagBuilder.InnerHtml = Headers.HtmlString + string.Join("", DataRows.Select(_ => _.HtmlString));
            htmlString = TagBuilder.UnencodedHtmlString;
        }

        /// <summary>
        /// Adds Style to Header Row
        /// </summary>
        /// <param name="style"></param>
        public void StyleHeadersRow(CssClass style)
        {
            Headers.AddStyle(style);
            UpdateTagAndHtmlString();
        }

        /// <summary>
        /// Alterante styles in the DataRows
        /// </summary>
        /// <param name="alt1"></param>
        /// <param name="alt2"></param>
        public void StyleAlternateDataRow(CssClass alt1, CssClass alt2)
        {
            var iterator = DataRows.GetEnumerator();

            while(iterator.MoveNext())
            {
                iterator.Current.AddStyle(alt1);

                if (iterator.MoveNext())
                    iterator.Current.AddStyle(alt2);
                else
                    break;
            }
            UpdateTagAndHtmlString();
        }

        /// <summary>
        /// Specific ShallowCopy of Table object
        /// </summary>
        /// <returns></returns>
        public Table ShallowCopy() => new()
        {
            htmlString = htmlString,
            TagBuilder = TagBuilder,
            Headers = Headers,
            DataRows = DataRows,
        };
    }
}
