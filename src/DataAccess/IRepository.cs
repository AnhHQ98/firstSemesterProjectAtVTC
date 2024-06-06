namespace CoursesSystem.DataAccess
{
    public interface IRepository<V>
    {
        List<V> GetList(int id);
        V? GetById(int id);
        void Add(V item);
        void Edit(V item);
    }
}