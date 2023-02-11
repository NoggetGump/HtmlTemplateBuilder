using Html.Builders;
using Html.EstruturasAuxiliares;
using Html.Interfaces;
using Html.Styles;

namespace Html.Components.Table
{

    /// <inheritdoc/>
    public class Table : IHtmlTable
    {
        internal Tr Headers = new();

        internal IEnumerable<Tr> DataRows = Enumerble.Empty<Tr>();

        /// <inheritdoc/>
        private protected override HtmlTagBuilder TagBuilder { get; set; } = new("table");

        /// <summary>
        /// Constructor that adds a Style to it's Html Tag - doesn`t update HtmlString.
        /// Supposidely to be used only by TableBuilder.
        /// </summary>
        /// <param name="style"></param>
        internal Table(CssClass? style = null) { if (style != null) AddStyle(style); }

        /// <inheritdoc/>
        public void UpdateInnerText() =>
            TagBuilder.InnerHtml = Headers.HtmlString + string.Join("", DataRows.Select(_ => _.HtmlString));

        /// <inheritdoc/>
        public void UpdateHeadersStyle(CssClass style) 
        {
            Headers.AddOrUpdateStyle(style);
            UpdateInnerText();
        }

        /// <inheritdoc/>
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

            UpdateInnerText();
        }

        /// <inheritdoc/>
        public IHtmlTable ShallowCopy() => 
        (IHtmlTable) new Table()
        {
            TagBuilder = TagBuilder,
            Headers = Headers,
            DataRows = DataRows,
        };
    }
}
