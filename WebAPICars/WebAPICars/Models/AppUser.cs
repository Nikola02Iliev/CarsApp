using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebAPICars.Models
{
    public class AppUser : IdentityUser
    {
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
