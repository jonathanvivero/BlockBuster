using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using BlockBuster.IAM.Infrastructure.Factory;
using BlockBuster.Infrastructure.Persistence.Context;
using BlockBuster.IAM.Infrastructure.Presistence.Repositories;
using BlockBuster.Shared.Infrastructure.Persistence.Seed;
using System;
using System.Linq;
using BlockBuster.IAM.Domain.UserAggregate;

namespace BlockBuster.IAM.Infrastructure.Persistence.Seed
{
    public class SeedUsers : SeedChannel<IBlockBusterIAMContext>
    {
        private readonly UserFactory _userFactory;
        private readonly UserRepository _userRepository;
        public SeedUsers(
            IBlockBusterIAMContext context, 
            UserFactory userFactory, 
            UserRepository userRepository)
            : base(context)
        {
            _userFactory = userFactory;
            _userRepository = userRepository;
        }
        public override void SeedDatabase()
        {
            Country mainCountry = _context
                .Countries
                .Where(w => w.Code.GetValue() == "ESP")
                .FirstOrDefault();                
            

            if (!_context.Users.Any())
            {
                string id = new Guid().ToString();
                string email = "jonathanvivero@gmail.com";
                string password = "123456789";
                string fistName = "Jonathan";
                string lastName = "Vivero Gázquez";
                string role = UserRole.ROLE_ADMIN;                

                //fill with first user
                var user = _userFactory.Create(id,
                    email,
                    password,
                    password,
                    fistName,
                    lastName,
                    role,
                    mainCountry);

                _userRepository.Add(user);
                _context.SaveChanges();

            }

        }
    }
}
