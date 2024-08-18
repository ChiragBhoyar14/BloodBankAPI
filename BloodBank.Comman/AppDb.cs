namespace BloodBank.Comman
{
    public class AppDb
    {
        public string Connectionstring { get; set; }
        public string Key {  get; set; }
        public string IV {  get; set; }


        public AppDb(string connectionstring, string key, string iV)
        {
            Connectionstring = connectionstring;
            Key = key;
            IV = iV;
        }
    }
}
