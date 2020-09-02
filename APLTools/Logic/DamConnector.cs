/* Created by hzzhao in 2015 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using APLTools.Models;
using Models;

namespace APLTools.Logic
{
    /*
     * === We are using some uniform variable names in this class, below are some instructions about these variables ===
     * assetPath: the relative path of the asset in DAM, e.g. "/content/dam/amsterdam/CustomerCleanedLogo/asset1.jpg"
     * fullAssetName: the full path of the asset in DAM, e.g. "http://aplauthdev.corp.tcc.inet:4502/content/dam/amsterdam/Stockart/asset7.jpg"
     * fileName: a short file name, e.g. "asset1.jpg"
     * cachedFileName: the file name in the local HDD, e.g. "C:\wwwroot\DamService\Resources\20151201122523152.jpg", this file is only for temporary use, it will be deleted after being used
     */
    public class DamConnector
    {

        #region Public Varibles

        public static readonly string SavedArtSamllThumbnailSuffix160 = "/jcr:content/renditions/cq5dam.thumbnail.cropped.160.160.png";
        public static readonly string SavedArtLargeThumbnailSuffix319 = "/jcr:content/renditions/cq5dam.thumbnail.cropped.319.319.png";
        public static readonly string SavedArtSamllThumbnailProperty160 = "jcr:content/renditions/cq5dam.thumbnail.cropped.160.160.png/jcr:content/jcr:mimeType";
        public static readonly string SavedArtLargeThumbnailProperty319 = "jcr:content/renditions/cq5dam.thumbnail.cropped.319.319.png/jcr:content/jcr:mimeType";
        public static readonly string SavedArtThumbnailValue = "image/png";
        public static readonly string SavedArtLargeThumbnailProperty1280 = "jcr:content/renditions/cq5dam.web.1280.1280.png/jcr:content/jcr:mimeType";
        public static readonly string SavedArtLargeThumbnailSuffix1280 = "/jcr:content/renditions/cq5dam.web.1280.1280.png";

        #endregion

        #region Private Constants
        private const int MinRefId = 5;
        private const int MaxRefId = 40000;
        #endregion

        #region Private Varibles

        private static DamConnector _instance;
        private static readonly object Lock = new object();
        private readonly string _cqAuthorAddress;
        private readonly string _assetsCacheFolder;

        //DAM pathes by image types
        private readonly string _imageTypeStockartPath;
        private readonly string _imageTypeTemplatePath;
        private readonly string _imageTypeCustomerArtWorkPath;
        private readonly string _imageTypePersonalizationfilePath;
        private readonly string _imageTypeCustomersuppliedstockartPath;
        private readonly string _imageTypeStaticArtworkPath;

        //DAM pathes by artwork type
        private readonly string _artworkTypeCustomerCleanedLogoPath;
        private readonly string _artworkTypeProofPath;
        private readonly string _artworkTypeWorkFilePath;
        private readonly string _artworkTypeProductionArtWorkPath;
        private readonly string _artworkTypeCustomerSuppliedLogoPath;
        private readonly string _artworkTypeWebPreviewPath;
        private readonly string _artworkTypeCustomerSuppliedWebEditedPath;

        //DAM pathes by customerSuppliedStockart type
        private readonly string _customerSuppliedStockartTypeWebPreview;
        private readonly string _customerSuppliedStockartTypeProductionArtwork;

        //DAM pathes by stockart type
        private readonly string _stockartTypeDigitalBackgroundPath;
        private readonly string _stockartTypeAdArtPath;
        private readonly string _stockartTypeDateArtPath;
        private readonly string _stockartTypeSloganPath;
        private readonly string _stockartTypeVersePath;

        //DAM pathes by staticArtwork type
        private readonly string _staticArtworkTypeProductionArtwork;

        //DAM pathes by template type
        private readonly string _templateTypeGridPath;
        private readonly string _templateTypeSinglePath;
        private readonly string _templateTypeXeikonPath;
        private readonly string _templateTypePimPath;
        private readonly string _templateTypeThayer;

        //credential for accessing to DAM
        private readonly NetworkCredential _credential;

        private const string MetadataSuffix = "/_jcr_content/metadata.json";
        private const string TypeHintSuffix = "@TypeHint";
        private const string MetadataPath = "/jcr:content/metadata";

        private readonly string[] _versionKeyWords = { "\"jcr:baseVersion\"", "\"jcr:versionHistory\"" };


        private const int RequestTimeout = 1800000;
        #endregion

        #region Private Constants
        private const string folderCreationServelet = @"/bin/ingestion.html?assetPath={0}";
        #endregion

        public DamConnector(ConnectionType conType = ConnectionType.Dev)
        {
            var conTypeStr = Enum.GetName(conType.GetType(), conType);
            //get web.config settings
            var cqCredentialUserName = ConfigurationManager.AppSettings[$"Cq.Credential.{conTypeStr}.UserName"];
            var cqCredentialPassword = ConfigurationManager.AppSettings[$"Cq.Credential.{conTypeStr}.Password"];
            _cqAuthorAddress = ConfigurationManager.AppSettings[$"Cq.Author.{conTypeStr}.Address"];


            _assetsCacheFolder = ConfigurationManager.AppSettings["AssetsCacheFolder"];

            //pathes defined by image type
            _imageTypeStockartPath = ConfigurationManager.AppSettings["ImageType.Stockart"];
            _imageTypeTemplatePath = ConfigurationManager.AppSettings["ImageType.Template"];
            _imageTypeCustomerArtWorkPath = ConfigurationManager.AppSettings["ImageType.CustomerArtWork"];
            _imageTypePersonalizationfilePath = ConfigurationManager.AppSettings["ImageType.Personalizationfile"];
            _imageTypeCustomersuppliedstockartPath = ConfigurationManager.AppSettings["ImageType.Customersuppliedstockart"];
            _imageTypeStaticArtworkPath = ConfigurationManager.AppSettings["ImageType.StaticArtwork"];

            //pathes defined by artwork type
            _artworkTypeCustomerCleanedLogoPath = ConfigurationManager.AppSettings["CustomerArtworkType.CustomerCleanedLogo"];
            _artworkTypeProofPath = ConfigurationManager.AppSettings["CustomerArtworkType.Proof"];
            _artworkTypeWorkFilePath = ConfigurationManager.AppSettings["CustomerArtworkType.WorkFile"];
            _artworkTypeProductionArtWorkPath = ConfigurationManager.AppSettings["CustomerArtworkType.ProductionArtWork"];
            _artworkTypeCustomerSuppliedLogoPath = ConfigurationManager.AppSettings["CustomerArtworkType.CustomerSuppliedLogo"];
            _artworkTypeWebPreviewPath = ConfigurationManager.AppSettings["CustomerArtworkType.WebPreview"];
            _artworkTypeCustomerSuppliedWebEditedPath = ConfigurationManager.AppSettings["CustomerArtworkType.CustomerSuppliedWebEdited"];

            //pathes defined by customerSuppliedStockart type
            _customerSuppliedStockartTypeWebPreview = ConfigurationManager.AppSettings["CustomerSuppliedStockartType.WebPreview"];
            _customerSuppliedStockartTypeProductionArtwork = ConfigurationManager.AppSettings["CustomerSuppliedStockartType.ProductionArtwork"];

            //pathes defined by stockart type
            _stockartTypeDigitalBackgroundPath = ConfigurationManager.AppSettings["StockartType.DigitalBackground"];
            _stockartTypeAdArtPath = ConfigurationManager.AppSettings["StockartType.AdArt"];
            _stockartTypeDateArtPath = ConfigurationManager.AppSettings["StockartType.DateArt"];
            _stockartTypeSloganPath = ConfigurationManager.AppSettings["StockartType.Slogan"];
            _stockartTypeVersePath = ConfigurationManager.AppSettings["StockartType.Verse"];

            //pathes defined by staticArtwork type
            _staticArtworkTypeProductionArtwork = ConfigurationManager.AppSettings["staticArtworkType.ProductionArtwork"];

            //pathes defined by template type
            _templateTypeGridPath = ConfigurationManager.AppSettings["TemplateType.Grid"];
            _templateTypeSinglePath = ConfigurationManager.AppSettings["TemplateType.Single"];
            _templateTypeXeikonPath = ConfigurationManager.AppSettings["TemplateType.Xeikon"];
            _templateTypePimPath = ConfigurationManager.AppSettings["TemplateType.Pim"];
            _templateTypeThayer = ConfigurationManager.AppSettings["TemplateType.Thayer"];

            //initialize the network credential object
            _credential = new NetworkCredential(cqCredentialUserName, cqCredentialPassword);
        }

        #region Public Methods
        public bool UploadFile2(string localFullFileName, MetaData metadata, string assetName = null)
        {
            try
            {
                var uploadResult = false;
                var assetLocation = GetAssetLocation(metadata);
                if (metadata.customerArtworkType == customerArtworkType.WebPreview ||
                    metadata.customerArtworkType == customerArtworkType.ProductionArtWork)
                {//shared
                    assetLocation += GetVendorSubFolder(metadata.vendorStudioId);
                }
                else if (metadata.customerArtworkType == customerArtworkType.CustomerCleanedLogo)
                {//saved
                    assetLocation += GetCustomerArtworkSubFolder(metadata.customerNumber, metadata.imprintFormat);
                }
                if (assetName == null)
                {
                    assetName = Path.GetFileName(localFullFileName);
                }
                assetName = assetLocation + assetName;
                if (!string.IsNullOrEmpty(assetName))
                {
                    //get asset folder name, e.g. "/content/dam/amsterdam/pre-press/customer-supplied-logos"
                    var assetFolderName = Path.GetDirectoryName(assetName);

                    if (!string.IsNullOrEmpty(assetFolderName))
                    {
                        assetFolderName = assetFolderName.Replace("\\", "/");

                        //create the folder in DAM
                        var ret = CreateFolder(assetFolderName, string.Empty);
                        if (!ret)
                        {
                            Exception ex = new Exception(string.Format("Could Not Create Folder '{0}' In AEM.", assetFolderName));
                            throw ex;
                        }
                    }

                    //the post data list
                    //we need 3 steps to complete the uploading process
                    //step1: create the asset node in DAM with PUT method
                    //step2: post the file content to the sub-node "/jcr:content/renditions" with "POST" method
                    //step3: post the metadata for the asset to the DAM
                    var postDataList = new List<PostData>
                    {
                        new PostData//for step 1
                        {

                            Method = HttpVerbs.Put,
                            RelativeUrl = assetName,

                            Parameters = new List<Parameter>
                            {
                                new Parameter
                                {
                                    Name = "jcr:primaryType",
                                    Value = "dam:Asset",
                                    IsFile = false
                                }
                            }
                        },
                        new PostData//for step 2
                        {
                            Method = HttpVerbs.Post,
                            RelativeUrl = assetName + "/jcr:content/renditions",

                            Parameters = new List<Parameter>
                            {
                                new Parameter
                                {
                                    Name = "original",
                                    Value = localFullFileName,
                                    IsFile = true
                                }
                            }
                        },
                        new PostData//for step 3
                        {
                            Method = HttpVerbs.Post,
                            RelativeUrl = assetName + "/jcr:content/renditions",

                            Parameters = new List<Parameter>
                                         {
                                             new Parameter
                                             {
                                                 Name = "cq5dam.thumbnail.cropped.160.160.png",
                                                 Value = localFullFileName,
                                                 IsFile = true
                                             }
                                         }
                        },
                        new PostData//for step 4
                        {
                            Method = HttpVerbs.Post,
                            RelativeUrl = assetName + "/jcr:content/renditions",

                            Parameters = new List<Parameter>
                                         {
                                             new Parameter
                                             {
                                                 Name = "cq5dam.thumbnail.cropped.319.319.png",
                                                 Value = localFullFileName,
                                                 IsFile = true
                                             }
                                         }
                        }
                    };

                    uploadResult = postDataList.Count > 0;
                    uploadResult = postDataList.Select(Post).Aggregate(uploadResult, (current, postResult) => current & postResult);
                    uploadResult &= PostMetadata(assetName, metadata);//for step 3
                }
                return uploadResult;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public bool UploadFile3(string localFullFileName, MetaData metadata, string assetName)
        {
            try
            {
                var uploadResult = false;

                if (!string.IsNullOrEmpty(assetName))
                {
                    //get asset folder name, e.g. "/content/dam/amsterdam/pre-press/customer-supplied-logos"
                    var assetFolderName = Path.GetDirectoryName(assetName);

                    if (!string.IsNullOrEmpty(assetFolderName))
                    {
                        assetFolderName = assetFolderName.Replace("\\", "/");

                        //create the folder in DAM
                        var ret = CreateFolder(assetFolderName, string.Empty);
                        if (!ret)
                        {
                            Exception ex = new Exception(string.Format("Could Not Create Folder '{0}' In AEM.", assetFolderName));
                            throw ex;
                        }
                    }

                    //the post data list
                    //we need 3 steps to complete the uploading process
                    //step1: create the asset node in DAM with PUT method
                    //step2: post the file content to the sub-node "/jcr:content/renditions" with "POST" method
                    //step3: post the metadata for the asset to the DAM
                    var postDataList = new List<PostData>
                    {
                        new PostData//for step 1
                        {

                            Method = HttpVerbs.Put,
                            RelativeUrl = assetName,

                            Parameters = new List<Parameter>
                            {
                                new Parameter
                                {
                                    Name = "jcr:primaryType",
                                    Value = "dam:Asset",
                                    IsFile = false
                                }
                            }
                        },
                        new PostData//for step 2
                        {
                            Method = HttpVerbs.Post,
                            RelativeUrl = assetName + "/jcr:content/renditions",

                            Parameters = new List<Parameter>
                            {
                                new Parameter
                                {
                                    Name = "original",
                                    Value = localFullFileName,
                                    IsFile = true
                                }
                            }
                        }
                    };

                    uploadResult = postDataList.Count > 0;
                    uploadResult = postDataList.Select(Post).Aggregate(uploadResult, (current, postResult) => current & postResult);
                    uploadResult &= PostMetadata(assetName, metadata);//for step 3
                }
                return uploadResult;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool UploadFileForDigitalBackground(string localFullFileName, MetaData metadata, string assetName = null)
        {
            try
            {
                if (string.IsNullOrEmpty(metadata.refId))
                {
                    return false;
                }

                var uploadResult = false;
                var assetLocation = GetAssetLocation(metadata);
                if (metadata.stockArtType == stockArtType.DigitalBackground)
                {
                    var filename = Path.GetFileNameWithoutExtension(metadata.refId);
                    var subFolder = string.Join("/",
                                                filename.ToCharArray()
                                                        .Select(x => x.ToString()))
                                    + @"/";
                    assetLocation += subFolder;
                }
                if (assetName == null)
                {
                    assetName = metadata.refId + Path.GetExtension(localFullFileName);
                }
                assetName = assetLocation + assetName;
                if (!string.IsNullOrEmpty(assetName))
                {
                    //get asset folder name, e.g. "/content/dam/amsterdam/pre-press/customer-supplied-logos"
                    var assetFolderName = Path.GetDirectoryName(assetName);

                    if (!string.IsNullOrEmpty(assetFolderName))
                    {
                        assetFolderName = assetFolderName.Replace("\\", "/");

                        //create the folder in DAM
                        var ret = CreateFolder(assetFolderName, string.Empty);
                        if (!ret)
                        {
                            Exception ex = new Exception(string.Format("Could Not Create Folder '{0}' In AEM.", assetFolderName));
                            throw ex;
                        }
                    }

                    //the post data list
                    //we need 3 steps to complete the uploading process
                    //step1: create the asset node in DAM with PUT method
                    //step2: post the file content to the sub-node "/jcr:content/renditions" with "POST" method
                    //step3: post the metadata for the asset to the DAM
                    var postDataList = new List<PostData>
                    {
                        new PostData//for step 1
                        {

                            Method = HttpVerbs.Put,
                            RelativeUrl = assetName,

                            Parameters = new List<Parameter>
                            {
                                new Parameter
                                {
                                    Name = "jcr:primaryType",
                                    Value = "dam:Asset",
                                    IsFile = false
                                }
                            }
                        },
                        new PostData//for step 2
                        {
                            Method = HttpVerbs.Post,
                            RelativeUrl = assetName + "/jcr:content/renditions",

                            Parameters = new List<Parameter>
                            {
                                new Parameter
                                {
                                    Name = "original",
                                    Value = localFullFileName,
                                    IsFile = true
                                }
                            }
                        },
                        //new PostData//for step cq5dam.web.1280.1280.jpeg
                        //{
                        //    Method = HttpVerbs.Post,
                        //    RelativeUrl = assetName + "/jcr:content/renditions",

                        //    Parameters = new List<Parameter>
                        //                 {
                        //                     new Parameter
                        //                     {
                        //                         Name = "cq5dam.web.1280.1280.jpeg",
                        //                         Value = localFullFileName,
                        //                         IsFile = true
                        //                     }
                        //                 }
                        //},
                        //new PostData//for step 3
                        //{
                        //    Method = HttpVerbs.Post,
                        //    RelativeUrl = assetName + "/jcr:content/renditions",

                        //    Parameters = new List<Parameter>
                        //                 {
                        //                     new Parameter
                        //                     {
                        //                         Name = "cq5dam.thumbnail.cropped.160.160.png",
                        //                         Value = localFullFileName,
                        //                         IsFile = true
                        //                     }
                        //                 }
                        //},
                        //new PostData//for cq5dam.thumbnail.cropped.319.319.png
                        //{
                        //    Method = HttpVerbs.Post,
                        //    RelativeUrl = assetName + "/jcr:content/renditions",

                        //    Parameters = new List<Parameter>
                        //                 {
                        //                     new Parameter
                        //                     {
                        //                         Name = "cq5dam.thumbnail.cropped.319.319.png",
                        //                         Value = localFullFileName,
                        //                         IsFile = true
                        //                     }
                        //                 }
                        //},
                        //new PostData//for cq5dam.thumbnail.cropped.160.160.png
                        //{
                        //    Method = HttpVerbs.Post,
                        //    RelativeUrl = assetName + "/jcr:content/renditions",

                        //    Parameters = new List<Parameter>
                        //                 {
                        //                     new Parameter
                        //                     {
                        //                         Name = "cq5dam.thumbnail.cropped.160.160.png",
                        //                         Value = localFullFileName,
                        //                         IsFile = true
                        //                     }
                        //                 }
                        //},
                        //new PostData//for cq5dam.thumbnail.cropped.1500.1500.png
                        //{
                        //    Method = HttpVerbs.Post,
                        //    RelativeUrl = assetName + "/jcr:content/renditions",

                        //    Parameters = new List<Parameter>
                        //                 {
                        //                     new Parameter
                        //                     {
                        //                         Name = "cq5dam.thumbnail.cropped.1500.1500.png",
                        //                         Value = localFullFileName,
                        //                         IsFile = true
                        //                     }
                        //                 }
                        //},
                        //new PostData//for cq5dam.thumbnail.319.319.png
                        //{
                        //    Method = HttpVerbs.Post,
                        //    RelativeUrl = assetName + "/jcr:content/renditions",

                        //    Parameters = new List<Parameter>
                        //                 {
                        //                     new Parameter
                        //                     {
                        //                         Name = "cq5dam.thumbnail.319.319.png",
                        //                         Value = localFullFileName,
                        //                         IsFile = true
                        //                     }
                        //                 }
                        //},
                        //new PostData//for cq5dam.thumbnail.160.160.png
                        //{
                        //    Method = HttpVerbs.Post,
                        //    RelativeUrl = assetName + "/jcr:content/renditions",

                        //    Parameters = new List<Parameter>
                        //                 {
                        //                     new Parameter
                        //                     {
                        //                         Name = "cq5dam.thumbnail.160.160.png",
                        //                         Value = localFullFileName,
                        //                         IsFile = true
                        //                     }
                        //                 }
                        //},
                        //new PostData//for cq5dam.thumbnail.1500.1500.png
                        //{
                        //    Method = HttpVerbs.Post,
                        //    RelativeUrl = assetName + "/jcr:content/renditions",

                        //    Parameters = new List<Parameter>
                        //                 {
                        //                     new Parameter
                        //                     {
                        //                         Name = "cq5dam.thumbnail.1500.1500.png",
                        //                         Value = localFullFileName,
                        //                         IsFile = true
                        //                     }
                        //                 }
                        //}
                    };


                    uploadResult = postDataList.Count > 0;
                    uploadResult = postDataList.Select(Post).Aggregate(uploadResult, (current, postResult) => current & postResult);
                    uploadResult &= PostMetadata(assetName, metadata);//for step 3
                }
                return uploadResult;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// get asset by asset name
        /// </summary>
        /// <param name="assetPath">asset path</param>
        /// <returns>asset file byte array</returns>
        public byte[] GetAsset(string assetPath)
        {
            try
            {
                //get the full asset name
                var fullAssetName = _cqAuthorAddress + assetPath;
                if (CheckUrlStatus(fullAssetName))
                {
                    using (var wc = new WebClient())
                    {
                        wc.Credentials = _credential;
                        //get the asset byte data
                        return wc.DownloadData(fullAssetName);
                    }
                }
                else
                {
                    Exception ex = new Exception(string.Format("Asset '{0}' was not found in AEM.", fullAssetName));
                    throw ex;
                }
            }
            catch (WebException we)
            {
                // if it's a not-found exception, then supress the exception, or throw the exception
                if (((HttpWebResponse)we.Response)?.StatusCode != HttpStatusCode.NotFound)
                {
                    throw;
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return null;
        }

        /// <summary>
        /// get asset by metadata
        /// </summary>
        /// <param name="metadata">metadata object</param>
        /// <returns>asset file byte array</returns>
        public byte[] GetAsset(MetaData metadata)
        {
            try
            {
                //get asset name by metadata
                var assetName = GetAssetPathByMetadata(metadata);
                if (!string.IsNullOrEmpty(assetName))
                {
                    //get asset file byte by asset name
                    return GetAsset(assetName);
                }
                return null;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// post asset to DAM
        /// </summary>
        /// <param name="fileName">the file name that will be used as the node name in DAM</param>
        /// <param name="fileStream">file byte array that will be posted to DAM</param>
        /// <param name="metadata">the metadata object for the asset</param>
        /// <returns></returns>
        public bool PostAsset(string fileName, byte[] fileStream, MetaData metadata)
        {
            var isValid = MetaDataValidation(metadata);
            var result = false;
            if (!isValid)
            {
                throw new Exception("Required meta-data is mismatching.");
            }
            var assetLocation = GetAssetLocation(metadata);
            if (string.IsNullOrEmpty(assetLocation))
            {
                return false;
            }

            #region append sub-folders
            //not to apply the sub directory logic to PIM templates
            if (metadata.imageType == imageType.Template && metadata.templateType != templateType.Pim)
            {
                //if it's template, append sub directory to the asset location string
                var subDirectory = GetTemplateSubDirectory(fileName);
                assetLocation += subDirectory;
            }
            else if (metadata.imageType == imageType.CustomerArtWork)
            {
                //if it's customerArtWork, append sub directory to the asset location string
                assetLocation += GetCustomerArtworkSubFolder(metadata.customerNumber, metadata.imprintFormat);
            }
            else if (metadata.imageType == imageType.StaticArtwork)
            {
                var subDirectory = GetStaticArtworkDirectory(metadata.imprintFormat);
                assetLocation += subDirectory;
            }
            else if (metadata.imageType == imageType.StockArt)
            {
                if (metadata.stockArtType == stockArtType.AdArt)
                {
                    var subDirectory = GetAddArtDirectory(metadata.refId);
                    assetLocation += subDirectory;
                }
                else if (metadata.stockArtType == stockArtType.Verse)
                {
                    var subDirectory = GetVerseDirectory(metadata.verseId);
                    assetLocation += subDirectory;
                }
            }
            else if (metadata.imageType == imageType.CustomerSuppliedStockArt)
            {
                var subDirectory = GetVendorSubFolder(metadata.vendorStudioId);
                assetLocation += subDirectory;
            }
            #endregion
            //get the asset name
            var assetName = assetLocation + fileName;

            var cachedFileName = string.Empty;
            try
            {
                //save the file to the cache folder and get the cached file name
                var extension = Path.GetExtension(assetName);
                if (SaveBytesToFile(fileStream, extension, out cachedFileName))
                {
                    //upload the file to DAM
                    result = UploadFile(cachedFileName, assetName, metadata);
                    var fullAssetName = _cqAuthorAddress + assetName;

                    if (!CheckUrlStatus(fullAssetName))
                    {
                        Exception ex = new Exception(string.Format("Asset '{0}' was not found in AEM.", fullAssetName));
                        throw ex;
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                //delete the cached file
                if (File.Exists(cachedFileName))
                {
                    File.Delete(cachedFileName);
                }
            }
            return result;
        }
        public bool PostAsset(byte[] fileStream, string assetName, MetaData metadata)
        {

            var result = false;
            var cachedFileName = string.Empty;
            try
            {
                //save the file to the cache folder and get the cached file name
                var extension = Path.GetExtension(assetName);
                if (SaveBytesToFile(fileStream, extension, out cachedFileName))
                {
                    //upload the file to DAM
                    result = UploadFile(cachedFileName, assetName, metadata);
                    var fullAssetName = _cqAuthorAddress + assetName;

                    if (!CheckUrlStatus(fullAssetName))
                    {
                        Exception ex = new Exception(string.Format("Asset '{0}' was not found in AEM.", fullAssetName));
                        throw ex;
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                //delete the cached file
                if (File.Exists(cachedFileName))
                {
                    File.Delete(cachedFileName);
                }
            }
            return result;
        }

        /// <summary>
        /// get metadata by asset name
        /// </summary>
        /// <param name="assetPath">asset path</param>
        /// <returns>metadata object</returns>
        public MetaData GetMetadataByAssetPath(string assetPath)
        {
            try
            {
                //assetMetadata: /content/dam/amsterdam/customer-supplied-logos/08/05/73/07/Microsoft.jpg/_jcr_content/metadata.json
                var assetMetadata = assetPath + MetadataSuffix;
                var metadataFullPath = _cqAuthorAddress + assetMetadata;
                //remove hyphens from meta-data
                var metadataJsonStr = GetResponseString(metadataFullPath);
                metadataJsonStr = metadataJsonStr.Replace("\"customer-art-work\"", "\"CustomerArtWork\"");
                metadataJsonStr = metadataJsonStr.Replace("\"personalization-file\"", "\"PersonalizationFile\"");
                metadataJsonStr = metadataJsonStr.Replace("\"customer-supplied-stock-art\"", "\"CustomerSuppliedStockArt\"");
                metadataJsonStr = metadataJsonStr.Replace("\"stock-art\"", "\"StockArt\"");
                metadataJsonStr = metadataJsonStr.Replace("\"customer-supplied-logo\"", "\"CustomerSuppliedLogo\"");
                metadataJsonStr = metadataJsonStr.Replace("\"customer-supplied-logo-web-edited\"", "\"CustomerSuppliedLogoWebEdited\"");
                metadataJsonStr = metadataJsonStr.Replace("\"web-preview\"", "\"WebPreview\"");
                metadataJsonStr = metadataJsonStr.Replace("\"customer-cleaned-logo\"", "\"CustomerCleanedLogo\"");
                metadataJsonStr = metadataJsonStr.Replace("\"work-file\"", "\"WorkFile\"");
                metadataJsonStr = metadataJsonStr.Replace("\"production-artwork\"", "\"ProductionArtwork\"");
                metadataJsonStr = metadataJsonStr.Replace("\"production-art-work\"", "\"ProductionArtWork\"");
                metadataJsonStr = metadataJsonStr.Replace("\"digital-background\"", "\"DigitalBackground\"");
                metadataJsonStr = metadataJsonStr.Replace("\"ad-art\"", "\"AdArt\"");
                metadataJsonStr = metadataJsonStr.Replace("\"date-art\"", "\"DateArt\"");
                metadataJsonStr = metadataJsonStr.Replace("\"multiple-color\"", "\"MultipleColor\"");
                metadataJsonStr = metadataJsonStr.Replace("\"single-color\"", "\"SingleColor\"");
                metadataJsonStr = metadataJsonStr.Replace("\"proof\"", "\"Proof\"");
                //get the metadata json string
                var jss = new JavaScriptSerializer();
                //register a custom converter
                jss.RegisterConverters(new JavaScriptConverter[] { new MetaDataConverter() });
                //convert the metadata json string to metadata object
                var metadata = jss.Deserialize<MetaData>(metadataJsonStr);
                return metadata;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// post the metadata to DAM
        /// </summary>
        /// <param name="assetName">asset name</param>
        /// <param name="metadata">metadata object</param>
        /// <returns>post result</returns>
        public bool PostMetadata(string assetName, MetaData metadata)
        {
            try
            {
                //get the post data by asset name and metadata object
                var postData = GeneratePostDataByMetadata(assetName, metadata);
                //post to DAM
                return Post(postData);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public List<MetaData> GetArtworkMetaDataListAdvance(MetaData meta)
        {
            var searchHierarchy = new List<MetaData>
                                  {
                                          new MetaData// search #1
                                          {
                                              imageType = imageType.CustomerSuppliedStockArt,
                                              customerArtworkType = customerArtworkType.WebPreview,
                                              vendorStudioId = meta.vendorStudioId,
                                              itemIds = meta.itemIds,
                                              colorSpace = meta.colorSpace
                                          },
                                          new MetaData// search #2
                                          {
                                              imageType = imageType.CustomerSuppliedStockArt,
                                              customerArtworkType = customerArtworkType.WebPreview,
                                              vendorStudioId = meta.vendorStudioId,
                                              itemIds = meta.itemIds
                                          },
                                          new MetaData// search #3
                                          {
                                              imageType = imageType.CustomerSuppliedStockArt,
                                              customerArtworkType = customerArtworkType.WebPreview,
                                              vendorStudioId = meta.vendorStudioId,
                                              processIds = meta.processIds,
                                              colorSpace = meta.colorSpace
                                          },
                                      new MetaData// search #4
                                      {
                                          imageType = imageType.CustomerSuppliedStockArt,
                                          customerArtworkType = customerArtworkType.WebPreview,
                                          vendorStudioId = meta.vendorStudioId,
                                          processIds = meta.processIds
                                      }
                                  };

            var hits = SearchAssetBySearchHierarchy(searchHierarchy);

            if (hits.Count > 0)
            {
                //get asset names
                var assetNames = hits.Select(hit => GetAssetNameByPath(hit.Path)).ToList();
                var returnedMetaDataLst = assetNames.Select(GetMetadataByAssetPath).ToList();
                return returnedMetaDataLst;
            }
            return null;
        }

        public List<MetaData> GetArtworkMetaDataList(MetaData meta)
        {
            var searchHierarchy = new List<MetaData>
            {
                new MetaData// search #1
                {
                    imageType = imageType.CustomerSuppliedStockArt,
                    customerArtworkType = customerArtworkType.WebPreview,
                    vendorStudioId = meta.vendorStudioId,
                    itemIds = meta.itemIds,
                    colorSpace = meta.colorSpace
                },
                new MetaData// search #2
                {
                    imageType = imageType.CustomerSuppliedStockArt,
                    customerArtworkType = customerArtworkType.WebPreview,
                    vendorStudioId = meta.vendorStudioId,
                    itemIds = meta.itemIds
                },
                new MetaData// search #3
                {
                    imageType = imageType.CustomerSuppliedStockArt,
                    customerArtworkType = customerArtworkType.WebPreview,
                    vendorStudioId = meta.vendorStudioId,
                    processIds = meta.processIds,
                    colorSpace = meta.colorSpace
                },
                new MetaData// search #4
                {
                    imageType = imageType.CustomerSuppliedStockArt,
                    customerArtworkType = customerArtworkType.WebPreview,
                    vendorStudioId = meta.vendorStudioId,
                    processIds = meta.processIds
                }
            };
            var hits = SearchAssetBySearchHierarchy(searchHierarchy);

            if (hits.Count > 0)
            {
                //get asset names
                var assetNames = hits.Select(hit => GetAssetNameByPath(hit.Path)).ToList();
                var returnedMetaDataLst = assetNames.Select(GetMetadataByAssetPath).ToList();
                return returnedMetaDataLst;
            }
            return null;
        }

        public List<MetaData> GetSavedArtThumbnails(MetaData meta)
        {
            var hits = GetSavedArtHits(meta, false);

            if (hits.Count > 0)
            {
                //get asset names
                var assetNames = hits.Select(hit => GetAssetNameByPath(hit.Path)).ToList();
                var returnedMetaDataLst = assetNames.Select(GetMetadataByAssetPath).ToList();
                var idx = 0;
                foreach (var assetName in assetNames)
                {
                    var largeThumbnailExist =
                        CheckUrlStatus(_cqAuthorAddress + assetName + SavedArtLargeThumbnailSuffix319);
                    if (largeThumbnailExist)
                    {
                        var smallThumbnail = GetAsset(assetName + SavedArtSamllThumbnailSuffix160);
                        returnedMetaDataLst[idx].fileBytes = smallThumbnail;
                    }
                    returnedMetaDataLst[idx].assetPath = assetName;
                    idx++;
                }
                returnedMetaDataLst.RemoveAll(m => m.fileBytes == null);
                return returnedMetaDataLst;
            }
            return null;
        }

        public List<MetaData> GetSavedArtThumbnailsByPage(MetaData meta, int pageIndex, int pageSize)
        {
            var hits = GetSavedArtHits(meta, pageIndex, pageSize);

            if (hits.Count > 0)
            {
                //get asset names
                var assetNames = hits.Select(hit => GetAssetNameByPath(hit.Path)).ToList();
                var returnedMetaDataLst = assetNames.Select(GetMetadataByAssetPath).ToList();
                var idx = 0;
                foreach (var assetName in assetNames)
                {
                    try
                    {
                        var smallThumbnail = GetAsset(assetName + SavedArtSamllThumbnailSuffix160);
                        returnedMetaDataLst[idx].fileBytes = smallThumbnail;
                        returnedMetaDataLst[idx].assetPath = assetName;
                    }
                    catch
                    {
                        returnedMetaDataLst[idx].fileBytes = null;
                    }
                    idx++;
                }
                returnedMetaDataLst.RemoveAll(m => m.fileBytes == null);
                return returnedMetaDataLst;
            }
            return null;
        }

        public int GetSavedArtCount(MetaData meta)
        {
            var hits = GetSavedArtHits(meta);
            return hits.Count;
        }

        public MetaData GetSavedArtThumbnail(string assetPath)
        {
            try
            {
                var meta = GetMetadataByAssetPath(assetPath);
                meta.fileBytes = GetAsset(assetPath + SavedArtLargeThumbnailSuffix319);
                meta.assetPath = assetPath;
                return meta;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        /// <summary>
        /// search artwork files
        /// </summary>
        /// <param name="meta">metadata used for searching</param>
        /// <returns>filenames without extension</returns>
        public List<string> SearchArtworkFiles(MetaData meta)
        {
            var metaDataList = GetArtworkMetaDataList(meta);
            if (metaDataList != null && metaDataList.Count > 0)
            {
                var fileNamesWithNoExtension = metaDataList.Select(m => m.filenameNoExtension).ToList();
                return fileNamesWithNoExtension;
            }
            return null;
        }

        public string GetOriginalFileName(MetaData meta)
        {
            if (string.IsNullOrEmpty(meta.vendorStudioId) || string.IsNullOrEmpty(meta.filenameNoExtension))
            {
                return string.Empty;
            }
            var m = new MetaData
            {
                imageType = imageType.CustomerSuppliedStockArt,
                customerArtworkType = customerArtworkType.WebPreview,
                vendorStudioId = meta.vendorStudioId,
                filenameNoExtension = meta.filenameNoExtension
            };
            var hits = SearchByMetadata(m);
            if (hits.Count > 0)
            {
                var hit = hits[0];
                var assetName = GetAssetNameByPath(hit.Path);
                var returnedMetaData = GetMetadataByAssetPath(assetName);
                return returnedMetaData.originalFilename;
            }
            return string.Empty;
        }

        public List<string> GetAssetList(MetaData metadata)
        {
            try
            {
                var hits = SearchByMetadata(metadata);
                if (hits != null && hits.Count > 0)
                {
                    var assetPathList = new List<string>();
                    foreach (var hit in hits)
                    {
                        //if it's a metadata node
                        if (hit.Path.EndsWith(MetadataPath))
                        {
                            //get asset name
                            var assetName = hit.Path.Substring(0, hit.Path.Length - 21);
                            assetPathList.Add(assetName);
                        }
                        else
                        {
                            assetPathList.Add(hit.Path);
                        }
                    }
                    return assetPathList;
                }
                return null;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public float GetCurrentVersionNumber(MetaData meta)
        {
            var isValid = MetaDataValidation(meta);
            if (!isValid)
            {
                throw new Exception("Required meta-data is mismatching.");
            }
            try
            {
                var assetPath = GetAssetPathByMetadata(meta);
                var versionValues = GetVersionValuesByAssetPath(assetPath);
                var baseVersion = versionValues[_versionKeyWords[0]].ToString();
                var simpleProperty = GetMostRecentVersionAssetSimpleProperty(baseVersion);
                if (simpleProperty != null)
                {
                    float currentVersionNumber;
                    var success = float.TryParse(simpleProperty.Name, out currentVersionNumber);
                    if (success)
                    {
                        return currentVersionNumber;
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return -1;
        }

        public byte[] GetAssetsByVersionNumber(MetaData meta, string versionNumber = null)
        {
            var isValid = MetaDataValidation(meta);
            if (!isValid)
            {
                throw new Exception("Required meta-data is mismatching.");
            }
            try
            {
                var assetPath = GetAssetPathByMetadata(meta);
                if (!string.IsNullOrEmpty(assetPath))
                {
                    var versionValues = GetVersionValuesByAssetPath(assetPath);
                    string oldAssetPath;
                    if (string.IsNullOrEmpty(versionNumber))
                    {
                        var baseVersion = versionValues[_versionKeyWords[0]].ToString();
                        var simpleProperty = GetMostRecentVersionAssetSimpleProperty(baseVersion);
                        oldAssetPath = simpleProperty.Path;
                        oldAssetPath = GetOldVersionAssetPath(oldAssetPath);
                    }
                    else
                    {
                        var historyVersion = versionValues[_versionKeyWords[1]].ToString();
                        oldAssetPath = GetHitoryPath(historyVersion);
                        oldAssetPath = GetOldVersionAssetPath(oldAssetPath, versionNumber);
                    }
                    if (!string.IsNullOrEmpty(oldAssetPath))
                    {
                        return GetAsset(oldAssetPath);
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return null;
        }
        public FileData GetThumbnail(MetaData meta)
        {
            FileData fileData = null;
            try
            {

                var assetPath = GetAssetPathByMetadata(meta);

                if (!string.IsNullOrEmpty(assetPath))
                {
                    fileData = new FileData();
                    assetPath += SavedArtLargeThumbnailSuffix319;
                    fileData.FileExt = "png";
                    fileData.FileStream = GetAsset(assetPath);
                }
            }
            catch (Exception e)
            {
                throw;

            }
            return fileData;
        }
        public void ToUpperMetaData(MetaData metadata)
        {
            if (metadata == null)
            {
                return;
            }
            //get metadata object
            var type = metadata.GetType();
            //get all properties of the metadata object
            var properties = type.GetProperties();
            var toUpperPropertyInclusions = Constant.GetToUpperPropertyInclusions();
            //loop the metadata object
            foreach (var pi in properties)
            {
                string value;
                string name = pi.Name;
                if (!toUpperPropertyInclusions.Exists(p => p.Equals(name)))
                {
                    continue;
                }

                if (pi.PropertyType == typeof(string))//string-type property
                {
                    //get property value
                    var obj = pi.GetValue(metadata);
                    value = obj?.ToString().Trim() ?? string.Empty;

                    if (!string.IsNullOrEmpty(value))
                    {
                        value = "originalFilename".Equals(name) ? FormatFileName(value) : value.ToUpper();
                        pi.SetValue(metadata, value);
                    }
                }
                else if (pi.PropertyType == typeof(List<string>))//list-type property
                {
                    var list = (List<string>)pi.GetValue(metadata);
                    if (list != null)
                    {
                        var tmpList = new List<string>();
                        foreach (var item in list)
                        {
                            value = item;
                            if (!string.IsNullOrEmpty(value))
                            {
                                value = value.ToUpper();
                            }
                            tmpList.Add(value);
                        }
                        pi.SetValue(metadata, tmpList);
                    }
                }
            }
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// query DAM nodes by criterion
        /// </summary>
        /// <param name="criterion">query criterion</param>
        /// <returns>query results</returns>
        private QueryResult Query(IEnumerable<KeyValuePair<string, string>> criterion)
        {
            try
            {
                // get base query URL, e.g. http://aplauthdev.corp.tcc.inet:4502/bin/querybuilder.json?
                var baseQueryUrl = _cqAuthorAddress + "/bin/querybuilder.json?";
                var sbQueryUrl = new StringBuilder(baseQueryUrl);
                // append the criterion to the end of the base query URL
                foreach (var criteria in criterion)
                {
                    sbQueryUrl.Append(HttpUtility.UrlDecode(criteria.Key, Encoding.UTF8));
                    sbQueryUrl.Append("=");
                    var value = criteria.Value;
                    sbQueryUrl.Append(HttpUtility.UrlDecode(value, Encoding.UTF8));
                    sbQueryUrl.Append("&");
                }

                // get the response string(a JSON string) from DAM
                var responseStr = GetResponseString(sbQueryUrl.ToString());
                var jss = new JavaScriptSerializer();



                // convert the JSON string to a 'QueryResult' object
                var queryResult = jss.Deserialize<QueryResult>(responseStr);
                return queryResult;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// get response string
        /// </summary>
        /// <param name="requestUrl">request URL</param>
        /// <returns>the response string</returns>
        private string GetResponseString(string requestUrl)
        {
            try
            {
                var req = (HttpWebRequest)WebRequest.Create(requestUrl);
                req.Credentials = _credential;
                req.Method = "GET";
                req.KeepAlive = true;
                req.Timeout = RequestTimeout;
                var responseStr = string.Empty;
                using (var response = (HttpWebResponse)req.GetResponse())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                        {
                            using (var reader = new StreamReader(responseStream))
                            {
                                responseStr = reader.ReadToEnd();
                            }
                        }
                    }
                }
                return responseStr;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// save the byte array to a local file
        /// </summary>
        /// <param name="fileBytes">file bytes</param>
        /// <param name="extension">extension of the file</param>
        /// <param name="chachedFileName">the cached file name</param>
        /// <returns>result</returns>
        private bool SaveBytesToFile(byte[] fileBytes, string extension, out string chachedFileName)
        {
            try
            {
                //get the full cached file name
                chachedFileName = _assetsCacheFolder + "\\" +
                                  DateTime.Now.ToString("yyyyMMddhhmmssfffffff") + extension;
                //get the cached folder name
                var directoryName = Path.GetDirectoryName(chachedFileName);
                if (directoryName != null && !Directory.Exists(directoryName))
                {
                    Directory.CreateDirectory(directoryName);
                }
                //save file
                File.WriteAllBytes(chachedFileName, fileBytes);
                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// Post data to DAM
        /// </summary>
        /// <param name="postData">the post data</param>
        /// <returns></returns>
        private bool Post(PostData postData)
        {
            FileStream fileStream = null;
            try
            {
                var postResult = false;
                //post data boundary
                var boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
                //create web request
                var req = (HttpWebRequest)WebRequest.Create(_cqAuthorAddress + postData.RelativeUrl);
                //set credential
                req.Credentials = _credential;
                //set method
                req.Method = Enum.GetName(typeof(HttpVerbs), postData.Method);
                //set content type
                req.ContentType = "multipart/form-data; boundary=" + boundary;
                req.KeepAlive = true;
                req.Timeout = RequestTimeout;

                var sb = new StringBuilder();
                //generate the parameter list
                foreach (var p in postData.Parameters)
                {
                    sb.Append("--" + boundary);
                    sb.Append("\r\n");
                    if (p.IsFile)
                    {
                        //sb.Append("Content-Disposition: form-data; name=\"" + p.Name + "\"");
                        sb.Append("Content-Disposition: form-data; name=\"" + p.Name + "\"; filename=\"" +
                                  p.Value + "\"");
                        sb.Append("\r\n\r\n\r\n");
                    }
                    else
                    {
                        sb.Append("Content-Disposition: form-data; name=\"" + p.Name + "\"");
                        sb.Append("\r\n\r\n");
                        sb.Append(p.Value);
                        sb.Append("\r\n");
                    }
                }
                var head = sb.ToString();
                if (head.EndsWith("\r\n"))
                {
                    //remove the extra "\r\n"
                    head = head.Substring(0, head.Length - 2);
                }
                var formData = Encoding.UTF8.GetBytes(head);
                var footData = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");

                long fileLength = 0;

                if (postData.Parameters.Exists(m => m.IsFile))
                {
                    //get file stream
                    var fileParameter = postData.Parameters.Find(m => m.IsFile);
                    fileStream = new FileStream(fileParameter.Value, FileMode.Open, FileAccess.Read);
                    fileLength = fileStream.Length;
                }

                //get the total content length
                var length = formData.Length + fileLength + footData.Length;
                req.ContentLength = length;

                using (var requestStream = req.GetRequestStream())
                {
                    //write the form data to request stream
                    requestStream.Write(formData, 0, formData.Length);

                    if (fileStream != null)
                    {
                        //write the file content to the request stream
                        var buffer = new Byte[checked((uint)Math.Min(4096, (int)fileLength))];
                        int bytesRead;
                        while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                            requestStream.Write(buffer, 0, bytesRead);
                    }

                    //write the foot data to the request stream
                    requestStream.Write(footData, 0, footData.Length);
                }
                //get the response from server
                using (var response = (HttpWebResponse)req.GetResponse())
                {
                    #region commented code

                    //using (var responseStream = response.GetResponseStream())
                    //{
                    //    if (responseStream != null)
                    //    {
                    //        using (var reader = new StreamReader(responseStream))
                    //        {
                    //            var responseValue = reader.ReadToEnd();
                    //            Console.WriteLine(responseValue);
                    //        }
                    //    }
                    //}

                    #endregion

                    //Console.WriteLine(response.StatusCode);
                    //we consider it as posted successfully if the following status codes are returned
                    //(we can add more status codes in future if we need to)
                    if (response.StatusCode == HttpStatusCode.Created ||
                        response.StatusCode == HttpStatusCode.OK ||
                        response.StatusCode == HttpStatusCode.NoContent)
                    {
                        postResult = true;
                    }
                }

                return postResult;
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                    fileStream.Dispose();
                }
            }
        }

        /// <summary>
        /// upload a file to DAM
        /// </summary>
        /// <param name="chachedFileName"></param>
        /// <param name="assetName">asset name</param>
        /// <param name="metadata">metadata object</param>
        /// <returns>the result of the uploading process</returns>
        public bool UploadFile(string chachedFileName, string assetName, MetaData metadata)
        {
            try
            {
                var uploadResult = false;
                if (!string.IsNullOrEmpty(assetName))
                {
                    //get asset folder name, e.g. "/content/dam/amsterdam/pre-press/customer-supplied-logos"
                    var assetFolderName = Path.GetDirectoryName(assetName);

                    if (!string.IsNullOrEmpty(assetFolderName))
                    {
                        assetFolderName = assetFolderName.Replace("\\", "/");

                        //create the folder in DAM
                        var ret = CreateFolder(assetFolderName, string.Empty);
                        if (!ret)
                        {
                            Exception ex = new Exception(string.Format("Could Not Create Folder '{0}' In AEM.", assetFolderName));
                            throw ex;
                        }
                    }

                    //the post data list
                    //we need 3 steps to complete the uploading process
                    //step1: create the asset node in DAM with PUT method
                    //step2: post the file content to the sub-node "/jcr:content/renditions" with "POST" method
                    //step3: post the metadata for the asset to the DAM
                    var postDataList = new List<PostData>
                    {
                        new PostData//for step 1
                        {

                            Method = HttpVerbs.Put,
                            RelativeUrl = assetName,

                            Parameters = new List<Parameter>
                            {
                                new Parameter
                                {
                                    Name = "jcr:primaryType",
                                    Value = "dam:Asset",
                                    IsFile = false
                                }
                            }
                        },
                        new PostData//for step 2
                        {
                            Method = HttpVerbs.Post,
                            RelativeUrl = assetName + "/jcr:content/renditions",

                            Parameters = new List<Parameter>
                            {
                                new Parameter
                                {
                                    Name = "original",
                                    Value = chachedFileName,
                                    IsFile = true
                                }
                            }
                        }
                    };

                    uploadResult = postDataList.Count > 0;
                    uploadResult = postDataList.Select(Post).Aggregate(uploadResult, (current, postResult) => current & postResult);
                    if (metadata != null)
                    {
                        uploadResult &= PostMetadata(assetName, metadata);//for step 3
                    }
                }
                return uploadResult;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// check if a folder in DAM already exists
        /// </summary>
        /// <param name="assetFolderName">asset folder name</param>
        /// <returns>result</returns>
        private bool CheckDamFolderExist(string assetFolderName)
        {
            try
            {
                var kvList = new List<KeyValuePair<string, string>>();
                //var kvList = new List<KeyValuePair<string, string>>
                //{
                //    new KeyValuePair<string, string>("path", assetFolderName),
                //    new KeyValuePair<string, string>("path.self", "true"),
                //    new KeyValuePair<string, string>("path.exact", "true")
                //};
                assetFolderName = assetFolderName.TrimEnd('/');
                var lastIndexOfSlash = assetFolderName.LastIndexOf('/');
                var relativeFolder = assetFolderName.Substring(0, lastIndexOfSlash);
                var nodeName = assetFolderName.Substring(lastIndexOfSlash + 1);

                //search under this path
                var kvPath = new KeyValuePair<string, string>("path", relativeFolder);
                kvList.Add(kvPath);

                //node name of the folder
                var kvFileName = new KeyValuePair<string, string>("nodename", nodeName);
                kvList.Add(kvFileName);

                //specify the node type
                var kvNodeType = new KeyValuePair<string, string>("type", "sling:OrderedFolder");
                kvList.Add(kvNodeType);

                var queryResults = Query(kvList);
                return queryResults != null && queryResults.Hits.Count > 0;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// get asset name by metadata
        /// </summary>
        /// <param name="metadata">metadata object</param>
        /// <returns>asset path(e.g. /content/dam/amsterdam/prepress/customerArtwork/customerSuppliedLogo/09421602ALA0210001.png)</returns>
        public string GetAssetPathByMetadata(MetaData metadata)
        {
            try
            {
                var hits = SearchByMetadata(metadata);
                if (hits != null && hits.Count > 0)
                {

                    var hit = hits[0];
                    //var path = hit.Path;
                    //const string pathSuffix = "/jcr:content/metadata";
                    ////if it's a metadata node
                    //if (path.EndsWith(pathSuffix))
                    //{
                    //    //get asset name
                    //    var assetPath = path.Substring(0, path.Length - 21);
                    //    return assetPath;
                    //}
                    //else
                    //{
                    //    var assetPath = hit.Path + hit.Name;
                    //    return assetPath;
                    //}
                    return GetAssetNameByPath(hit.Path);
                }
                return string.Empty;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private string GetAssetNameByPath(string path)
        {
            //path example: /content/dam/amsterdam/prepress/CustomerStockArt/CustomerSuppliedLogoWebEdited/asset5A.jpg/_jcr_content/metadata
            try
            {
                //if it's a metadata node
                if (path.EndsWith(MetadataPath))
                {
                    //get asset name
                    var assetName = path.Substring(0, path.Length - 21);
                    return assetName;
                }
                return path;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        private List<QueryHit> SearchByMetadata(MetaData metadata)
        {
            try
            {
                //get the criterion from the metadata
                var criterion = GenerateCriterionByMetadata(metadata, OrderByOptions.LastModified, SortOptions.Descending);
                var hits = new List<QueryHit>();
                if (criterion.Count > 0)
                {
                    //query the DAM with the criterion
                    var queryResult = Query(criterion);

                    //has result(s)
                    //has result(s)
                    if (queryResult.Total > 0 && queryResult.Hits.Count > 0)
                    {
                        if (queryResult.Hits.Count > 1)
                        {
                            foreach (QueryHit hit in queryResult.Hits)
                            {
                                if (hit.LastModified <= DateTime.MinValue)
                                {
                                    hit.LastModified = GetAssetJcrLastModifiedDate(hit.Path);
                                }
                            }
                        }

                        queryResult.Hits.Sort((x, y) => DateTime.Compare(x.LastModified, y.LastModified));
                        hits = queryResult.Hits.OrderByDescending(x => x.LastModified).ToList();
                    }
                }
                return hits;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        private const string JcrLastModifiedFormat = "{0}{1}/_jcr_content.json";
        private const string AssetCreatedDateFormat = "{0}{1}.json";
        private DateTime GetAssetJcrLastModifiedDate(string assetPath)
        {
            DateTime jcrLastModifiedDate = DateTime.MinValue;
            var assetLastModifiedFullPath = string.Format(JcrLastModifiedFormat, _cqAuthorAddress, assetPath);
            string jcrContentJsonStr = string.Empty;
            JavaScriptSerializer jss = null;
            JcrContent jcrContent = null;
            List<string> subStrings = new List<string>();

            subStrings.Add("jcr:");
            subStrings.Add("dam:");
            subStrings.Add("cq:");

            try
            {

                jcrContentJsonStr = GetResponseString(assetLastModifiedFullPath);
                jcrContentJsonStr = RemoveSubStringsFromString(jcrContentJsonStr, subStrings);

                jss = new JavaScriptSerializer();
                jcrContent = jss.Deserialize<JcrContent>(jcrContentJsonStr);
                jcrLastModifiedDate = jcrContent.JcrLastModified;

                if (jcrLastModifiedDate.Equals(DateTime.MinValue))
                {
                    assetLastModifiedFullPath = string.Format(AssetCreatedDateFormat, _cqAuthorAddress, assetPath);
                    jcrContentJsonStr = GetResponseString(assetLastModifiedFullPath);
                    jcrContentJsonStr = RemoveSubStringsFromString(jcrContentJsonStr, subStrings);


                    jcrContent = jss.Deserialize<JcrContent>(jcrContentJsonStr);
                    jcrLastModifiedDate = jcrContent.JcrLastModified;
                }
            }
            catch (Exception e)
            {
                throw;// Log.GetCustomizedException(e, "DamConnector.GetAssetJcrLastModifiedDate(string)");
            }

            return jcrLastModifiedDate;

        }
        private string RemoveSubStringsFromString(string input, List<string> substrings)
        {
            string strResult = input;
            string tempResult = string.Empty;

            if (!string.IsNullOrEmpty(input))
            {
                if (substrings != null)
                {
                    if (substrings.Count > 0)
                    {
                        tempResult = input;
                        for (int i = 0; i < substrings.Count; i++)
                        {
                            tempResult = tempResult.Replace(substrings[i], string.Empty);
                        }
                    }
                }

                if (!string.IsNullOrEmpty(tempResult))
                {
                    strResult = tempResult;
                }
            }

            return strResult;
        }

        /// <summary>
        /// generate criterion by metadata
        /// </summary>
        /// <param name="metadata">metadata object</param>
        /// <returns>query criterion</returns>
        private List<KeyValuePair<string, string>> GenerateCriterionByMetadata(MetaData metadata, OrderByOptions orderBy = OrderByOptions.NotSet, SortOptions sortBy = SortOptions.NotSet)
        {
            try
            {
                var criterion = new List<KeyValuePair<string, string>>();
                var propertyIdx = 1;//starting property index
                const string propertyName = "{0}_property";
                const string propertyValue = "{0}_property.value";
                const string propertyValueON = "{0}_property.{1}_value";
                var assetPath = GetAssetLocation(metadata);
                if (string.IsNullOrEmpty(assetPath))
                {
                    assetPath = Constant.AssetsRootPath;
                }
                // for saved artwork: narrow down the search scope to optimize the performance
                if (metadata.imageType == imageType.CustomerArtWork &&
                    metadata.customerArtworkType == customerArtworkType.CustomerCleanedLogo)
                {
                    if (!string.IsNullOrEmpty(metadata.customerNumber))
                    {
                        if (!assetPath.EndsWith("/"))
                        {
                            assetPath += "/";
                        }
                        assetPath += GetCustomerPath(metadata.customerNumber);
                    }
                }
                criterion.Add(new KeyValuePair<string, string>("path", assetPath));
                criterion.Add(new KeyValuePair<string, string>("type", "dam:Asset"));
                var metadataExtend = metadata as MetaDataExtend;
                if (metadataExtend != null)
                {
                    criterion.Add(new KeyValuePair<string, string>("p.limit", metadataExtend.limit.ToString()));
                    if (metadataExtend.offset >= 0)
                    {
                        criterion.Add(new KeyValuePair<string, string>("p.offset", metadataExtend.offset.ToString()));
                    }
                    if (metadataExtend.universal != null)
                    {
                        foreach (var item in metadataExtend.universal)
                        {
                            criterion.Add(new KeyValuePair<string, string>(string.Format(propertyName, propertyIdx), item.Key));
                            criterion.Add(new KeyValuePair<string, string>(string.Format(propertyValue, propertyIdx), item.Value));
                            propertyIdx++;
                        }
                    }
                    if (!string.IsNullOrEmpty(metadataExtend.nodename))
                    {
                        criterion.Add(new KeyValuePair<string, string>("nodename", metadataExtend.nodename));
                    }
                }
                else
                {
                    //by default, the query builder json servlet displays a maximum of 10 hits
                    //adding the following parameter allows the servlet to display all query results
                    criterion.Add(new KeyValuePair<string, string>("p.limit", "-1"));
                }
                //get metadata object
                var type = metadata.GetType();
                //get all properties of the metadata object
                var properties = type.GetProperties();

                //loop the metadata object
                foreach (var pi in properties)
                {
                    //property name
                    var name = pi.Name;
                    if (name.ToLower().Equals("nodename"))
                    {
                        continue;
                    }
                    name = @"jcr:content/metadata/" + name;
                    string value;

                    if (pi.PropertyType == typeof(string) || pi.PropertyType == typeof(int?))//string-type or int-type property
                    {
                        //get property value
                        var obj = pi.GetValue(metadata);
                        value = obj?.ToString().Trim() ?? string.Empty;

                        if (!string.IsNullOrEmpty(value))
                        {
                            value = ConvertEnumToSpecs(pi.Name, value);
                            //add propery name and value to the criterion list
                            criterion.Add(new KeyValuePair<string, string>(string.Format(propertyName, propertyIdx), name));
                            criterion.Add(new KeyValuePair<string, string>(string.Format(propertyValue, propertyIdx), value));
                            propertyIdx++;
                        }
                    }
                    else if (pi.PropertyType.IsEnum)//enumeration-type property
                    {
                        //get property value
                        value = Enum.GetName(pi.PropertyType, pi.GetValue(metadata));
                        if (!string.IsNullOrEmpty(value) && !"NotSet".Equals(value))
                        {
                            value = ConvertEnumToSpecs(pi.Name, value);
                            criterion.Add(new KeyValuePair<string, string>(string.Format(propertyName, propertyIdx), name));
                            criterion.Add(new KeyValuePair<string, string>(string.Format(propertyValue, propertyIdx), value));
                            propertyIdx++;
                        }
                    }
                    else if (pi.PropertyType == typeof(List<string>))//list-type property
                    {
                        var criterionAdded = false;
                        var list = (List<string>)pi.GetValue(metadata);
                        if (list != null)
                        {
                            criterion.Add(
                                       new KeyValuePair<string, string>(string.Format(propertyName, propertyIdx),
                                           name));
                            if (list.Count == 1)
                            {
                                criterion.Add(
                                    new KeyValuePair<string, string>(string.Format(propertyValue, propertyIdx), list[0]));
                                criterionAdded = true;
                            }
                            else
                            {
                                var valueindex = 1;
                                foreach (var item in list)
                                {
                                    value = item;
                                    if (!string.IsNullOrEmpty(value))
                                    {
                                        value = ConvertEnumToSpecs(pi.Name, value);
                                        criterion.Add(
                                            new KeyValuePair<string, string>(string.Format(propertyValueON, propertyIdx, valueindex), value));
                                        criterionAdded = true;
                                        valueindex++;
                                    }
                                }
                            }
                            if (criterionAdded)
                            {
                                propertyIdx++;
                            }
                        }
                    }
                }

                switch (orderBy)
                {
                    case OrderByOptions.LastModified:
                        criterion.Add(new KeyValuePair<string, string>("orderby", "@jcr:content/jcr:lastModified"));
                        break;
                    case OrderByOptions.Created:
                        criterion.Add(new KeyValuePair<string, string>("orderby", "@jcr:created"));
                        break;
                }

                switch (sortBy)
                {
                    case SortOptions.Ascending:
                        criterion.Add(new KeyValuePair<string, string>("orderby.sort", "asc"));
                        break;
                    case SortOptions.Descending:
                        criterion.Add(new KeyValuePair<string, string>("orderby.sort", "desc"));
                        break;
                }

                return criterion;
            }
            catch (Exception e)
            {
                throw;// Log.GetCustomizedException(e, "DamConnector.GenerateCriterionByMetadata(MetaData)");
            }
        }
        //private List<KeyValuePair<string, string>> GenerateCriterionByMetadata(MetaData metadata, OrderByOptions orderBy = OrderByOptions.NotSet, SortOptions sortBy = SortOptions.NotSet)
        //{
        //    try
        //    {
        //        var criterion = new List<KeyValuePair<string, string>>();
        //        var propertyIdx = 1;//starting property index
        //        const string propertyName = "{0}_property";
        //        const string propertyValue = "{0}_property.value";
        //        var assetPath = GetAssetLocation(metadata);
        //        if(string.IsNullOrEmpty(assetPath))
        //        {
        //            assetPath = Constant.AssetsRootPath;
        //        }
        //        // for saved artwork: narrow down the search scope to optimize the performance
        //        if (metadata.imageType == imageType.CustomerArtWork &&
        //            metadata.customerArtworkType == customerArtworkType.CustomerCleanedLogo)
        //        {
        //            if (!string.IsNullOrEmpty(metadata.customerNumber))
        //            {
        //                if (!assetPath.EndsWith("/"))
        //                {
        //                    assetPath += "/";
        //                }
        //                assetPath += GetCustomerPath(metadata.customerNumber);
        //            }
        //        }
        //        criterion.Add(new KeyValuePair<string, string>("path", assetPath));
        //        criterion.Add(new KeyValuePair<string, string>("type", "dam:Asset"));
        //        var metadataExtend = metadata as MetaDataExtend;
        //        if (metadataExtend != null)
        //        {
        //            criterion.Add(new KeyValuePair<string, string>("p.limit", metadataExtend.limit.ToString()));
        //            if (metadataExtend.offset >= 0)
        //            {
        //                criterion.Add(new KeyValuePair<string, string>("p.offset", metadataExtend.offset.ToString()));
        //            }
        //            if (metadataExtend.universal != null)
        //            {
        //                foreach (var item in metadataExtend.universal)
        //                {
        //                    criterion.Add(new KeyValuePair<string, string>(string.Format(propertyName, propertyIdx),item.Key));
        //                    criterion.Add(new KeyValuePair<string, string>(string.Format(propertyValue, propertyIdx), item.Value));
        //                    propertyIdx++;
        //                }
        //            }
        //            if (!string.IsNullOrEmpty(metadataExtend.nodename))
        //            {
        //                criterion.Add(new KeyValuePair<string, string>("nodename", metadataExtend.nodename));
        //            }
        //        }
        //        else
        //        {
        //            //by default, the query builder json servlet displays a maximum of 10 hits
        //            //adding the following parameter allows the servlet to display all query results
        //            criterion.Add(new KeyValuePair<string, string>("p.limit", "-1"));
        //        }
        //        //get metadata object
        //        var type = metadata.GetType();
        //        //get all properties of the metadata object
        //        var properties = type.GetProperties();

        //        //loop the metadata object
        //        foreach (var pi in properties)
        //        {
        //            //property name
        //            var name = pi.Name;
        //            if (name.ToLower().Equals("nodename"))
        //            {
        //                continue;
        //            }
        //            name = @"jcr:content/metadata/" + name;
        //            string value;

        //            if (pi.PropertyType == typeof(string) || pi.PropertyType == typeof(int?))//string-type or int-type property
        //            {
        //                //get property value
        //                var obj = pi.GetValue(metadata);
        //                value = obj?.ToString().Trim() ?? string.Empty;

        //                if (!string.IsNullOrEmpty(value))
        //                {
        //                    value = ConvertEnumToSpecs(pi.Name, value);
        //                    //add propery name and value to the criterion list
        //                    criterion.Add(new KeyValuePair<string, string>(string.Format(propertyName, propertyIdx), name));
        //                    criterion.Add(new KeyValuePair<string, string>(string.Format(propertyValue, propertyIdx), value));
        //                    propertyIdx++;
        //                }
        //            }
        //            else if (pi.PropertyType.IsEnum)//enumeration-type property
        //            {
        //                //get property value
        //                value = Enum.GetName(pi.PropertyType, pi.GetValue(metadata));
        //                if (!string.IsNullOrEmpty(value) && !"NotSet".Equals(value))
        //                {
        //                    value = ConvertEnumToSpecs(pi.Name, value);
        //                    criterion.Add(new KeyValuePair<string, string>(string.Format(propertyName, propertyIdx), name));
        //                    criterion.Add(new KeyValuePair<string, string>(string.Format(propertyValue, propertyIdx), value));
        //                    propertyIdx++;
        //                }
        //            }
        //            else if (pi.PropertyType == typeof(List<string>))//list-type property
        //            {
        //                var criterionAdded = false;
        //                var list = (List<string>)pi.GetValue(metadata);
        //                if (list != null)
        //                {
        //                    foreach (var item in list)
        //                    {
        //                        value = item;
        //                        if (!string.IsNullOrEmpty(value))
        //                        {
        //                            value = ConvertEnumToSpecs(pi.Name, value);
        //                            criterion.Add(
        //                                new KeyValuePair<string, string>(string.Format(propertyName, propertyIdx),
        //                                    name));
        //                            criterion.Add(
        //                                new KeyValuePair<string, string>(string.Format(propertyValue, propertyIdx),
        //                                    value));
        //                            criterionAdded = true;
        //                        }
        //                    }
        //                    if (criterionAdded)
        //                    {
        //                        propertyIdx++;
        //                    }
        //                }
        //            }
        //        }

        //        switch (orderBy)
        //        {
        //            case OrderByOptions.LastModified:
        //                criterion.Add(new KeyValuePair<string, string>("orderby", "@jcr:content/jcr:lastModified"));
        //                break;
        //            case OrderByOptions.Created:
        //                criterion.Add(new KeyValuePair<string, string>("orderby", "@jcr:created"));
        //                break;
        //        }

        //        switch (sortBy)
        //        {
        //            case SortOptions.Ascending:
        //                criterion.Add(new KeyValuePair<string, string>("orderby.sort", "asc"));
        //                break;
        //            case SortOptions.Descending:
        //                criterion.Add(new KeyValuePair<string, string>("orderby.sort", "desc"));
        //                break;
        //        }

        //        return criterion;
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //}

        /// <summary>
        /// create a folder in DAM
        /// </summary>
        /// <param name="folder">folder path</param>
        /// <param name="folderName">folder name</param>
        /// <returns>result</returns>
        private bool CreateFolder(string folder, string folderName = "")
        {
            bool folderCreated = CreateFolderInternal(folder, folderName);

            if (!folderCreated)
            {
                folderCreated = CreateFolderInternal(folder, folderName, false);
            }

            return folderCreated;

        }

        private bool CreateFolderInternal(string folder, string folderName = "", bool useServlet = true)
        {
            bool createdFolder = false;

            try
            {
                // trim the end '/' and blank spaces so that the extra folder won't be created
                folder = folder.Trim();
                folder = folder.TrimEnd('/');
                folder = folder.Trim();

                if (useServlet)
                {
                    string requestUrl = _cqAuthorAddress + string.Format(folderCreationServelet, folder);
                    string responseStr = GetResponseString(requestUrl);

                    var jss = new JavaScriptSerializer();

                    // convert the JSON string to a 'QueryResult' object
                    var queryResult = jss.Deserialize<QueryResult>(responseStr);

                    createdFolder = (queryResult != null && queryResult.Hits.Count > 0);
                }
                else
                {
                    var postData = new PostData
                    {
                        Method = HttpVerbs.Post,
                        RelativeUrl = folder,
                        Parameters = new List<Parameter>
                        {
                            new Parameter
                            {
                                Name = "folderName",
                                Value = folderName,
                                IsFile = false
                            }
                        }
                    };
                    Post(postData);
                    createdFolder = true;
                }
            }
            catch (Exception e)
            {
                createdFolder = false;
            }

            return createdFolder;

        }

        /// <summary>
        /// generate post data by metadata object
        /// </summary>
        /// <param name="assetName">asset name</param>
        /// <param name="metadata">metadata object</param>
        /// <returns>post data</returns>
        private PostData GeneratePostDataByMetadata(string assetName, MetaData metadata)
        {
            try
            {
                var postData = new PostData
                {
                    Method = HttpVerbs.Post,
                    RelativeUrl = assetName + MetadataPath
                };

                var parameters = new List<Parameter>();
                var type = metadata.GetType();

                //get all properties of the metadata object
                var properties = type.GetProperties();

                foreach (var pi in properties)
                {
                    var pairs = new List<KeyValuePair<string, string>>();
                    var name = pi.Name;
                    string value;
                    if (pi.PropertyType == typeof(string))
                    {//string type
                        var obj = pi.GetValue(metadata);
                        value = obj?.ToString().Trim() ?? string.Empty;
                        if (!string.IsNullOrEmpty(value))
                        {
                            value = ConvertEnumToSpecs(pi.Name, value);
                            pairs.Add(new KeyValuePair<string, string>(name, value));
                        }
                    }
                    else if (pi.PropertyType.IsEnum)
                    {//enum type
                        value = Enum.GetName(pi.PropertyType, pi.GetValue(metadata));
                        if (!string.IsNullOrEmpty(value) && !"NotSet".Equals(value))
                        {
                            value = ConvertEnumToSpecs(pi.Name, value);
                            var typeName = pi.PropertyType.Name;
                            pairs.Add(new KeyValuePair<string, string>(name, value));
                            pairs.Add(new KeyValuePair<string, string>(name + TypeHintSuffix, typeName));
                        }
                    }
                    else if (pi.PropertyType == typeof(List<string>))
                    {//List<string> type
                        var list = (List<string>)pi.GetValue(metadata);
                        if (list != null)
                        {
                            foreach (var item in list)
                            {
                                value = item;
                                if (!string.IsNullOrEmpty(value))
                                {
                                    value = ConvertEnumToSpecs(pi.Name, value);
                                    pairs.Add(new KeyValuePair<string, string>(name, value));
                                }
                            }
                            const string typeName = "String[]";
                            pairs.Add(new KeyValuePair<string, string>(name + TypeHintSuffix, typeName));
                        }
                    }
                    else if (pi.PropertyType == typeof(int?))
                    {//int? type
                        var obj = pi.GetValue(metadata);
                        value = obj?.ToString().Trim() ?? string.Empty;
                        if (!string.IsNullOrEmpty(value))
                        {
                            var longTypeValue = Convert.ToInt32(value);
                            pairs.Add(new KeyValuePair<string, string>(name, longTypeValue.ToString()));
                            const string typeName = "Long";
                            pairs.Add(new KeyValuePair<string, string>(name + TypeHintSuffix, typeName));
                        }
                    }
                    parameters.AddRange(from pair in pairs
                                        where !(string.IsNullOrEmpty(pair.Key) || string.IsNullOrEmpty(pair.Value))
                                        select new Parameter
                                        {
                                            Name = pair.Key,
                                            Value = pair.Value
                                        });
                }
                postData.Parameters = parameters;
                return postData;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private string GetAssetLocation(MetaData metadata)
        {
            var assetLocation = string.Empty;
            if (metadata != null)
            {
                if (metadata.imageType != imageType.NotSet)
                {
                    switch (metadata.imageType)
                    {
                        case imageType.StockArt:
                            assetLocation = _imageTypeStockartPath;
                            break;
                        case imageType.Template:
                            assetLocation = _imageTypeTemplatePath;
                            break;
                        case imageType.CustomerArtWork:
                            assetLocation = _imageTypeCustomerArtWorkPath;
                            break;
                        case imageType.PersonalizationFile:
                            assetLocation = _imageTypePersonalizationfilePath;
                            break;
                        case imageType.CustomerSuppliedStockArt:
                            assetLocation = _imageTypeCustomersuppliedstockartPath;
                            break;
                        case imageType.StaticArtwork:
                            assetLocation = _imageTypeStaticArtworkPath;
                            break;
                    }
                    if (metadata.customerArtworkType != customerArtworkType.NotSet)
                    {
                        switch (metadata.customerArtworkType)
                        {
                            case customerArtworkType.CustomerSuppliedLogo:
                                assetLocation += _artworkTypeCustomerSuppliedLogoPath;
                                break;
                            case customerArtworkType.CustomerCleanedLogo:
                                assetLocation += _artworkTypeCustomerCleanedLogoPath;
                                break;
                            case customerArtworkType.WorkFile:
                                assetLocation += _artworkTypeWorkFilePath;
                                break;
                            case customerArtworkType.ProductionArtWork:
                                assetLocation += _artworkTypeProductionArtWorkPath;
                                break;
                            case customerArtworkType.Proof:
                                assetLocation += _artworkTypeProofPath;
                                break;
                            case customerArtworkType.WebPreview:
                                assetLocation += _artworkTypeWebPreviewPath;
                                break;
                            case customerArtworkType.CustomerSuppliedLogoWebEdited:
                                assetLocation += _artworkTypeCustomerSuppliedWebEditedPath;
                                break;
                        }
                    }
                    else if (metadata.stockArtType != stockArtType.NotSet)
                    {
                        switch (metadata.stockArtType)
                        {
                            case stockArtType.DigitalBackground:
                                assetLocation += _stockartTypeDigitalBackgroundPath;
                                break;
                            case stockArtType.AdArt:
                                assetLocation += _stockartTypeAdArtPath;
                                break;
                            case stockArtType.DateArt:
                                assetLocation += _stockartTypeDateArtPath;
                                break;
                            case stockArtType.Slogan:
                                assetLocation += _stockartTypeSloganPath;
                                break;
                            case stockArtType.Verse:
                                assetLocation += _stockartTypeVersePath;
                                break;
                        }
                    }
                    else if (metadata.templateType != templateType.NotSet)
                    {
                        switch (metadata.templateType)
                        {
                            case templateType.Grid:
                                assetLocation += _templateTypeGridPath;
                                break;
                            case templateType.Single:
                                assetLocation += _templateTypeSinglePath;
                                break;
                            case templateType.Xeikon:
                                assetLocation += _templateTypeXeikonPath;
                                break;
                            case templateType.Pim:
                                assetLocation += _templateTypePimPath;
                                break;
                            case templateType.Thayer:
                                assetLocation += _templateTypeThayer;
                                break;
                        }
                    }
                    else if (metadata.customerSuppliedStockartType != customerSuppliedStockartType.NotSet)
                    {
                        switch (metadata.customerSuppliedStockartType)
                        {
                            case customerSuppliedStockartType.WebPreview:
                                assetLocation += _customerSuppliedStockartTypeWebPreview;
                                break;
                            case customerSuppliedStockartType.ProductionArtwork:
                                assetLocation += _customerSuppliedStockartTypeProductionArtwork;
                                break;
                        }
                    }
                    else if (metadata.staticArtworkType != staticArtworkType.NotSet)
                    {
                        switch (metadata.staticArtworkType)
                        {
                            case staticArtworkType.ProductionArtwork:
                                assetLocation += _staticArtworkTypeProductionArtwork;
                                break;
                        }
                    }
                }
            }
            return assetLocation.Trim();
        }

        private bool MetaDataValidation(MetaData metaData)
        {
            var isValid = false;

            switch (metaData.imageType)
            {
                case imageType.StockArt:
                    if (metaData.stockArtType == stockArtType.Verse && !string.IsNullOrEmpty(metaData.verseList) &&
                        !string.IsNullOrEmpty(metaData.verseId))
                    {
                        isValid = true;
                    }
                    else if (metaData.stockArtType == stockArtType.AdArt && metaData.colorSpace != colorSpace.NotSet &&
                             !string.IsNullOrEmpty(metaData.refId))
                    {
                        isValid = true;
                    }
                    else if (metaData.stockArtType != stockArtType.NotSet && metaData.colorSpace != colorSpace.NotSet)
                    {
                        isValid = true;
                    }
                    break;
                case imageType.Template:
                    if (metaData.templateType != templateType.NotSet)
                    {
                        if (metaData.templateType == templateType.Thayer)
                        {
                            if (!string.IsNullOrEmpty(metaData.calendarYear))
                            {
                                if ("odd".Equals(metaData.calendarYear) || "odd".Equals(metaData.calendarYear) ||
                                    "odd".Equals(metaData.calendarYear))
                                {
                                    isValid = true;
                                }
                            }
                        }
                        else
                        {
                            isValid = true;
                        }
                    }
                    break;
                case imageType.CustomerArtWork:
                    if (metaData.customerArtworkType != customerArtworkType.NotSet &&
                        !string.IsNullOrEmpty(metaData.customerNumber) &&
                        metaData.colorSpace != colorSpace.NotSet &&
                        !string.IsNullOrEmpty(metaData.originalFilename) &&
                        !string.IsNullOrEmpty(metaData.filenameNoExtension) &&
                        !string.IsNullOrEmpty(metaData.imprintFormat))
                    {
                        isValid = true;
                    }
                    break;
                case imageType.PersonalizationFile:
                    if (!string.IsNullOrEmpty(metaData.customerNumber) &&
                        !string.IsNullOrEmpty(metaData.imprintFormat) &&
                        metaData.sequenceNumber != null &&
                        metaData.sequenceNumber > 0 &&
                        !string.IsNullOrEmpty(metaData.customerFormatSequence))
                    {
                        isValid = true;
                    }
                    break;
                case imageType.CustomerSuppliedStockArt:
                    if (metaData.customerArtworkType != customerArtworkType.NotSet &&
                        !string.IsNullOrEmpty(metaData.vendorStudioId) &&
                        metaData.colorSpace != colorSpace.NotSet)
                    {
                        isValid = true;
                    }
                    break;
                case imageType.StaticArtwork:
                    if (metaData.customerArtworkType != customerArtworkType.NotSet &&
                        !string.IsNullOrEmpty(metaData.imprintFormat))
                    {
                        // the business rule should be that if the imageType is staticArtwork, then the customerArtworkType is always productionArtwork no matter what is in the meta-data
                        if (metaData.customerArtworkType == customerArtworkType.ProductionArtWork)
                        {
                            isValid = true;
                        }
                    }
                    break;
            }
            return isValid;
        }

        private string ConvertEnumToSpecs(string propertyName, string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return "";
            }
            if (Constant.GetExculsions().Exists(p => p.Equals(propertyName)))
            {
                return text;
            }
            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]) && text[i - 1] != '-')
                    newText.Append('-');
                newText.Append(text[i]);
            }
            return newText.ToString().ToLower();
        }

        /// <summary>
        /// get template sub directory
        /// </summary>
        /// <param name="filename">filename</param>
        /// <returns>template sub directory(has no leading slash but has tailing slash)</returns>
        private string GetTemplateSubDirectory(string filename)
        {
            var filenameNoExtension = Path.GetFileNameWithoutExtension(filename);
            if (filenameNoExtension == null)
            {
                throw new NullReferenceException("The filename='" + filename + "' is invalid");
            }
            var prefix = string.Empty;
            var subfix = string.Empty;
            if (filenameNoExtension.Length >= 6)
            {
                prefix = filenameNoExtension.Substring(0, 3);
                subfix = filenameNoExtension.Substring(3, 3);
            }
            else if (filenameNoExtension.Length >= 3)
            {
                prefix = filenameNoExtension.Substring(0, 3);
            }
            //if (!string.IsNullOrEmpty(filenameNoExtension))
            //{
            //    if (filenameNoExtension.Length > 3)
            //    {
            //        //var prefix = filenameNoExtension.Substring(0, 3);
            //        //var subfix = filenameNoExtension.Substring(3);
            //        if (subfix.Length < 3)
            //        {
            //            subfix = subfix.PadLeft(3, '0');
            //        }
            //        else
            //        {
            //            subfix = subfix.Substring(subfix.Length - 3);
            //        }
            //        var subDirectory = prefix + "/" + subfix + "/";
            //        return subDirectory;
            //    }
            //}
            var subDirectory = string.Empty;
            if (!string.IsNullOrEmpty(prefix))
            {
                subDirectory += prefix + "/";
            }
            if (!string.IsNullOrEmpty(subfix))
            {
                subDirectory += subfix + "/";
            }
            return subDirectory;
        }

        private string GetStaticArtworkDirectory(string imprintFormat)
        {
            if (imprintFormat == null || imprintFormat.Length <= 3)
            {
                throw new Exception("The imprintFormat is invalid");
            }
            var part1 = imprintFormat.Substring(0, 3);
            var part2 = imprintFormat.Substring(3);
            var subDirectory = $"{part1}/{part2}/";
            return subDirectory;
        }

        private string GetVerseDirectory(string verseId)
        {
            if (!string.IsNullOrEmpty(verseId))
            {
                return $"{verseId[0]}/";
            }
            return string.Empty;
        }

        private string GetAddArtDirectory(string refId)
        {
            string subDirectory = string.Empty;
            int iRefId = 0;

            if (string.IsNullOrEmpty(refId))
            {
                throw new Exception(string.Format("The refId '{0}' is invalid", refId));
            }

            int.TryParse(refId, out iRefId);

            if (iRefId < MinRefId || iRefId > MaxRefId)
            {
                throw new Exception(string.Format("The refId '{0}' is out of range", refId));
            }

            subDirectory = GetRefIdFolderName(iRefId);

            return subDirectory;
        }

        private string GetRefIdFolderName(int refId)
        {
            string foldername = string.Empty;
            List<AddArtRange> addArtFolderRanges = GetAddArtFolderRanges();

            foreach (AddArtRange range in addArtFolderRanges)
            {
                if (range.IsWithinRange(refId))
                {
                    foldername = range.Foldername;
                    break;
                }
            }

            return foldername;
        }

        private List<AddArtRange> GetAddArtFolderRanges()
        {
            List<AddArtRange> folderRanges = new List<AddArtRange>();
            int min = 1;
            int max = 100;

            while (max <= MaxRefId)
            {
                folderRanges.Add(new AddArtRange(min, max));
                min += 100;
                max += 100;
            }

            return folderRanges;
        }

        /// <summary>
        /// get customer path(with trailing slash but without leading slash, e.g. 08/05/73/07/)
        /// </summary>
        /// <param name="customerNumber">customer number</param>
        /// <returns>customer path</returns>
        private string GetCustomerPath(string customerNumber)
        {
            return SplitStringToPath(customerNumber, 2);
        }

        /// <summary>
        /// get imprintFormat path(with trailing slash but without leading slash, e.g. ASP/624/)
        /// </summary>
        /// <param name="imprintFormat"></param>
        /// <returns></returns>
        private string GetImprintFormatPath(string imprintFormat)
        {
            return SplitStringToPath(imprintFormat, 3);
        }

        /// <summary>
        /// split string to path
        /// </summary>
        /// <param name="str">string</param>
        /// <param name="len">length of each part of the path</param>
        /// <returns></returns>
        private string SplitStringToPath(string str, int len)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }

            var stringLength = str.Length;
            var sliceCount = stringLength / len;
            if (sliceCount == 0)
            {
                return str;
            }
            var sbPath = new StringBuilder();
            int i;
            for (i = 0; i < sliceCount; i++)
            {
                sbPath.Append(str.Substring(i * len, len)).Append('/');
            }
            if (i * len < stringLength)
            {
                sbPath.Append(str.Substring(i * len)).Append('/');
            }
            return sbPath.ToString();
        }

        private string GetCustomerArtworkSubFolder(string customerNumber, string imprintFormat)
        {
            var customerNumberPath = GetCustomerPath(customerNumber);
            var imprintFormatPath = GetImprintFormatPath(imprintFormat);
            return customerNumberPath + imprintFormatPath;
        }

        private string GetVendorSubFolder(string vendorId)
        {
            vendorId = vendorId?.Trim();
            var subFolder = new StringBuilder();
            if (!string.IsNullOrEmpty(vendorId))
            {
                foreach (char c in vendorId)
                {
                    subFolder.Append(c);
                    subFolder.Append("/");
                }
            }
            return subFolder.ToString();
        }

        private string GetValueWithKeyFromString(string str, string key)
        {
            if (!string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(key))
            {
                var keyIndex = str.IndexOf(key, StringComparison.Ordinal);
                if (keyIndex >= 0)
                {
                    var tmpStr = str.Substring(keyIndex + key.Length + 2);
                    var tmpIdx = tmpStr.IndexOf("\"", StringComparison.Ordinal);
                    if (tmpIdx >= 0)
                    {
                        return tmpStr.Substring(0, tmpIdx);
                    }
                }
            }
            return null;
        }
        private Hashtable GetVersionValuesByAssetPath(string assetPath)
        {
            try
            {
                var ht = new Hashtable();
                if (!string.IsNullOrEmpty(assetPath))
                {
                    var requestAddress = _cqAuthorAddress + assetPath + ".json";
                    var responseString = GetResponseString(requestAddress);
                    for (int i = 0; i < _versionKeyWords.Length; i++)
                    {
                        var value = GetValueWithKeyFromString(responseString, _versionKeyWords[i]);
                        ht.Add(_versionKeyWords[i], value);
                    }

                    return ht;
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return null;
        }

        private QueryHit GetMostRecentVersionAssetSimpleProperty(string baseVersion)
        {
            try
            {
                if (!string.IsNullOrEmpty(baseVersion))
                {
                    var kvList = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("path", "/jcr:system/jcr:versionStorage/"),
                        new KeyValuePair<string, string>("type", "nt:version"),
                        new KeyValuePair<string, string>("1_property", "jcr:uuid"),
                        new KeyValuePair<string, string>("1_property.value", baseVersion)
                    };
                    var results = Query(kvList);
                    if (results.Hits.Count > 0)
                    {
                        var hit = results.Hits[0];
                        return hit;
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return null;
        }

        private string GetHitoryPath(string versionHistory)
        {
            try
            {
                if (!string.IsNullOrEmpty(versionHistory))
                {
                    //http://aplauthdev.corp.tcc.inet:4502/bin/querybuilder.json?path=/jcr:system/jcr:versionStorage&type=nt:versionHistory&1_property=jcr:uuid&1_property.value=bec8399d-6988-434f-8ebb-42b32ed36c6c
                    var kvList = new List<KeyValuePair<string, string>>();
                    kvList.Add(new KeyValuePair<string, string>("path", "/jcr:system/jcr:versionStorage&type=nt:versionHistory"));
                    kvList.Add(new KeyValuePair<string, string>("type", "nt:versionHistory"));
                    kvList.Add(new KeyValuePair<string, string>("1_property", "jcr:uuid"));
                    kvList.Add(new KeyValuePair<string, string>("1_property.value", versionHistory));

                    var results = Query(kvList);
                    if (results.Hits.Count > 0)
                    {
                        var hit = results.Hits[0];
                        return hit.Path;
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return null;
        }

        private string GetOldVersionAssetPath(string baseAssetPath, string version = null)
        {
            var sbOldVersionAssetPath = new StringBuilder(baseAssetPath);
            //sbOldVersionAssetPath.Append(baseAssetPath);

            if (!string.IsNullOrEmpty(version))
            {
                sbOldVersionAssetPath.Append("/");
                sbOldVersionAssetPath.Append(version);
            }
            sbOldVersionAssetPath.Append("/jcr:frozenNode/jcr:content/renditions/original");
            return sbOldVersionAssetPath.ToString();
        }

        private List<QueryHit> SearchAssetBySearchHierarchy<T>(List<T> searchHierarchy) where T : MetaData
        {
            var hits = new List<QueryHit>();
            foreach (var metaData in searchHierarchy)
            {
                hits = SearchByMetadata(metaData);
                if (hits.Count > 0)
                {
                    break;
                }
            }
            return hits;
        }

        private bool CheckUrlStatus(string assetUrl)
        {
            HttpWebResponse response = null;
            try
            {
                var request = WebRequest.Create(assetUrl);
                request.Method = "GET";
                request.Credentials = _credential;
                response = (HttpWebResponse)request.GetResponse();
                //var statusCode = response.StatusCode.ToString();
                return true;
            }
            catch (WebException we)
            {
                // if it's a not-found exception, then supress the exception, or throw the exception
                if (((HttpWebResponse)we.Response)?.StatusCode != HttpStatusCode.NotFound)
                {
                    throw;
                }
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                    response.Dispose();
                }
            }
            return false;
        }

        private List<QueryHit> GetSavedArtHits(MetaData meta, int pageIndex = -1, int pageSize = -1)
        {
            var limit = -1;
            var offset = -1;
            if (pageSize > 0 && pageIndex >= 0)
            {
                limit = pageSize;
                offset = pageSize * pageIndex;
            }
            var searchBySequence = meta.sequenceNumber != null && meta.sequenceNumber > 0;

            var universal = new Dictionary<string, string>
                            {
                                { SavedArtSamllThumbnailProperty160, SavedArtThumbnailValue },
                                { SavedArtLargeThumbnailProperty319, SavedArtThumbnailValue },
                              //  { SavedArtLargeThumbnailProperty1280, SavedArtThumbnailValue }
                            };
            List<MetaDataExtend> searchHierarchy;
            if (searchBySequence)
            {
                searchHierarchy = new List<MetaDataExtend>
                {
                    // For Reorder, we should only return customerCleanedLogo for the CustomerNumber, Imprint Area Code (format), and Sequence (seq) of that order
                    new MetaDataExtend// search #1
                    {
                        imageType = imageType.CustomerArtWork,
                        customerArtworkType = customerArtworkType.CustomerCleanedLogo,
                        customerNumber = meta.customerNumber,
                        imprintFormat = meta.imprintFormat,
                        sequenceNumber = meta.sequenceNumber,
                        universal = universal,
                        limit = limit,
                        offset = offset
                    }
                };
            }
            else
            {
                // For New, we will have three searches:
                // 1.CustomerNumber - Format
                // 2.CustomerNumber - ProcessId
                // 3.CustomerNumber
                searchHierarchy = new List<MetaDataExtend>
                {
                    new MetaDataExtend// search #1
                    {
                        imageType = imageType.CustomerArtWork,
                        customerArtworkType = customerArtworkType.CustomerCleanedLogo,
                        customerNumber = meta.customerNumber,
                        imprintFormat = meta.imprintFormat,
                        universal = universal,
                        limit = limit,
                        offset = offset
                    },
                    new MetaDataExtend// search #2
                    {
                        imageType = imageType.CustomerArtWork,
                        customerArtworkType = customerArtworkType.CustomerCleanedLogo,
                        customerNumber = meta.customerNumber,
                        processIds = meta.processIds,
                        universal = universal,
                        limit = limit,
                        offset = offset
                    },
                    new MetaDataExtend// search #3
                    {
                        imageType = imageType.CustomerArtWork,
                        customerArtworkType = customerArtworkType.CustomerCleanedLogo,
                        customerNumber = meta.customerNumber,
                        universal = universal,
                        limit = limit,
                        offset = offset
                    }
                };
            }

            var hits = SearchAssetBySearchHierarchy(searchHierarchy);
            return hits;
        }

        private List<QueryHit> GetSavedArtHits(MetaData meta, bool searchNodename)
        {
            var searchBySequence = meta.sequenceNumber != null && meta.sequenceNumber > 0;
            List<MetaDataExtend> searchHierarchy;
            if (searchBySequence)
            {
                searchHierarchy = new List<MetaDataExtend>
                {
                    // For Reorder, we should only return customerCleanedLogo for the CustomerNumber, Imprint Area Code (format), and Sequence (seq) of that order
                    new MetaDataExtend// search #1
                    {
                        imageType = imageType.CustomerArtWork,
                        customerArtworkType = customerArtworkType.CustomerCleanedLogo,
                        customerNumber = meta.customerNumber,
                        imprintFormat = meta.imprintFormat,
                        sequenceNumber = meta.sequenceNumber
                    }
                };
            }
            else
            {
                // For New, we will have three searches:
                // 1.CustomerNumber - Format
                // 2.CustomerNumber - ProcessId
                // 3.CustomerNumber
                searchHierarchy = new List<MetaDataExtend>
                {
                    new MetaDataExtend// search #1
                    {
                        imageType = imageType.CustomerArtWork,
                        customerArtworkType = customerArtworkType.CustomerCleanedLogo,
                        customerNumber = meta.customerNumber,
                        imprintFormat = meta.imprintFormat,
                    },
                    new MetaDataExtend// search #2
                    {
                        imageType = imageType.CustomerArtWork,
                        customerArtworkType = customerArtworkType.CustomerCleanedLogo,
                        customerNumber = meta.customerNumber,
                        processIds = meta.processIds
                    },
                    new MetaDataExtend// search #3
                    {
                        imageType = imageType.CustomerArtWork,
                        customerArtworkType = customerArtworkType.CustomerCleanedLogo,
                        customerNumber = meta.customerNumber
                    }
                };
            }
            List<QueryHit> hits;
            if (!string.IsNullOrEmpty(meta.originalFilename))
            {
                if (searchNodename)
                {
                    searchHierarchy.ForEach(m => m.nodename = meta.originalFilename);
                    hits = SearchAssetBySearchHierarchy(searchHierarchy);
                    return hits;
                }
                else
                {
                    searchHierarchy.ForEach(m => m.originalFilename = meta.originalFilename);
                    hits = SearchAssetBySearchHierarchy(searchHierarchy);
                    if (hits == null || hits.Count == 0)
                    {
                        hits = GetSavedArtHits(meta, true);
                    }
                    return hits;
                }
            }

            hits = SearchAssetBySearchHierarchy(searchHierarchy);
            return hits;
        }
        private string FormatFileName(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                var fileNameNoExtension = Path.GetFileNameWithoutExtension(fileName);
                var ext = Path.GetExtension(fileName);
                fileName = fileNameNoExtension?.ToUpper() + ext?.ToLower();
            }
            return fileName;
        }
        #endregion
    }
}
