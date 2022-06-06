namespace Trackr.Models
{
    public class Settings
    {
        public string Id { get; set; }
        public Boolean IsDarkMode { get; set; } = false;
        public ListDisplayType DefaultListDisplayType { get; set; } = ListDisplayType.Card;

    }

    public enum ListDisplayType
    {
        Card,
        List
    }
}
