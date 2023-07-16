using System.ComponentModel.DataAnnotations;

namespace Moralis.Net.Models.Enums
{
    public enum ExchangeEnum
    {
        NONE,

        [Display(Name = "uniswapv2")]
        UNISWAPV2,

        [Display(Name = "uniswapv3")]
        UNISWAPV3,

        [Display(Name = "sushiswapv2")]
        SUSHISWAPV2,

        [Display(Name = "pancakeswapv1")]
        PANCAKESWAPV1,

        [Display(Name = "pancakeswapv2")]
        PANCAKESWAPV2,

        [Display(Name = "quickswap")]
        QUICKSWAP,

        [Display(Name = "quickswapv2")]
        QUICKSWAPV2,

        [Display(Name = "traderjoe")]
        TRADERJOE,

        [Display(Name = "pangolin")]
        PANGOLIN,

        [Display(Name = "spookyswap")]
        SPOOKYSWAP,

        [Display(Name = "vvs")]
        VVS,

        [Display(Name = "camelotv2")]
        CAMELOTV2
    }
}
