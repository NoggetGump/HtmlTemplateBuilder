using Html.Components;
using Html.Exceptions;
using Html.Interfaces;
using Html.Styles;
using System.Collections.Generic;
using System.Linq;

namespace Html.Builders
{
    /// <inheritdoc/>
    public class HtmlTableBuilder : IHtmlTableBuilder
    {
        private readonly Table toBuild;
        /// <summary>
        /// Constructor with optional Style Addition
        /// </summary>
        /// <param name="style"></param>
        public HtmlTableBuilder(CssClass? style = null) { toBuild = new(style); }

        /// <inheritdoc/>
        public void AddHeaders(IEnumerable<Th> ths, CssClass? rowStyle = null)
        {
            Tr tr = new(ths, style: rowStyle);

            toBuild.Headers = tr;
        }

        /// <inheritdoc/>
        public void AddDataRow(IEnumerable<Td> tds, CssClass? rowStyle = null)
        {
            if (tds.Count() == toBuild.Headers.ThCount)
                toBuild.DataRows = toBuild.DataRows.Append(new(tds: tds, style: rowStyle));
            else
                throw new HtmlConstructionFailedException("Cannot Add a DataRow which size is different from Headers\'");
        }

        /// <inheritdoc/>
        public Table BuildFromDataHolderTable(DataHolderTable table, CssClass? style = null)
        {
            if (style != null)
                AddStyle(style);

            toBuild.Headers = new Tr(table.Headers.Select(_ => new Th(_)));

            foreach (object[] values in table.Values)
            {
                IEnumerable<Td> tds = values.Select(str => new Td(str, autoFormatData: table.AutoFormatData));
                DataRows = DataRows.Append(new(tds: tds));
            }

            return Build();
        }
        

        /// <inheritdoc/>
        public Table Build()
        {
            toBuild.UpdateTagAndHtmlString();

            return toBuild.ShallowCopy();
        }
    }
}
