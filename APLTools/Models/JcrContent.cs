using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Models
{
    public class JcrContent
    {
        public string primaryType { get; set; }
        public string lastModifiedBy { get; set; }
        
        public string lastModified { get; set; }
        
        public string parentPath { get; set; }
        
        public string name { get; set; }
        
        public string assetState { get; set; }
        
        public string relativePath { get; set; }
        
        public string Asset { get; set; }
        
        public string created { get; set; }
        
        public string createdBy { get; set; }

        public DateTime JcrLastModified { get { return ConvertDateTime(); }}

        private DateTime ConvertDateTime()
        {
            DateTime newDateTime = DateTime.MinValue;
            string strReformattedDate = GetReformatedDateString();

            if (!string.IsNullOrEmpty(strReformattedDate))
            {
                newDateTime = Convert.ToDateTime(strReformattedDate);
            }

            return newDateTime;
        }

        private string GetReformatedDateString()
        {
            string strDate = (string.IsNullOrEmpty(lastModified) ? created : lastModified);
            string dateformat = "{0}, {1} {2} {3} {4}";
            string[] dateParts = null;

            if (!string.IsNullOrEmpty(strDate))
            {
                dateParts = strDate.Split(new char[] { ' ', '-' });

                if (dateParts != null)
                {
                    if (dateParts.Length > 0)
                    {
                        if (dateParts.Length > 4)
                        {
                            strDate = string.Format(dateformat, dateParts[0], dateParts[2], dateParts[1], dateParts[3], dateParts[4]);
                        }
                    }
                }
            }

            return strDate;
        }
    }
}
