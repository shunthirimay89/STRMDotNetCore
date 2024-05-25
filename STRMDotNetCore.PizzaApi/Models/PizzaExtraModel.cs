using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STRMDotNetCore.PizzaApi.Models;

    [Table("Tbl_PizzaExtra")]
    public class PizzaExtraModel
    {
        [Key]
        [Column ("PizzaExtraId")]
        public int  id { get; set; }
        [Column("PizzaExtraName")]
        public string pizzaExtraName { get; set; }
        [Column("PizzaExtraPrice")]
        public decimal pizzaExtraPrice { get; set; }
        [NotMapped]
        public string priceStr { get { return  "$" +pizzaExtraPrice; } }  
    }

