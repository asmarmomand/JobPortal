using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
	public class CompanyJobLogic : BaseLogic<CompanyJobPoco>
	{
		public CompanyJobLogic(IDataRepository<CompanyJobPoco> repository) : base(repository)
		{
		}
		public override void Add(CompanyJobPoco[] pocos)
		{
            Verify(pocos);
			base.Add(pocos);
		}

		public override CompanyJobPoco Get(Guid id)
		{
			return base.Get(id);
		}

		public override List<CompanyJobPoco> GetAll()
		{
			return base.GetAll();
		}

		public override string ToString()
		{
			return base.ToString();
		}

		public override void Update(CompanyJobPoco[] pocos)
		{
			base.Update(pocos);
		}

		protected override void Verify(CompanyJobPoco[] pocos)
		{
			base.Verify(pocos);
		}
	}
}
