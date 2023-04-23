using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _153504_SIVY.Domain.Entities;

namespace _153504_SIVY.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<Song> SongRepository { get; }
        IRepository<Performer> PerformerRepository { get; }
        public Task RemoveDatabaseAsync();
        public Task CreateDatabaseAsync();
        public Task SaveAllAsync();
    }
}
