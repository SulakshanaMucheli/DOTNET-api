namespace DotnetAPI.models{
    public class Products
    {
        public string  Name{get; set;}
        public string Description{get; set;}
        public decimal  Price{get; set;}
        public int  Quantity{get; set;}

        public Products()
        {
            if(Name==null)
            {
                Name = " ";
            }
            if(Description==null)
            {
                Description = " ";
            }

        }
    };
}