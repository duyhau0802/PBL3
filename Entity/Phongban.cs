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
        private int _leader;

        public Phongban(int id, string name, int leader)
        {
            _id = id;
            _name = name;
            _leader = leader;
        }

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public int Leader { get => _leader; set => _leader = value; }
    }
}
