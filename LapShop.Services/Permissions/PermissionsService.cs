using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LapShop.Data;
using LapShop.Domains;
using Microsoft.EntityFrameworkCore;

namespace LapShop.Services.Permissions
{
    public class PermissionsService : IPermissionsService
    {
        private readonly MainContext _context;

        public PermissionsService(MainContext context)
        {
            _context = context;
        }

        public async Task<UserPermissions> GetPermissionByAction(string userId, string area, string controller, string action)
        {
                       return await _context.UserPermissions
                           .AsQueryable()
                           .FirstOrDefaultAsync(up => up.UserId == userId && 
                                                 up.Area == area && 
                                                 up.Controller == controller && 
                                                 up.Action == action);
        }

        public async Task<List<UserPermissions>> GetPermissionsByUser(string userId)
        {
            return await _context.UserPermissions
                                 .AsQueryable()
                                 .Where(up => up.UserId == userId)
                                 .ToListAsync();
        }

        public async Task Save(List<string> SelectedActions)
        {
            List<UserPermissions> userPermissions = new List<UserPermissions>();
            foreach (var entry in SelectedActions)
            {
                var parts = entry.Split('|');
                if (parts.Length == 4)
                {
                    userPermissions.Add(new UserPermissions
                    {
                        UserId = parts[0].Trim(),
                        Area = parts[1].Trim(),
                        Controller = parts[2].Trim(),
                        Action = parts[3].Trim()
                    });
                }

            }
            _context.UserPermissions.AddRange(userPermissions);
            await _context.SaveChangesAsync();
        }
    }
}
