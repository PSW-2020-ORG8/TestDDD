using Backend.Model.PatientDoctor;
using IntegrationAdapters.Dto;

namespace IntegrationAdapters.Mapper
{
    public class EPrescriptionMapper 
    {
        public static EPrescriptionDto EPrescriptionToEPresctriptionDto(EPrescription ePrescription)
        {
            EPrescriptionDto dto = new EPrescriptionDto();
            dto.Id = ePrescription.Id;
            dto.PatientId = ePrescription.PatientId;
            dto.PatientName = ePrescription.PatientName;
            dto.Comment = ePrescription.Comment;
            dto.MedicamentName = ePrescription.MedicamentName;
            dto.PublishingDate = ePrescription.PublishingDate;
            return dto;
        }

        public static EPrescription EPrescriptionDtoToEPrescription(EPrescriptionDto dto)
        {
            EPrescription newEPrescriptions = new EPrescription();
            newEPrescriptions.PatientName = dto.PatientName;
            newEPrescriptions.MedicamentName = dto.MedicamentName;
            newEPrescriptions.Comment = dto.Comment;
            newEPrescriptions.PublishingDate = dto.PublishingDate;
            return newEPrescriptions;
        }
    }
}
