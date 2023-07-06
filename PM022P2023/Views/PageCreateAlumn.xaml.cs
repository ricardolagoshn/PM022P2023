using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using System.IO;

namespace PM022P2023.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageCreateAlumn : ContentPage
    {
        Plugin.Media.Abstractions.MediaFile photo = null;
        public PageCreateAlumn()
        {
            InitializeComponent();
        }

        public String Getimage64()
        {
            if (photo != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = photo.GetStream();
                    stream.CopyTo(memory);
                    byte[] fotobyte = memory.ToArray();

                    String Base64 = Convert.ToBase64String(fotobyte);

                    return Base64;
                }
            }

            return null;
        }

        private async void btnfoto_Clicked(object sender, EventArgs e)
        {
            photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "MYAPP",
                Name = "Foto.jpg",
                SaveToAlbum = true
            });

            if (photo != null)
            {
                foto.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
            }
        }

        private async void btnguardar_Clicked(object sender, EventArgs e)
        {
            var alum = new Models.Alumnos
            {
                nombres = nombres.Text,
                apellidos = apellidos.Text,
                direccion = direccion.Text,
                telefono    = Convert.ToInt32(telefono.Text),
                foto = Getimage64()
            };

            Models.Msg resultado = await Controllers.AlumController.CreateAlum(alum);
            if (resultado != null) 
            {
                await DisplayAlert("Aviso", resultado.message.ToString(), "OK");
            }

        }



    }
}