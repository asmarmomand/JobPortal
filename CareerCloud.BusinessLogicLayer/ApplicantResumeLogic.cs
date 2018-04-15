using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
	public class ApplicantResumeLogic : BaseLogic<ApplicantResumePoco>
	{
		public ApplicantResumeLogic(IDataRepository<ApplicantResumePoco> repository) : base(repository)
		{
		}
		public override void Add(ApplicantResumePoco[] pocos)
		{
			Verify(pocos);
			base.Add(pocos);
		}

		public override ApplicantResumePoco Get(Guid id)
		{
			return base.Get(id);
		}

		public override List<ApplicantResumePoco> GetAll()
		{
			return base.GetAll();
		}

		public override string ToString()
		{
			return base.ToString();
		}

		public override void Update(ApplicantResumePoco[] pocos)
		{
			Verify(pocos);
			base.Update(pocos);
		}

		protected override void Verify(ApplicantResumePoco[] pocos)
		{
			
			List<ValidationException> exceptions = new List<ValidationException>();
			foreach (var entity in pocos)
			{
				
				if (string.IsNullOrEmpty(entity.Resume))
				{
					exceptions.Add(new ValidationException(113, $"Resume cannot be empty."));
				}
			}
			if (exceptions.Count > 0)
			{
				throw new AggregateException(exceptions);
			}
		}
	}
}
