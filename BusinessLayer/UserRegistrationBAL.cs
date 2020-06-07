using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;
namespace BusinessLayer
{
    public class UserRegistrationBAL
    {

        UserRegistrationDAL objUserRegistrationDAL = new UserRegistrationDAL();
        public List<CommonDropDownBO> getDonorProgramList(int iUserId)
        {
           return objUserRegistrationDAL.getDonorProgramList(iUserId);
        }


        public List<CommonDropDownBO> CountriesList()
        {
            return objUserRegistrationDAL.CountriesList();
        }
        public List<CommonDropDownBO> StatesList(int iCountryId)
        {
            return objUserRegistrationDAL.StatesList(iCountryId);
        }

        public List<CommonDropDownBO> GenderList()
        {
            return objUserRegistrationDAL.GenderList();
        }

        public List<CommonDropDownBO> RolesList()
        {
            return objUserRegistrationDAL.RolesList();
        }
        public List<CommonDropDownBO> LocationList()
        {
            return objUserRegistrationDAL.LocationList();
        }

        public List<UserRegistrationBO> getUsersList()
        {
            return objUserRegistrationDAL.getUsersList();
        }
        public string SaveorUpdateUserRegistration(UserRegistrationBO objUserRegistrationBO, int iUserId)
        {
            return objUserRegistrationDAL.SaveorUpdateUserRegistration(objUserRegistrationBO, iUserId);
        }
        public UserRegistrationBO EditUserDetails(int iUserId)
        {
            return objUserRegistrationDAL.EditUserDetails(iUserId);
        }
        public UserRegistrationBO DisplayUser(int iUserId)
        {
            return objUserRegistrationDAL.DisplayUser(iUserId);
        }
        public string deleteUser(int iUserId)
        {
            return objUserRegistrationDAL.deleteUser(iUserId);
        }

    }
}
