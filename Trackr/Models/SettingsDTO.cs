using System.ComponentModel.DataAnnotations;
using Trackr.Utils.Types;

namespace Trackr.Models
{
    public class SettingsDTO
    {
        public string Id { get; set; }

        [RegularExpression(ListDisplayType.Fields)]
        public string DefaultListDisplayType { get; set; } = ListDisplayType.Card;

        public bool IsDarkMode { get; set; } = false;
    }
}
