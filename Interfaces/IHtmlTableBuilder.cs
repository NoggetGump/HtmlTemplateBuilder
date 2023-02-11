using Html.Components;
using Html.Exceptions;
using Html.Styles;
using System.Collections.Generic;

namespace Html.Interfaces
{
    /// <summary>
    /// Represents an Html Table
    /// </summary>
    public interface IHtmlTableBuilder<T> where T : IHtmlTable
    {
        /// <summary>
        /// Add Headers to this Table
        /// Overwrites previous Headers
        /// </summary>
        /// <param name="ths"></param>
        /// <param name="rowStyle"></param>
        public void AddHeaders(IEnumerable<Th> ths, CssClass? rowStyle = null);

        /// <summary>
        /// Add DataRow if it has Headers size
        /// Throws HtmlConstructionFailedException
        /// </summary>
        /// <param name="tds"></param>
        /// <param name="rowStyle"></param>
        /// <exception cref="HtmlConstructionFailedException"></exception>
        public void AddDataRow(IEnumerable<Td> tds, CssClass? rowStyle = null);

        /// <summary>
        /// Builds Table From DataHolderTable
        /// </summary>
        publicc T BuildFromDataHolderTable(DataHolderTable dataHolder, CssClass? style);

        /// <summary>
        /// Builds Table - finishes Table Creation Process
        /// </summary>
        /// <returns></returns>
        public T Build();
    }
}
