using Html.Interfaces;
using Html.Styles;
using Microsoft.AspNetCore.Html;
using System.Web.Mvc;

namespace Html.Components.Abstract
{
    /// <inheritdoc/>
    public abstract class HtmlComponent : IHtmlComponent
    {
        #region properties

        /// <summary>
        /// TagBuilder with Html Tag Content
        /// </summary>
        private protected abstract TagBuilder TagBuilder { get; set; }

        /// <inheritdoc/>
        public string HtmlString => TagBuilder.ToString(TagRenderMode.Normal);

        #endregion

        #region methods

        /// <inheritdoc/>
        public virtual IHtmlContent ToHtmlContent() => new HtmlString(HtmlString);

        /// <inheritdoc/>
        public virtual void AddOrUpdateStyle(CssClass style) => TagBuilder.MergeAttribute("style", style.GenHtmlStyleInnerText());

        /// <inheritdoc/>
        public void AddOrUpdateAttribute(string key, string value) => TagBuilder.MergeAttribute(key, value, true);

        /// <inheritdoc/>
        public void AddClass(string className) => TagBuilder.AddCssClass(className);

        #endregion
    }
}
