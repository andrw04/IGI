using _153504_SIVY.Domain.Abstractions;
using _153504_SIVY.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _153504_SIVY.Persistense.Repository
{
    public class FakeSongRepository : IRepository<Song>
    {
        List<Song> _songs = new List<Song>();
        public FakeSongRepository()
        {
            Random rand = new Random();
            int k = 1;
            for(int i = 0; i < 2; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    _songs.Add(new Song() { Id = k,
                        Name = $"Song{k++}",
                        Duration = rand.Next(180, 240),
                        Genre = "Rock",
                        Language = "RU",
                        Position = rand.Next(1,20),
                        PerformerId = i
                    });
                }
            }
        }

        public Task AddAsync(Song entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Song entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Song> FirstOrDefaultAsync(Expression<Func<Song, bool>> filter, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Song> GetByIdAsync(int id, CancellationToken cencellationToken = default, params Expression<Func<Song, object>>[] includesProperties)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Song>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return _songs.ToList();
        }

        public async Task<IReadOnlyList<Song>> ListAsync(Expression<Func<Song, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Song, object>>[]? includesProperties)
        {
            var data = _songs.AsQueryable();
            return data.Where(filter).ToList();
        }

        public Task UpdateAsync(Song entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
