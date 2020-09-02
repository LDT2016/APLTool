using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundProductionFileDownloader
{
    public class UserSettingsModel
    {
        public IList<string> ItemIdList { get; set; }

        public int? ExecuteTimes { get; set; }

        public string SourcePath { get; set; }

        public string DestinationPath { get; set; }

        public string SubFolder { get; set; }

        public string FtpUserName { get; set; }

        public string FtpPassword { get; set; }

        public string FtpHost { get; set; }

        public string Path => System.IO.Path.Combine(DestinationPath + SubFolder);
    }
}
