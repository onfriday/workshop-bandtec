using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopBandtecApp.Data
{
    sealed class MusicaDto : BaseDto<MusicaDto>
    {
        public string Trilha { get; set; }
        public string Nome { get; set; }
        public string Duracao { get; set; }
    }
}
