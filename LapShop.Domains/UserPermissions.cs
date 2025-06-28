using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LapShop.Domains
{
    public class UserPermissions
    {
        public int UserPermissionsId { get; set; }
        public string UserId { get; set; } = null!;
        public string Area { get; set; } = null!;
        public string Controller { get; set; } = null!;
        public string Action { get; set; } = null!;
    }
}
