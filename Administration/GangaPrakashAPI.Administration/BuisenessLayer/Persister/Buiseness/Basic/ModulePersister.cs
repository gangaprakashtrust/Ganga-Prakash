using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GangaPrakashAPI.Administration.Dal;
using GangaPrakashAPI.Administration.IDal;
using GangaPrakashAPI.Model;

namespace GangaPrakashAPI.Administration.Persister
{
    public class ModulePersister
    {
        public Module Insert(Module module, SqlConnection con = null, SqlTransaction trans = null)
        {
            IModuleDal ImoduleDal = new ModuleDal();
            ModuleDto moduleDto = new ModuleDto
            {
                Name = module.Name,
                SequenceNo = module.SequenceNo,
                IsActive = true
            };
            ImoduleDal.IsModuleAlreadyPresent(moduleDto);
            if (moduleDto.ErrorCount == 0)
            {
                ImoduleDal.IsSequenceNoAlreadyPresent(moduleDto);
                if (moduleDto.ErrorCount == 0)
                {
                    ImoduleDal.Insert(moduleDto, con, trans);
                    module.Id = moduleDto.Id;
                }
                else
                {
                    module.IsError = true;
                    module.ErrorMessage = moduleDto.ErrorMessage;
                    module.ErrorMessageFor = "SequenceNo";

                }
            }
            else
            {
                module.IsError = true;
                module.ErrorMessage = moduleDto.ErrorMessage;
                module.ErrorMessageFor = "Name";

            }
            return module;
        }

        public Module Update(Module module, SqlConnection con = null, SqlTransaction trans = null)
        {
            IModuleDal ImoduleDal = new ModuleDal();
            ModuleDto moduleDto = new ModuleDto
            {
                Id = module.Id,
                Name = module.Name,
                SequenceNo = module.SequenceNo,
                IsActive = true
            };
            ImoduleDal.IsModuleAlreadyPresent(moduleDto);
            if (moduleDto.ErrorCount == 0)
            {
                ImoduleDal.IsSequenceNoAlreadyPresent(moduleDto);
                if (moduleDto.ErrorCount == 0)
                {
                    ImoduleDal.Update(moduleDto, con, trans);
                    module.Id = moduleDto.Id;
                }
                else
                {
                    module.IsError = true;
                    module.ErrorMessage = moduleDto.ErrorMessage;
                    module.ErrorMessageFor = "SequenceNo";

                }
            }
            else
            {
                module.IsError = true;
                module.ErrorMessage = moduleDto.ErrorMessage;
                module.ErrorMessageFor = "Name";

            }
            return module;
        }

        public Module Delete(Module module, SqlConnection con = null, SqlTransaction trans = null)
        {
            IModuleDal ImoduleDal = new ModuleDal();
            ModuleDto moduleDto = new ModuleDto
            {
                Id = module.Id,
                Name = module.Name,
                SequenceNo = module.SequenceNo,
                IsActive = false
            };
            ImoduleDal.Delete(moduleDto, con, trans);
            module.Id = moduleDto.Id;
            return module;
        }

        public static Module GetModule(Guid Id)
        {
            IModuleDal ImoduleDal = new ModuleDal();
            ModuleDto moduleDto = ImoduleDal.FetchById(Id);
            Module module = new Module
            {
                Id = moduleDto.Id,
                Name = moduleDto.Name,
                SequenceNo = moduleDto.SequenceNo
            };
            return module;
        }

        public static Module Get()
        {
            Module module = new Module();
            return module;
        }

        public static ModulePersister GetPersister()
        {
            ModulePersister modulePersister = new ModulePersister();
            return modulePersister;
        }
    }
}
