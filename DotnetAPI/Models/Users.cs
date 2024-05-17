namespace DotnetAPI.models{
    public class User
    {
        public int userId{get; set;}
        public string Firstname{get; set;}
        public string Lastname{get; set;}
        public string PASSWORD{get; set;}

        public User()
        {
            if(Firstname==null)
            {
                Firstname = " ";
            }
            if(Lastname==null)
            {
                Lastname = " ";
            }
            if(PASSWORD==null)
            {
                PASSWORD = " ";
            }
        }
    };
}