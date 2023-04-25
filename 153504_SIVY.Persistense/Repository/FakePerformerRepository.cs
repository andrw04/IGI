using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using _153504_SIVY.Domain.Abstractions;
using _153504_SIVY.Domain.Entities;

namespace _153504_SIVY.Persistense.Repository
{
    public class FakePerformerRepository : IRepository<Performer>
    {
        List<Performer> _performers;

        public FakePerformerRepository()
        {
            _performers = new List<Performer>()
            { 
                new Performer() { Id = 0, Name = "Performer1", Nationality = "BY",
                    DebuteDate = 2004 },
                new Performer(){ Id = 1, Name = "Performer2", Nationality = "RU",
                    DebuteDate = 2010 }
            };
        }

        public Task AddAsync(Performer entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Performer entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Performer> FirstOrDefaultAsync(Expression<Func<Performer, bool>> filter, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Performer> GetByIdAsync(int id, CancellationToken cencellationToken = default, params Expression<Func<Performer, object>>[] includesProperties)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Performer>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await Task.Run(() => _performers);
        }

        public Task<IReadOnlyList<Performer>> ListAsync(Expression<Func<Performer, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Performer, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Performer entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
