using Html.Components;
using Html.Dividers.Abstract;
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
        private readonly IHtmlContent htmlConfig = new HtmlString("<!DOCTYPE html><html lang=\"pt-br\" dir=\"ltr\">");
        private readonly IHtmlContent startHtml = new HtmlString("<html>");
        private readonly IHtmlContent endHtml = new HtmlString("</html>");

        private readonly IHtmlContent startBody = new HtmlString("<body><main>");
        private readonly IHtmlContent endBody = new HtmlString("</main></body>");

        /// <inheritdoc/>
        public string Title { get; set; } = string.Empty;

        /// <inheritdoc/>
        public HtmlDivider MainDivider { get; set; } = null;

        /// <inheritdoc/>
        public List<DataHolderTable> Tables { get; set; } = new();

        private string htmlString;
        /// <inheritdoc/>
        public string HtmlString => htmlString;

        /// <summary>
        /// Construtor Padrão
        /// </summary>
        public OutlookMailBodyTemplate() { }

        /// <summary>
        /// Default Build - Can Be Overridden, use as example
        /// Build should return the HTML document as a string encoded or not.
        /// TODO FALTA "SOMENTE" REFATORAR ESTRUTURA DE DIVIDERS (PARTE MAIS DIFÍCIL) E REPENSAR COMO ADICIONAR O BODY MENOS "NA MÃO"
        /// quanto
        /// </summary>
        public virtual string Build()
        {
            HtmlContentBuilder builder = new();

            //Configures Html
            builder.AppendHtml(htmlConfig);
            //Starts Html
            builder.AppendHtml(startHtml);

            //Important CSS Styling usage example
            //"table{width: 100%;} th,td{text-align: left; padding: 8px;} tr{background-color: #D6EEEE;}")
            IEnumerable<CssClass> cssClasses = Enumerable.Empty<CssClass>().
                Append(new("table") { WidthPercent = 100.0f }).
                Append(new("td") { PaddingRight = 8.0f, }).
                Append(new("tr") { BackGroundColor = Color.FromArgb(0x0, 0xdf, 0xf3, 0xdb) }). //#DFF3DB
                Append(new("h3") { TextDecorationLine = TextDecorationLine.underline });

            //head section
            Head head = new(h: new(Title, 3), style: new Style(cssClasses));
            builder.AppendHtml(head.ToHtmlContent());

            //body section TODO PENSAR EM COMO MELHORAR BODY BUILDING
            builder.AppendHtml(startBody);

            foreach (var table in Tables)
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

            //EndsBody
            builder.AppendHtml(endBody);

            //Ends Html Document
            builder.AppendHtml(endHtml);

            var writer = new StringWriter();
            //Writes through Writer
            builder.WriteTo(writer, HtmlEncoder.Default);
            htmlString = writer.ToString();

            return htmlString;
        }
    }
}
