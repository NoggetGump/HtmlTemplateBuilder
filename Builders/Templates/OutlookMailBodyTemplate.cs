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
            _title = title;

            mainDivider ??= new Div();
            _mainDivider = mainDivider;

            _tables = Enumerable.Empty<Table>();
            if(dataHolders != null)
            {
                foreach(var dataHolder in dataHolders)
                {
                    HtmlTableBuilder tableBuilder = new(
                        new CssClass()
                        {
                            WidthPercent = 50
                        }
                    );

                    _tables = _tables.Append(tableBuilder.BuildFromDataHolderTable(dataHolder));
                }
            }
        }

        /// <summary>
        /// Default Build - Can Be Overridden, use as example
        /// Build should return the html document as a string - encoded or not.
        /// </summary>
        public string Build()
        {
            HtmlContentBuilder builder = new();

            // starts html doocument
            builder.AppendHtml(_mainDivider.StartTagContent);

            builder.AppendHtml(new H(_title, 3).ToHtmlContent());

            CssClass headersCss = new()
            {
                TextAlign = TextAlign.center,
                BackGroundColor = Color.FromArgb(0x00, 0xa7, 0xa8, 0xa8),
                TextColor = Color.White
            };

            CssClass alt1css = new()
            {
                BackGroundColor = Color.FromArgb(0x00, 0x3d, 0x4d, 0xd6),
                TextColor = Color.White
            };

            CssClass alt2css = new()
            {
                BackGroundColor = Color.FromArgb(0x00, 0xa7, 0xa8, 0xa8),
                TextColor = Color.White
            };

            foreach (var table in _tables)
            {
                table.Headers.AddOrUpdateStyle(headersCss);
                table.StyleAlternateDataRow(alt1css, alt2css);

                if(table.Title != null)
                    builder.AppendHtml(new H(table.Title, 3).ToHtmlContent());

                builder.AppendHtml(table.ToHtmlContent());
            }

            builder.AppendHtml(_mainDivider.EndTagContent);

            //Ends Html Document

            var writer = new StringWriter();
            //Writes through Writer
            builder.WriteTo(writer, HtmlEncoder.Default);
            htmlString = writer.ToString();

            return htmlString;
        }
    }
}
