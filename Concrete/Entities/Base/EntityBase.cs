using SupplierApp.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupplierApp.Concrete.Entities.Base
{
    public abstract class EntityBase : IEntity
    {
        /// <summary>
        /// Auto Increment Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }


        /// <summary>
        /// Now / GetDate()
        /// </summary>
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
