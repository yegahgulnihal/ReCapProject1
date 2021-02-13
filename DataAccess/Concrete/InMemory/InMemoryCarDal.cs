using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{ Id=1,ColorId=1,BrandId=1,ModelName="Ford Focus",ModelYear=2009,DailyPrice=100,Description="--"},
                new Car{ Id=2,ColorId=2,BrandId=2,ModelName="Toyota Camry",ModelYear=2008,DailyPrice=90,Description="--"},
                new Car{ Id=3,ColorId=2,BrandId=3,ModelName="Honda Civic",ModelYear=2018,DailyPrice=250,Description="--"},
                new Car{ Id=4,ColorId=3,BrandId=3,ModelName="Honda Accord",ModelYear=2015,DailyPrice=180,Description="--"}

            };
        }
        public void Add(Car entity)
        {
            _cars.Add(entity);
        }

        public void Delete(Car entity)
        {
            Car carsToDelete = _cars.SingleOrDefault(c => c.Id == entity.Id);
            _cars.Remove(carsToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public List<CarDetailsDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car entity)
        {
            Car carsToUpdate = _cars.SingleOrDefault(c => c.Id == entity.Id);
            carsToUpdate.ModelName = entity.ModelName;
            carsToUpdate.ModelYear = entity.ModelYear;
            carsToUpdate.DailyPrice = entity.DailyPrice;
            carsToUpdate.Description = entity.Description;
            carsToUpdate.ColorId = entity.ColorId;
        }
    }
}
