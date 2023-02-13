using Html.Interfaces;
using Html.Components.Dividers.Abstract;
using System.Web.Mvc;

namespace Html.Components.Dividers
{
    /// <summary>
    /// Html Div
    /// </summary>
    public class Div : HtmlDivider
    {
        private protected override TagBuilder TagBuilder { get; set; } = new("div");

        private IEnumerable<IHtmlComponent> childComponents = Enumerable.Empty<IHtmlComponent>();
        public override IEnumerable<IHtmlComponent> ChildComponents => childComponents;
    }
}
