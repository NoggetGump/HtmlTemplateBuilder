using Html.Components.Abstract;
using Html.Styles;
using System.Web.Mvc;

namespace Html.Components
{
    /// <summary>
    /// Título da Página Html (title)content(/title)
    /// </summary>
    public class Title : HtmlComponent
    {
        ///<inheritdoc/>
        private protected override TagBuilder TagBuilder { get; set; } = new("title");

        /// <summary>
        /// Construtor Padrão
        /// </summary>
        /// <param name="content"></param>
        /// <param name="style"></param>
        public Title(string content, CssClass? style = null)
        {
            if(style != null)
                AddOrUpdateStyle(style);

            TagBuilder.InnerHtml = content;
        }
    }
}
