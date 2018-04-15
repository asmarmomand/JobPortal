using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
	public class SecurityLoginsRoleLogic : BaseLogic<SecurityLoginsRolePoco>
	{
		public SecurityLoginsRoleLogic(IDataRepository<SecurityLoginsRolePoco> repository) : base(repository)
		{
		}
		public override void Add(SecurityLoginsRolePoco[] pocos)
		{
			
			base.Add(pocos);
		}

		public override SecurityLoginsRolePoco Get(Guid id)
		{
			return base.Get(id);
		}

		public override List<SecurityLoginsRolePoco> GetAll()
		{
			return base.GetAll();
		}

		public override string ToString()
		{
			return base.ToString();
		}

		public override void Update(SecurityLoginsRolePoco[] pocos)
		{
			
			base.Update(pocos);
		}

		protected override void Verify(SecurityLoginsRolePoco[] pocos)
		{
			base.Verify(pocos);
		}
	}
}
