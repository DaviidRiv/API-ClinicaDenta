using Microsoft.AspNetCore.Authorization;

namespace Clinica.Infraestructure.Authentication
{
    public sealed class HasPermissionAttribute : AuthorizeAttribute
    {
        public HasPermissionAttribute(Permission permissions) : base(policy: permissions.ToString()! )
        {
           
        }
    }
}
