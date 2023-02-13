using Html.Components.Dividers.Abstract;
using Html.EstruturasAuxiliares;
using System.Collections.Generic;

namespace Html.Interfaces
{
    /// <summary>
    /// IHtmlTemplateBuilder is the main interface and only Interface that should be
    /// implemented to use this library Correctly, or use a default Builder implemented
    /// by this library without worrying with it's implementation - ps: read it's doc though.
    /// </summary>
    public interface IHtmlTemplateBuilder
    {
        /// <summary>
        /// Title to be used in the Builder
        /// Tip: you don't neccessarily need to use Title Tag
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Html string to be written wherever needed
        /// </summary>
        public string HtmlString { get; }

        /// <summary>
        /// Main method that Builds Html Template Document using it's properties
        /// </summary>
        public string Build();
    }
}
