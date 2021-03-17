namespace los_api.Models
{
    public class StockInfoModel
    {
        public Stock stock { set; get; }
    }

    public abstract class Stock : StockModel
    {
        public ProductDetail product { set; get; }
    }

    public abstract class ProductDetail : ProductModel
    {
    }

}