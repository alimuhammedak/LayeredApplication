using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class OrderManager : IOrderService
{
    public OrderManager(IOrderDal? orderDal)
    {
        _orderDal = orderDal;
    }

    public IOrderDal? _orderDal { get; set; }

    public Order GetById(int id)
    {
        return _orderDal.Get(o => o.OrderID == id);
    }

    //[SuppressMessage("ReSharper.DPA", "DPA0007: Large number of DB records")]
    public List<Order> GetAll()
    {
        return _orderDal.GetAll();
    }
}