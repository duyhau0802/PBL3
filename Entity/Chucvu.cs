using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PBL3.Entity
{
    internal class Chucvu
    {
        private int _id;
        private string _tenchucvu;
        private double _luong;

        public Chucvu(int id, string tenchucvu, double luong)
        {
            _id = id;
            _tenchucvu= tenchucvu;
            _luong = luong;
        }

        public int Id { get => _id; set => _id = value; }
        public string Tenchucvu { get => _tenchucvu; set => _tenchucvu = value; }
        public double Luong { get => _luong; set => _luong = value; }


    }
}
