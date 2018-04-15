using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
	public class SystemLanguageCodeLogic 
	{
		readonly IDataRepository<SystemLanguageCodePoco> _repo;
		public SystemLanguageCodeLogic(IDataRepository<SystemLanguageCodePoco> repository)
		{
			_repo = repository;
		}
		public void Add(SystemLanguageCodePoco[] pocos)
		{
			Verify(pocos);

			_repo.Add(pocos);
		}

		public virtual List<SystemLanguageCodePoco> GetAll()
		{
			return _repo.GetAll().ToList();
		}

		public SystemLanguageCodePoco Get(string id)
		{
			return _repo.GetSingle(x => x.LanguageID == id);
		}

		public void Delete(SystemLanguageCodePoco[] pocos)
		{
			_repo.Remove(pocos);
		}

		public  void Update(SystemLanguageCodePoco[] pocos)
		{
			 Verify(pocos);
			_repo.Update(pocos);
		}

		protected void Verify(SystemLanguageCodePoco[] pocos)
		{
			List<ValidationException> exceptions = new List<ValidationException>();
			foreach (var poco in pocos)
			{
				if (string.IsNullOrEmpty(poco.LanguageID))
				{
					exceptions.Add(new ValidationException(1000, $"The language ID cannot empty."));
				}

				if (string.IsNullOrEmpty(poco.Name))
				{
					exceptions.Add(new ValidationException(1001, $"The name cannot empty."));
				}

				if (string.IsNullOrEmpty(poco.NativeName))
				{
					exceptions.Add(new ValidationException(1002, $"The native name cannot empty."));
				}
			}
			if (exceptions.Count > 0)
			{
				throw new AggregateException(exceptions);
			}

		}
	}
}
