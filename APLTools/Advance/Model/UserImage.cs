using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using APLTools.Models;

namespace APLTools.Advance.Model
{
    [Serializable]
    public class UserImage: INotifyPropertyChanged
    {
        public int RowNum { set; get; }
        public string OriginalFilename { set; get; } = string.Empty;
        public string FilenameNoExtension { set; get; } = string.Empty;
        public string Scene7FileName{ set; get; } = string.Empty;
        public UserImageType Type { set; get; } = UserImageType.NotSet;
        public colorSpace ColorSpace { set; get; } = colorSpace.NotSet;
        public Image Preview { set; get; }
        public byte[] FileBytes
        {
            set; get;
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //public string Scene7FileName { set; get; } = string.Empty;

    }

    public enum UserImageType
    {
        NotSet = -1,
        UploadLogo = 0,
        StockArt = 1,
        Slogan = 2,
        RecentArt = 3,
        SharedArt = 4,
        SavedArt = 5,
        Static = 6,
        Verse = 7,
        Sentiment = 8
    }
}
