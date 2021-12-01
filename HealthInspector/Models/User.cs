using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
       
        public DateTime Dob { get; set; }
        
        public string Gender { get; set; }
      
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        
        public string UserId { get; set; }
        [DataType(DataType.Password)]
     
        public string Password { get; set; }
        
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
   
        public string Role { get; set; }
 
        public string Answer1 { get; set; }
        
        public string Answer2 { get; set; }
        
        public string Answer3 { get; set; }


    }
}
