using System;

namespace BlockBuster.IAM.Application.UseCases.User.GetUsers
{
    public class CountryDTO
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public double Tax { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public CountryDTO(string id, 
            string code, 
            double tax, 
            DateTime createdAt, 
            DateTime updatedAt)
        {
            this.Id = id;
            this.Code = code;
            this.Tax = tax;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
        }

    }
}