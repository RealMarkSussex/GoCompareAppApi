namespace GoCompareAppApi.Models.Responses
{
    public class Vehicle
    {
        public string RegNo { get; }
        public Vehicle(string regNo)
        {
            RegNo = regNo;
        }
    }
}
