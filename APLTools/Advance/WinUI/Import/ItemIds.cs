using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using APLTools.Advance.Model;
using Ionic.Zip;

namespace APLTools.Advance.WinUI.Import
{
    public partial class ItemIds : UserControl
    {
        #region fields

        private static int currentSearchStatus = 0;
        private static ItemIds instance;
        private readonly bool NewFxgLogoPanel = true;
        private string _offLineCount = string.Empty;
        private string _onLineCount = string.Empty;
        private List<ImprintFormat> imprintFormat = new List<ImprintFormat>();

        //private BindingList<Model.Devices> devicesBindList = new BindingList<Model.Devices>();
        private List<UserImage> savedArtWorkList = new List<UserImage>();

        #endregion

        #region constructors

        private ItemIds()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        #endregion

        #region properties

        public static ItemIds Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ItemIds();
                }

                return instance;
            }
        }

        #endregion

        #region methods

        /// <summary>
        /// 解压ZIP文件
        /// </summary>
        /// <param name="strZipPath">待解压的ZIP文件</param>
        /// <param name="strUnZipPath">解压的目录</param>
        /// <param name="overWrite">是否覆盖</param>
        /// <returns>成功：true/失败：false</returns>
        public static bool Decompression(string strZipPath, string strUnZipPath, bool overWrite)
        {
            try
            {
                var options = new ReadOptions();
                options.Encoding = Encoding.Default; //设置编码，解决解压文件时中文乱码

                using (var zip = ZipFile.Read(strZipPath, options))
                {
                    foreach (var entry in zip)
                    {
                        if (string.IsNullOrEmpty(strUnZipPath))
                        {
                            strUnZipPath = strZipPath.Split('.')
                                                     .First();
                        }

                        if (overWrite)
                        {
                            entry.Extract(strUnZipPath, ExtractExistingFileAction.OverwriteSilently); //解压文件，如果已存在就覆盖
                        }
                        else
                        {
                            entry.Extract(strUnZipPath, ExtractExistingFileAction.DoNotOverwrite); //解压文件，如果已存在不覆盖
                        }
                    }

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        //http://importdata.amsterdamprinting.inet2/api/CallCmd/source_Live
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var url = ConfigurationManager.AppSettings["ItemDataUrl"];
                var importPath = ConfigurationManager.AppSettings["importPath"].TrimEnd(@"\".ToCharArray());
                var filename = $@"{importPath}\download\" + DateTime.Now.Ticks + ".zip";
                var decompressPath = $@"{importPath}\Data\";

                /*
                //1. download
                DownloadDataZip(url, filename);
                Thread.Sleep(300);

                if (Directory.Exists(decompressPath))
                {
                    var files = new DirectoryInfo(decompressPath).GetFiles();

                    for (var i = 0; i < files.Length; i++)
                    {
                        files[i].Delete();
                    }
                    
                    Directory.Delete(decompressPath);
                }
                Thread.Sleep(300);

                //2. decompress
                Decompression(filename, decompressPath, true);
                Thread.Sleep(300);
                */

                //3. bat
                var destinationServerBat = $@"{importPath}\DestinationServer_nltc550.bat";
                var result = Bat(destinationServerBat);
                richTextBox1.Text += result;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private static void DownloadDataZip(string url, string filename)
        {
            var req = WebRequest.Create(url);
            req.Method = "GET";

            //获得用户名密码的Base64编码  添加Authorization到HTTP头 不需要的账号密码的可以注释下面两行代码
            byte[] fileBytes;

            using (var webRes = req.GetResponse())
            {
                var length = (int)webRes.ContentLength;
                var response = webRes as HttpWebResponse;
                var stream = response?.GetResponseStream();

                if (stream != null)
                {
                    //读取到内存
                    var stmMemory = new MemoryStream();
                    var buffer = new byte[length];
                    int i;

                    //将字节逐个放入到Byte中
                    while ((i = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        stmMemory.Write(buffer, 0, i);
                    }

                    fileBytes = stmMemory.ToArray(); //文件流Byte，需要文件流可直接return，不需要下面的保存代码
                    stmMemory.Close();

                    var m = new MemoryStream(fileBytes);
                    var file = string.Format(filename); //可根据文件类型自定义后缀
                    var fs = new FileStream(file, FileMode.OpenOrCreate);
                    m.WriteTo(fs);
                    m.Close();
                    fs.Close();
                }
            }
        }

        private void PageBar_Load(object sender, EventArgs e)
        {
        }

        private string Bat(string batName)
        {
            try
            {
                var psi = new ProcessStartInfo();
                psi.FileName = batName;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
                psi.RedirectStandardOutput = true;
                var s = "";
                var p = Process.Start(psi);

                //while (p.WaitForExit(0) == false)
                //{
                //    s += p.StandardOutput.ReadLine() + "\r\n";
                //}
                s += p?.StandardOutput?.ReadLine() ?? "" + "\r\n";
                return s;
            }
            catch (Exception ex)
            {
                return $"Exception Occurred :{ex.Message},{ex.StackTrace}：";
            }
        }

        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var psi = new ProcessStartInfo();
                psi.FileName = @"D:\LIDATONG\WK03(MVC EF Study)\test\ImportDate-2017\APL\Itemid\SourceServer_nltc550.bat";
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
                psi.RedirectStandardOutput = true;
                var s = "";
                var p = Process.Start(psi);

                while (p.WaitForExit(0) == false)
                {
                    s += p.StandardOutput.ReadLine() + "\r\n";
                }

                var dd = s;
            }
            catch (Exception ex)
            {
                var s = $"Exception Occurred :{ex.Message},{ex.StackTrace}：";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var downloadurl = "http://apltools.amsterdamprinting.inet2/Content/data/ImportDate-2017/APL/Itemid/data.zip";
            var wc = new WebClient();
            wc.DownloadFile(downloadurl, $@"D:\LIDATONG\WK03(MVC EF Study)\test\{DateTime.Now.Ticks}.zip");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var ids = new[]
                      {
                          "30301",
                          "30302",
                          "30303"
                      };
            var paramsvals = ids.Aggregate(string.Empty,
                                           (x, y) => x + $"('{y}'),").TrimEnd(",".ToCharArray());

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var itemid = txtItemid.Text.Trim();
            var url = ConfigurationManager.AppSettings["ItemIdCheckUrl"].TrimEnd(@"\".ToCharArray())  + itemid;
            var req = WebRequest.Create(url);
            req.Method = "GET";

            using (var webRes = req.GetResponse())
            {
                var response = webRes as HttpWebResponse;
                var streamRead = new StreamReader(response.GetResponseStream(), Encoding.Default);
                var valid = streamRead.ReadToEnd().Trim().GetInt();
                if (valid == 1)
                {
                    listBox1.Items.Add(itemid);
                    txtItemid.Text = string.Empty;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}
