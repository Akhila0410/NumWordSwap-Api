namespace NumWordSwap_Tests;

using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using NumWordSwap_Api;
using NumWordSwap_Api.Controllers;
using NumWordSwap_Api.Interfaces;
using NumWordSwap_Api.Models;
/**
 * NumWorpSwapControllerTest - Unit tests for Methods in NumWorpSwapController
 * 
 * @author Akhila Rachupalli
 */
public class NumWorpSwapControllerTest
{

    public Mock<ILogger<NumWordSwapController>> mockLogger = new Mock<ILogger<NumWordSwapController>>();
    public Mock<INumWordSwapService> mockNwsService = new Mock<INumWordSwapService>();
    [Fact(DisplayName = "Testing NumWordSwapService Dependency Injection and Function call in the NumWordSwapController")]
    public void GetSwappedNumWords()
    {
       // Mocking start
        NumWordSwapRequest dummyRequest = new NumWordSwapRequest() {
            MaxNumber = 5,
            SortedOrder = false,
        };
        var dummyResponseJsonString = "[{\"number\":1,\"swappedWord\":\"1\"},{\"number\":2,\"swappedWord\":\"2\"},{\"number\":3,\"swappedWord\":\"3\"},{\"number\":4,\"swappedWord\":\"4\"},{\"number\":5,\"swappedWord\":\"5\"}]";
        var dummyResponse = JsonConvert.DeserializeObject<List<NumberSwapedWord>>(dummyResponseJsonString);
        mockNwsService.Setup(controller => controller.GetSwappedNumWords(dummyRequest)).Returns(dummyResponse);
        // Mocking end

        // Test start
        NumWordSwapController nwsController = new NumWordSwapController(mockLogger.Object, mockNwsService.Object);

        var response = nwsController.GetSwappedNumWords(dummyRequest);

        Assert.Equal(response, dummyResponse);
        // Test end
    }
}
