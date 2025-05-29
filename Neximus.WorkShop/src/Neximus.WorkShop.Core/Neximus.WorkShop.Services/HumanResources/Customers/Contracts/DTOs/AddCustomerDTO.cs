using Neximus.WorkShop.Domain.HumanResources.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neximus.WorkShop.Services.HumanResources.Customers.Contracts.DTOs
{
    public class AddCustomerDTO
    {
        public AddCustomerDTO()
        {
            Addresses = new List<AddCustomerAddressDTO>();
            ContactInfo = new AddCustomerContactInfoDTO();
            ProfilePicture = new AddCustomerProfilePictureDTO();
        }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public Gender Gender { get; set; }

        public AddCustomerContactInfoDTO ContactInfo { get; set; }
        public AddCustomerProfilePictureDTO ProfilePicture { get; set; }
        public List<AddCustomerAddressDTO> Addresses { get; set; }

    }
}
