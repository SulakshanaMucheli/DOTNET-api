namespace DotnetAPI.models{
    public class Roles
    {
        public int RoleId{get; set;}
        public string Rolename{get; set;}
        public string Permissions{get; set;}
       

        public Roles()
        {
            if(Rolename==null)
            {
                Rolename = " ";
            }
            if(Permissions==null)
            {
                Permissions = " ";
            }
        }
    };
}