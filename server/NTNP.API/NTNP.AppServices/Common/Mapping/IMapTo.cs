using AutoMapper;

namespace NTNP.AppServices.Common.Mapping
{
    public interface IMapTo<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(GetType(), typeof(T));
    }
}
