using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
	public class ApplicantEducationLogic : BaseLogic<ApplicantEducationPoco>
	{
		public ApplicantEducationLogic(IDataRepository<ApplicantEducationPoco> repository) : base(repository)
		{
		}
		public override void Add(ApplicantEducationPoco[] pocos)
		{
			Verify(pocos);			
			base.Add(pocos);
		}

		public override ApplicantEducationPoco Get(Guid id)
		{
			return base.Get(id);
		}

		public override List<ApplicantEducationPoco> GetAll()
		{
			return base.GetAll();
		}


		public override string ToString()
		{
			return base.ToString();
		}

		public override void Update(ApplicantEducationPoco[] pocos)
		{
			Verify(pocos);
			base.Update(pocos);
		}
	
		protected override void Verify(ApplicantEducationPoco[] pocos)
		{
			List<ValidationException> exceptions = new List<ValidationException>();
			
			foreach (var entity in pocos)
			{
				
				if (string.IsNullOrEmpty(entity.Major) || entity.Major.Length < 3)
				{
					exceptions.Add(new ValidationException(107, $"Major cannot be empty or less then three characters."));
				}
                
				if (entity.StartDate.HasValue && (entity.StartDate.Value > DateTime.Now))
				{
					exceptions.Add(new ValidationException(108, $"Start date cannot be greater than today's date."));
				}
                
				if (entity.CompletionDate.HasValue && entity.StartDate.HasValue && (entity.CompletionDate.Value < entity.StartDate.Value))
				{
					exceptions.Add(new ValidationException(109, $"Completion date cannot be earlier than start date."));
				}
			}

			if (exceptions.Count > 0)
			{
				throw new AggregateException(exceptions);
			}
		}
	}
}
