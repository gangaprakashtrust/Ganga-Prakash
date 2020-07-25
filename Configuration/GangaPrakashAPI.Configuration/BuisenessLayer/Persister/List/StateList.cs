using GangaPrakashAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GangaPrakashAPI.Configuration.IDal;
using GangaPrakashAPI.Configuration.Dal;


namespace GangaPrakashAPI.Configuration.Persister
{
    public class StateList
    {
        public static List<State> GetList()
        {
            return Fetch();
        }

        private static List<State> Fetch()
        {
            IStateDal IstateDal = new StateDal();
            List<State> stateList = new List<State>();
            foreach (var item in IstateDal.Fetch())
            {
                State state = new State
                {
                    Id = item.Id,
                    CountryId = item.CountryId,
                    Name = item.Name,
                    Country = item.Country
                };
                stateList.Add(state);
            }
            return stateList;
        }
    }
}
