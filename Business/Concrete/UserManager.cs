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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            if (user.FirstName.Length<3)
            {
                return new ErrorResult(Messages.InvalidUser);
            }
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            if (user.Email==user.Email)
            {
                return new SuccessResult(Messages.DeletedUser);
            }
            _userDal.Delete(user);
            return new ErrorResult(Messages.InvalidUser);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<List<User>> GetById(int UserId)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u=>u.UserId==UserId));
        }

        public IResult Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
