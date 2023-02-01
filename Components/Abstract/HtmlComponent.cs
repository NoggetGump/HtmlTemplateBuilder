using Html.Builders;
using Html.Interfaces;
using Html.Styles;
using Microsoft.AspNetCore.Html;

namespace HtmlTemplateBuilder.Components.Abstract
{
    /// <inheritdoc/>
    public abstract class HtmlComponent : IHtmlComponent
    {
        #region properties

        /// <summary>
        /// TagBuilder with Html Tag Content
        /// </summary>
        private protected abstract HtmlTagBuilder TagBuilder { get; set; }

        private protected string htmlString;
        /// <inheritdoc/>
        public string HtmlString => htmlString;

        #endregion

        #region methods

        /// <summary>
        /// Clone current class's content
        /// </summary>
        /// <returns></returns>
        public IHtmlComponent ShallowCopy<T>() where T : HtmlComponent, new() => new T()
        {
            htmlString = HtmlString,
            TagBuilder = TagBuilder,
        };

        /// <inheritdoc/>
        public virtual IHtmlContent ToHtmlContent() => new HtmlString(HtmlString);

        /// <inheritdoc/>
        public virtual void AddStyle(CssClass style)
        {
            TagBuilder.MergeAttribute("style", style.GenHtmlStyleInnerText());
            htmlString = TagBuilder.UnencodedHtmlString;
        }

        /// <inheritdoc/>
        public void AddClass(string className) => TagBuilder.AddCssClass(className);

        /// <inheritdoc/>
        public void AddOrUpdateAttribute(string key, string value) => TagBuilder.MergeAttribute(key, value, true);

        #endregion
    }
}
