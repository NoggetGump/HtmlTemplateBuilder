namespace Html.Components.Dividers
{
    /// <summary>
    /// Html Div
    /// </summary>
    public class Div : HtmlDivider
    {
        private protected override HtmlTagBuilder TagBuilder { get; set; } = new("div");

        private IEnumerable<HtmlComponent> childComponents;
        public abstract IEnumerable<HtmlComponent> ChildComponents => childComponents;
    }
}
