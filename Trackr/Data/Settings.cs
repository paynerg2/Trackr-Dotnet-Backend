using System.ComponentModel.DataAnnotations.Schema;
using Trackr.Utils.Types;

namespace Trackr.Data
{
    public class Settings
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public bool IsDarkMode { get; set; } = false;
        public string DefaultListDisplayType { get; set; } = ListDisplayType.Card;

    }
}
