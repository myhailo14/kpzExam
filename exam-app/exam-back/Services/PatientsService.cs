using AutoMapper;
using exam_back.DB;
using exam_back.DTOs;
using exam_back.Models;
using Microsoft.EntityFrameworkCore;

namespace exam_back.Services
{
    public interface IPatientService
    {
        Task<Patient?> GetPatientById(Guid id);
        IQueryable<Patient?> GetAllPatients();

        Task AddPatient(PatientDto patient);
        Task UpdatePatient(PatientDto patient);

        Task<bool> DeletePatient(Guid id);
    }

    public class PatientsService : IPatientService
    {
        private readonly DbSet<Patient> _patients;
        private readonly DentistDbContext _context;
        private readonly IMapper _mapper;

        public PatientsService(DentistDbContext context, IMapper mapper)
        {
            _patients = context.Set<Patient>();
            _context = context;
            _mapper = mapper;
        }

        public async Task<Patient?> GetPatientById(Guid id)
        {
            return await _patients.FirstOrDefaultAsync(p => p.Id == id);
        }

        public IQueryable<Patient?> GetAllPatients()
        {
            return _patients.AsQueryable();
        }

        public async Task AddPatient(PatientDto patient)
        {

            var newPatient = _mapper.Map<Patient>(patient);
            await _context.AddAsync(newPatient);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePatient(PatientDto patient)
        {
            if (!await _patients.AnyAsync(p => p.Id == patient.Id))
            {
                throw new ArgumentException($"Patient with id {patient.Id} does not exist.");
            }

            var newPatient = _mapper.Map<Patient>(patient);
            _context.Update(newPatient);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeletePatient(Guid id)
        {
            var patient = await GetPatientById(id);
            if (patient is null)
            {
                return false;
            }

            _context.Remove(patient);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
