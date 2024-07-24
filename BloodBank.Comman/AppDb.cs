namespace BloodBank.Comman
{
    public class AppDb
    {
        public string Connectionstring { get; set; }


        public AppDb(string connectionstring)
        {
            Connectionstring = connectionstring;
        }
    }
}
