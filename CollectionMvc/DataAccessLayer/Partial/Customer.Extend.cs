using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DataAccessLayer
{
    [MetadataType(typeof(CustomerMetadata))]
    public partial class Customer
    {

    }

    public class CustomerMetadata
    {
        [Display(Name = "Customer ID")]
        [Required(ErrorMessage = "Customer ID need to be filled")]
        [StringLength(5,ErrorMessage = "Maximum 5 characters")]
        [Remote("CheckCustomerID","Customers",ErrorMessage = "Customer ID has been used")]
        public string CustomerID { get; set; }

        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Company Name need to be filled")]
        [StringLength(40, ErrorMessage = "Maximum 40 characters")]
        public string CompanyName { get; set; }
    }
}
