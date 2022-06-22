using System.ComponentModel.DataAnnotations;
using Trackr.Data.Utils.Types;

namespace Trackr.Core.DTOs
{
    public class SettingsDTO
    {
        public string Id { get; set; }

        [RegularExpression(ListDisplayType.Fields)]
        public string DefaultListDisplayType { get; set; } = ListDisplayType.Card;

        public bool IsDarkMode { get; set; } = false;
    }
}
