using _153504_SIVY.Application.Abstractions;
using _153504_SIVY.Domain.Abstractions;
using _153504_SIVY.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153504_SIVY.Application.Services
{
    public class SongService : ISongService
    {
        private IUnitOfWork _unitOfWork;
        public SongService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(Song item)
        {
            await _unitOfWork.CreateDatabaseAsync();
            await _unitOfWork.SongRepository.AddAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            Song? song = await _unitOfWork.SongRepository.GetByIdAsync(id);
            await _unitOfWork.SongRepository.DeleteAsync(song);
        }

        public async Task<IEnumerable<Song>> GetAllAsync()
        {
            return await _unitOfWork.SongRepository.ListAllAsync();
        }

        public async Task<Song> GetByIdAsync(int id)
        {
            return await _unitOfWork.SongRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Song item)
        {
            await _unitOfWork.SongRepository.UpdateAsync(item);
        }
    }
}
