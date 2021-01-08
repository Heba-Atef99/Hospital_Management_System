using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_University.ViewModels
{
    public class PaymentVM
    {
        [Required(ErrorMessage ="Please Enter a Valid Credit Card Holder")]
        [StringLength(30)]
        public string CardHolderName { get; set; } 
        [Required(ErrorMessage ="Please Enter Valid Credit Card")]
        [CreditCard]
        [StringLength(15)]
        public int CardNumber { get; set; }
        [Required(ErrorMessage = "Please Enter A Valid Card Date")]
        //[DataType(DataType.Date)]
        public string ExpDate { get; set; }
        [Required(ErrorMessage ="Required")]
        [StringLength(3)]
        public int CVcode { get; set; }
        [Required(ErrorMessage ="Please Enter Your ZIP Code")]
        [StringLength(5)]
        public int ZipCode { get; set; }
    }
}
