using System.Collections.Generic;

namespace APLTools.Models
{
    /// <summary>
    /// postData object
    /// </summary>
    public class PostData
    {
        /// <summary>
        /// relative URL, e.g. "/content/dam/amsterdam/customer-supplied-logos/08/05/73/07/asset.jpg"
        /// </summary>
        public string RelativeUrl { get; set; }
        /// <summary>
        /// Http verb
        /// </summary>
        public HttpVerbs Method { get; set; }
        /// <summary>
        /// parameters send to the DAM
        /// </summary>
        public List<Parameter> Parameters { get; set; } 
    }

    /// <summary>
    /// parameter object
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// parameter name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// parameter value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// true: we are sending a file
        /// </summary>
        public bool IsFile { get; set; }
    }

    /// <summary>
    /// HttpVerbs enumerations
    /// </summary>
    public enum HttpVerbs
    {
        Post,
        Get,
        Put,
        Delete
    }
}
