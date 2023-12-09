using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
