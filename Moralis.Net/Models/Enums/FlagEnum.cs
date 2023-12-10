using System.ComponentModel.DataAnnotations;

namespace Moralis.Net.Models.Enums
{
    public enum FlagEnum
    {
        NONE,

        [Display(Name = "uri")]
        URI,

        [Display(Name = "metadata")]
        METADATA
    }
}
