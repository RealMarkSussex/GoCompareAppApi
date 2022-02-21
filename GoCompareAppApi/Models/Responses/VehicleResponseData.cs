namespace GoCompareAppApi.Models.Responses
{
    public class VehicleResponseData
    {
        public string RegNo { get; }
        public VehicleResponseData(string regNo)
        {
            RegNo = regNo;
        }
    }
}
