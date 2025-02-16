using Html.Interfaces;

namespace Html.Builders
{
    /// <summary>
    /// TODO Pensar em uma maneira fazer o Build do Divider
    /// Classe responsável por montat a estrutur de HtmlDividers, ex: Div, Section, etc
    /// </summary>
    public class HtmlDividerBuilder
    {
        private readonly IHtmlDivider _mainDiv;

        /// <summary>
        /// Construtor Padrão
        /// </summary>
        /// <param name="mainDiv"></param>
        public HtmlDividerBuilder(IHtmlDivider mainDiv)
        {
            _mainDiv = mainDiv;
        }

        public string Build()
        {
            if (_mainDiv.ChildComponents.Any())
                foreach (var component in _mainDiv.ChildComponents)
                {
                    if (component is IHtmlDivider subDivider)
                    {
                        HtmlDividerBuilder builder = new(subDivider);
                        _mainDiv.AppendToInnerText(builder.Build());
                    }
                    else
                        _mainDiv.AppendToInnerText(component.HtmlString);
                }

            return _mainDiv.HtmlString;
        }
    }
}
