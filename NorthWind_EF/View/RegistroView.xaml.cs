using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NorthWind_EF.View;
using NorthWind_EF.Model;
using System.Collections.ObjectModel;

namespace NorthWind_EF.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroView : ContentPage
    {
        CRUD Database = new CRUD();
        public RegistroView()
        {
            InitializeComponent();

            List<CategoriaModel> categorias = new List<CategoriaModel>(); 
            categorias = Database.ReadCategories();
            CategoriaLV.ItemsSource = categorias;
        }

        private void VerCat_Clicked(object sender, EventArgs e)
        {
            CategoriaLV.IsVisible = true;
            ProductosLV.IsVisible = false;
        }

        private void AñadirBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new IngresoView());
        }

        private void CategoriaLV_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            CategoriaModel categoriaelegida = new CategoriaModel();
            categoriaelegida = (CategoriaModel)e.SelectedItem;
            int idcategoria = categoriaelegida.IdC;
            List<ProductosModel> productosAMostrar = new List<ProductosModel>();
            productosAMostrar = Database.ReadProductsByIdCategory(idcategoria);


            ProductosLV.ItemsSource = productosAMostrar;

            CategoriaLV.IsVisible = false;
            ProductosLV.IsVisible = true;
        }
    }
}

 