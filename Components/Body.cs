using HtmlTemplateBuilder.Components.Abstract;
using Html.Builders;
using Html.Dividers.Abstract;

namespace Html.Components
{
    //TODO
    public class Body : HtmlComponent
    {
        private protected override HtmlTagBuilder TagBuilder { get; set; } = new("body");

        public Body(HtmlDivider divider, HtmlDividerBuilder mainDividerBuilder)
        {

        }
    }
}
