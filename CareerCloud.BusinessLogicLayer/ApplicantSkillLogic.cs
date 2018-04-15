using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
	public class ApplicantSkillLogic : BaseLogic<ApplicantSkillPoco>
	{
		public ApplicantSkillLogic(IDataRepository<ApplicantSkillPoco> repository) : base(repository)
		{
		}
		public override void Add(ApplicantSkillPoco[] pocos)
		{
			Verify(pocos);
			base.Add(pocos);
		}

		public override ApplicantSkillPoco Get(Guid id)
		{
			return base.Get(id);
		}

		public override List<ApplicantSkillPoco> GetAll()
		{
			return base.GetAll();
		}

		public override string ToString()
		{
			return base.ToString();
		}

		public override void Update(ApplicantSkillPoco[] pocos)
		{
			Verify(pocos);
			base.Update(pocos);
		}

		protected override void Verify(ApplicantSkillPoco[] pocos)
		{
			List<ValidationException> exceptions = new List<ValidationException>();
			foreach (var entity in pocos)
			{
				
				if (entity.StartMonth > 12)
				{
					exceptions.Add(new ValidationException(101, $"Start month cannot be greater than 12."));
				}
				else if (entity.EndMonth > 12)
				{
					exceptions.Add(new ValidationException(102, $"End month cannot be greater than 12."));
				}
				else if (entity.StartYear < 1900)
				{
					exceptions.Add(new ValidationException(103, $"Start year cannot be less than 1900."));
				}
				else if (entity.EndYear < entity.StartYear)
				{
					exceptions.Add(new ValidationException(104, $"End year cannot be less than start year."));
				}
			}
			if (exceptions.Count > 0)
			{
				throw new AggregateException(exceptions);
			}
		}
	}
}
