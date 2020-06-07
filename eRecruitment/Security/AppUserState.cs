using Models;
namespace eRecruitment.Security
{
    public class AppUserState
    {

        public string UserId = string.Empty;
        public string FirstName = string.Empty;
        public string LastName = string.Empty;
        public string UserName = string.Empty;
        public string EmailId = string.Empty;
        public string Gender = string.Empty;
        public string Address = string.Empty;
        public string PhoneNo = string.Empty;
        public int EmployeeId = 0;
        public bool IsActive = true;
        public bool IsAdmin = false;
        public int RoleId = 0;
        public string RoleName = "";


        public override string ToString()
        {
            return this.FirstName + this.LastName;
        }


        /// <summary>
        /// Imports Id, Email and Name from a | separated string
        /// </summary>
        /// <param name="itemString"></param>
        public bool FromString(string itemString)
        {
            if (string.IsNullOrEmpty(itemString))
                return false;

            string[] strings = itemString.Split('|');
            if (strings.Length < 3)
                return false;

            UserId = strings[0];
            UserName = strings[1];

            return true;
        }

        /// <summary>
        /// Populates the AppUserState properties from a
        /// User instance
        /// </summary>
        /// <param name="user"></param>
        public void FromUser(UserBO objUserBo)
        {
            UserId = objUserBo.UserId;
            FirstName = objUserBo.FirstName;
            LastName = objUserBo.LastName;
            UserName = objUserBo.UserName;
            EmailId = objUserBo.EmailId;
            Gender = objUserBo.Gender;
            Address = objUserBo.Address;
            PhoneNo = objUserBo.PhoneNo;
            IsActive = objUserBo.IsActive;
            EmployeeId = objUserBo.EmployeeId;
            RoleId = objUserBo.RoleId;
            RoleName = objUserBo.RoleName;
        }

        /// <summary>
        /// Determines if the user is logged in
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            if (string.IsNullOrEmpty(this.UserId) || string.IsNullOrEmpty(this.UserName))
                return true;

            return false;
        }
    }
}