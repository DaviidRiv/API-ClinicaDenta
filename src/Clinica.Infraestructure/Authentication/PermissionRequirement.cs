using Microsoft.AspNetCore.Authorization;

namespace Clinica.Infraestructure.Authentication
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        //nombre permiso requerido
        public string Permission { get; }

        public PermissionRequirement(string permission)
        {
            Permission = permission;
        }
    }
}
