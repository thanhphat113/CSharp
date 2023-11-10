using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    internal class hoadonbandto
    {
        private String mhdb;
        private String mnv;
        private String mkh;
        private String mkm;
        private int tongtien;
        private DateTime ngaytao;

        public hoadonbandto()
        {

        }

        public hoadonbandto(string mhdb, string mnv, string mkh, string mkm, int tongtien, DateTime ngaytao)
        {
            this.Mhdb = mhdb;
            this.Mnv = mnv;
            this.Mkh = mkh;
            this.Mkm = mkm;
            this.Tongtien = tongtien;
            this.Ngaytao = ngaytao;
        }

        public string Mhdb { get => mhdb; set => mhdb = value; }
        public string Mnv { get => mnv; set => mnv = value; }
        public string Mkh { get => mkh; set => mkh = value; }
        public string Mkm { get => mkm; set => mkm = value; }
        public int Tongtien { get => tongtien; set => tongtien = value; }
        public DateTime Ngaytao { get => ngaytao; set => ngaytao = value; }
    }
}
