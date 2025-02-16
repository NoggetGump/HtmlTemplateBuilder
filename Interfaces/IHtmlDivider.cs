using Microsoft.AspNetCore.Html;

namespace Html.Interfaces
{
    /// <summary>
    /// Represents an Html Component that usually goes inside Dividers like Div, Section, etc;
    /// elements that contain the actual informational data wich wants to be displayed.
    /// </summary>
    public interface IHtmlDivider : IHtmlComponent
    {
        public string StartTag { get; }

        public string EndTag { get; }

        public IHtmlContent StartTagContent => new HtmlString(StartTag);

        public IHtmlContent EndTagContent => new HtmlString(EndTag);

        public IEnumerable<IHtmlComponent> ChildComponents { get; }

        public void AppendToInnerText(string text);
    }
}