using System.Text;
using Microsoft.AspNetCore.Mvc;
using NumWordSwap_Api.Models;

namespace NumWordSwap_Api.Controllers;

[ApiController]
[Route("api")]
public class NumWordSwapController : ControllerBase
{

    private readonly ILogger<NumWordSwapController> _logger;

    public NumWordSwapController(ILogger<NumWordSwapController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    [Route("getswappednumwords")]
    public IEnumerable<NumWordSwap> GetSwappedNumWords(NumWordSwapRequest request)
    {

        // Null Request and Invalid Max Number validation
        if (request == null || request.MaxNumber <= 0)
        {
            return new List<NumWordSwap>();
        }

        var result = new NumWordSwap[request.MaxNumber];
        try
        {
            // If No NumWordSwaps sent
            if (request.NumWordSwaps?.Count == 0)
            {
                for (var i = 1; i <= request.MaxNumber; i++)
                {
                    result[i - 1] = new NumWordSwap() { Number = i, WordSwap = i.ToString() };
                }
            }

            // If NumWordSwaps Present
            for (var i = 1; i <= request.MaxNumber; i++)
            {
                var wordSwapResult = new StringBuilder();
                var numWordSwaps = !!request.SortedOrder ? request.NumWordSwaps?.OrderBy(nws => nws.Number).ToList() : request.NumWordSwaps;

                numWordSwaps?.ForEach(nws =>
                {
                    if (i % nws.Number == 0)
                    {
                        wordSwapResult.Append(nws.WordSwap);
                    }
                });

                result[i - 1] = new NumWordSwap() { Number = i, WordSwap = (wordSwapResult.Length == 0) ? i.ToString() : wordSwapResult.ToString() };
            }
        }
        catch(Exception ex) {
            _logger.LogError("Get NumWordSwaps request error:" + ex);
            throw new Exception("Get NumWordSwaps request error:" + ex);
        }

        return result;
    }
}

