using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkshopBandtecApp.Data;
using WorkshopBandtecApp.Pages.Musicas;
using Xamarin.Forms;

namespace WorkshopBandtecApp.ViewModels.Musicas
{
    sealed class MusicasViewModel : WorkshopBandtecBaseViewModel
    {
        public MusicasViewModel(INavigation pNavigation) : base(pNavigation)
        {
        }

        public ObservableCollection<MusicaDto> Items { get; private set; } = new ObservableCollection<MusicaDto>();

        private Command _RefreshCommand;
        public Command RefreshCommand => this._RefreshCommand ?? (this._RefreshCommand = new Command(async () => await RefreshCommandExecute(), () => RefreshCommandCanExecute()));

        private bool RefreshCommandCanExecute()
        {
            return this.IsNotBusy;
        }

        private async Task RefreshCommandExecute()
        {
            try
            {
                if (this.IsBusy)
                    return;

                this.IsBusy = true;
                this.RefreshCommand.ChangeCanExecute();

                MobileDatabase.Current.Save(await new Client.MusicaClient().Get());

                var _result = await MobileDatabase.Current.Get<MusicaDto>();

                this.Items.Clear();

                foreach (var item in _result)
                {
                    this.Items.Add(item);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                this.IsBusy = false;
                this.RefreshCommand.ChangeCanExecute();
            }
        }


        private Command _NovoCommand;
        public Command NovoCommand => this._NovoCommand ?? (this._NovoCommand = new Command(async () => await NovoCommandExecute()));

        private async Task NovoCommandExecute()
        {
            await this.Navigation.PushAsync(new MusicaPage());
        }

        internal Task Selecionar(MusicaDto pDto)
        {
            return this.Navigation.PushAsync(new MusicaPage(pDto.Id));
        }
    }
}
