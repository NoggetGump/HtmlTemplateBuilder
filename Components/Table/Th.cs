using Html.Components.Abstract;
using Html.Builders;
using Html.Styles;
using System.Web.Mvc;

namespace Html.Components.Table
{
    /// <summary>
    /// A Html Table Header
    /// </summary>
    public class Th : HtmlComponent
    {
        private protected override TagBuilder TagBuilder { get; set; } = new ("th");

        /// <summary>
        /// Receives a Header
        /// </summary>
        /// <param name="header"></param>
        /// <param name="style"></param>
        public Th(string header, CssClass? style = null)
        {
            if(style !=null)
                AddOrUpdateStyle(style);

            TagBuilder.InnerHtml = header;
        }
    }
}
