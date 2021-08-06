using SupplierApp.Concrete.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupplierApp.Concrete.Entities
{
    public class Product : EntityBase
    {
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        [StringLength(250, ErrorMessage = "Field [Product Name] cannot exceed 250 characters")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Required")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Required")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Required")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Tax { get; set; }


        [Column(TypeName = "decimal(18, 2)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal PriceIncludedTax { get; private set; }
    }
}
