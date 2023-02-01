using Html.Exceptions;
using HtmlTemplateBuilder.Components.Abstract;

namespace Html.Dividers.Abstract
{
    /// <summary>
    /// Html Dividers as a Tree Like Structure
    /// Examples: section, div, articler, etc
    /// </summary>
    public abstract class HtmlDivider
    {
        /// <summary>
        /// Starts Divider, HtmlComponent(s) go after this point
        /// </summary>
        internal abstract string StartsDivider { get; }

        /// <summary>
        /// Ends Divider, HtmlComponent(s) should be before this point
        /// </summary>
        internal abstract string EndsDivider { get; }

        /// <summary>
        /// A Divider Can Have multiple HtmlDivider
        /// </summary>
        public abstract IEnumerable<HtmlDivider> ChildDividers { get; }

        /// <summary>
        /// A Divider can Have multiple HtmlComponent
        /// </summary>
        public abstract IEnumerable<HtmlComponent> ComponentList { get; }

        /// <summary>
        /// String of Html's Element
        /// </summary>
        public abstract string HtmlString { get; }

        /// <summary>
        /// Add a HtmlComponent
        /// </summary>
        /// <param name="component"></param>
        public virtual void AddComponent(HtmlComponent component)
        {
            if (ChildDividers != null)
                throw new HtmlConstructionFailedException("Um Divider que já teve Dividers Adicionado a sua DividerList não pode receber um Component");

            ComponentList.Append(component);
        }

        /// <summary>
        /// Add a HtmlDivider
        /// </summary>
        /// <param name="divider"></param>
        /// <exception cref="HtmlConstructionFailedException"></exception>
        public virtual void AddDivider(HtmlDivider divider)
        {
            if (ComponentList != null)
                throw new HtmlConstructionFailedException("Um Divider que já teve um Component Adicionado a sua ComponentList não pode receber um Component");

            ChildDividers.Append(divider);
        }
    }
}
