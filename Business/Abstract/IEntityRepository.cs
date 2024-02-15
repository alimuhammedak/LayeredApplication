using Core.Entities;

namespace Business.Abstract
{
    public interface IEntityRepository<T> where T : class,IEntity,new()
    {
        List<T> GetAll(); // Get all products
    }
} 