using System.Linq;
using HotChocolate;

using GraphQl.Data;
using GraphQl.Extensions;
using Microsoft.EntityFrameworkCore;
using GraphQl.DataLoader;

namespace GraphQl
{
    public class Query
    {
        [UseApplicationDbContext]
        public Task<List<Speaker>> GetSpeakers([ScopedService] ApplicationDbContext context)
        {
            var speakers = context.Speakers.ToListAsync();
            return speakers;
        }
           


        [UseApplicationDbContext]
        public Task<Speaker> GetSpeakerAsync(
            int id,
            SpeakerByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
        dataLoader.LoadAsync(id, cancellationToken);




    }
}