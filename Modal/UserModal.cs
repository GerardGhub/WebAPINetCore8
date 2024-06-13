using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPINetCore8.Modal
{
    public class UserModal
    {
        [StringLength(50)]
        [Unicode(false)]
        public string Code { get; set; } 

        [StringLength(50)]
        [Unicode(false)]
        public string Name { get; set; } 

        [StringLength(50)]
        [Unicode(false)]
        public string? Email { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        public string? Phone { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        public string Password { get; set; }


        public bool? IsActive { get; set; }

        public string Role { get; set; }
    }
}
