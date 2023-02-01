using Html.Interfaces;
using Html.Styles;
using System.Collections.Generic;
using System.Linq;

namespace Html.EstruturasAuxiliares
{
    /// <inheritdoc/>
    public class DataHolderTable : IDataHolderTable
    {
        /// <inheritdoc/>
        public string? Title { get; set; }

        /// <inheritdoc/>
        public string[] Headers { get; set; }

        /// <inheritdoc/>
        public CssClass[] HeadersStyles { get; set; }

        /// <inheritdoc/>
        public IEnumerable<object[]> Values { get; set; } = Enumerable.Empty<object[]>();

        /// <inheritdoc/>
        public IEnumerable<CssClass[]> ValuesStyles { get; set; } = Enumerable.Empty<CssClass[]>();

        /// <inheritdoc/>
        public bool AutoFormatData { get; set; } = false;
    }
}
