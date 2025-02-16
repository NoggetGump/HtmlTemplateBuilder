using Html.Exceptions;
using System.Drawing;

namespace Html.Styles
{
    /// <summary>
    /// CssComponent to build a Style
    /// TODO: config main html style components through a configuration file!!! Than this solution will be really good
    /// </summary>
    public class CssClass
    {
        /// <summary>
        /// CSS Style Class Name
        /// </summary>
        public readonly string ClassName = string.Empty;
        private readonly Dictionary<string, string> dict = new();

        #region properties

        /// <summary>
        /// Marca a classe como !important.
        /// </summary>
        public bool Important { get; set; } = false;

        #region border

        private static readonly string borderColorKey = "border-color";
        private Color? borderColor;
        public Color? BorderColor
        {
            get => borderColor;
            set
            {
                borderColor = value;
                ColorSet(borderColorKey, value);
            }
        }

        private static readonly string borderWidthKey = "border-width";
        private float? borderWidth;
        public float? BorderWidth
        {
            get => borderWidth;
            set
            {
                borderWidth = value;
                Set(borderWidthKey, value?.ToString() + "px");
            }
        }

        private static readonly string borderStyleKey = "border-style";
        //TODO borderStyle

        #endregion

        #region text

        private static readonly string textColoKey = "color";
        private Color? textColor;
        public Color? TextColor
        {
            get => textColor;
            set
            {
                textColor = value;
                ColorSet(textColoKey, value);
            }
        }

        private static readonly string textAlignKey = "text-align";
        private TextAlign? textAlign;
        public TextAlign? TextAlign
        {
            get => textAlign;
            set
            {
                textAlign = value;
                Set(textAlignKey, 
                    textAlign.HasValue ? Enum.GetName(typeof(TextAlign), textAlign.Value) : null);
            }
        }

        #region text decoration

        public Color? TextDecorationColor { get; set; }

        private static readonly string textDecorationLineKey = "text-decoration-line";
        private TextDecorationLine? textDecorationLine;
        public TextDecorationLine? TextDecorationLine
        {
            get => textDecorationLine;
            set
            {
                textDecorationLine = value;
                Set(textDecorationLineKey, 
                    textDecorationLine.HasValue ? TextDecorationLineHelper.ToString(textDecorationLine.Value) : null);
            }
        }

        private static readonly string textDecorationKey = "text-decoration-style";
        private TextDecorationStyle? textDecorationStyle;
        public TextDecorationStyle? TextDecorationStyle
        {
            get => textDecorationStyle;
            set
            {
                textDecorationStyle = value;
                Set(textDecorationKey,
                    textDecorationStyle.HasValue ? Enum.GetName(typeof(TextDecorationStyle?), textDecorationStyle.Value) : null);
            }
        }

        #endregion

        #endregion

        #region background

        private static readonly string backGroundColorKey = "background-color";
        private Color? backGroundColor;
        public Color? BackGroundColor
        {
            get => backGroundColor;
            set
            {
                backGroundColor = value;
                ColorSet(backGroundColorKey, value);
            }
        }
        public string? BackGroundImage { get; set; }
        public BackGroundRepeat? BackGroundRepeat { get; set; }
        // TODO BackGroundPosition

        #endregion

        #region margin

        private static readonly string marginTopKey = "margin-top";
        private float? marginTop;
        public float? MarginTop
        {
            get => marginTop;
            set
            {
                marginTop = value;
                Set(marginTopKey, value?.ToString() + "px");
            }
        }

        private static readonly string marginBottomKey = "margin-bottom";
        private float? marginBottom;
        public float? MarginBotom
        {
            get => marginBottom;
            set
            {
                marginBottom = value;
                Set(marginBottomKey, value?.ToString() + "px");
            }
        }

        private static readonly string marginRightKey = "margin-right";
        private float? marginRight;
        public float? MarginRight
        {
            get => marginRight;
            set
            {
                marginRight = value;
                Set(marginRightKey, value?.ToString() + "px");
            }
        }

