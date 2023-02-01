using System;

namespace Html.Exceptions
{
    /// <summary>
    /// Html Construction Exception: Not Ablet to Construct Element
    /// </summary>
    public class HtmlConstructionFailedException : Exception
    {
        public HtmlConstructionFailedException() : base() { }

        public HtmlConstructionFailedException(string message) : base(message) { }

        public HtmlConstructionFailedException(string message, Exception inner) : base(message, inner) { }
    }
}
