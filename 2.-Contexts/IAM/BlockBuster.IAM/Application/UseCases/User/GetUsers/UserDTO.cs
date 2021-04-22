using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Application.UseCases.User.GetUsers
{
    public class UserDTO
    {
        public string Id { get; private set; }
        public string Email { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Role { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public string CountryId { get; private set; }
        public CountryDTO Country { get; private set; }
        public UserDTO(string id, 
            string email, 
            string firstName, 
            string lastName, 
            string role, 
            DateTime createdAt, 
            DateTime updatedAt, 
            string countryId, 
            CountryDTO country)
        {
            this.Id = id;
            this.Email = email;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Role = role;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.CountryId = countryId;
            this.Country = country;
        }        
    }
}
