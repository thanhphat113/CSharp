using Doanqlchdt.BUS;
using Doanqlchdt.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doanqlchdt.GUI
{

    public partial class sanphamgui : Form
    {
        static sanphambus spb = new sanphambus();
        private Boolean timkiem = false;
        private Boolean sx = false;
        private Boolean temppage = true;
        private Boolean side = false;
        private int totalpage = 0;
        private static int record = 23;
        private static int temp = 1;
        private static int ofset = (temp - 1) * record;
        private String tenlcsx = "";
        private String loaisx = "";
        private String tempsx = "";
        private String temploaisx = "";

        private String ketquatim = "";
        private String ten = "";
        private int totalpageorder = 0;
        private static int recordorder = 3;
        private static int temporder = 1;
        private static int ofsetorder = (temporder - 1) * recordorder;
        private ArrayList ds = spb.getdsfrompage(ofset, record);
        private System.Windows.Forms.Button[] btnarray;
        private System.Windows.Forms.Button[] btnarrayod;
       private ImageList imgs = new ImageList();
     
        public sanphamgui()
        {
            InitializeComponent();
            imgs.ImageSize = new Size(30, 30);
            listView1.SmallImageList = imgs;
            loadtable();
            listView1.Columns[0].DisplayIndex = 6;
        }
        public Image ByteArraytoimage(byte[]b)
        {
            MemoryStream m=new MemoryStream(b);
            return Image.FromStream(m);

        }
        public void loadtable()
        {
            //setvisiblebutonpage(totalpageorder, btnarrayod);
            ofset = (temp - 1) * record;
            sanphambus spbus=new sanphambus();
            ds.Clear();
            if (sx == false)
            {
                ds = spbus.getdsfrompage(ofset, record);
            }
            //else
            //{
            //    ds = khb.getdspagesx(tenlcsx, loaisx, ofset, record);
            //}
            listView1.Items.Clear();
            foreach (sanphamdto spdto in ds)
            {
                imgs.Images.Clear();
                imgs.Images.Add(ByteArraytoimage(spdto.Hinhanh));
                ListViewItem ls = new ListViewItem();
                ls.SubItems.Add(spdto.Tensp);
                ls.SubItems.Add(spdto.Maloai);
                ls.SubItems.Add(spdto.Gianhap.ToString());
                ls.SubItems.Add(spdto.Giaban.ToString());
                ls.SubItems.Add(spdto.Mota);
                ls.SubItems.Add(spdto.Masp);
                ls.SubItems.Add(spdto.Soluong.ToString());
                ls.ImageIndex = 0;
                listView1.Items.Add(ls);
                
            }

        }
    }
}
