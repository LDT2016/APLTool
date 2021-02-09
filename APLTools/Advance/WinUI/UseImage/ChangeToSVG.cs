using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using APLTools.Advance.Common;
using APLTools.Advance.Model;
using APLTools.Logic;
using APLTools.Models;
using DMS;
using Svg;

namespace APLTools.Advance.WinUI.UseImage
{
    public partial class ChangeToSVG : UserControl
    {
        #region fields

        private static ChangeToSVG instance;
        private List<UserImage> sharedArtWorkList = new List<UserImage>();
        private static List<CListItem> vendorlist = new List<CListItem>();
        #endregion

        #region constructors

        private ChangeToSVG()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        #endregion

        #region properties

        public static ChangeToSVG Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ChangeToSVG();
                }

                return instance;
            }
        }

        #endregion


        private void button1_Click_1(object sender, EventArgs e)
        {
            //SvgDocument svgDocument = SvgDocument.Open(@"D:\Projects\Git\websites\configurator-web\Configurator.Web\ClientApp\build\resources\assets\imprint\location\APRON_001.jpg");
        }
    }
}