        private static readonly string marginLeftKey = "margin-left";
        private float? marginLeft;
        public float? MarginLeft
        {
            get => marginLeft;
            set
            {
                marginLeft = value;
                Set(marginLeftKey, value?.ToString() + "px");
            }
        }

        #endregion

        #region padding

        private static readonly string paddingTopKey = "padding-top";
        private float? paddingTop;
        public float? PaddingTop
        {
            get => paddingTop;
            set
            {
                paddingTop = value;
                Set(paddingTopKey, value?.ToString() + "px");
            }
        }

        private static readonly string paddingBottomKey = "padding-bottom";
        private float? paddingBottom;
        public float? PaddingBottom

        {
            get => paddingBottom;
            set
            {
                paddingBottom = value;
                Set(paddingBottomKey, value?.ToString() + "px");
            }
        }

        private static readonly string paddingRightKey = "padding-right";
        private float? paddingRight;
        public float? PaddingRight
        {
            get => paddingRight;
            set
            {
                paddingRight = value;
                Set(paddingRightKey, value?.ToString() + "px");
            }
        }

        private static readonly string paddingLeftKey = "padding-left";
        private float? paddingLeft;
        public float? PaddingLeft
        {
            get => paddingLeft;
            set
            {
                paddingLeft = value;
                Set(paddingLeftKey, value?.ToString() + "px");
            }
        }

        #endregion

        private static readonly string widthKey = "width";
        private float? widthPercent;
        /// <summary>
        /// Porcentagem em Percentual
        /// </summary>
        public float? WidthPercent
        {
            get => widthPercent;
            set
            {
                widthPercent = value;
                Set(widthKey, value?.ToString() + "%");
            }
        }

        //TODO PROPERTIES FROM THIS POINT FORWARD
        public float? HeightPercentage { get; set; }
        public float? HeightAbsolute { get; set; }
        public float? WidthAbsolute { get; set; }
        public float? LetterSpacing { get; set; }
        public float? LineHeight { get; set; }
        public string? FontStyle { get; set; }

        #endregion

        #region private methods

        private void Set(string key, string? value)
        {
            if (value != null)
            {
                if (dict.ContainsKey(key))
                    dict[key] = value.ToString();
                else
                    dict.Add(key, value.ToString());
            }
        }

        private void ColorSet(string key, Color? color)
        {
            var strValue = color.HasValue ? ColorTranslator.ToHtml(color.Value) : null;
            Set(key, strValue);
        }

        #endregion

        #region constructors

        public CssClass() {}

        /// <summary>
        /// Standard Constructor with necessary parameters
        /// </summary>
        /// <param name="name"></param>
        public CssClass(string name) { ClassName = name; }

        #endregion

        #region public methods

        /// <summary>
        /// Generates Css Class Component, usually to be Added to a Style's TagBuilder InnerText, 
        /// but do whatever you want.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="HtmlConstructionFailedException"></exception>
        public string GenCssClassComponent()
        {
            if (ClassName == string.Empty)
                throw new HtmlConstructionFailedException("This CssClass can only be used to Style individual HtmlComponents because it has no ClassName.\n" +
                    "use GenHtmlStyleInnerText if you want to Add Style to a HtmlComponent Tag like style=\"key1: value1;key2: value2\"");

            if (dict.Any())
            {
                string result = ClassName + "{";
                foreach (var key in dict.Keys)
                    result += key + ": " + dict[key] + (Important ? "!important" : string.Empty) + ";";
                result += "}";

                return result;
            }
            else
                throw new HtmlConstructionFailedException("Tryed Generating an Empty Css Coponent");
        }

        /// <summary>
        /// Used to Generate html's tag inner text style string i.e:
        /// style="key1: value1;key2: value2".
        /// </summary>
        /// <returns></returns>
        public string GenHtmlStyleInnerText()
        {
            string result = string.Empty;

            foreach (var key in dict.Keys)
                result += key + ": " + dict[key] + (Important ? " !important" : string.Empty) + ";";

            return result;
        }

        #endregion
    }
}
