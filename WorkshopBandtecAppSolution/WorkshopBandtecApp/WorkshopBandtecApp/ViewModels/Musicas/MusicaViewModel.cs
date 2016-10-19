using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkshopBandtecApp.Data;
using Xamarin.Forms;

namespace WorkshopBandtecApp.ViewModels.Musicas
{
    sealed class MusicaViewModel : WorkshopBandtecBaseViewModel
    {
        private readonly MusicaDto _Dto;

        public MusicaViewModel(INavigation pNavigation, Guid? pId = null) : base(pNavigation)
        {
            if (pId.HasValue)
                this._Dto = MobileDatabase.Current.Get<MusicaDto>(pId.Value);

            if (this._Dto == null)
                this._Dto = new MusicaDto();
        }

        //<Entry Text="{Binding Trilha}" />
        public string Trilha
        {
            get { return this._Dto.Trilha; }
            set
            {
                this._Dto.Trilha = value;
                OnPropertyChanged();
            }
        }

        //<Entry Text="{Binding Nome}" />
        public string Nome
        {
            get { return this._Dto.Nome; }
            set
            {
                this._Dto.Nome = value;
                OnPropertyChanged();
            }
        }

        //<Entry Text="{Binding Duracao}" />
        public string Duracao
        {
            get { return this._Dto.Duracao; }
            set
            {
                this._Dto.Duracao = value;
                OnPropertyChanged();
            }
        }

        private Command _SalvarCommand;

        public Command SalvarCommand => this._SalvarCommand ?? (this._SalvarCommand = new Command(async () => await SalvarCommandExecute()));

        private async Task SalvarCommandExecute()
        {
            try
            {
                MobileDatabase.Current.Save(this._Dto);

                await new Client.MusicaClient().Post(this._Dto);

                await this.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Ah não", "Algo de errado não deu certo!", "Blz então");
            }
        }
    }
}
