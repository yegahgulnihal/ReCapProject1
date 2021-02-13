using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface ICarService
    { 
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetById(int Id);
        IDataResult<List<Car>> GetByColor(int colorId);
        IDataResult<List<CarDetailsDto>> GetCarDetails();

        IResult Add(Car car);
       

    }
}
