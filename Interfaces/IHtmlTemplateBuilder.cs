using Html.Dividers.Abstract;
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
        /// Title to be used in the Builder, not necessarily it will be Title Tag's Inner Text
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Main Divider that carries most of the html information
        /// </summary>
        public HtmlDivider MainDivider { get; set; }

        /// <summary>
        /// Optional usage of DataHolderTable List to transmit Data Tables to the Builder
        /// </summary>
        public List<DataHolderTable> Tables { get; set; }

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
