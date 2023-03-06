namespace NTNP.AppServices.VocabularyAppServices.Dtos.RequestDtos
{
    public class UpdateVocabularyRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Transcript { get; set; }
        public bool Deleted { get; set; }
        public string Path { get; set; } = string.Empty;
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }

        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<CreateVocabularyRequest, EFCore.Models.Vocabularies.Vocabulary>()
                .ForMember(
                    dest => dest.Name,
                    options => options.MapFrom(source => source.Name))
                .ForMember(
                    dest => dest.Transcript,
                    options => options.MapFrom(source => source.Transcript))
                .ForMember(
                    dest => dest.Deleted,
                    options => options.MapFrom(source => source.Deleted))
                .ForMember(
                    dest => dest.Path,
                    options => options.MapFrom(source => source.Path))
                .ForMember(
                    dest => dest.Comment,
                    options => options.MapFrom(source => source.Comment))
                .ForMember(
                    dest => dest.CreatedAt,
                    options => options.MapFrom(source => source.CreatedAt));
        }
    }
}
