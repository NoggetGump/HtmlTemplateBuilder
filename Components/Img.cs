using Html.Components;
using Html.Components.Abstract;
using Html.Styles;
using System.Web.Mvc;

namespace HtmlTemplateBuilder.Components
{
    public class Img : HtmlComponent
    {
        private protected override TagBuilder TagBuilder { get; set; } = new("img");

        public Img(string source, float? width, float? height, CssClass? style, string alternateText = "")
        {
            AddOrUpdateAttribute("src", source);
            AddOrUpdateAttribute("alt", alternateText);
            if (width != null)
                AddOrUpdateAttribute("width", width.ToString());
            if (height != null)
                AddOrUpdateAttribute("heigh", height.ToString());
            if (style != null)
                AddOrUpdateStyle(style);
        }
    }
}
