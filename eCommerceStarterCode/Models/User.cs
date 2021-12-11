using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceStarterCode.Models
{
    public class User : IdentityUser
    { 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ShoppingCartId { get; set; }
    }
}
