namespace Domain.Enums
{
    public enum CarUsage
    {
        SocialOnly,
        BusinessUse,
        SocialAndCommuting
    }

    public static class CarUsageExtensions
    {
        public static string ToFriendlyString(this CarUsage me)
        {
            switch (me)
            {
                case CarUsage.SocialOnly:
                    return "SocialOnly";
                case CarUsage.BusinessUse:
                    return "BusinessUse";
                case CarUsage.SocialAndCommuting:
                    return "SocialAndCommuting";
                default:
                    return "";
            }
        }
    }
}
