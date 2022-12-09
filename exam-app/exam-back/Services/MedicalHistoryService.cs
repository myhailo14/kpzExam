using AutoMapper;
using exam_back.DB;
using exam_back.DTOs;
using exam_back.Models;
using Microsoft.EntityFrameworkCore;

namespace exam_back.Services
{
    public interface IMedicalHistoryService
    {
        Task<MedicalHistory?> GetHistoryById(Guid id);
        IQueryable<MedicalHistory?> GetAllHistories();
        IQueryable<MedicalHistory?> GetPatientsHistories(Guid patientId);

        Task AddHistory(MedicalHistoryDto history);
        Task UpdateHistory(MedicalHistoryDto history);

        Task<bool> DeleteHistory(Guid id);
    }

    public class MedicalHistoryService : IMedicalHistoryService
    {
        private readonly DbSet<MedicalHistory> _histories;
        private readonly DentistDbContext _context;
        private readonly IMapper _mapper;

        public MedicalHistoryService(DentistDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _histories = context.Set<MedicalHistory>();
        }

        public async Task<MedicalHistory?> GetHistoryById(Guid id)
        {
            return await _histories.FirstOrDefaultAsync(mh => mh.Id == id);
        }

        public IQueryable<MedicalHistory?> GetAllHistories()
        {
            return _histories.AsQueryable();
        }

        public IQueryable<MedicalHistory?> GetPatientsHistories(Guid patientId)
        {
            return _histories.Where(h => h.PatientId == patientId).AsQueryable();
        }

        public async Task AddHistory(MedicalHistoryDto history)
        {
            var newHistory = _mapper.Map<MedicalHistory>(history);
            await _context.AddAsync(newHistory);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateHistory(MedicalHistoryDto history)
        {
            if (!await _histories.AnyAsync(h => h.Id == history.Id))
            {
                throw new ArgumentException($"Medical history with Id {history.Id} does not exist.");
            }

            var newHistory = _mapper.Map<MedicalHistory>(history);
            _context.Update(newHistory);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteHistory(Guid id)
        {
            var history = await GetHistoryById(id);
            if (history is null)
            {
                return false;
            }

            _context.Remove(history);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
