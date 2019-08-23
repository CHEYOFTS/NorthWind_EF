using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace NorthWind_EF.Model
{
    public class CategoriaModel
    {
        [PrimaryKey, AutoIncrement]
        public int IdC { get; set; }
        public string NameC { get; set; }
        public string DescriptionC { get; set; }
    }
}
