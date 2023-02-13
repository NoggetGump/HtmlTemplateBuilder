using Html.Styles;
namespace Html.EstruturasAuxiliares
{
    /// <inheritdoc/>
    public class DataHolderTable
    {
        /// <inheritdoc/>
        public string? Title { get; set; }

        /// <inheritdoc/>
        public IEnumerable<string> Headers { get; set; } = Enumerable.Empty<string>();

        /// <inheritdoc/>
        public IEnumerable<CssClass> HeadersStyles { get; set; } = Enumerable.Empty<CssClass>();

        /// <inheritdoc/>
        public IEnumerable<object[]> Values { get; set; } = Enumerable.Empty<object[]>();

        /// <inheritdoc/>
        public IEnumerable<CssClass[]> ValuesStyles { get; set; } = Enumerable.Empty<CssClass[]>();

        /// <inheritdoc/>
        public bool AutoFormatData { get; set; } = false;
    }
}
