using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Models
{
    public class MenuMasterBO
    {

     public int MenuId { get; set; }

     [Display(Name = "Menu Name")]
     [Required(ErrorMessage = "Menu Name Required")]
     public string MenuName { get; set; }

        public string ParentMenuId { get; set; }
        //public string ParentMenuName { get; set; }

        public int? DisplayOrder { get; set; }

    [Display(Name = "PageURL")]
    [Required(ErrorMessage = "PageURL Required")]
    public string PageURL { get; set; }

     [Display(Name = "ImageURL")]
     [Required(ErrorMessage = "ImageURL Required")]
     public string ImageURL { get; set; }

    public string MenuGroupId { get; set; }

    [Display(Name = "Menu Key")]
    [Required(ErrorMessage = "Menu Key Required")]
    public string MenuKey { get; set; }

    [Display(Name = "faIcon")]
    [Required(ErrorMessage = "faIcon Required")]
    public string faIcon { get; set; }

    [Display(Name = "Help URL")]
    [Required(ErrorMessage = "Help URL Required")]
    public string HelpURL { get; set; }

    [Display(Name = "Help DocURL")]
    [Required(ErrorMessage = "Help DocURL Required")]
    public string HelpDocURL { get; set; }

    [Display(Name = "Local Video")]
    [Required(ErrorMessage = "Local Video Required")]
    public string LocalVideo { get; set; }

    [Display(Name = "Local Document")]
    [Required(ErrorMessage = "Local Document Required")]
    public string LocalDocument { get; set; }
    public string CreatedOn { get; set; }

    public bool IsActive { get; set; }
  

    }
}
