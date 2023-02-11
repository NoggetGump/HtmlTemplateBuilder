using Html.Exceptions;
using HtmlTemplateBuilder.Components.Abstract;

namespace Html.Components.Dividers.Abstract
{
    /// <summary>
    /// Html Dividers as a Tree Like Structure
    /// Examples: section, div, articler, etc
    /// </summary>
    public abstract class HtmlDivider : HtmlComponent
    {
        /// <summary>
        /// A Divider can Have multiple HtmlComponent
        /// </summary>
        public abstract IEnumerable<HtmlComponent> ChildComponents { get; }
    }
}
