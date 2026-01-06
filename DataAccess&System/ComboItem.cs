using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_System
{
    public class ComboItem
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public override string ToString() => Name;

        public ComboItem() { }
        public ComboItem(int id, string? name)
        {
            Id = id;
            Name = name;
        }
    }
}
