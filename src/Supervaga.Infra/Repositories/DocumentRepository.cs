using Domain.Shared.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using Supervaga.Domain.Documents;
using Supervaga.Infra.Data.DataContexts;

namespace Infra.Repositories
{
    public class DocumentRepository : IRepository<Document>
    {
        public DocumentRepository(DataContext context)
        {
            this.context = context;
        }

        private readonly DataContext context;

        public async Task<List<Document>> Get(int page, int limit)
        {
            var docs = await context.Documents!
                .AsNoTracking()
                .Skip(page * limit)
                .Take(limit)
                .ToListAsync();

            return docs;
        }

        public async Task<Document> Get(Guid id)
        {
            var doc = await context.Documents!
                .AsNoTracking()
                .FirstOrDefaultAsync(DocumentQueries.Get(id));

            return doc!;
        }

        public Task<Document> Get(string email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task Create(Document value)
        {
            context.Documents!.Add(value);
            await context.SaveChangesAsync();
        }

        public async Task Update(Document value)
        {
            context.Entry<Document>(value).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task Delete(Document doc)
        {
            context.Documents!.Remove(doc);
            await context.SaveChangesAsync();
        }

        public async Task<List<Document>> Search(string key, int page, int limit)
        {
            var docs = await context.Documents!
                .AsNoTracking()
                .AsQueryable()
                .Where(DocumentQueries.Get(key))
                .ToListAsync();

            return docs!;
        }

    }
}