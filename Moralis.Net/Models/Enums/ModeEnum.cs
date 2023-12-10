using System.ComponentModel.DataAnnotations;

namespace Moralis.Net.Models.Enums
{
    public enum ModeEnum
    {
        NONE,

        [Display(Name = "sync")]
        SYNC,

        [Display(Name = "async")]
        ASYNC
    }
}
