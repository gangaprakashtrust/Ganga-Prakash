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
			IModuleDal IModuleDal = new ModuleDal();
			List<Module> ModuleList = new List<Module>();
			foreach (var item in IModuleDal.Fetch())
			{
				Module module = new Module
				{
					Id = item.Id,
					Name = item.Name,
					SequenceNo=item.SequenceNo
				};
				ModuleList.Add(module);
			}
			return ModuleList;
		}
	}
}
