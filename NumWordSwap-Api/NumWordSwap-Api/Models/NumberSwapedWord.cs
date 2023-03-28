using System;
/**
 * NumWordSwap - This Model is used to define a set of multiple and wordswap
 * 
 * @author Akhila Rachupalli
 *
 */
namespace NumWordSwap_Api.Models
{
	public record NumberSwapedWord
    {
        public int Number { get; set; }
        public string? SwappedWord { get; set; }
    }
}

