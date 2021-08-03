using System;
using System.Data;
using System.Runtime.Serialization;

namespace Model
{
    [Serializable]
    public class ThumbnailsNewTable : ICloneable
    {
        public ThumbnailsNewTable()
        { }


        public int RowNum { get; set; } = 0;

        public string ItemId { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Filename { get; set; } = string.Empty;

        public string CombinationId { get; set; } = string.Empty;

        public string Company { get; set; } = string.Empty;

        public string Division { get; set; } = string.Empty;

        public int ID { get; set; } = 0;

        public bool ImageNoFound { get; set; } = false;



        public object Clone()
        {
            return this.MemberwiseClone();
        }


        public override bool Equals(object obj)
        {
            Model.ThumbnailsNewTable model = obj as Model.ThumbnailsNewTable;
            if (model != null && model.ID == this.ID)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
}