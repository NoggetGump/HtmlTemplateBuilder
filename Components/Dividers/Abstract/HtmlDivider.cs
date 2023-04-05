using Html.Components.Abstract;
using Html.Interfaces;
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

        /// <summary>
        /// A Divider can Have multiple Html Components including other Dividers
        /// </summary>
        public abstract IEnumerable<IHtmlComponent> ChildComponents { get; }

        /// <summary>
        /// Appends to Components InnerText, implementation should consider IHtmlComponent implementation
        /// </summary>
        /// <param name="text"></param>
        public void AppendToInnerText(string text) { TagBuilder.InnerHtml = TagBuilder.InnerHtml.Concat(text).ToString(); }
    }
}