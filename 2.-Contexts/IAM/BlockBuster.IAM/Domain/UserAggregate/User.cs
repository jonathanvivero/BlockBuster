﻿using BlockBuster.IAM.Domain.UserAggregate.Events;
using BlockBuster.IAM.Domain.UserAggregate.Events.Body;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using BlockBuster.IAM.Infrastructure.Services.User;
using BlockBuster.Shared.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlockBuster.IAM.Domain.UserAggregate
{
    public class User : AggregateRoot
    {        
        [Key]
        public UserId Id { get; private set; }
        public UserEmail Email { get; private set; }
        public UserHashedPassword HashedPassword { get; private set; }
        public UserFirstName FirstName { get; private set; }
        public UserLastName LastName { get; private set; }
        public UserRole Role { get; private set; }
        public UserCreatedAt CreatedAt { get; private set; }
        public UserUpdatedAt UpdatedAt { get; private set; }
        public UserCountryId CountryId { get; private set; }
        public UserCountry Country { get; private set; }

        public User() { }
        private User(UserId userId,
            UserEmail userEmail,
            UserHashedPassword userHashedPassword,
            UserFirstName userFirstName,
            UserLastName userLastName,
            UserRole userRole,
            UserCountryId userCountryId,
            UserCountry userCountry,
            UserCreatedAt userCreatedAt,
            UserUpdatedAt userUpdatedAt
            )
        {
            this.Id = userId;
            this.Email = userEmail;
            this.HashedPassword = userHashedPassword;
            this.FirstName = userFirstName;
            this.LastName = userLastName;
            this.Role = userRole;
            this.CountryId = userCountryId;
            this.CreatedAt = userCreatedAt;
            this.UpdatedAt = userUpdatedAt;
            this.Country = userCountry;
        }
        public static User SignUp(UserId userId,
            UserEmail userEmail,
            UserHashedPassword userHashedPassword,
            UserFirstName userFirstName,
            UserLastName userLastName,
            UserRole userRole,
            UserCountryId userCountryId,
            UserCountry userCountry)
        {
            var userCreatedAt = new UserCreatedAt(DateTime.Now);
            var userUpdatedAt = new UserUpdatedAt(DateTime.Now);

            var user = new User(userId,
                userEmail,
                userHashedPassword,
                userFirstName,
                userLastName,
                userRole,
                userCountryId,
                userCountry,
                userCreatedAt,
                userUpdatedAt);

            user.Record(
                new UserSignedUpEvent(
                    userId.GetValue().ToString(),
                    new UserSignedUpEventBody(user)
                )
            );

            return user;
        }        

        public void SetUserCountry(UserCountry country) 
        {
            this.Country = country;
        }

        public void UpdateField(UserFirstName firstName)
            => this.FirstName = firstName;
        public void UpdateField(UserLastName lastName)
            => this.LastName = lastName;
        public void UpdateField(UserHashedPassword password)
            => this.HashedPassword = password;
        public void UpdateField(UserUpdatedAt updatedAt)
            => this.UpdatedAt = updatedAt;


    }
}
