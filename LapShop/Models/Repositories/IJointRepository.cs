namespace Models.Repositories
{
    public interface IJointRepository<Type>
    {
        public ValueTask Create(Type obj);
        public Task<Type> GetById(int id);
        public Task<IEnumerable<Type>> GetRangeById(int id);
        public Task<Type> GetById(int id, List<string> NavProps);
        public Task<IEnumerable<Type>> GetRangeById(int id, List<string> NavProps);
        public Task<IEnumerable<Type>> GetAll();
        public Task<IEnumerable<Type>> GetAll(List<string> NavProps);
        public ValueTask Update(Type obj);
        public ValueTask Delete(Type obj);
        public ValueTask DeleteRange(IEnumerable<Type> obj);
        public ValueTask UploadToDatabase();
    }
}
