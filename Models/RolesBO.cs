
using System.ComponentModel.DataAnnotations;
namespace Models
{
    public class RolesBO
    {
        public int RoleId { get; set; }
        [Display(Name ="Role Name")]
        public string RoleName { get; set; }

        [Display(Name ="Description")]
        public string Description { get; set; }

        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }

    }
}
