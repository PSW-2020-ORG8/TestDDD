using UserMicroservice.Domain;
using UserMicroservice.Dto;

namespace UserMicroservice.Mapper
{
    public class SpecializationMapper
    {
        public static Specialitation SpecializationDtoToSpecialization(SpecializationDto dto)
        {
            Specialitation specialization = new Specialitation();
            specialization.Id = dto.Id;
            specialization.SpecialitationForDoctor = dto.SpecialitationForDoctor;
            return specialization;
        }

        public static SpecializationDto SpecializationToSpecializationDto(Specialitation specialization)
        {
            SpecializationDto dto = new SpecializationDto();
            dto.Id = specialization.Id;
            dto.SpecialitationForDoctor = specialization.SpecialitationForDoctor;
            return dto;
        }
    }
}
