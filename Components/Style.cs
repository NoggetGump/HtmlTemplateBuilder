using Html.Components.Abstract;
using Html.Styles;
using System.Web.Mvc;

namespace Html.Components
{
    /// <summary>
    /// Style Class to style other HtmlComponent(s) 
    /// </summary>
    public class Style : HtmlComponent
    {
        /// <inheritdoc/>
        private protected override TagBuilder TagBuilder { get; set; } = new("style");

        internal IEnumerable<CssClass> _cssClasses;

        /// <summary>
        /// TODO enhance^2 to optimize customization without any string development required
        /// </summary>
        /// <param name="cssClasses"></param>
        public Style(IEnumerable<CssClass> cssClasses)
        {
            _cssClasses = cssClasses;

            var innerText = string.Join(" ", cssClasses.Select(_ => _.GenCssClassComponent()));
            TagBuilder.InnerHtml = innerText;
        }
    }
}
