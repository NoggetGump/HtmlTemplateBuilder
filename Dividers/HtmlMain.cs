using Html.Dividers.Abstract;
using HtmlTemplateBuilder.Components.Abstract;

namespace Html.Dividers
{
    public class HtmlMain : HtmlDivider
    {
        public override IEnumerable<HtmlDivider> ChildDividers => throw new NotImplementedException();

        public override IEnumerable<HtmlComponent> ComponentList => throw new NotImplementedException();

        public override string HtmlString => throw new NotImplementedException();

        internal override string StartsDivider => throw new NotImplementedException();

        internal override string EndsDivider => throw new NotImplementedException();
    }
}
