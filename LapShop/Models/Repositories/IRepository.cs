namespace Models.Repositories
{
    public interface IRepository<Type>
    {
        public Task<bool> Create(Type obj);
        // returns a null object of Type if non-existant
        public Task<Type> GetById(int id);
        public Task<Type> GetById(int id, List<string> NavProps);
        public Task<IEnumerable<Type>> GetBySubString(string SubString);
        public Task<IEnumerable<Type>> GetBySubString(string SubString, List<string> NavProps);
        public Task<IEnumerable<Type>> GetAll();
        public Task<IEnumerable<Type>> GetAll(List<string> NavProps);
        public Task<bool> Update(Type obj);
        public Task<bool> Delete(Type obj);
    }
}
