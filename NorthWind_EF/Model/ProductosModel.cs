using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace NorthWind_EF.Model
{
    [Table(nameof(ProductosModel))]
    public class ProductosModel : BaseClassModel
    {
        private int IdProducto_;
        [PrimaryKey, AutoIncrement]
        public int IdProductos
        {
            get { return IdProducto_; }
            set { IdProducto_ = value; OnPropertyChanged(); }
        }
        /////////////////////////////////////////////////////////////
        private string NombreProducto_;
        public string NombreProducto
        {
            get { return NombreProducto_; }
            set { NombreProducto_ = value; OnPropertyChanged(); }
        }
        /////////////////////////////////////////////////////////////

        private int IdCategoria_;
        public int IdCategoria
        {
            get { return IdCategoria_; }
            set { IdCategoria_ = value; OnPropertyChanged(); }
        }

    }
}

