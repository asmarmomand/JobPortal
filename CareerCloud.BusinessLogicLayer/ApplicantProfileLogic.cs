using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
	public class ApplicantProfileLogic : BaseLogic<ApplicantProfilePoco>
	{
		public ApplicantProfileLogic(IDataRepository<ApplicantProfilePoco> repository) : base(repository)
		{
		}
		public override void Add(ApplicantProfilePoco[] pocos)
		{
			Verify(pocos);
			base.Add(pocos);
		}

		public override ApplicantProfilePoco Get(Guid id)
		{
			return base.Get(id);
		}

		public override List<ApplicantProfilePoco> GetAll()
		{
			return base.GetAll();
		}

		public override string ToString()
		{
			return base.ToString();
		}

		public override void Update(ApplicantProfilePoco[] pocos)
		{
			Verify(pocos);
			base.Update(pocos);
		}

		protected override void Verify(ApplicantProfilePoco[] pocos)
		{
			List<ValidationException> exceptions = new List<ValidationException>();
			foreach (var entity in pocos)
			{
				if (entity.CurrentSalary < 0)
				{
					exceptions.Add(new ValidationException(111, $"Current salary cannot be a negative value."));
				}
				else if (entity.CurrentRate < 0)
				{
					exceptions.Add(new ValidationException(112, $"Current rate cannot be a negative value."));
				}
			}
			if (exceptions.Count > 0)
			{
				throw new AggregateException(exceptions);
			}
		}
	}
}
