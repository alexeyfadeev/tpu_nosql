using System;
using AutoMapper;

namespace Tpu.NoSql.CatalogImporter
{
    public class CommonMapper
    {
        static CommonMapper()
        {
            Mapper.CreateMap<Offer, Tpu.NoSql.Sql.Offer>().ForMember(d => d.BarCode, m => m.MapFrom(s => s.BarCode));
        }
        
        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);
        }
    }
}
