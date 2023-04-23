using _153504_SIVY.MyApplication.Abstractions;
using _153504_SIVY.Domain.Abstractions;
using _153504_SIVY.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153504_SIVY.MyApplication.Services
{
    public class PerformerService : IPerformerService
    {
        private IUnitOfWork _unitOfWork;
        public PerformerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(Performer item)
        {
            await _unitOfWork.PerformerRepository.AddAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            Performer? performer = await _unitOfWork.PerformerRepository.GetByIdAsync(id);
            await _unitOfWork.PerformerRepository.DeleteAsync(performer);
        }

        public async Task<IEnumerable<Performer>> GetAllAsync()
        {
            return await _unitOfWork.PerformerRepository.ListAllAsync();
        }

        public async Task<Performer> GetByIdAsync(int id)
        {
            return await _unitOfWork.PerformerRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Performer item)
        {
            await _unitOfWork.PerformerRepository.UpdateAsync(item);
        }
    }
}
