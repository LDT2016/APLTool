using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using APLTools.Advance.WinUI.UseImage;

namespace BackgroundProductionFileDownloader
{
    public partial class BackgroundProductionFileDownloader : UserControl
    {
        private static BackgroundProductionFileDownloader instance;

        public static BackgroundProductionFileDownloader Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BackgroundProductionFileDownloader();
                }

                return instance;
            }
        }
        public BackgroundProductionFileDownloader()
        {
            InitializeComponent();
        }

        private void BtnExecute_Click(object sender, EventArgs e)
        {
            UserSettings.ItemIdList = this.TxtItemID.Text
                .Split("\r\n,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Where(m => !string.IsNullOrWhiteSpace(m))
                .Select(m => m.Trim())
                .ToList();
            if (UserSettings.ItemIdList.Count == 0)
            {
                MessageBox.Show(this, "Item ID required.");
                return;
            }

            this.BtnExecute.Enabled = false;
            this.TxtOutput.Text = string.Empty;
            OutputHistory.Clear();
            UserSettings.ExecuteTimes = null;
            if (RdSpecified.Checked)
            {
                UserSettings.ExecuteTimes = int.Parse(NumTimes.Text);
            }

            Worker.RunWorkerAsync();
        }

        private BackgroundWorker Worker { get; set; }

        private UserSettingsModel UserSettings { get; set; } = new UserSettingsModel();

        private void Form1_Load(object sender, EventArgs e)
        {
            UserSettings.SourcePath = ConfigurationManager.AppSettings["SourcePath"];
            UserSettings.DestinationPath = ConfigurationManager.AppSettings["DestinationPath"];
            UserSettings.SubFolder = ConfigurationManager.AppSettings["SubFolder"];
            UserSettings.FtpUserName = ConfigurationManager.AppSettings["FtpUserName"];
            UserSettings.FtpPassword = ConfigurationManager.AppSettings["FtpPassword"];
            UserSettings.FtpHost = ConfigurationManager.AppSettings["FtpHost"];
            Worker = new BackgroundWorker();
            Worker.WorkerSupportsCancellation = true;
            Worker.WorkerReportsProgress = true;
            Worker.DoWork += Worker_DoWork;
            Worker.ProgressChanged += Worker_ProgressChanged;
            Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.BtnExecute.Enabled = true;
            this.BtnCancel.Text = "Cancel";
            MessageBox.Show(this, e.Cancelled ? "Canceled" : "Completed");
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.TxtOutput.Text = e.UserState as string + "\r\n" + this.TxtOutput.Text;

            this.TxtOutput.Update();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (var itemId in UserSettings.ItemIdList)
            {
                var folderImageCodeList = GetFolderImageCodeList(itemId);
                foreach (var c in folderImageCodeList)
                {
                    var templateIdList = GetTemplateIdList(c, itemId);
                    templateIdList.Insert(0, c.DefaultTemplateId);
                    templateIdList = templateIdList.Distinct().ToList();
                    if (UserSettings.ExecuteTimes.HasValue)
                    {
                        templateIdList = templateIdList.Take(UserSettings.ExecuteTimes.Value + 1).ToList();
                    }

                    foreach (var t in templateIdList)
                    {
                        var images = GetImages(t);
                        foreach (var img in images)
                        {
                            if (Worker.CancellationPending)
                            {
                                e.Cancel = true;
                                return;
                            }

                            var folderName = GetFolderName(img.FolderId);
                            var path = CheckFolder(folderName);
                            AppendMessage(itemId, path);
                            FtpDownloadFile(UserSettings.FtpHost + UserSettings.SourcePath + UserSettings.SubFolder + img.ProductionImage.Replace("\\", "/"), UserSettings.Path + img.ProductionImage, UserSettings.FtpUserName, UserSettings.FtpPassword);

                            var sourcePath = UserSettings.Path + img.ProductionImage;
                            var destPath = $"{UserSettings.Path.TrimEnd(@"\".ToCharArray())}\\imageCopied\\{t}{Path.GetExtension(img.ProductionImage)}";
                            if (File.Exists(sourcePath)&&!File.Exists(destPath))
                            {
                                Thread.Sleep(50);

                                var directoryInfo = new FileInfo(destPath).Directory;
                                if (directoryInfo != null && !directoryInfo.Exists)
                                {
                                    directoryInfo.Create();
                                }
                                File.Copy(sourcePath, destPath, true);
                            }
                        }
                    }
                }
            }
        }

        private string ConnectionString => ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        private IList<FolderImageCodeModel> GetFolderImageCodeList(string itemId)
        {
            IList<FolderImageCodeModel> list = new List<FolderImageCodeModel>();
            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand("admin.design_FolderImageCode_GetListByItemID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ItemId", itemId);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new FolderImageCodeModel()
                            {
                                DefaultCategoryId = (int)reader["DefaultCategoryId"],
                                ImageCode = (string)reader["ImageCode"],
                                ImprintLocation = (string)reader["ImprintLocation"],
                                DefaultTemplateId = (int)reader["DefaultTemplateId"]
                            });
                        }
                    }
                }
            }

            return list;
        }

        private IList<int> GetTemplateIdList(FolderImageCodeModel folderImageCode, string itemId)
        {
            IList<int> list = new List<int>();
            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand("design_GetCommonTemplateList", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoryId", folderImageCode.DefaultCategoryId);
                    cmd.Parameters.AddWithValue("@ItemId", itemId);
                    cmd.Parameters.AddWithValue("@ImprintAreaCode", folderImageCode.ImageCode);
                    cmd.Parameters.AddWithValue("@ImprintLocation", folderImageCode.ImprintLocation);
                    cmd.Parameters.AddWithValue("@Org", 1);
                    cmd.Parameters.AddWithValue("@EditId", 0);

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add((int)reader["TemplateId"]);
                        }
                    }
                }
            }

            return list;
        }

        private IList<ImageModel> GetImages(int imageId)
        {
            IList<ImageModel> list = new List<ImageModel>();
            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand("design_GetImageById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ImageId", imageId);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ImageModel()
                            {
                                ProductionImage = (string)reader["ProductionImage"],
                                FolderId = (int)reader["FolderId"]
                            });
                        }
                    }
                }
            }

            return list;
        }

        private string GetFolderName(int folderId)
        {
            string folderName = null;
            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand("select FolderTitle from design_Folder where FolderId=@FolderId and FolderOrg=1;", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@FolderId", folderId);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            folderName = (string)reader["FolderTitle"];
                            break;
                        }
                    }
                }
            }

            return folderName;
        }

        private string CheckFolder(string folderName)
        {
            var path = Path.Combine(UserSettings.Path.Replace("/", "\\"), folderName.Replace("/", "\\"));
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                return path;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private IList<string> OutputHistory = new List<string>();

        private void AppendMessage(string itemId, string message)
        {
            var msg = $"{itemId}  {message}";
            if (OutputHistory.Any(m => m == msg))
            {
                return;
            }

            OutputHistory.Add(msg);
            Worker.ReportProgress(0, msg);
        }

        private void FtpDownloadFile(string to_uri, string path, string userName, string password)
        {
            if (File.Exists(path))
            {
                return;
            }

            try
            {
                var request = (FtpWebRequest)WebRequest.Create(to_uri);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(userName, password);

                using (var response = (FtpWebResponse)request.GetResponse())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        using (var fs = new FileStream(path, FileMode.Create))
                        {
                            var buffer = new byte[102400];
                            var read = 0;
                            do
                            {
                                read = responseStream.Read(buffer, 0, buffer.Length);
                                fs.Write(buffer, 0, read);
                                fs.Flush();
                            } while (read != 0);

                            fs.Flush();
                            fs.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Worker.ReportProgress(0, $"{to_uri}\r\n{ex.Message}\r\n{ex.StackTrace}");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (Worker.IsBusy && !Worker.CancellationPending)
            {
                Worker.CancelAsync();
                this.BtnCancel.Text = "Canceling";
            }
        }
    }
}
