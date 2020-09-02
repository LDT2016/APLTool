using System;
using System.IO;
using System.Windows.Forms;
using APLTools.Models;

namespace APLTools.Logic
{
    public class DamToolsHelper
    {
        public static bool AddDigitalBackgroundFile(string fullFileName, MetaData meta)
        {
            var damConnector = new DamConnector();
            damConnector.ToUpperMetaData(meta);
            var ret = damConnector.UploadFileForDigitalBackground(fullFileName, meta);
            return ret;
        }

        public static bool AddSharedArtwork(string fullFileName, MetaData meta)
        {

            var ret = AddSharedArtworkInWebPreview(fullFileName, meta);
            if (!ret)
            {
                return false;
            }
            ret = AddSharedArtworkInProductionFile(fullFileName, meta);
            return ret;
        }

        public static bool AddSavedArtwork(string fullFileName, MetaData meta)
        {
            meta.imageType = imageType.CustomerArtWork;
            meta.customerArtworkType = customerArtworkType.CustomerCleanedLogo;
            var damConnector = new DamConnector();
            damConnector.ToUpperMetaData(meta);
            var ret = damConnector.UploadFile2(fullFileName, meta);
            return ret;
        }

        public static string GetCacheFolder()
        {
            string startPath = Application.StartupPath;
            var cacheFolder = startPath + "\\cache\\";
            if (!Directory.Exists(cacheFolder))
            {
                Directory.CreateDirectory(cacheFolder);
            }
            return cacheFolder;
        }
        public static bool UploadFile(string localFullFileName, string assetName)
        {
            var damConnector = new DamConnector();
            var ret = damConnector.UploadFile(localFullFileName, assetName, null);
            return ret;
        }

        public static bool TransferFromLiveToDev(string liveAssetPath, string devAssetPath)
        {
            var result = false;
            try
            {
                var localFullFileName = DownloadFileByAssetPath(liveAssetPath);
                if (!string.IsNullOrEmpty(localFullFileName))
                {
                    var meta = GetMetaDataByAssetPath(liveAssetPath);
                    if (meta != null)
                    {
                        var damConnector=new DamConnector();
                        //var assetName = Path.GetFileName(devAssetPath);
                        result = damConnector.UploadFile3(localFullFileName, meta, devAssetPath);
                    }
                }
            }
            catch (Exception)
            {

                result = false;
            }
            return result;
        }

        public static bool CheckDigitalBackground(ConnectionType connectionType, string refId)
        {
            try
            {
                var meta = new MetaData();
                meta.imageType = imageType.StockArt;
                meta.stockArtType = stockArtType.DigitalBackground;
                meta.refId = refId.Trim();
                var damConnector = new DamConnector(connectionType);
                var assetPath = damConnector.GetAssetPathByMetadata(meta);
                return !string.Empty.Equals(assetPath);
            }
            catch
            {
                return false;
            }
            
        }
        /*********************************  Public/Private Seperator  ******************************/
        private static bool AddSharedArtworkInWebPreview(string fullFileName, MetaData meta)
        {
            meta.imageType = imageType.CustomerSuppliedStockArt;
            meta.customerArtworkType = customerArtworkType.WebPreview;
            var damConnector=new DamConnector();
            damConnector.ToUpperMetaData(meta);
            var ret = damConnector.UploadFile2(fullFileName, meta);
            return ret;
        }

        private static bool AddSharedArtworkInProductionFile(string fullFileName, MetaData meta)
        {
            meta.imageType = imageType.CustomerSuppliedStockArt;
            meta.customerArtworkType = customerArtworkType.ProductionArtWork;
            var damConnector = new DamConnector();
            damConnector.ToUpperMetaData(meta);
            var ret = damConnector.UploadFile2(fullFileName, meta);
            return ret;
        }

        private static string DownloadFileByAssetPath(string assetPath,
            ConnectionType connectionType = ConnectionType.Live)
        {
            var damConnector = new DamConnector(connectionType);
            var fileBytes = damConnector.GetAsset(assetPath);
            if (fileBytes != null && fileBytes.Length > 0)
            {
                var fileName = Path.GetFileName(assetPath);
                var cacheFolder = GetCacheFolder();
                var fullFileName = cacheFolder + fileName;
                if (File.Exists(fullFileName))
                {
                    File.Delete(fullFileName);
                }
                File.WriteAllBytes(fullFileName, fileBytes);
                return fullFileName;
            }
            return string.Empty;
        }

        private static MetaData GetMetaDataByAssetPath(string assetPath,
            ConnectionType connectionType = ConnectionType.Live)
        {
            var damConnector = new DamConnector(connectionType);
            var meta = damConnector.GetMetadataByAssetPath(assetPath);
            return meta;
        }
    }
}
