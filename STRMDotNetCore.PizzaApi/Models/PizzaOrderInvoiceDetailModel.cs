using System.ComponentModel.DataAnnotations.Schema;

namespace STRMDotNetCore.PizzaApi.Models;

    public class PizzaOrderInvoiceDetailModel
    {
  
    public int PizzaOrderDetailId { get; set; }
    
    public string PizzaOrderInvoiceNo { get; set; }
    
    public int PizzaExtraId { get; set; }
    public string PizzaExtraName {  get; set; }
    public decimal PizzaExraPrice { get; set; }
}

