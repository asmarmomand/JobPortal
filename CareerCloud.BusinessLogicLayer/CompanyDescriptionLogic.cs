using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
	public class CompanyDescriptionLogic : BaseLogic<CompanyDescriptionPoco>
	{
		public CompanyDescriptionLogic(IDataRepository<CompanyDescriptionPoco> repository) : base(repository)
		{
		}
		public override void Add(CompanyDescriptionPoco[] pocos)
		{
			Verify(pocos);
			base.Add(pocos);
		}

		public override CompanyDescriptionPoco Get(Guid id)
		{
			return base.Get(id);
		}

		public override List<CompanyDescriptionPoco> GetAll()
		{
			return base.GetAll();
		}

		public override string ToString()
		{
			return base.ToString();
		}

		public override void Update(CompanyDescriptionPoco[] pocos)
		{
			Verify(pocos);
			base.Update(pocos);
		}

		protected override void Verify(CompanyDescriptionPoco[] pocos)
		{
			List<ValidationException> exceptions = new List<ValidationException>();
			foreach (var entity in pocos)
			{
				if (string.IsNullOrEmpty(entity.CompanyName))
				{
					exceptions.Add(new ValidationException(106, $"The company name must not be null."));
				}

                if (entity.CompanyName.Length <= 2)
                {
                    exceptions.Add(new ValidationException(106, $"The company name must be greater then two characters."));
                }

				if (string.IsNullOrEmpty(entity.CompanyDescription))
				{
					exceptions.Add(new ValidationException(107, $"The company description must not be null."));
				}				

                if (entity.CompanyDescription.Length < 3)
                {
                    exceptions.Add(new ValidationException(107, $"The company description must be greater then two characters."));
                }
			}
			if (exceptions.Count > 0)
			{
				throw new AggregateException(exceptions);
			}
		}
	}
}
