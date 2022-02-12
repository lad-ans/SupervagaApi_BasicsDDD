using System.Linq.Expressions;

namespace Supervaga.Domain.Documents
{
    public static class DocumentQueries
    {
        public static Expression<Func<Document, bool>> Get(Guid id)
        {
            return x => x.Id == id;
        }

        public static Expression<Func<Document, bool>> Get(string fileName)
        {
            return x => x.FileName == fileName;
        }
    }
}