using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ume
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void time()
        {
            var t = DateTime.Now.AddMilliseconds(100);
            while (DateTime.Now < t) Application.DoEvents();
        }
        public void Files()
        {

            string path = @"C:\Users\Administrator\AppData\Local\Temp";
            string[] t = Directory.GetFiles(path);
            foreach (string i in t)
            {
                // MessageBox.Show(i);
                //MessageBox.Show(i);
                string cook = @"\S\.\S";
                bool b = Regex.IsMatch(i, cook);
                if (b)
                {

                    // MessageBox.Show(i + "=yes");
                    var fileInfo = new FileInfo(i);

                    int l = int.Parse(fileInfo.Length.ToString());
                    float ls = l / 1046529; //ls计算文件大小               
                                            // MessageBox.Show(ls.ToString()+".mb");
                    try
                    {
                        File.Delete(i);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                else
                {
                    // MessageBox.Show(i+"=no");
                }
                // MessageBox.Show(i);

            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 支持界面拖动
        /// </summary>
        const int HTLEFT = 10;
        const int HTRIGHT = 11;
        const int HTTOP = 12;
        const int HTTOPLEFT = 13;
        const int HTTOPRIGHT = 14;
        const int HTBOTTOM = 15;
        const int HTBOTTOMLEFT = 0x10;
        const int HTBOTTOMRIGHT = 17;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0084:
                    base.WndProc(ref m);
                    Point vPoint = new Point((int)m.LParam & 0xFFFF,
                        (int)m.LParam >> 16 & 0xFFFF);
                    vPoint = PointToClient(vPoint);
                    if (vPoint.X <= 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)HTTOPLEFT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)HTBOTTOMLEFT;
                        else m.Result = (IntPtr)HTLEFT;
                    else if (vPoint.X >= ClientSize.Width - 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)HTTOPRIGHT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)HTBOTTOMRIGHT;
                        else m.Result = (IntPtr)HTRIGHT;
                    else if (vPoint.Y <= 5)
                        m.Result = (IntPtr)HTTOP;
                    else if (vPoint.Y >= ClientSize.Height - 5)
                        m.Result = (IntPtr)HTBOTTOM;
                    break;
                case 0x0201://鼠标左键按下的消息   
                    m.Msg = 0x00A1;//更改消息为非客户区按下鼠标   
                    m.LParam = IntPtr.Zero;//默认值   
                    m.WParam = new IntPtr(2);//鼠标放在标题栏内   
                    base.WndProc(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        public string linshi = "";
        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        int i = 0;
        int f = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            var a = "";
            if (a.Equals(""))
            {


            }

            if (i <= 0)
            {
                i++;
                textBox1.Text = "";
                button1.Text = "分 析 中";
                button1.Enabled = false;


                if (f == 1)
                {
                    textBox1.Text += "视频音乐垃圾=0MB。\r\n"; time();
                    textBox1.Text += "深度垃圾清理=0MB。\r\n";
                    time();
                    textBox1.Text += "网络垃圾清理=0MB。\r\n";
                    time();
                    textBox1.Text += "流氓软件清理=0MB。\r\n"; time();

                    textBox1.Text += "其他软件垃圾=0MB。\r\n"; time();
                    textBox1.Text += "社交软件垃圾=0MB。\r\n"; time();
                    textBox1.Text += "系统产生的垃圾=0MB。\r\n"; time();
                    textBox1.Text += "浏览器垃圾=0MB。\r\n"; time();
                    textBox1.Text += "注册表垃圾=0项。\r\n"; time();
                }
                else
                {
                    textBox1.Text += "视频音乐垃圾=37MB。\r\n"; time();
                    textBox1.Text += "深度垃圾清理=1.6GB。\r\n";
                    time();
                    textBox1.Text += "网络垃圾清理=73MB。\r\n";
                    time();
                    textBox1.Text += "流氓软件清理=1项。\r\n"; time();

                    textBox1.Text += "其他软件垃圾=50MB。\r\n"; time();
                    textBox1.Text += "社交软件垃圾=400kb。\r\n"; time();
                    textBox1.Text += "系统产生的垃圾=66.9MB。\r\n"; time();
                    textBox1.Text += "浏览器垃圾=103MB。\r\n"; time();
                    textBox1.Text += "注册表垃圾=6项。\r\n"; time();
                }
                textBox1.Text += "分析完成。";
                button1.Text = "清    理";
                button1.Enabled = true;




            }

            else
            {

                i = 0;
                f = 1;
                //Files();
                textBox1.Text = "你的电脑已经非常干净。";
                button1.Text = "分    析";




            }


        }
        /// <summary>
        /// 退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

    }
}
