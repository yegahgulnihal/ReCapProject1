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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            if (rental.RentalId!=rental.CustomerId)
            {
                return new ErrorResult(Messages.InvalidRental);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.NewRentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            if(rental.RentalId != rental.CustomerId)
            {
                return new ErrorResult(Messages.InvalidRental);
            }
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<Rental>> GetById(int rentalId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.RentalId == rentalId));
        }

        public IResult Update(Rental rental)
        {
            throw new NotImplementedException();
        }
    }
}
