using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.IO;
using NorthWind_EF.Model;

namespace NorthWind_EF.Model
{
    public class CRUD
    {
        public SQLiteConnection BaseDeDatos;

        public CRUD()
        {
            string Conexion = Path.Combine(Environment.GetFolderPath
           (Environment.SpecialFolder.LocalApplicationData), "NorthWindEF.db3");
            BaseDeDatos = new SQLiteConnection(Conexion);
            BaseDeDatos.CreateTable<CategoriaModel>();
            BaseDeDatos.CreateTable<ProductosModel>();
        }

        public int InsertarCategoria(CategoriaModel Categoria_)
        {
            return BaseDeDatos.Insert(Categoria_);
        }

        public int InsertProduct(ProductosModel Productos_)
        {
            return BaseDeDatos.Insert(Productos_);
        }

        ////////////////////////////////////////////////////////////////

        public CategoriaModel LeerCategoria ( int IdCategoria )
        {
            return BaseDeDatos.Table<CategoriaModel>().Where(n => n.IdC == IdCategoria).FirstOrDefault();
        }

        ///LEER TODOS

        public List<CategoriaModel> ReadCategories()
        {
            return BaseDeDatos.Table<CategoriaModel>().ToList();
        }

        ///LEER 1

        public ProductosModel ReadProduct(int IdProduct)
        {
            return BaseDeDatos.Table<ProductosModel>().Where(n => n.IdProductos == IdProduct).FirstOrDefault();
        }

        ///LEER TODOS

        public List<ProductosModel> ReadProducts()
        {
            return BaseDeDatos.Table<ProductosModel>().ToList();
        }

        public List<ProductosModel> ReadProductsByIdCategory(int idcategoria)
        {
            //            return BaseDatos.Table<Products>().ToList();
            return BaseDeDatos.Table<ProductosModel>().Where(n => n.IdCategoria == idcategoria).ToList();
        }
    }
}
