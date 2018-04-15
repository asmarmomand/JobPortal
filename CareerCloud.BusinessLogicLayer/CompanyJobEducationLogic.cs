using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
	public class CompanyJobEducationLogic : BaseLogic<CompanyJobEducationPoco>
	{
		public CompanyJobEducationLogic(IDataRepository<CompanyJobEducationPoco> repository) : base(repository)
		{
		}
		public override void Add(CompanyJobEducationPoco[] pocos)
		{
			Verify(pocos);
			base.Add(pocos);
		}

		public override CompanyJobEducationPoco Get(Guid id)
		{
			return base.Get(id);
		}

		public override List<CompanyJobEducationPoco> GetAll()
		{
			return base.GetAll();
		}

		public override string ToString()
		{
			return base.ToString();
		}

		public override void Update(CompanyJobEducationPoco[] pocos)
		{
			Verify(pocos);
			base.Update(pocos);
		}

		protected override void Verify(CompanyJobEducationPoco[] pocos)
		{
			List<ValidationException> exceptions = new List<ValidationException>();
			foreach (var entity in pocos)
			{
				if (string.IsNullOrEmpty(entity.Major) || entity.Major.Length < 3)
				{
					exceptions.Add(new ValidationException(200, $"The major name must be greater than 2 characters."));
				}

				if (entity.Importance < 0)
				{
					exceptions.Add(new ValidationException(201, $"The importance cannot be less than zero."));
				}
			}
			if (exceptions.Count > 0)
			{
				throw new AggregateException(exceptions);
			}
		}
	}
}
