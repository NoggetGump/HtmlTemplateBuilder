using Html.Dividers.Abstract;
using HtmlTemplateBuilder.Components.Abstract;

namespace Html.Contents
{
    ///<inheritdoc cref="HtmlDivider"/>
    public class Section : HtmlDivider
    {
        #region Propreties

        ///<inheritdoc cref="HtmlDivider.StartsDivider"/>
        internal override string StartsDivider => "<section>";

        ///<inheritdoc cref="HtmlDivider.EndsDivider"/>
        internal override string EndsDivider => "</section>";

        internal string _htmlString;
        /// <inheritdoc cref="HtmlDivider.HtmlString"/>
        public override string HtmlString => _htmlString;

        internal readonly IEnumerable<HtmlComponent>? _componentList;

        internal readonly IEnumerable<HtmlDivider>? _dividerList;

        /// <inheritdoc cref="HtmlDivider.ChildDividers"/>
        public override IEnumerable<HtmlDivider>? ChildDividers { get => _dividerList; }

        /// <inheritdoc cref="HtmlDivider.ComponentList"/>
        public override IEnumerable<HtmlComponent>? ComponentList { get => _componentList; }

        #endregion

        #region Construtor Padrão

        /// <summary>
        /// Construtor padrão
        /// </summary>
        public Section() { }

        #endregion
    }
}
