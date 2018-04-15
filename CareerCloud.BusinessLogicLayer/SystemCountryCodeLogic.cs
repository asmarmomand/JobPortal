using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
	public class SystemCountryCodeLogic
	{
		readonly IDataRepository<SystemCountryCodePoco> _repo;
		public SystemCountryCodeLogic(IDataRepository<SystemCountryCodePoco> repository)
		{
			this._repo = repository;
		}
		public void Add(SystemCountryCodePoco[] pocos)
		{
			Verify(pocos);

			_repo.Add(pocos);
		}

		public void Update(SystemCountryCodePoco[] pocos)
		{
			Verify(pocos);
			_repo.Update(pocos);
		}
		public virtual SystemCountryCodePoco Get(string id)
		{
			return _repo.GetSingle(a => a.Code == id);
		}

		public virtual List<SystemCountryCodePoco> GetAll()
		{
			return _repo.GetAll().ToList();
		}

		public void Delete(SystemCountryCodePoco[] pocos)
		{
			_repo.Remove(pocos);
		}
		protected  void Verify(SystemCountryCodePoco[] pocos)
		{					
			List<ValidationException> exceptions = new List<ValidationException>();
			foreach (var entity in pocos)
			{
                if (string.IsNullOrEmpty(entity.Name))
                {
                    exceptions.Add(new ValidationException(901, $"The name cannot empty."));
                }

                if (string.IsNullOrEmpty(entity.Code))
				{
					exceptions.Add(new ValidationException(900, $"The code cannot empty."));
				}

				
			}
			if (exceptions.Count > 0)
			{
				throw new AggregateException(exceptions);
			}
		}
	}
}
