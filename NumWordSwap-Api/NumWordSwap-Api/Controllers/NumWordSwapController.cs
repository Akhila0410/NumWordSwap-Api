using System.Text;
using Microsoft.AspNetCore.Mvc;
using NumWordSwap_Api.Interfaces;
using NumWordSwap_Api.Models;

/**
 * NumWordSwapController - This controller is the API Endpoint for JSON NumWordSwap request
 * 
 * @author Akhila Rachupalli
 *
 */

namespace NumWordSwap_Api.Controllers;
[ApiController]
[Route("api")]
public class NumWordSwapController : ControllerBase
{
    private readonly ILogger<NumWordSwapController> _logger;
    private readonly INumWordSwapService _nwsService;

    public NumWordSwapController(ILogger<NumWordSwapController> logger, INumWordSwapService nwsService)
    {
        _logger = logger;
        _nwsService = nwsService;
    }

    [HttpPost]
    [Route("getswappednumwords")]
    public IEnumerable<NumberSwapedWord> GetSwappedNumWords(NumWordSwapRequest request)
    {
        _logger.LogInformation($"Received NumWordSwap Request: {request.ToString()}");
        return _nwsService.GetSwappedNumWords(request);
    }
}

