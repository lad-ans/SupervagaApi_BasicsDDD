namespace Domain.Shared.Contracts.Repositories
{
    public interface IRepository<T>
    {
        Task<List<T>> Get(int page = 0, int limit = 25);
        Task<List<T>> Search(string keyword, int page, int limit);
        Task<T> Get(Guid id);
        Task<T> Get(string key1, string key2);
        Task Create(T value);
        Task Update(T value);
        Task Delete(T id);
    }
}