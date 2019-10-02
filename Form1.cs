using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Тренировка00
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void Button1_Click(object sender, EventArgs a)
        {
            string url = "https://download.virtualbox.org/virtualbox/6.0.10/VirtualBox-6.0.10-132072-Win.exe";
            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.OpenRead(url);
                    string size = (Convert.ToDouble(wc.ResponseHeaders["Content-Length"]) / 1048576).ToString("#.#");
                    wc.DownloadProgressChanged += (s, e) =>
                    {
                        label1.Text = $"Размер файла: {size}\n Загружено:{e.ProgressPercentage}%({((double)e.BytesReceived / 1048576).ToString("#.#")})";
                        progressBar1.Value = e.ProgressPercentage;
                    };
                    wc.DownloadFileAsync(new Uri(url), @"C:\Users\magom\Desktop\VirtualBox 6.0.10.exe");

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
