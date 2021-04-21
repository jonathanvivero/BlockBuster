using BlockBuster.IAM.Domain.UserAggregate;
using BlockBuster.IAM.Domain.UserAggregate.Repository;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using BlockBuster.IAM.Infrastructure.Presistence.Repositories;
using BlockBuster.Infrastructure.Persistence.Context;
using BlockBuster.Shared.Testing.Domain.UserAggregate.Dummies;
using BlockBuster.Shared.Testing.Domain.UserAggregate.Stub;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BlockBuster.Shared.Testing.Domain.UserAggregate
{
    public class UserRepositoryTest
    {
        Mock<IBlockBusterIAMContext> context =
            new Mock<IBlockBusterIAMContext>();
        IServiceScopeFactory dummyServiceScopeFactory;
        [SetUp]
        public void Setup()
        {
            dummyServiceScopeFactory =
                new DummyServiceScopeFactory(context.Object);
        }
        
        public void FindUserByEmailShouldReturnValidUserAndUseCollaborators()
        {
            var userRepository = new UserRepository(context.Object, dummyServiceScopeFactory);
            User user = UserStub.ByDefault();
            Mock<DbSet<User>> dbUserSetMock = new Mock<DbSet<User>>();
            UserEmail userEmail = UserEmailStub.ByDefault();            
            dbUserSetMock
                .Setup(x => x.FirstOrDefault())
                .Returns(user);
            context
                .Setup(s => s.Users)
                .Returns(dbUserSetMock.Object)
                .Verifiable();

            userRepository.FindUserByEmail(userEmail);

            Mock.VerifyAll();            

        }
    }
}
