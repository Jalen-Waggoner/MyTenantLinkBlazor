using Microsoft.AspNetCore.Identity;

namespace MyTenantLink.Data
{
    public class User : IdentityUser
    {

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public string LongName => $"{FirstName} {LastName}";
    }
}
