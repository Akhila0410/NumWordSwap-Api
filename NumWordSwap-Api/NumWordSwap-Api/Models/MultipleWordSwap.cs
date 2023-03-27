using System;
/**
 * NumWordSwap - This Model is used to define a set of multiple and wordswap
 * 
 * @author Akhila Rachupalli
 *
 */
namespace NumWordSwap_Api.Models
{
	public record MultipleWordSwap
    {
        public int Multiple { get; set; }
        public string? WordSwap { get; set; }
    }
}

