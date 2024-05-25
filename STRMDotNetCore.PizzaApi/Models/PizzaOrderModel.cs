using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STRMDotNetCore.PizzaApi.Models;

    [Table("Tbl_PizzaOrder")]
    public class PizzaOrderModel
    {
        [Key]
        [Column("PizzaOrderId")]
        public int PizzaOrderId { get; set; }
        [Column("PizzaOrderInvoiceNo")]
        public string PizzaOrderInvoiceNo { get; set; }
        [Column("PizzaId")]
        public int PizzaId { get; set; }
        [Column("TotalAmount")]
        public decimal TotalAmount { get; set; }
        
}

