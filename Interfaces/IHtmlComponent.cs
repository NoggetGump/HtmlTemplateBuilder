using Html.Styles;
using Microsoft.AspNetCore.Html;

namespace Html.Interfaces
{
    /// <summary>
    /// Represents an Html Component that usually goes inside Dividers like Div, Section, etc;
    /// elements that contain the actual informational data wich wants to be displayed.
    /// </summary>
    public interface IHtmlComponent
    {
        /// <summary>
        /// Html's Content as a String
        /// </summary>
        public string HtmlString { get; }

        /// <summary>
        /// Html Component as a HtmlContent - only to be overwritten if you want to change
        /// the component's encoding, else HtmlContentBuilder will Write the string unencoded.
        /// </summary>
        /// <returns></returns>
        public IHtmlContent ToHtmlContent();

        /// <summary>
        /// Adds or Update a Attribute to the HtmlTag
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void AddOrUpdateAttribute(string key, string value);

        /// <summary>
        /// Add Style to the Html Tag using a CssClass Style
        /// </summary>
        /// <param name="style"></param>
        public void AddOrUpdateStyle(CssClass style);

        /// <summary>
        /// Adds a Class to the Html Tag
        /// </summary>
        /// <param name="className"></param>
        public void AddClass(string className);
    }
}
