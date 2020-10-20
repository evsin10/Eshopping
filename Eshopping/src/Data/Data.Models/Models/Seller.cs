using Data.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models.Models
{
   public class Seller : BaseModel
    {
        public string SellerName { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<SellerCustomers> SellerCustomers { get; set; }
    }
}
