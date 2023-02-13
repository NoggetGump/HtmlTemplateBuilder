using Html.Components.Dividers.Abstract;

namespace Html.Builders
{
    /// <summary>
    /// TODO Pensar em uma maneira fazer o Build do Divider
    /// Classe responsável por montat a estrutur de HtmlDividers, ex: Div, Section, etc
    /// </summary>
    public class HtmlDividerBuilder
    {
        private readonly HtmlDivider _mainDiv;

        /// <summary>
        /// Construtor Padrão
        /// </summary>
        /// <param name="mainDiv"></param>
        public HtmlDividerBuilder(HtmlDivider mainDiv)
        {
            _mainDiv = mainDiv;
        }
    }
}
