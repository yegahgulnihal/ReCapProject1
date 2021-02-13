using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentingContext>, ICarDal
    {
        
        public List<CarDetailsDto> GetCarDetails()
        {

            using (CarRentingContext context = new CarRentingContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             select new CarDetailsDto
                             {
                                 CarId = c.Id,
                                 ModelName = c.ModelName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };
                return result.ToList();
            }
        }
    }
}
