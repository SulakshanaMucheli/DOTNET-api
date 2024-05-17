namespace DotnetAPI.models{
public class Customers
    {
        public int CustomerId{get; set;}
        public string Name{get; set;}
        public string ContactInfo{get; set;}
        public string BillingAddress{get; set;}
        public string ShippingAddress{get; set;}

        public Customers()
        {
            if(Name==null)
            {
                Name= " ";
            }
            if(ContactInfo==null)
            {
                ContactInfo = " ";
            }
            if(BillingAddress==null)
            {
                BillingAddress = " ";
            }
            if(ShippingAddress==null)
            {
                ShippingAddress = " ";
            }
        }
    };
}