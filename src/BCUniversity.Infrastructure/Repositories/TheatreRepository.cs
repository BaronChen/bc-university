using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCUniversity.Domain.TheatreAggregate;
using BCUniversity.Infrastructure.Common;
using BCUniversity.Infrastructure.DataModel;
using BCUniversity.Infrastructure.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace BCUniversity.Infrastructure.Repositories
{
    public class TheatreRepository: RepositoryBase<Theatre>, ITheatreRepository
    {
        public TheatreRepository(UniversityContext dbContext) : base(dbContext)
        {
        }

        public override async Task Save(Theatre theatre)
        {
            TheatreDataModel theatreDataModel = null;
            if (!string.IsNullOrWhiteSpace(theatre.Id))
            {
                theatreDataModel = await _dbContext.Theatres.SingleOrDefaultAsync(x => x.Id == theatre.Id);
            }
            
            if (theatreDataModel == null)
            {
                theatreDataModel = new TheatreDataModel()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = theatre.Name,
                    Capacity = theatre.Capacity
                };
            }

            _dbContext.Theatres.Update(theatreDataModel);
            await _dbContext.SaveChangesAsync();
        }

        public override async Task<Theatre> GetById(string id)
        {
            var theatreDataModel = await _dbContext.Theatres.SingleOrDefaultAsync(x => x.Id == id);

            var theatre = theatreDataModel.ToTheatreAggregate();

            return theatre;
        }

        public override async Task<IEnumerable<Theatre>> ListAll()
        {
            var dataModels = await _dbContext.Theatres.ToListAsync();

            return dataModels.Select(x => x.ToTheatreAggregate()).ToList();
        }
    }
}