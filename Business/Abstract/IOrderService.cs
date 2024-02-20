using Entities.Concrete;

namespace Business.Abstract;

public interface IOrderService
{
    Order GetById(int id);
}