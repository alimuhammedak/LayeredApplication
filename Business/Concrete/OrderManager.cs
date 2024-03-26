using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

    public IDataResult<List<Order>> GetAll()
    {
        return new SuccessDataResult<List<Order>>(_orderDal.GetAll(), Messages.OrderListed);
    }

    public IDataResult<List<Order>> GetByTime(DateTime min, DateTime max)
    {
        return new SuccessDataResult<List<Order>>(_orderDal.GetAll(o =>
            o.OrderDate > min && o.OrderDate < max), Messages.OrderListed);
    }

    public IDataResult<Order> GetOrderById(int id)
    {
        return new SuccessDataResult<Order>(_orderDal.Get(o => o.OrderID == id), Messages.OrderBrought);
    }

    public IResult OrderAdd(Order order)
    {
        _orderDal.Add(order);
        return new SuccessResult(Messages.OrderAdded);
    }
}