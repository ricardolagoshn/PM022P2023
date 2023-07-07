using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM022P2023.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageListAlumn : ContentPage
    {
        public PageListAlumn()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            List<Models.Alumnos> alumnos= new List<Models.Alumnos>();
            alumnos = await Controllers.AlumController.GetAlumnos();
            listalumn.ItemsSource = alumnos;
        }
    }
}