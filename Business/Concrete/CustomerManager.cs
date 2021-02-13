using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public IResult Add(Customer customer)
        {
            if (customer.CustomerId!=customer.UserId)
            {
                return new ErrorResult(Messages.InvalidCustomer);
            }
            _customerDal.Add(customer);
            return new SuccessResult(Messages.NewCustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            if (customer.CustomerId!=customer.UserId)
            {
                return new ErrorResult(Messages.InvalidCustomer);
            }
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomerListed);
        }

        public IDataResult<List<Customer>> GetById(int customerId)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(c => c.CustomerId == customerId));
        }

        public IResult Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
