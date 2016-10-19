using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkshopBandtecApp.Data;
using WorkshopBandtecApp.ViewModels.Musicas;
using Xamarin.Forms;

namespace WorkshopBandtecApp.Pages.Musicas
{
    public partial class MusicasPage : ContentPage
    {
        public MusicasPage()
        {
            InitializeComponent();

            this.BindingContext = new MusicasViewModel(this.Navigation);
        }

        //ItemTapped="Handle_ItemTapped"
        void Handle_ItemTapped(object sender, ItemTappedEventArgs e) => ((ListView)sender).SelectedItem = null;

        //ItemSelected="Handle_ItemSelected"
        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                var _selected = ((ListView)sender).SelectedItem as MusicaDto;

                if (_selected == null)
                    return;

                await ((MusicasViewModel)this.BindingContext).Selecionar(_selected);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected override void OnAppearing()
        {
            ((MusicasViewModel)this.BindingContext).RefreshCommand.Execute(null);
        }
    }
}
