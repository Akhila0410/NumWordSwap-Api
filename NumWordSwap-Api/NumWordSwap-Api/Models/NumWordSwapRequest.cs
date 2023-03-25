using NumWordSwap_Api.Models;

namespace NumWordSwap_Api;

public class NumWordSwapRequest
{
    public int MaxNumber{ get; set; }
    public List<NumWordSwap>? NumWordSwaps { get; set; }
}

