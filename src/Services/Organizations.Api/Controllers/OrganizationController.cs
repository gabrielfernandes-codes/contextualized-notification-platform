using Organizations.Api.Entity;

namespace Organizations.Api.Controllers
{
    class OrganizationController
    {
        public static Organization Create()
        {
            var organization = new Organization { Id = Guid.NewGuid().ToString() };

            return organization;
        }
    }
}