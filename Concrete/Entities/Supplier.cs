using SupplierApp.Concrete.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace SupplierApp.Concrete.Entities
{
    public class Supplier : EntityBase
    {
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Field [First Name] cannot exceed 50 characters")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Field [Last Name] cannot exceed 50 characters")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        [StringLength(250, ErrorMessage = "Field [Street Address] cannot exceed 250 characters")]
        public string StreetAddress { get; set; }


        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        [StringLength(150, ErrorMessage = "Field [Suburb] cannot exceed 150 characters")]
        public string Suburb { get; set; }


        public int PostCode { get; set; }


        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "Field [State] cannot exceed 100 characters")]
        public string State { get; set; }


        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        [StringLength(150, ErrorMessage = "Field [Country] cannot exceed 150 characters")]
        public string Country { get; set; }
    }
}
