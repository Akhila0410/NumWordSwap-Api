using NumWordSwap_Api.Models;
/**
 * NumWordSwapRequest - This Request Model is used to receive the JSON NumWordSwapRequest Body from Angular Client
 * 
 * @author Akhila Rachupalli
 *
 */
namespace NumWordSwap_Api;

public class NumWordSwapRequest
{
    public int MaxNumber{ get; set; }
    public List<MultipleWordSwap>? MultipleWordSwaps { get; set; }
    public bool SortedOrder { get; set; }
}

