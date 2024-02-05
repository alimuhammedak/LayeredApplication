using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    internal class InMermoryCustomerDal : ICustomerDal
    {
        public readonly List<Customer>? _customers;

        public InMermoryCustomerDal() => _customers = new List<Customer>() {
                new Customer { CustomerId="DFDDS", CompanyName="Company 1"},
                new Customer{CustomerId="DFSDS", CompanyName="Company 2"},
                new Customer{CustomerId="DFTDS", CompanyName="Company 3"},
                new Customer{CustomerId="DFLDS", CompanyName="Company 4"},
                new Customer{CustomerId="DFPDS", CompanyName="Company 5"}
               };

        public void Add(Customer entity) => _customers.Add(entity);

        public void Delete(Customer entity)=>
            _customers.Where(c => c.CustomerId == entity.CustomerId)
                .ToList().ForEach(c => _customers.Remove(c));

        public Customer Get(Expression<Func<Customer, bool>> filter) =>
            _customers.SingleOrDefault(filter.Compile());

        public List<Customer>? GetAll(Expression<Func<Customer, bool>>? filter = null) => 
            filter == null ? _customers : _customers.Where(filter.Compile()).ToList();

        public void Update(Customer entity) =>
            _customers.Where(c => c.CustomerId == entity.CustomerId)
                .ToList().ForEach(c => c.CompanyName = entity.CompanyName);
    }
}
