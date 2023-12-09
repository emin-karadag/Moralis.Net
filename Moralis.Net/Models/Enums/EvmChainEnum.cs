using System.ComponentModel.DataAnnotations;

namespace Moralis.Net.Models.Enums
{
    public enum EvmChainEnum
    {
        [Display(Name = "0x1")]
        ETHEREUM,

        [Display(Name = "0x5")]
        GOERLI,

        [Display(Name = "0xaa36a7")]
        SEPOLIA,

        [Display(Name = "0x89")]
        POLYGON,

        [Display(Name = "0x13881")]
        MUMBAI,

        [Display(Name = "0x38")]
        BSC,

        [Display(Name = "0x61")]
        BSC_TESTNET,

        [Display(Name = "0xa86a")]
        AVALANCHE,

        //[Display(Name = "")]
        //AVALANCHE_TESTNET,

        [Display(Name = "0xfa")]
        FANTOM,

        //[Display(Name = "")]
        //FANTOM_TESTNET,

        [Display(Name = "0x19")]
        CRONOS,

        [Display(Name = "0x2a15c308d")]
        PALM,

        [Display(Name = "0xa4b1")]
        ARBITRUM,

        //[Display(Name = "")]
        //ARBITRUM_TESTNET,

        //[Display(Name = "")]
        //RONIN,

        //[Display(Name = "")]
        //OPTIMISM

        [Display(Name = "0x64")]
        GNOSIS,

        [Display(Name = "0x27d8")]
        GNOSIS_TESTNET,

        [Display(Name = "0x15b38")]
        CHILIZ,

        [Display(Name = "0x15b32")]
        CHILIZ_TESTNET,

        [Display(Name = "0x2105")]
        BASE,

        [Display(Name = "0x14a33")]
        BASE_TESTNET,
    }
}
