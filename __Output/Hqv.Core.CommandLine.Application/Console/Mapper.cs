using AutoMapper;
using IMapper = AutoMapper.IMapper;

namespace $safeprojectname$
{
    public class Mapper : Hqv.CSharp.Common.Map.IMapper
    {
        private readonly MapperConfiguration _mapperConfiguration;
        private readonly IMapper _mapper;

        public Mapper()
        {
            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                // todo: add mappings
            });
            _mapper = _mapperConfiguration.CreateMapper();
        }

        public TT Map<TT>(object source)
        {
            return _mapper.Map<TT>(source);
        }

        public void Map<TU, TT>(TU source, TT destination)
        {
            _mapper.Map(source, destination);
        }

        public void AssertConfigurationIsValid()
        {
            _mapperConfiguration.AssertConfigurationIsValid();
        }
    }
}