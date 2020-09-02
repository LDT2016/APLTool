using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APLTools.Models
{
    public class Constant
    {
        public const string AssetsRootPath = "/content/dam/amsterdam/prepress";
        public const string LastModifiedUser = "DAMTools";
        public const string LastModifiedApplication = "DAMTools";
        //public static readonly string CacheFolder = ConfigurationManager.AppSettings["CacheFolder"];
        private static readonly List<string> Exclusions = new List<string>();

        public static List<string> GetExculsions()
        {
            Exclusions.Add(GetPropertyName<MetaData>(meta => meta.imprintFormat));
            Exclusions.Add(GetPropertyName<MetaData>(meta => meta.lastModifiedApplication));
            Exclusions.Add(GetPropertyName<MetaData>(meta => meta.lastModifiedUser));
            Exclusions.Add(GetPropertyName<MetaData>(meta => meta.customerFormatSequence));
            Exclusions.Add(GetPropertyName<MetaData>(meta => meta.filenameNoExtension));
            Exclusions.Add(GetPropertyName<MetaData>(meta => meta.originalFilename));
            Exclusions.Add(GetPropertyName<MetaData>(meta => meta.itemIds));
            Exclusions.Add(GetPropertyName<MetaData>(meta => meta.customerNumber));
            Exclusions.Add(GetPropertyName<MetaData>(meta => meta.sequenceNumber));
            Exclusions.Add(GetPropertyName<MetaData>(meta => meta.processIds));
            Exclusions.Add(GetPropertyName<MetaData>(meta => meta.orderNumbers));
            Exclusions.Add(GetPropertyName<MetaData>(meta => meta.orderLineNumbers));
            Exclusions.Add(GetPropertyName<MetaData>(meta => meta.vendorStudioId));
            Exclusions.Add(GetPropertyName<MetaData>(meta => meta.verseId));
            return Exclusions;
        }
        public static List<string> GetToUpperPropertyInclusions()
        {
            var inclusions = new List<string>
            {
                GetPropertyName<MetaData>(meta => meta.customerFormatSequence),
                GetPropertyName<MetaData>(meta => meta.customerNumber),
                //GetPropertyName<MetaData>(meta => meta.filenameNoExtension),
                GetPropertyName<MetaData>(meta => meta.imprintFormat),
                GetPropertyName<MetaData>(meta => meta.lastModifiedApplication),
                GetPropertyName<MetaData>(meta => meta.lastModifiedUser),
                GetPropertyName<MetaData>(meta => meta.orderNumbers),
                GetPropertyName<MetaData>(meta => meta.verseId),
                GetPropertyName<MetaData>(meta => meta.verseList),
                GetPropertyName<MetaData>(meta => meta.originalFilename)
            };
            return inclusions;
        }
        private static string GetPropertyName<T>(Expression<Func<T, object>> expr)
        {
            var rtn = "";
            if (expr.Body is UnaryExpression)
            {
                rtn = ((MemberExpression)((UnaryExpression)expr.Body).Operand).Member.Name;
            }
            else if (expr.Body is MemberExpression)
            {
                rtn = ((MemberExpression)expr.Body).Member.Name;
            }
            else if (expr.Body is ParameterExpression)
            {
                rtn = ((ParameterExpression)expr.Body).Type.Name;
            }
            return rtn;
        }

        public static byte[] GetNetworkFileBytes(string url)
        {
            using (WebClient wc = new WebClient())
            {
                return wc.DownloadData(url);
            }
        }
    }
}
