using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_System
{
    public class ComboItem
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public ComboItem(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
