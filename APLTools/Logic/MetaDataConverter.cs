using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Script.Serialization;
using APLTools.Models;

namespace APLTools.Logic
{
    public class MetaDataConverter : JavaScriptConverter
    {
        public override object Deserialize(IDictionary<string, object> dictionary, Type type,
            JavaScriptSerializer serializer)
        {
            var meta = new MetaData();
            var properties = type.GetProperties();

            foreach (var propertyInfo in properties)
            {
                object value;
                var name = propertyInfo.Name;
                if (name.StartsWith("jcr"))
                {
                    name = name.Substring(0, 3) + ":" + name.Substring(3);
                }

                dictionary.TryGetValue(name, out value);
                
                if (value != null)
                {
                    //enum type
                    if (propertyInfo.PropertyType.IsEnum)
                    {
                        var enumVal = Enum.Parse(propertyInfo.PropertyType, value.ToString());
                        propertyInfo.SetValue(meta, enumVal);
                    }
                    //list
                    else if (propertyInfo.PropertyType == typeof (List<string>))
                    {
                        var list = value as ArrayList;
                        if (list != null)
                        {
                            var array = (string[]) list.ToArray(typeof (string));
                            propertyInfo.SetValue(meta, array.ToList());
                        }
                        else
                        {
                            //we may get a string type value when we set a single vaue in DAM
                            var tmpList = new List<string>() {value.ToString()};
                            propertyInfo.SetValue(meta, tmpList);
                        }
                    }
                    //datetime
                    else if (propertyInfo.PropertyType == typeof (DateTime))
                    {
                        var dateStr = value.ToString(); // e.g. "Wed Jul 13 2016 20:08:44 GMT-0400"
                        dateStr = dateStr.Replace("GMT-0400", "").Trim();
                        var dateFmt = "ddd MMM dd yyyy HH:mm:ss";
                        DateTime dt;
                        var success = DateTime.TryParseExact(dateStr, dateFmt, System.Globalization.CultureInfo.InvariantCulture,DateTimeStyles.None, out dt);
                        if(success)
                        {
                            propertyInfo.SetValue(meta, dt);
                        }
                    }
                    else if (propertyInfo.PropertyType == typeof (int?))
                    {
                        int tmpInt;
                        var success = int.TryParse(value.ToString(), out tmpInt);
                        if (success)
                        {
                            propertyInfo.SetValue(meta, tmpInt);
                        }
                    }
                    //other types
                    else
                    {
                        propertyInfo.SetValue(meta, value);
                    }
                }
            }
            return meta;
        }

        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Type> SupportedTypes => new[] {typeof (MetaData)};
    }
}
