using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkshopBandtecApp.Providers;
using Xamarin.Forms;

namespace WorkshopBandtecApp.Data
{
    sealed class MobileDatabase
    {
        private static Lazy<MobileDatabase> _lazy = new Lazy<MobileDatabase>(() => new MobileDatabase());

        public static MobileDatabase Current { get { return _lazy.Value; } }

        private SQLite.Net.SQLiteConnection _SQLiteConnection;

        private MobileDatabase()
        {
            this._SQLiteConnection = DependencyService.Get<ISQLiteConnectionProvider>().GetConnection();

            this._SQLiteConnection.CreateTable<MusicaDto>();
        }

        internal Task<List<TDto>> Get<TDto>() where TDto : BaseDto<TDto>
        {
            return Task.Factory.StartNew(() => { return this._SQLiteConnection.Table<TDto>().ToList(); });
        }

        internal TDto Get<TDto>(Guid pId) where TDto : BaseDto<TDto>
        {
            return this._SQLiteConnection.Table<TDto>().FirstOrDefault(lbda => lbda.Id == pId);
        }

        internal void Save<TDto>(BaseDto<TDto> pDto) where TDto : BaseDto<TDto>
        {
            this._SQLiteConnection.InsertOrReplace(pDto);
        }

        internal void Save<TDto>(List<TDto> pDtoCollection) where TDto : BaseDto<TDto>
        {
            this._SQLiteConnection.InsertOrReplaceAll(pDtoCollection);
        }
    }
}
