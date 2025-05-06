namespace LapShop.Data.Repository
{
    public interface IRepository<Type> where Type : class
    {
        // returns a null object of Type if non-existant
        public Task<Type> GetByIdAsync(int Id);
        public Task<IEnumerable<Type>> GetAllAsync();
        public Task<bool> AddAsync(Type Entity);
        public bool Update(Type Entity);
        public bool Delete(Type Entity);
    }
}
