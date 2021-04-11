using BlockBuster.IAM.Domain.UserAggregate.Exceptions;
using BlockBuster.IAM.Domain.UserAggregate.Resources;
using BlockBuster.Shared.Domain.ValueObjects;

namespace BlockBuster.IAM.Domain.UserAggregate.ValueObjects
{
	public class UserEmail : StringValueObject
	{
		public UserEmail(string value) : base(value)
		{
			try
			{
				new System.Net.Mail.MailAddress(value);
			}
			catch
			{
				throw InvalidUserAttributeException
					.FromValue(UserResources.FieldEmail, value);
			}
		}
	}
}
