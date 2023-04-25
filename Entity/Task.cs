using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.Entity
{
    internal class Task
    {
        private int id;
        private string detail;
        private DateTime deadline;
        private int id_nv;
        private int id_status;

        public Task(int id, string detail, DateTime deadline, int id_nv, int id_status)
        {
            this.Id = id;
            this.Detail = detail;
            this.Deadline = deadline;
            this.Id_nv = id_nv;
            this.Id_status = id_status;
        }

        public int Id { get => id; set => id = value; }
        public string Detail { get => detail; set => detail = value; }
        public DateTime Deadline { get => deadline; set => deadline = value; }
        public int Id_nv { get => id_nv; set => id_nv = value; }
        public int Id_status { get => id_status; set => id_status = value; }
    }
}
