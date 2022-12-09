using AutoMapper;
using exam_back.DTOs;
using exam_back.Models;

namespace exam_back.Mapping
{
    public class Mapping
    {
        public static IMapper Create()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PatientDto, Patient>();
                cfg.CreateMap<MedicalHistoryDto, MedicalHistory>();
                
            });
            return config.CreateMapper();

        }
    }
}
