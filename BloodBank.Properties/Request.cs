namespace BloodBank.Properties
{
    public class Request
    {
        public long StateId { get; set; }
        public long CityId { get; set; }
        public int BloodGroupId {  get; set; }
        public string Name { get; set; }
        public long DonerId { get; set; }
        public string State { get; set; }
        public string City { get; set; }

        public Request()
        {
            StateId = 0;
            CityId = 0;
            BloodGroupId = 0;
            Name = string.Empty;
            DonerId = 0;
            State = string.Empty;
            City = string.Empty;
        }

    }
}
