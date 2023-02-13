using Html.Components.Table;
using Html.Styles;

namespace Html.Interfaces
{
    /// <summary>
    /// Represents a Html Table (table)innerText(/table)
    /// </summary>
    public interface IHtmlTable : IHtmlComponent
    {
        public Tr Headers { get; set; }

        public IEnumerable<Tr> DataRows { get; set; }

        /// <summary>
        /// Updates Html Inner Text String
        /// </summary>
        public void UpdateInnerText();

        /// <summary>
        /// Alternate styles in the DataRows
        /// </summary>
        /// <param name="alt1"></param>
        /// <param name="alt2"></param>
        public void StyleAlternateDataRow(CssClass alt1, CssClass alt2);

        /// <summary>
        /// Copies IHtmlTable object.
        /// Minimally should copy Headers, DataRows and updated HtmlString.
        /// </summary>
        /// <returns></returns>
        public IHtmlTable ShallowCopy();
    }
}
