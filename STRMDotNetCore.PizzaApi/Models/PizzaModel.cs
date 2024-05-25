using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STRMDotNetCore.PizzaApi.Models;


[Table("Tbl_Pizza")]
public class PizzaModel
 {

    [Key]
    [Column("PizzaId")]
    public int id { get; set; }

    [Column("Pizza")]
    public string name { get; set; }

    [Column("Price")]
    public decimal price { get; set; }
} 

