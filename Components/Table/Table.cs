using Html.Components.Abstract;
using Html.Interfaces;
using Html.Styles;
using System.Web.Mvc;

namespace Html.Components.Table
{

    /// <inheritdoc/>
    public class Table : HtmlComponent, IHtmlTable
    {
        public string Title { get; set; } = string.Empty;

        public Tr Headers { get; set; } = new();

        public IEnumerable<Tr> DataRows { get; set; } = Enumerable.Empty<Tr>();

        /// <inheritdoc/>
        private protected override TagBuilder TagBuilder { get; set; } = new("table");

        /// <summary>
        /// Constructor that adds a Style to it's Html Tag - doesn`t update HtmlString.
        /// Supposidely to be used only by TableBuilder.
        /// </summary>
        /// <param name="style"></param>
        internal Table(CssClass? style = null) { if (style != null) AddOrUpdateStyle(style); }

        /// <inheritdoc/>
        public void UpdateInnerText() => 
            TagBuilder.InnerHtml = Headers.HtmlString + string.Join("", DataRows.Select(_ => _.HtmlString));

        /// <inheritdoc/>
        public void StyleAlternateDataRow(CssClass alt1, CssClass alt2)
        {
            var iterator = DataRows.GetEnumerator();

            while(iterator.MoveNext())
            {
                iterator.Current.AddOrUpdateStyle(alt1);

                if (iterator.MoveNext())
                    iterator.Current.AddOrUpdateStyle(alt2);
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
