using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MainMenuBO
    {
        public int MenuId
        {
            get;
            set;
        }

        public string MenuName
        {
            get;
            set;
        }

        public int ParentMenuId
        {
            get;
            set;
        }

        public int DisplayOrder
        {
            get;
            set;
        }

        public string faIcon
        {
            get;
            set;
        }

        public string ImageURL
        {
            get;
            set;
        }

        public string HelpURL
        {
            get;
            set;
        }

        public string HelpDocURL
        {
            get;
            set;
        }

        public int MenuGroupId
        {
            get;
            set;
        }

        public string LocalDocument
        {
            get;
            set;
        }

        public string LocalVideo
        {
            get;
            set;
        }

        public string MenuKey
        {
            get;
            set;
        }

        public string PageURL
        {
            get;
            set;
        }

    }
}
