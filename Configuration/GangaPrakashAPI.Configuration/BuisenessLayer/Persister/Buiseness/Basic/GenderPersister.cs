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
    public class GenderPersister
    {
        public Gender Insert(Gender gender, SqlConnection con = null, SqlTransaction trans = null)
        {
            IGenderDal IgenderDal = new GenderDal();
            GenderDto genderDto = new GenderDto
            {
                Name = gender.Name,
                IsActive = true
            };
            IgenderDal.IsGenderAlreadyPresent(genderDto);
            if (genderDto.ErrorCount == 0)
            {
                IgenderDal.Insert(genderDto, con, trans);
                gender.Id = genderDto.Id;

            }
            else
            {
                gender.IsError = true;
                gender.ErrorMessage = genderDto.ErrorMessage;
                gender.ErrorMessageFor = "Name";

            }
            return gender;
        }

        public Gender Update(Gender gender, SqlConnection con = null, SqlTransaction trans = null)
        {
            IGenderDal IgenderDal = new GenderDal();
            GenderDto genderDto = new GenderDto
            {
                Id = gender.Id,
                Name = gender.Name,
                IsActive = true
            };
            IgenderDal.IsGenderAlreadyPresent(genderDto);
            if (genderDto.ErrorCount == 0)
            {
                IgenderDal.Update(genderDto, con, trans);
                gender.Id = genderDto.Id;
            }
            else
            {
                gender.IsError = true;
                gender.ErrorMessage = genderDto.ErrorMessage;
                gender.ErrorMessageFor = "Name";

            }
            return gender;
        }

        public Gender Delete(Gender gender, SqlConnection con = null, SqlTransaction trans = null)
        {
            IGenderDal IgenderDal = new GenderDal();
            GenderDto genderDto = new GenderDto
            {
                Id = gender.Id,
                IsActive = false
            };
            IgenderDal.Delete(genderDto, con, trans);
            gender.Id = genderDto.Id;
            return gender;
        }

        public static Gender GetGender(Guid Id)
        {
            IGenderDal IgenderDal = new GenderDal();
            GenderDto genderDto = IgenderDal.FetchById(Id);
            Gender gender = new Gender
            {
                Id = genderDto.Id,
                Name = genderDto.Name
            };
            return gender;
        }

        public static Gender Get()
        {
            Gender gender = new Gender();
            return gender;
        }

        public static GenderPersister GetPersister()
        {
            GenderPersister genderPersister = new GenderPersister();
            return genderPersister;
        }
    }
}
