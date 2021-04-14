using BlockBuster.Shared.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.GEO.Country.Domain.CountryAggregate.Exceptions
{
    public class InvalidCountryAttributeException : InvalidAttributeException
    {
        public InvalidCountryAttributeException(string message)
            :base(message)
        {

        }
    }
}
