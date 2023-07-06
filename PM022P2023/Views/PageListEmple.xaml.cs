using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM022P2023.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageListEmple : ContentPage
    {
        public PageListEmple()
        {
            InitializeComponent();
        }

        private async void btnconsulta_Clicked(object sender, EventArgs e)
        {
            var url = "https://jsonplaceholder.typicode.com/posts";
            HttpResponseMessage respuesta = null;


            using (HttpClient client = new HttpClient())
            {
                respuesta = await client.GetAsync(url);

                if(respuesta.IsSuccessStatusCode) 
                {
                    var contenido = await respuesta.Content.ReadAsStringAsync();
                }
            }

        }
    }
}