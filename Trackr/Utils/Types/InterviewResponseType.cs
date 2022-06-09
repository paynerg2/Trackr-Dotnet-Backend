namespace Trackr.Utils.Types
{
    public static class InterviewResponseType
    {
        public const string None = "none";
        public const string Passed = "passed";
        public const string Rejected = "rejected";
        public const string Offer = "offer";

        public const string Fields = $"{None}|{Passed}|{Rejected}|{Offer}";
    }
}
