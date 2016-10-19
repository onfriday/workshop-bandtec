using SQLite.Net.Attributes;
using System;

namespace WorkshopBandtecApp.Data
{
    abstract class BaseDto<TDto> where TDto : BaseDto<TDto>
    {
        [PrimaryKey]
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
