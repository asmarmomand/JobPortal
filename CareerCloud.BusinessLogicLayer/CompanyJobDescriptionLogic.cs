using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
	public class CompanyJobDescriptionLogic : BaseLogic<CompanyJobDescriptionPoco>
	{
		public CompanyJobDescriptionLogic(IDataRepository<CompanyJobDescriptionPoco> repository) : base(repository)
		{
		}
		public override void Add(CompanyJobDescriptionPoco[] pocos)
		{
			Verify(pocos);
			base.Add(pocos);
		}

		public override CompanyJobDescriptionPoco Get(Guid id)
		{
			return base.Get(id);
		}

		public override List<CompanyJobDescriptionPoco> GetAll()
		{
			return base.GetAll();
		}

		public override string ToString()
		{
			return base.ToString();
		}

		public override void Update(CompanyJobDescriptionPoco[] pocos)
		{
			Verify(pocos);
			base.Update(pocos);
		}

		protected override void Verify(CompanyJobDescriptionPoco[] pocos)
		{
			List<ValidationException> exceptions = new List<ValidationException>();
			foreach (var entity in pocos)
			{
				if (string.IsNullOrEmpty(entity.JobName))
				{
					exceptions.Add(new ValidationException(300, $"The job name cannot be empty."));
				}

				if (string.IsNullOrEmpty(entity.JobDescriptions))
				{
					exceptions.Add(new ValidationException(301, $"The job description cannot be empty."));
				}
			}
			if (exceptions.Count > 0)
			{
				throw new AggregateException(exceptions);
			}
		}
	}
}
