using _153504_SIVY.Domain.Abstractions;
using _153504_SIVY.Domain.Entities;
using _153504_SIVY.Persistense.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153504_SIVY.Persistense.Repository
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        private readonly Lazy<IRepository<Performer>> _performerRepository;
        private readonly Lazy<IRepository<Song>> _songRepository;
        public FakeUnitOfWork()
        {
            _performerRepository = new Lazy<IRepository<Performer>>(() => new FakePerformerRepository());
            _songRepository = new Lazy<IRepository<Song>>(() => new FakeSongRepository());
        }

        public IRepository<Song> SongRepository => _songRepository.Value;

        public IRepository<Performer> PerformerRepository => _performerRepository.Value;

        public async Task CreateDatabaseAsync()
        {
            throw new NotImplementedException();
        }

        public async Task RemoveDatabaseAsync()
        {
            throw new NotImplementedException();
        }

        public async Task SaveAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
