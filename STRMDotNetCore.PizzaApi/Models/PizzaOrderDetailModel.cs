using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STRMDotNetCore.PizzaApi.Models;
    [Table("Tbl_PizzaOrderDetail")]
    public class PizzaOrderDetailModel
    {
        [Key]
        [Column("PizzaOrderDetailId")]
        public int PizzaOrderDetailId { get; set; }
        [Column("PizzaOrderInvoiceNo")]
        public string PizzaOrderInvoiceNo { get; set; }
        [Column("PizzaExtraId")]
        public int PizzaExtraId {  get; set; }
        
     }

