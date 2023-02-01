using System.Web.Mvc;

namespace Html.Builders
{
    public class HtmlTagBuilder : TagBuilder
    {
        public HtmlTagBuilder(string tagName) : base(tagName) { }

        /// <summary>
        /// Unencodede Html Sring
        /// </summary>
        public string UnencodedHtmlString => ToString(TagRenderMode.StartTag) + InnerHtml + ToString(TagRenderMode.EndTag);
    }
}
