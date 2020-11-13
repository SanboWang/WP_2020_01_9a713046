using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("請輸入內容");
                return;
            }
           
            int index = GetHashIndexBymod(textBox1.Text );
            MessageBox.Show( "幸運數字為:"+index );  //輸出視窗結果

        }
        private int GetHashIndexBymod(string inputString, int modNum = 16)
        {
            MD5 md5 = MD5.Create();//建立一個MD5
            byte[] source = Encoding.Default.GetBytes(textBox1.Text);//將字串轉為Byte[]
            byte[] crypto = md5.ComputeHash(source);//進行MD5加密
            string result = Convert.ToBase64String(crypto);//把加密後的字串從Byte[]轉為字串
            label1.Text = ("MD5加密結果為:" + result);
            int value = (int)crypto[12];//固定抓的位置
            int cardIndex = value % 16; // 0-15           
            return value % modNum;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
