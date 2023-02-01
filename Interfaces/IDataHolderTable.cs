using Html.Styles;

namespace Html.Interfaces
{
    /// <summary>
    /// Holds Data to Fill a Html Table
    /// </summary>
    public interface IDataHolderTable
    {
        /// <summary>
        /// Title
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Column Headers of the table
        /// </summary>
        public string[] Headers { get; set; }

        /// <summary>
        /// Styles of column headers 
        /// </summary>
        public CssClass[]? HeadersStyles { get; set; }

        /// <summary>
        /// Values of the table converted to string
        /// </summary>
        public IEnumerable<object[]> Values { get; set; }

        /// <summary>
        /// Styles of each value of the table in jsonformat
        /// example:
        /// { "background-color": "white" }
        /// </summary>
        public IEnumerable<CssClass[]>? ValuesStyles { get; set; }

        /// <summary>
        /// Set to true if you want data to be autoformated to default
        /// style implementation; i.e: numbers align right.
        /// </summary>
        public bool AutoFormatData{ get; set; }
    }
}
