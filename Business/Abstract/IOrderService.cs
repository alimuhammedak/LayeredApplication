using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract;

public interface IOrderService
{
    IDataResult<List<Order>> GetAll();
    IDataResult<List<Order>> GetByTime(DateTime begin, DateTime end); // Get all Orders by price range
    IDataResult<Order> GetOrderById(int id);
    IResult OrderAdd(Order order);
}