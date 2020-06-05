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
        public Module Insert(Module Module, SqlConnection con = null, SqlTransaction trans = null)
        {
            IModuleDal IModuleDal = new ModuleDal();
            ModuleDto ModuleDto = new ModuleDto
            {
                Name = Module.Name,
                SequenceNo = Module.SequenceNo,
                IsActive = true
            };
            IModuleDal.IsModuleAlreadyPresent(ModuleDto);
            if (ModuleDto.ErrorCount == 0)
            {
                IModuleDal.IsSequenceNoAlreadyPresent(ModuleDto);
                if (ModuleDto.ErrorCount == 0)
                {
                    IModuleDal.Insert(ModuleDto, con, trans);
                    Module.Id = ModuleDto.Id;
                }
                else
                {
                    Module.IsError = true;
                    Module.ErrorMessage = ModuleDto.ErrorMessage;
                    Module.ErrorMessageFor = "SequenceNo";

                }
            }
            else
            {
                Module.IsError = true;
                Module.ErrorMessage = ModuleDto.ErrorMessage;
                Module.ErrorMessageFor = "Name";

            }
            return Module;
        }

        public Module Update(Module Module, SqlConnection con = null, SqlTransaction trans = null)
        {
            IModuleDal IModuleDal = new ModuleDal();
            ModuleDto ModuleDto = new ModuleDto
            {
                Id = Module.Id,
                Name = Module.Name,
                SequenceNo = Module.SequenceNo,
                IsActive = true
            };
            IModuleDal.IsModuleAlreadyPresent(ModuleDto);
            if (ModuleDto.ErrorCount == 0)
            {
                IModuleDal.IsSequenceNoAlreadyPresent(ModuleDto);
                if (ModuleDto.ErrorCount == 0)
                {
                    IModuleDal.Update(ModuleDto, con, trans);
                    Module.Id = ModuleDto.Id;
                }
                else
                {
                    Module.IsError = true;
                    Module.ErrorMessage = ModuleDto.ErrorMessage;
                    Module.ErrorMessageFor = "SequenceNo";

                }
            }
            else
            {
                Module.IsError = true;
                Module.ErrorMessage = ModuleDto.ErrorMessage;
                Module.ErrorMessageFor = "Name";

            }
            return Module;
        }

        public Module Delete(Module Module, SqlConnection con = null, SqlTransaction trans = null)
        {
            IModuleDal IModuleDal = new ModuleDal();
            ModuleDto ModuleDto = new ModuleDto
            {
                Id = Module.Id,
                Name = Module.Name,
                SequenceNo = Module.SequenceNo,
                IsActive = false
            };
            IModuleDal.Delete(ModuleDto, con, trans);
            Module.Id = ModuleDto.Id;
            return Module;
        }

        public static Module GetModule(Guid Id)
        {
            IModuleDal IModuleDal = new ModuleDal();
            ModuleDto ModuleDto = IModuleDal.FetchById(Id);
            Module Module = new Module
            {
                Id = ModuleDto.Id,
                Name = ModuleDto.Name,
                SequenceNo= ModuleDto.SequenceNo
            };
            return Module;
        }

        public static Module Get()
        {
            Module Module = new Module();
            return Module;
        }

        public static ModulePersister GetPersister()
        {
            ModulePersister ModulePersister = new ModulePersister();
            return ModulePersister;
        }
    }
}
