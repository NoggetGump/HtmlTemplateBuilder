using Html.Components;
using Html.Components.Dividers;
using Html.Components.Table;
using Html.EstruturasAuxiliares;
using Html.Interfaces;
using Html.Styles;
using Microsoft.AspNetCore.Html;
using System.Drawing;
using System.Text.Encodings.Web;

namespace Html.Builders.Templates
{
    /// <summary>
    /// Default Html Builder - Builds the Html Document
    /// </summary>
    public class OutlookMailBodyTemplate : IHtmlTemplateBuilder
    {
        private string _title;

        private IHtmlDivider _mainDivider;

        private IEnumerable<IHtmlTable> _tables;

        public string Title => _title;

        private string htmlString = string.Empty;
        /// <inheritdoc/>
        public string HtmlString => htmlString;

        /// <summary>
        /// Construtor Padrão
        /// </summary>
        public OutlookMailBodyTemplate(string title, IHtmlDivider? mainDivider = null, IEnumerable<IHtmlTable>? tables = null) 
        {
            _title = title;

            mainDivider ??= new Div();
            _mainDivider = mainDivider;

            tables ??= Enumerable.Empty<Table>();
            _tables = tables;
        }

        /// <summary>
        /// Construtor utilizando DataHolderTable (s)
        /// </summary>
        public OutlookMailBodyTemplate(string title, IHtmlDivider? mainDivider = null, IEnumerable<DataHolderTable>? dataHolders = null)
        {
            mainDivider ??= new Div();
            _mainDivider = mainDivider;

            dataHolders ??= Enumerable.Empty<Table>();
            _tables = dataHolders;
        }

        /// <summary>
        /// Default Build - Can Be Overridden, use as example
        /// Build should return the html document as a string - encoded or not.
        /// </summary>
        public string Build()
        {
            HtmlContentBuilder builder = new();

            // starts html doocument

            foreach (var table in _tables)
            {
                Table htmlTable = new(table);

                CssClass headersCss = new()
                {
                    Important = true,
                    TextAlign = TextAlign.center,
                    BackGroundColor = Color.FromArgb(0x0, 0x30, 0xba, 0x09), //#30ba09
                    TextColor = Color.White
                };

                htmlTable.StyleHeadersRow(headersCss);
                htmlTable.StyleAlternateDataRow(new CssClass() { Important = true, BackGroundColor = Color.FromArgb(0x00, 0xfd, 0xfd, 0xfb) },
                    new CssClass() { Important = true, BackGroundColor = Color.FromArgb(0x00, 0xe7, 0xe8, 0xe3) });

                if(table.Title != null)
                    builder.AppendHtml(new H(table.Title, 3).ToHtmlContent());

                builder.AppendHtml(htmlTable.ToHtmlContent());
            }

            //Ends Html Document

            var writer = new StringWriter();
            //Writes through Writer
            builder.WriteTo(writer, HtmlEncoder.Default);
            htmlString = writer.ToString();

            return htmlString;
        }
    }
}
