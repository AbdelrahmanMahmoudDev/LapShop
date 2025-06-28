using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LapShop.Domains;

namespace LapShop.Services.Permissions
{
    public interface IPermissionsService
    {
        public Task<UserPermissions> GetPermissionByAction(string userId, string area, string controller, string action);
        public Task<List<UserPermissions>> GetPermissionsByUser(string userId);
        public Task Save(List<string> SelectedActions);
    }
}
