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
    public class PrivilegePersister
    {
        public Privilege Insert(Privilege privilege, SqlConnection con = null, SqlTransaction trans = null)
        {
            IPrivilegeDal IprivilegeDal = new PrivilegeDal();
            PrivilegeDto privilegeDto = new PrivilegeDto
            {
                Name = privilege.Name,
                SequenceNo = privilege.SequenceNo,
                IsActive = true
            };
            IprivilegeDal.IsPrivilegeAlreadyPresent(privilegeDto);
            if (privilegeDto.ErrorCount == 0)
            {
                IprivilegeDal.IsSequenceNoAlreadyPresent(privilegeDto);
                if (privilegeDto.ErrorCount == 0)
                {
                    IprivilegeDal.Insert(privilegeDto, con, trans);
                    privilege.Id = privilegeDto.Id;
                }
                else
                {
                    privilege.IsError = true;
                    privilege.ErrorMessage = privilegeDto.ErrorMessage;
                    privilege.ErrorMessageFor = "SequenceNo";

                }
            }
            else
            {
                privilege.IsError = true;
                privilege.ErrorMessage = privilegeDto.ErrorMessage;
                privilege.ErrorMessageFor = "Name";

            }
            return privilege;
        }

        public Privilege Update(Privilege privilege, SqlConnection con = null, SqlTransaction trans = null)
        {
            IPrivilegeDal IprivilegeDal = new PrivilegeDal();
            PrivilegeDto privilegeDto = new PrivilegeDto
            {
                Id = privilege.Id,
                Name = privilege.Name,
                SequenceNo = privilege.SequenceNo,
                IsActive = true
            };
            IprivilegeDal.IsPrivilegeAlreadyPresent(privilegeDto);
            if (privilegeDto.ErrorCount == 0)
            {

                IprivilegeDal.IsSequenceNoAlreadyPresent(privilegeDto);
                if (privilegeDto.ErrorCount == 0)
                {
                    IprivilegeDal.Update(privilegeDto, con, trans);
                    privilege.Id = privilegeDto.Id;
                }
                else
                {
                    privilege.IsError = true;
                    privilege.ErrorMessage = privilegeDto.ErrorMessage;
                    privilege.ErrorMessageFor = "SequenceNo";

                }
            }
            else
            {
                privilege.IsError = true;
                privilege.ErrorMessage = privilegeDto.ErrorMessage;
                privilege.ErrorMessageFor = "Name";

            }
            return privilege;
        }

        public Privilege Delete(Privilege privilege, SqlConnection con = null, SqlTransaction trans = null)
        {
            IPrivilegeDal IprivilegeDal = new PrivilegeDal();
            PrivilegeDto privilegeDto = new PrivilegeDto
            {
                Id = privilege.Id,
                Name = privilege.Name,
                SequenceNo = privilege.SequenceNo,
                IsActive = false
            };
            Boolean IsPrivilegeReferencePresent = IprivilegeDal.IsPrivilegeReferencePresent(privilegeDto.Id);
            if (!IsPrivilegeReferencePresent)
            {
                IprivilegeDal.Delete(privilegeDto, con, trans);
                privilege.Id = privilegeDto.Id;
            }
            else
            {
                privilege.IsError = true;
                privilege.ErrorMessage = "Please first deallocate privilege under Menu ";
                privilege.ErrorMessageFor = "Name";
            }
            return privilege;
        }

        public static Privilege GetPrivilege(Guid Id)
        {
            IPrivilegeDal IprivilegeDal = new PrivilegeDal();
            PrivilegeDto privilegeDto = IprivilegeDal.FetchById(Id);
            Privilege privilege = new Privilege
            {
                Id = privilegeDto.Id,
                Name = privilegeDto.Name,
                SequenceNo = privilegeDto.SequenceNo,
            };
            return privilege;
        }

        public static Privilege Get()
        {
            Privilege privilege = new Privilege();
            return privilege;
        }

        public static PrivilegePersister GetPersister()
        {
            PrivilegePersister privilegePersister = new PrivilegePersister();
            return privilegePersister;
        }
    }
}
