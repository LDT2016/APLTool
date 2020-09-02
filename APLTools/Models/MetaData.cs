using System;
using System.Collections.Generic;

namespace APLTools.Models
{
    /// <summary>
    /// metadata object
    /// </summary>
    
    public class MetaData
    {
        /*
         * NOTE: MUST USE TYPE INT? INSTEAD OF INT, IT'S EASIER WHEN WE NEED TO CHECK IF THE INT? TYPE PROERTIES AER SET OR NOT
         */
        private string cusNum;

        /// <summary>
        /// image type
        /// </summary>
        
        public imageType imageType { get; set; }

        /// <summary>
        /// artwork type
        /// </summary>
        
        public customerArtworkType customerArtworkType { get; set; }

        /// <summary>
        /// customerSuppliedStockart type
        /// </summary>
        
        public customerSuppliedStockartType customerSuppliedStockartType { get; set; }

        /// <summary>
        /// stockart type
        /// </summary>
        
        public stockArtType stockArtType { get; set; }

        /// <summary>
        /// template type
        /// </summary>
        
        public templateType templateType { get; set; }

        /// <summary>
        /// static artwork type
        /// </summary>
        
        public staticArtworkType staticArtworkType { get; set; }

        /// <summary>
        /// customer number
        /// </summary>
        
        public string customerNumber
        {
            get { return cusNum; }
            set { cusNum = value?.Trim(); }
        }

        /// <summary>
        /// imprint format
        /// </summary>
        
        public string imprintFormat { get; set; }

        /// <summary>
        /// sequence number
        /// </summary>
        
        public int? sequenceNumber { get; set; }

        /// <summary>
        /// customer format sequence
        /// </summary>
        
        public string customerFormatSequence { get; set; }

        /// <summary>
        /// image code process
        /// </summary>
        
        public List<string> processIds { get; set; }

        /// <summary>
        /// color space
        /// </summary>
        
        public colorSpace colorSpace { get; set; }

        /// <summary>
        /// order number
        /// </summary>
        
        public List<string> orderNumbers { get; set; }

        /// <summary>
        /// last modified user
        /// </summary>
        
        public string lastModifiedUser { get; set; }

        /// <summary>
        /// lastmodified application
        /// </summary>
        
        public string lastModifiedApplication { get; set; }

        /// <summary>
        /// order line number
        /// </summary>
        
        public List<string> orderLineNumbers { get; set; }

        /// <summary>
        /// vendor studio id
        /// </summary>
        
        public string vendorStudioId { get; set; }

        /// <summary>
        /// original file name
        /// </summary>
        
        public string originalFilename { get; set; }

        /// <summary>
        /// filename with no extension
        /// </summary>
        
        public string filenameNoExtension { get; set; }

        /// <summary>
        /// item id
        /// </summary>
        
        public List<string> itemIds { get; set; }

        /// <summary>
        /// BomOption (Odd/Evn year option (string))
        /// </summary>
        
        public string bomOption { get; set; }

        /// <summary>
        /// verseList
        /// </summary>
        
        public string verseList { get; set; }

        /// <summary>
        /// verseId
        /// </summary>
        
        public string verseId { get; set; }

        /// <summary>
        /// verseId
        /// </summary>
        
        public string refId { get; set; }

        /// <summary>
        /// calendarYear (odd,even,blank)
        /// </summary>
        
        public string calendarYear { get; set; }

        
        public DateTime jcrlastModified { get; set; }

        
        public byte[] fileBytes { get; set; }

        
        public string assetPath { get; set; }

        
        public string actualFileName
        {
            get
            {
                if (!string.IsNullOrEmpty(assetPath))
                {
                    var lastIdxOfSlash = assetPath.LastIndexOf('/');
                    if (lastIdxOfSlash > -1)
                    {
                        return assetPath.Substring(lastIdxOfSlash + 1);
                    }
                }
                return string.Empty;
            }
            set { }
        }
    }

    #region Enumerations

    /// <summary>
    /// ImageType enumerations
    /// </summary>
    
    public enum imageType
    {
        
        NotSet,
        
        StockArt,
        
        Template,
        
        CustomerArtWork,
        
        PersonalizationFile,
        
        CustomerSuppliedStockArt,
        
        StaticArtwork
    }

    /// <summary>
    /// ArtworkType enumerations
    /// </summary>
    
    public enum customerArtworkType
    {
        
        NotSet,
        
        CustomerSuppliedLogo,
        
        CustomerCleanedLogo,
        
        WorkFile,
        
        ProductionArtWork,
        
        Proof,
        
        WebPreview,
        
        CustomerSuppliedLogoWebEdited

    }

    /// <summary>
    /// CustomerSuppliedStockartType enumerations
    /// </summary>
    
    public enum customerSuppliedStockartType
    {
        
        NotSet,
        
        WebPreview,
        
        ProductionArtwork
    }

    /// <summary>
    /// StockartType enumerations
    /// </summary>
    
    public enum stockArtType
    {
        
        NotSet,
        
        DigitalBackground,
        
        AdArt,
        
        DateArt,
        
        Slogan,
        
        Verse,
        
        Sentiment
    }

    /// <summary>
    /// TemplateType enumerations
    /// </summary>
    
    public enum templateType
    {
        
        NotSet,
        
        Grid,
        
        Single,
        
        Xeikon,
        
        Pim,
        
        Thayer
    }

    /// <summary>
    /// StaticArtworkType enumerations
    /// </summary>
    
    public enum staticArtworkType
    {
        
        NotSet,
        
        ProductionArtwork
    }

    /// <summary>
    /// ColorSpace enumerations
    /// </summary>
    
    public enum colorSpace
    {
        
        NotSet,
        
        SingleColor,
        
        MultipleColor
    }

    #endregion
}
