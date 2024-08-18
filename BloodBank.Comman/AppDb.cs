using System.Text.RegularExpressions;


namespace BloodBank.Comman
{
    public class AppDb
    {
        public string Connectionstring { get; private set; }
        public string Key {  get; private set; }
        public string IV {  get; private set; }


        public AppDb(string connectionstring, string key, string iV)
        {
       //     Connectionstring = connectionstring;
            Key = key;
            IV = iV;
            Connectionstring = General.DecryptString(connectionstring, Key, IV);
            Connectionstring = Regex.Unescape(Connectionstring);
        }
    }
}
