using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundProductionFileDownloader
{
    public class Logic
    {
        public UserSettingsModel UserSettings { get; set; }

        public BackgroundWorker Worker { get; set; }

        public void Process(IList<string> itemIdList)
        {
            foreach (var itemId in itemIdList)
            {
                if (Worker.CancellationPending)
                {
                    
                }
            }
        }

        
    }
}
