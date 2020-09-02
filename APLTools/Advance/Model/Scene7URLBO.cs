using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Configurator.Models.Scene7
{
    [Serializable]
    public class Scene7URLBO
    {
        private const string SCENE7_FXG_HOSTLINK = "/is/agm/";
        private const string SCENE7_IMAGEPRESET_HOSTLINK = "{0}i";
        private const string PLACEHOLDER_SCENE7 = "/is/image/PromotionalStore/";
        public const string OBJ = "obj";
        public const string COLOR = "color";
        public const string SHOW = "show";
        public const string IMPRINT = "imprint";
        public const string DECAL = "decal";
        public const string YR = "YR";
        public const string SLOGAN = "slogan";
        public const string SLOGAN_LOGOLOCATIONCODE = "SLOGAN";
        public const string VERSE = "verse";
        public const string YEAR = "YEAR";
        public const string TRUE = "true";
        public const string SHARPEN = "sharpen";
        public const string SRC = "src";
        public const string FXG = "fxg";
        public const string IR = "ir";
        public const string IS = "is";
        public const string I = "i";
        public const string FXG_LOGO = "logo";
        public const string IMAGEPRESET = "$Studio_VignetteThumb$";
        public const string MOREVIEWPRESET = "$Studio_MoreViewsThumb$";
        public const string DEBOSSPRESET = "$deboss-fx$";
        public const string GLOWPRESET = "$glow$";
        public const string FXG_LOGOLOCATION_TEXT = "_Text";
        public const string FXG_TEXT = "text";
        public const string FXG_LOGOLOCATION_IMAGE = "_Image";
        public const string FXG_IMAGE = "image";
        public const string FXG_SLOGAN = "SLOGAN";
        public const string FXG_SLOGAN2 = "SLOGAN2";
        public const string FXG_VERSE = "VERSE";
        public const string FXG_SIZE = "size";
        public const string FXG_FORMAT = "fmt";
        public const string FXG_FORMAT_PDF = "pdf";
        public const string FXG_FORMAT_PNG = "png";
        public const string FXG_FORMAT_PNGALPHA = "png-alpha";
        public const string FXG_FORMAT_FXG = "fxg";
        public const string FXG_TEXTURE = "texture";
        public const string FXG_SOURCE = "source";
        public const string FXG_HOTSTAMP = "hotstamp_";
        public const string FXG_EMBROIDERED = "Embroidered_";
        public const string LAYER = "layer";
        public const string OPAC = "opac";
        public const string OPSHARPEN1 = "op_sharpen=1";
        public const string OPGROW5 = "op_grow=5";
        public const string OPBLUR20 = "op_blur=20";
        public const string EFFECTN1 = "effect=-1";
        public const string SCALE1 = "scale=1";
        public const string SCALE = "scale";
        public const string RES10 = "res=10";
        public const string COMMA = ",";
        public const string SET_ELEMENT = "setElement.";
        public const string SET_ATTR = "setAttr.";
        public const string VISIBLE = "visible";
        public const string SLASH = "/";
        public const string QUESTION_MARK = "?";
        public const string AND = "&";
        public const string EQUALS = "=";
        public const string UNDERSCORE = "_";
        public const string CONTENT_BEGIN = "<content>";
        public const string P_BEGIN = "<p";
        public const string FONT_SIZE = "fontSize";
        public const string FONT_FAMILY = "fontFamily";
        public const string PLACEHOLDER_BOMCOLOR = "{BOMColor}";
        public const string REQ_PROPS = "req=props";
        public const string INFO_WIDTH = "image.width";
        public const string INFO_HEIGHT = "image.height";
        public const string SCL = "scl";
        public const string EXTEND = "extend";
        public const string FIT = "fit=fit,1";
        //bold parameter
        public const string FONT_WEIGHT = "fontWeight";
        //italic parameter
        public const string FONT_STYLE = "fontStyle";
        public const string FONT_WEIGHT_BOLD = "bold";
        public const string FONT_STYLE_ITALIC = "italic";
        public const string FONT_NORMAL = "normal";
        public const string P_END = "</p>";
        public const string CONTENT_END = "</content>";
        public const string SPACE = " ";
        public const string ANGLE_BRACKET_BEGIN = "<";
        public const string ANGLE_BRACKET_END = ">";
        public const string QUOTE = "\"";
        public const string BRACE_LEFT = "{";
        public const string BRACE_RIGHT = "}";
        public const string USER_GENERATE_CONTENT_BEGIN = "{source=@Embed('is(";
        public const string USER_GENERATE_CONTENT_END = ")')}";
        public const string IMAGE_COLORIZE = "op_colorize";
        public const string IMAGE_BRIGHTNESS = "op_brightness";
        public const string IMAGE_CONTRAST = "op_contrast";
        public const string BRACKET_LEFT = "(";
        public const string BRACKET_RIGHT = ")";
        //fxg parameters
        public const string BREAKOPPORTUNITY = "breakOpportunity=none";
        //thumbnail URL
        public const string PLACEHOLDER_0 = "{0}";
        public const string PLACEHOLDER_1 = "{1}";
        public const string PLACEHOLDER_2 = "{2}";
        public const string PLACEHOLDER_3 = "{3}";
        public const string VIGNETTE_WIDTH = "wid";
        public const string VIGNETTE_HEIGHT = "hei";
        public const string FXG_WIDTH = "wid";
        public const string ROTATE = "rotate";
        public const string CROP = "crop";
        
        //scene7 upload file
        public const string SCENE7_TOKEN = "http://s7ugc1.scene7.com/ugc/image?op=get_uploadtoken&shared_secret=ef787b36-18a9-4b8a-9dd7-c84a10f78984&expires=1800";

        public const string SCENE7_TOKEN_NODE_PATH = "scene7/user_generated_content/response/message/uploadtoken";
        public const string SCENE7_UPLOAD_HOST = "https://s7ugc1.scene7.com/ugc/image?op=upload";
        public const string SCENE7_UPLOAD_TOKEN = "upload_token";
        public const string SCENE7_UPLOAD_FILE_EXT = "file_exts";
        public const string SCENE7_RESPONSE_STATUS_PATH = "scene7/user_generated_content/response/serviceStatus";
        public const string SCENE7_RESPONSE_MESSAGE_PATH = "scene7/user_generated_content/response/errorMessage";
        public const string SCENE7_UPLOAD_FILE_PATH = "scene7/user_generated_content/response/message/path";
        public const string DEFAULT_THUMBNAIL_URL_KEY = "default";
        public const string PRODUCT_PLACEHOLDER = "product_";
        //general
        public const string HTTPS = "https:";
        public const string HTTP = "http:";
        public const string SLASH_SLASH = "//";
        private const string Format_Thumbnail_Filename = "/resources/icons/BOM/{0}.jpg";
        //digital template
        public const string DIGITAL = "digital";
        public const string THUMBNAIL = "thumb";
        public const string DESIGN = "design";
        public const string CUSTOM = "custom";
        public const string BLANK = "blank";
        public const string DIGITAL_BACKGROUND_VISIBLE = "background={visible=true}";
        public const string DIGITAL_BACKGROUNDIMAGE = "backgroundimage";
        //pdf parameters
        public const string ImageRes_300 = "imageRes=300";

        //public const string IBALANCER_FXG_FORMAT_JSON = "json";
        public const string IBALANCER_USER_GENERATE_CONTENT_BEGIN = "{source=@Embed(";
        public const string IBALANCER_USER_GENERATE_CONTENT_END = ")}";
        public const string IBALANCET_USER_GENERATE_CONTENT_DIMENSION = "api/v1/entity/Promo/content/";
        public const string IBALANCER_TEMPLATE = "api/v1/Promo/queue_by_template/";
        public const string IBALANCER_REQ_PROPS = "req=imageprops";
        public const string IBALANCER_RESIZEEXTEND = "resize_extend";
        public const string IBALANCER_IMAGE = "/image";
        public const string IBALANCER_EXTEND = "op_extend";

        public enum FXGParameterType
        {
            FXG = 0, Text, Image
        }
        
        public static string GetVignetteFolder()
        {
            return GetAppConfigurationSetting("Scene7.RenderFolder");
        }
        public static string GetImageServerFolder()
        {
            return GetAppConfigurationSetting("Scene7.ImageServerFolder");
        }
        public static string GetUploadCompany()
        {
            return "company_name=" + GetAppConfigurationSetting("Scene7.UGCCompany");
        }

        public static string GetFXGHostlink(string scene7ImagePath)
        {
            return scene7ImagePath.Replace(PLACEHOLDER_SCENE7, SCENE7_FXG_HOSTLINK);
        }
        public static string GetImagePresetHostlink(string scene7ImagePath)
        {
            return string.Format(SCENE7_IMAGEPRESET_HOSTLINK, scene7ImagePath);
        }

        public static string GetImageColorSwatchUrl(string codeValue)
        {
            return string.Format(Format_Thumbnail_Filename, codeValue);
        }
        #region Private Static Functions
        private static string GetAppConfigurationSetting(string section)
        {
            var setting = string.Empty;

            setting = ConfigurationManager.AppSettings[section];
            
            return setting;
        }
        #endregion
    }

    public enum Scene7TemplateTypes
    {
        FullSizeImage,
        DetailSizeImage,
        ThumbnailSizeImage,
        GeneralThumbnailSizeImage,
        StudioRecentArtThumbnailSizeImage,
        StudioStockArtThumbnailSizeImage,
        StudioStockArtDetailSizeImage,
        StudioUploadLogo,
        ProductDetailSwatch,
        SharedArtworkThumbnailSizeImage,
        SharedArtworkDetailSizeImage,
        StudioBackgroundThumbnailSizeImage,
        StudioBackgroundPreviewSizeImage,
        StudioVerseThumbnailSizeImage,
        StudioVerseDetailSizeImage
    }

    [Serializable]
    public class Scene7BaseURLBO
    {
        private string url = string.Empty;
        private int maxWidth = 0;
        private int defaultWidth = 0;
        private int defaultHeight = 0;
        private int realWidth = 0;
        private bool isDefault = false;
        private Scene7URLType type;
        private int templateID;
        private string key;

        public string URL
        {
            get { return url; }
            set { url = value; }
        }

        public int MaxWidth
        {
            get { return maxWidth; }
            set { maxWidth = value; }
        }

        public int DefaultWidth
        {
            get { return defaultWidth; }
            set { defaultWidth = value; }
        }

        public int DefaultHeight
        {
            get { return defaultHeight; }
            set { defaultHeight = value; }
        }

        public int RealWidth
        {
            get { return realWidth; }
            set { realWidth = value; }
        }

        public bool IsDefault
        {
            get { return isDefault; }
            set { isDefault = value; }
        }

        public Scene7URLType Type
        {
            get { return type; }
            set { type = value; }
        }

        public int TemplateID
        {
            get { return templateID; }
            set { templateID = value; }
        }

        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        public string GetDefaultURL()
        {
            return GetURL().Append(defaultWidth).Append(Scene7URLBO.AND).ToString();
        }

        public string GetEditorURL()
        {
            return GetURL().Append(realWidth).Append(Scene7URLBO.AND).ToString();
        }

        public string GetZoomURL(int width)
        {
            return GetURL().Append(width).Append(Scene7URLBO.AND).ToString();
        }

        private StringBuilder GetURL()
        {
            var sb = new StringBuilder(url);
            sb.Append(Scene7URLBO.AND);
            sb.Append(Scene7URLBO.VIGNETTE_WIDTH);
            sb.Append(Scene7URLBO.EQUALS);
            return sb;
        }
    }

    public enum Scene7URLType
    {
        FXG, Vignette
    }

    public class Revision
    {
        public int id { get; set; }
        public long created_at { get; set; }
        public bool is_active { get; set; }
    }


    public class Entity
    {
        public int id { get; set; }
        //public string alias { get; set; }
        public Revision[] revisions { get; set; }
    }

    public class ContentResponse
    {
        public int success { get; set; }
        public Entity[] entities { get; set; }
    }
}
