using System;
using System.Collections.Generic;
using Puzzle.Infrastructure.Data.Context;
using Puzzle.Infrastructure.Data.Model;
using Puzzle.Core.Interface;
using System.Linq;
using AutoMapper;

namespace Puzzle.Infrastructure.Data.Repository
{
    public class UserRepository:IUserRepository
    {
         private UserContext userContext;

         private IMapper mapper;

         public UserRepository(UserContext userContext,IMapper mapper){
             this.userContext=userContext ;
             this.userContext.Database.EnsureCreated();
             this.mapper=mapper;
        }

        public void CreateCustomer(Puzzle.Core.Model.User user){

        }

        public Puzzle.Core.Model.User Get(long userId){
            var user=this.userContext.User.Where(x=>x.UserID==userId).FirstOrDefault();

            if(user!=null){
                 return mapper.Map<User,Puzzle.Core.Model.User>(user);
            }
            return null;
        }
    }
}