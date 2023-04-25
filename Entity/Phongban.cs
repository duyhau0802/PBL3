using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.Entity
{
    internal class Phongban
    {
        private int _id;
        private string _name;
        private int _truongphong;

        public Phongban(string name, int truongphong)
        {
            _name = name;
            _truongphong = truongphong;
        }

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public int Truongphong { get => _truongphong; set => _truongphong = value; }
    }
}
