namespace Inventory_Project.Repo.IRepo
{
    public interface IRepo<T> where T : class,IBaseRepo, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> GetAll(string? includeProperties = null);
        Task AddAsync(T enitiy);
        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(int id,T entity);
        Task DeleteAsync(int id);
    }
}
