using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NorthWind_EF.Model;
using System.Collections;
using System.Collections.ObjectModel;

namespace NorthWind_EF.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IngresoView : ContentPage
    {
        public IngresoView()
        {
            InitializeComponent();
        }
        ObservableCollection<ProductosModel> productos_ = new ObservableCollection<ProductosModel>();
        private void VerBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistroView());
        }

        private void GuardarBtn_Clicked(object sender, EventArgs e)
        {

            CRUD Database = new CRUD();

            CategoriaModel NewCategory = new CategoriaModel();
            NewCategory.NameC = EntryCategoria.Text;
            NewCategory.DescriptionC = EntryDescripcion.Text;

            int IdCategoria = Database.InsertarCategoria(NewCategory);
            if (IdCategoria != -1)
            {
                foreach (ProductosModel ProductoAInsertar in productos_)
                {
                    ProductoAInsertar.IdCategoria = NewCategory.IdC;
                    Database.InsertProduct(ProductoAInsertar);
                }
                Navigation.PushAsync(new RegistroView());
            }
            else
            {
                DisplayAlert("Error", "No se ha podido realizar el registro", "Ok");
            }

        }

        private void AddBtn_Clicked(object sender, EventArgs e)
        {
            ProductosModel Agregar = new ProductosModel();
            Agregar.NombreProducto = EntryProducto.Text;
            EntryProducto.Text = "";
            productos_.Add(Agregar);
            Productos.ItemsSource = productos_;
        }
    }
}