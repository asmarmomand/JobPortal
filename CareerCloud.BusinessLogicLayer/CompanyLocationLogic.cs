using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
	public class CompanyLocationLogic : BaseLogic<CompanyLocationPoco>
	{
		public CompanyLocationLogic(IDataRepository<CompanyLocationPoco> repository) : base(repository)
		{
		}
		public override void Add(CompanyLocationPoco[] pocos)
		{
			Verify(pocos);
			base.Add(pocos);
		}

		public override CompanyLocationPoco Get(Guid id)
		{
			return base.Get(id);
		}

		public override List<CompanyLocationPoco> GetAll()
		{
			return base.GetAll();
		}

		public override string ToString()
		{
			return base.ToString();
		}

		public override void Update(CompanyLocationPoco[] pocos)
		{
			Verify(pocos);
			base.Update(pocos);
		}

		protected override void Verify(CompanyLocationPoco[] pocos)
		{
			List<ValidationException> exceptions = new List<ValidationException>();
			foreach (var entity in pocos)
			{
				if (string.IsNullOrEmpty(entity.CountryCode))
				{
					exceptions.Add(new ValidationException(500, $"The country code cannot be empty."));
				}

				if (string.IsNullOrEmpty(entity.Province))
				{
					exceptions.Add(new ValidationException(501, $"The province cannot be empty."));
				}

				if (string.IsNullOrEmpty(entity.Street))
				{
					exceptions.Add(new ValidationException(502, $"The Street cannot be empty."));
				}

				if (string.IsNullOrEmpty(entity.City))
				{
					exceptions.Add(new ValidationException(503, $"The city cannot be empty."));
				}

				if (string.IsNullOrEmpty(entity.PostalCode))
				{
					exceptions.Add(new ValidationException(504, $"The postal code cannot be empty."));
				}
			}
			if (exceptions.Count > 0)
			{
				throw new AggregateException(exceptions);
			}
		}
	}
}
