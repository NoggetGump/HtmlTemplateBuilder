namespace Html.Styles
{
    public enum TextDecorationLine
    {
        overline,
        linethrough,
        underline,
        overlineunderline
    }

    /// <summary>
    /// Supposedly helps to do things
    /// </summary>
    public static class TextDecorationLineHelper
    {
        /// <summary>
        /// Converts TextDecorationLine to String
        /// </summary>
        /// <param name="decoration"></param>
        /// <returns></returns>
        public static string ToString(TextDecorationLine decoration) => decoration switch
        { 
            TextDecorationLine.linethrough => "line-through",
            _ => Enum.GetName(typeof(TextDecorationLine), decoration),
        };

    }
}
