using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkshopBandtecApp.ViewModels.Musicas;
using Xamarin.Forms;

namespace WorkshopBandtecApp.Pages.Musicas
{
    public partial class MusicaPage : ContentPage
    {
        public MusicaPage(Guid? pId = null)
        {
            InitializeComponent();

            this.BindingContext = new MusicaViewModel(this.Navigation, pId);
        }
    }
}
