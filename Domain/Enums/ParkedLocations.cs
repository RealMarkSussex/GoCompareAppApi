namespace Domain.Enums
{
    public enum ParkedLocations
    {
        OnADriveway,
        OnTheRoadAtHome,
        InAWorkCarPark,
        Other
    }

    public static class ParkedLocationsExtensions
    {
        public static string ToFriendlyString(this ParkedLocations me)
        {
            switch (me)
            {
                case ParkedLocations.OnADriveway:
                    return "OnADriveway";
                case ParkedLocations.OnTheRoadAtHome:
                    return "OnTheRoadAtHome";
                case ParkedLocations.InAWorkCarPark:
                    return "InAWorkCarPark";
                case ParkedLocations.Other:
                    return "Other";
                default:
                    return "";
            }
        }
    }
}

