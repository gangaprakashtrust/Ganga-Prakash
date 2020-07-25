using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GangaPrakashAPI.Configuration.Dal;
using GangaPrakashAPI.Configuration.IDal;
using GangaPrakashAPI.Model;

namespace GangaPrakashAPI.Configuration.Persister
{
    public class StatePersister
    {
        public State Insert(State state, SqlConnection con = null, SqlTransaction trans = null)
        {
            IStateDal IstateDal = new StateDal();
            StateDto stateDto = new StateDto
            {
                CountryId= state.CountryId,
                Name = state.Name,
                IsActive = true
            };
            IstateDal.IsStateAlreadyPresent(stateDto);
            if (stateDto.ErrorCount == 0)
            {
                IstateDal.Insert(stateDto, con, trans);
                state.Id = stateDto.Id;

            }
            else
            {
                state.IsError = true;
                state.ErrorMessage = stateDto.ErrorMessage;
                state.ErrorMessageFor = "Name";

            }
            return state;
        }

        public State Update(State state, SqlConnection con = null, SqlTransaction trans = null)
        {
            IStateDal IstateDal = new StateDal();
            StateDto stateDto = new StateDto
            {
                Id = state.Id,
                CountryId = state.CountryId,
                Name = state.Name,
                IsActive = true
            };
            IstateDal.IsStateAlreadyPresent(stateDto);
            if (stateDto.ErrorCount == 0)
            {
                IstateDal.Update(stateDto, con, trans);
                state.Id = stateDto.Id;
            }
            else
            {
                state.IsError = true;
                state.ErrorMessage = stateDto.ErrorMessage;
                state.ErrorMessageFor = "Name";

            }
            return state;
        }

        public State Delete(State state, SqlConnection con = null, SqlTransaction trans = null)
        {
            IStateDal IstateDal = new StateDal();
            StateDto stateDto = new StateDto
            {
                Id = state.Id,
                IsActive = false
            };
            Boolean IsCityReferencePresent = IstateDal.IsCityReferencePresent(stateDto.Id);
            if (!IsCityReferencePresent)
            {
                IstateDal.Delete(stateDto, con, trans);
                state.Id = stateDto.Id;
            }
            else
            {
                state.IsError = true;
                state.ErrorMessage = "Please first delete cities under state " + state.Name;
                state.ErrorMessageFor = "Name";
            }
            return state;
        }

        public static State GetState(Guid Id)
        {
            IStateDal IstateDal = new StateDal();
            StateDto stateDto = IstateDal.FetchById(Id);
            State state = new State
            {
                Id = stateDto.Id,
                CountryId = stateDto.CountryId,
                Name = stateDto.Name,
                Country = stateDto.Country
            };
            return state;
        }

        public static State Get()
        {
            State state = new State();
            return state;
        }

        public static StatePersister GetPersister()
        {
            StatePersister statePersister = new StatePersister();
            return statePersister;
        }
    }
}
