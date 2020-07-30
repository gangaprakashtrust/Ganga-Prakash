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
    public class IdentityTypePersister
    {
        public IdentityType Insert(IdentityType identityType, SqlConnection con = null, SqlTransaction trans = null)
        {
            IIdentityTypeDal IidentityTypeDal = new IdentityTypeDal();
            IdentityTypeDto identityTypeDto = new IdentityTypeDto
            {
                Type = identityType.Type,
                IsActive = true
            };
            IidentityTypeDal.IsIdentityTypeAlreadyPresent(identityTypeDto);
            if (identityTypeDto.ErrorCount == 0)
            {
                IidentityTypeDal.Insert(identityTypeDto, con, trans);
                identityType.Id = identityTypeDto.Id;

            }
            else
            {
                identityType.IsError = true;
                identityType.ErrorMessage = identityTypeDto.ErrorMessage;
                identityType.ErrorMessageFor = "Type";

            }
            return identityType;
        }

        public IdentityType Update(IdentityType identityType, SqlConnection con = null, SqlTransaction trans = null)
        {
            IIdentityTypeDal IidentityTypeDal = new IdentityTypeDal();
            IdentityTypeDto identityTypeDto = new IdentityTypeDto
            {
                Id = identityType.Id,
                Type = identityType.Type,
                IsActive = true
            };
            IidentityTypeDal.IsIdentityTypeAlreadyPresent(identityTypeDto);
            if (identityTypeDto.ErrorCount == 0)
            {
                IidentityTypeDal.Update(identityTypeDto, con, trans);
                identityType.Id = identityTypeDto.Id;
            }
            else
            {
                identityType.IsError = true;
                identityType.ErrorMessage = identityTypeDto.ErrorMessage;
                identityType.ErrorMessageFor = "Type";

            }
            return identityType;
        }

        public IdentityType Delete(IdentityType identityType, SqlConnection con = null, SqlTransaction trans = null)
        {
            IIdentityTypeDal IidentityTypeDal = new IdentityTypeDal();
            IdentityTypeDto identityTypeDto = new IdentityTypeDto
            {
                Id = identityType.Id,
                IsActive = false
            };
            IidentityTypeDal.Delete(identityTypeDto, con, trans);
            identityType.Id = identityTypeDto.Id;
            return identityType;
        }

        public static IdentityType GetIdentityType(Guid Id)
        {
            IIdentityTypeDal IidentityTypeDal = new IdentityTypeDal();
            IdentityTypeDto identityTypeDto = IidentityTypeDal.FetchById(Id);
            IdentityType identityType = new IdentityType
            {
                Id = identityTypeDto.Id,
                Type = identityTypeDto.Type
            };
            return identityType;
        }

        public static IdentityType Get()
        {
            IdentityType identityType = new IdentityType();
            return identityType;
        }

        public static IdentityTypePersister GetPersister()
        {
            IdentityTypePersister identityTypePersister = new IdentityTypePersister();
            return identityTypePersister;
        }
    }
}
