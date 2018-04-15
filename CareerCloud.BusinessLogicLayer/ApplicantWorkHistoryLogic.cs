using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
	public class ApplicantWorkHistoryLogic : BaseLogic<ApplicantWorkHistoryPoco>
	{
		public ApplicantWorkHistoryLogic(IDataRepository<ApplicantWorkHistoryPoco> repository) : base(repository)
		{
		}
		public override void Add(ApplicantWorkHistoryPoco[] pocos)
		{
			Verify(pocos);			
			base.Add(pocos);
		}

		public override ApplicantWorkHistoryPoco Get(Guid id)
		{
			return base.Get(id);
		}

		public override List<ApplicantWorkHistoryPoco> GetAll()
		{
			return base.GetAll();
		}

		public override string ToString()
		{
			return base.ToString();
		}

		public override void Update(ApplicantWorkHistoryPoco[] pocos)
		{
			Verify(pocos);
			base.Update(pocos);
		}

		protected override void Verify(ApplicantWorkHistoryPoco[] pocos)
		{
			List<ValidationException> exceptions = new List<ValidationException>();
			foreach (var entity in pocos)
			{
				if (entity.CompanyName.Length < 3)
				{
					exceptions.Add(new ValidationException(105, $"The company name must be greater then two characters."));
				}				
			}
			if (exceptions.Count > 0)
			{
				throw new AggregateException(exceptions);
			}
		}
	}
}
