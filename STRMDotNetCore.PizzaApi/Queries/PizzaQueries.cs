namespace STRMDotNetCore.PizzaApi.Queries;

    public class PizzaQueries
    {
        public static string pizzaOrderQuery { get; } =
                    @"select po.*, p.Pizza, p.Price from Tbl_PizzaOrder po
                    inner join Tbl_Pizza p on p.PizzaId = po.PizzaId
                    where PizzaOrderInvoiceNo = @PizzaOrderInvoiceNo";

        public static string pizzaOrderDetailQuery { get; } =
                    @"select pod.*, px.PizzaExtraName, px.PizzaExtraPrice from Tbl_PizzaOrderDetail  pod
                    inner join Tbl_PizzaExtra px on pod.PizzaExtraId= px.PizzaExtraId
                    where PizzaOrderInvoiceNo = @PizzaOrderInvoiceNo;";
    }

