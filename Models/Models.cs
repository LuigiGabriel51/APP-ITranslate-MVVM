using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace appMVVM.Models
{
    public class Traducao
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string traduzir { get; set; }
        public string traducao { get; set; }
    }
}
