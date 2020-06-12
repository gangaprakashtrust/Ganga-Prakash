using GangaPrakashAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GangaPrakashAPI.Administration.IDal;
using GangaPrakashAPI.Administration.Dal;


namespace GangaPrakashAPI.Administration.Persister
{
	public class ModuleList
	{
		public static List<Module> GetList()
		{
			return Fetch();
		}

		private static List<Module> Fetch()
		{
			IModuleDal ImoduleDal = new ModuleDal();
			List<Module> moduleList = new List<Module>();
			foreach (var item in ImoduleDal.Fetch())
			{
				Module module = new Module
				{
					Id = item.Id,
					Name = item.Name,
					SequenceNo=item.SequenceNo
				};
				moduleList.Add(module);
			}
			return moduleList;
		}
	}
}
