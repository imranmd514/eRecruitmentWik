using BusinessLayer;
using eRecruitment.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserBO : ErrorDisplay
    {
        public string UserId
        {
            get;
            set;
        }
        public string UserName
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string Gender
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string Address
        {
            get;
            set;
        }

        public string PhoneNo
        {
            get;
            set;
        }

        public Boolean IsActive
        {
            get;
            set;
        }

        public string EmailId
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public Boolean IsAdmin
        {
            get;
            set;
        }

        public int EmployeeId
        {
            get;
            set;
        }

        public int RoleId
        {
            get;
            set;
        }

        public string RoleName
        {
            get;
            set;
        }


        public string GetNameFromUserId(string userId)
        {
            return "";
        }

        public void SetUserForEmailValidation(UserBO user = null)
        {
            if (user == null)
                return;

            user.IsActive = true;
        }


        /// <summary>
        /// Validates a user by username
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public bool ValidateUser(string strUsername, string strPassword)
        {
            SetError();
            if (string.IsNullOrEmpty(strUsername) || string.IsNullOrEmpty(strPassword))
            {
                SetError("Empty usernames or passwords are not allowed");
                return false;
            }
            SecurityBAL objSecurityBAL = new SecurityBAL();

            string strResult = "";
            UserMasterBO objUserMasterBO = objSecurityBAL.verifyLogin(strUsername, strPassword, ref strResult);
            UserBO objUserBO = null;
            if (strResult == "SUCCESS")
            {
                objUserBO = new UserBO();
                UserId = objUserMasterBO.UserId;
                FirstName = objUserMasterBO.FirstName;
                LastName = objUserMasterBO.LastName;
                UserName = objUserMasterBO.UserName;
                EmailId = objUserMasterBO.EmailId;
                Gender = objUserMasterBO.Gender;
                Address = objUserMasterBO.Address;
                PhoneNo = objUserMasterBO.PhoneNo;
                IsActive = objUserMasterBO.IsActive;
                EmployeeId = objUserMasterBO.EmployeeId;
            }

            if (strResult == "IN_VALID")
            {
                SetError("Invalid username or password.");
                return false;
            }

            if (strResult == "IN_ACTIVE")
            {
                SetError("User is not active. Please contact administrator");
                return false;
            }


            return true;
        }

        /// <summary>
        /// Authenticates a user and if successful returns a user instance
        /// </summary>
        /// <param name="strUserName"></param>
        /// <param name="strPassword"></param>
        /// <returns></returns>
        public UserBO ValidateUserAndLoad(string strUserName, string strPassword)
        {

            if (string.IsNullOrEmpty(strUserName) || string.IsNullOrEmpty(strPassword))
            {
                return null;
            }

            SecurityBAL objSecurityBAL = new SecurityBAL();

            string strResult = "";
            UserMasterBO objUserMasterBO = objSecurityBAL.verifyLogin(strUserName, strPassword, ref strResult);
            UserBO objUserBO = null;
            if (strResult == "SUCCESS")
            {
                objUserBO = new UserBO();
                objUserBO.UserId = objUserMasterBO.UserId;
                objUserBO.FirstName = objUserMasterBO.FirstName;
                objUserBO.LastName = objUserMasterBO.LastName;
                objUserBO.UserName = objUserMasterBO.UserName;
                objUserBO.EmailId = objUserMasterBO.EmailId;
                objUserBO.Gender = objUserMasterBO.Gender;
                objUserBO.Address = objUserMasterBO.Address;
                objUserBO.PhoneNo = objUserMasterBO.PhoneNo;
                objUserBO.IsActive = objUserMasterBO.IsActive;
                objUserBO.RoleId = objUserMasterBO.RoleId;
                objUserBO.RoleName = objUserMasterBO.RoleName;
                objUserBO.EmployeeId = objUserMasterBO.EmployeeId;
            }

            //string encodedPassword = AppSecurity.EncodePassword(strUserName, objUserBO.UserId);

            if (strResult == "IN_VALID")
            {
                SetError("Invalid username or password.");
                return null;
            }

            if (strResult == "IN_ACTIVE")
            {
                SetError("User is not active. Please contact administrator");
                return null;
            }

            return objUserBO;
        }

        /// <summary>
        /// Users open ID account. NOTE should only be called if returned from
        /// a successful OpenId validation
        /// </summary>
        /// <param name="providerKey"></param>
        /// <returns></returns>
        public UserBO ValidateUserWithExternalLogin(string providerKey)
        {
            UserBO objUserBO = null;
            //SetError();
            //if (string.IsNullOrEmpty(providerKey))
            //{
            //    SetError("Invalid login.");
            //    return null;
            //}

            //User user = LoadBase(usr => usr.OpenId == providerKey || usr.OpenIdClaim == providerKey);
            //if (user == null)
            //{
            //    SetError("OpenId Login is not associated with an account.");
            //    return null;
            //}

            //Entity = user;

            return objUserBO;
        }

        public UserBO ValidateEmailAddress(string validator)
        {
            UserBO objUserBO = null;
            if (objUserBO == null)
                throw new ApplicationException("Invalid email validator id.");

            objUserBO.IsActive = false;

            return objUserBO;
        }

        /// <summary>
        /// Loads a user from the email address
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public UserBO LoadUserByEmail(string email)
        {
            UserBO objUserBO = null;
            return objUserBO;
        }

        public UserBO LoadUserByUserId(string strUserId)
        {
            UserBO objUserBO = null;
            return objUserBO;
        }



        /// <summary>
        /// Returns a list of items
        /// </summary>
        /// <param name="whereClauseLambda"></param>
        /// <returns></returns>
        public List<UserBO> GetUserList(Func<UserBO, bool> whereClauseLambda)
        {
            List<UserBO> userList = null;

            return userList;
        }




    }
}
