using Html.Components.Abstract;
using Html.Interfaces;
using Microsoft.AspNetCore.Html;
using System.Web.Mvc;

namespace Html.Components.Dividers.Abstract
{
    /// <summary>
    /// Html Dividers as a Tree Like Structure
    /// Examples: section, div, articler, etc
    /// </summary>
    public abstract class HtmlDivider : HtmlComponent, IHtmlDivider
    {
        public string StartTag => TagBuilder.ToString(TagRenderMode.StartTag);

        public string EndTag => TagBuilder.ToString(TagRenderMode.EndTag);

        public IHtmlContent StartTagContent => new HtmlString(StartTag);

        public IHtmlContent EndTagContent => new HtmlString(EndTag);

        /// <summary>
        /// A Divider can Have multiple Html Components including other Dividers
        /// </summary>
        public abstract IEnumerable<IHtmlComponent> ChildComponents { get; }
    }
}
