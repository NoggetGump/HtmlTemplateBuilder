using Html.Components.Abstract;
using Html.Styles;
using System.Web.Mvc;

namespace Html.Components
{
    /// <summary>
    /// Parágrafo HTML (p)Content(/p)
    /// </summary>
    public class P : HtmlComponent
    {
        private protected override TagBuilder TagBuilder { get; set; } = new("p");

        /// <summary>
        /// Construtor Padrão
        /// </summary>
        /// <param name="content"></param>
        /// <param name="style"></param>
        public P(string content, CssClass? style = null)
        {
            TagBuilder.InnerHtml =content;
            
            if(style!=null)
                AddOrUpdateStyle(style);
        }
    }
}
