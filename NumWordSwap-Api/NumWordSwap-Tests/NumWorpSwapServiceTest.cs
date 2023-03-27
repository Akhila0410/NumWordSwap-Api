namespace NumWordSwap_Tests;

using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using NumWordSwap_Api;
using NumWordSwap_Api.Controllers;
using NumWordSwap_Api.Interfaces;
using NumWordSwap_Api.Models;
using NumWordSwap_Api.Services;

/**
 * NumWordSwapServiceTest - Unit tests for Methods in NumWordSwapService
 * 
 * @author Akhila Rachupalli
 */
public class NumWorpSwapServiceTest
{

    public Mock<ILogger<NumWordSwapService>> mockLogger = new Mock<ILogger<NumWordSwapService>>();

    #region GetSwapWordTests

    [Fact(DisplayName = "Get Swap Word Method - Zero current number")]
    public void GetSwapWordZeroCurrentNumber()
    {
        // Mock start
        var dummyMultipleWordSwapsJsonString = "[{\"multiple\":3,\"wordSwap\":\"Fizz\"}]";
        var dummyMultipleWordSwaps = JsonConvert.DeserializeObject<List<MultipleWordSwap>>(dummyMultipleWordSwapsJsonString);
        // Mock end

        // Test start
        NumWordSwapService nwsService = new NumWordSwapService(mockLogger.Object);

        var response = nwsService.GetSwapWord(0, dummyMultipleWordSwaps);

        Assert.Equal("0", response);
        // Test end
    }


    [Fact(DisplayName = "Get Swap Word Method - null multiple word swaps")]
    public void GetSwapWordNullMultipleWordSwaps()
     {
        // Test start
        NumWordSwapService nwsService = new NumWordSwapService(mockLogger.Object);

        var response = nwsService.GetSwapWord(1,null);

        Assert.Equal("1", response);
        // Test end
    }

    [Fact(DisplayName = "Get Swap Word Method - Zero multiple word swaps")]
    public void GetSwapWordZeroMultipleWordSwaps()
    {
        // Test start
        NumWordSwapService nwsService = new NumWordSwapService(mockLogger.Object);

        var response = nwsService.GetSwapWord(1, new List<MultipleWordSwap>());

        Assert.Equal("1", response);
        // Test end
    }

    [Fact(DisplayName = "Get Swap Word Method - One multiple word swaps")]
    public void GetSwapWordOneMultipleWordSwaps()
    {
        // Mock start
        var dummyMultipleWordSwapsJsonString = "[{\"multiple\":3,\"wordSwap\":\"Fizz\"}]";
        var dummyMultipleWordSwaps = JsonConvert.DeserializeObject<List<MultipleWordSwap>>(dummyMultipleWordSwapsJsonString);
        // Mock end

        // Test start
        NumWordSwapService nwsService = new NumWordSwapService(mockLogger.Object);

        var response = nwsService.GetSwapWord(3, dummyMultipleWordSwaps);

        Assert.Equal("Fizz", response);
        // Test end
    }

    [Fact(DisplayName = "Get Swap Word Method - One multiple word swap - Zero multiple")]
    public void GetSwapWordOneMultipleWordSwapWithZeroMultiple()
    {
        // Mock start
        var dummyMultipleWordSwapsJsonString = "[{\"multiple\":0,\"wordSwap\":\"Fizz\"}]";
        var dummyMultipleWordSwaps = JsonConvert.DeserializeObject<List<MultipleWordSwap>>(dummyMultipleWordSwapsJsonString);
        // Mock end

        // Test start
        NumWordSwapService nwsService = new NumWordSwapService(mockLogger.Object);

        var response = nwsService.GetSwapWord(3, dummyMultipleWordSwaps);

        Assert.Equal("3", response);
        // Test end
    }

    [Fact(DisplayName = "Get Swap Word Method - More multiple word swaps - First multiple Match")]
    public void GetSwapWordMoreMultipleWordSwapsWithFirstMatch()
    {
        // Mock start
        var dummyMultipleWordSwapsJsonString = "[{\"multiple\":3,\"wordSwap\":\"Fizz\"},{\"multiple\":5,\"wordSwap\":\"Buzz\"}]";
        var dummyMultipleWordSwaps = JsonConvert.DeserializeObject<List<MultipleWordSwap>>(dummyMultipleWordSwapsJsonString);
        // Mock end

        // Test start
        NumWordSwapService nwsService = new NumWordSwapService(mockLogger.Object);

        var response = nwsService.GetSwapWord(3, dummyMultipleWordSwaps);

        Assert.Equal("Fizz", response);
        // Test end
    }

    [Fact(DisplayName = "Get Swap Word Method - More multiple word swaps - Second multiple match")]
    public void GetSwapWordMoreMultipleWordSwapsWithSecondMatch()
    {
        // Mock start
        var dummyMultipleWordSwapsJsonString = "[{\"multiple\":3,\"wordSwap\":\"Fizz\"},{\"multiple\":5,\"wordSwap\":\"Buzz\"}]";
        var dummyMultipleWordSwaps = JsonConvert.DeserializeObject<List<MultipleWordSwap>>(dummyMultipleWordSwapsJsonString);
        // Mock end

        // Test start
        NumWordSwapService nwsService = new NumWordSwapService(mockLogger.Object);

        var response = nwsService.GetSwapWord(5, dummyMultipleWordSwaps);

        Assert.Equal("Buzz", response);
        // Test end
    }

    [Fact(DisplayName = "Get Swap Word Method - More multiple word swaps - Both multiples match")]
    public void GetSwapWordMoreMultipleWordSwapsWithBothMultipleMatches()
    {
        // Mock start
        var dummyMultipleWordSwapsJsonString = "[{\"multiple\":3,\"wordSwap\":\"Fizz\"},{\"multiple\":5,\"wordSwap\":\"Buzz\"}]";
        var dummyMultipleWordSwaps = JsonConvert.DeserializeObject<List<MultipleWordSwap>>(dummyMultipleWordSwapsJsonString);
        // Mock end

        // Test start
        NumWordSwapService nwsService = new NumWordSwapService(mockLogger.Object);

        var response = nwsService.GetSwapWord(15, dummyMultipleWordSwaps);

        Assert.Equal("Fizz Buzz", response);
        // Test end
    }

    #endregion GetSwapWordTests

    #region GetSwappedNumWordsTests
    [Fact(DisplayName = "Get Swapped Number Words Method - only max number")]
    public void GetSwappedNumWordsOnlyMaxNumber()
    {
        // Mock start
        var dummyRequest = new NumWordSwapRequest(){
            MaxNumber = 5,
        };
        var dummyResponseJsonString = "[{\"number\":1,\"swappedWord\":\"1\"},{\"number\":2,\"swappedWord\":\"2\"},{\"number\":3,\"swappedWord\":\"3\"},{\"number\":4,\"swappedWord\":\"4\"},{\"number\":5,\"swappedWord\":\"5\"}]";
        var dummyResponse = JsonConvert.DeserializeObject<List<NumberSwapedWord>>(dummyResponseJsonString);
        // Mock end

        // Test start
        NumWordSwapService nwsService = new NumWordSwapService(mockLogger.Object);

        var response = nwsService.GetSwappedNumWords(dummyRequest);

        Assert.Equal(dummyResponse, response);
        // Test end
    }

    [Fact(DisplayName = "Get Swapped Number Words Method - max number and sortedOrder")]
    public void GetSwappedNumWordsMaxNumberSortedOrder()
    {
        // Mock start
        var dummyRequest = new NumWordSwapRequest()
        {
            MaxNumber = 5,
            SortedOrder = false,
        };
        var dummyResponseJsonString = "[{\"number\":1,\"swappedWord\":\"1\"},{\"number\":2,\"swappedWord\":\"2\"},{\"number\":3,\"swappedWord\":\"3\"},{\"number\":4,\"swappedWord\":\"4\"},{\"number\":5,\"swappedWord\":\"5\"}]";
        var dummyResponse = JsonConvert.DeserializeObject<List<NumberSwapedWord>>(dummyResponseJsonString);
        // Mock end

        // Test start
        NumWordSwapService nwsService = new NumWordSwapService(mockLogger.Object);

        var response = nwsService.GetSwappedNumWords(dummyRequest);

        Assert.Equal(dummyResponse, response);
        // Test end
    }

    [Fact(DisplayName = "Get Swapped Number Words Method - max number and sortedOrder true")]
    public void GetSwappedNumWordsMaxNumberSortedOrderTrue()
    {
        // Mock start
        var dummyRequest = new NumWordSwapRequest()
        {
            MaxNumber = 5,
            SortedOrder = true,
        };
        var dummyResponseJsonString = "[{\"number\":1,\"swappedWord\":\"1\"},{\"number\":2,\"swappedWord\":\"2\"},{\"number\":3,\"swappedWord\":\"3\"},{\"number\":4,\"swappedWord\":\"4\"},{\"number\":5,\"swappedWord\":\"5\"}]";
        var dummyResponse = JsonConvert.DeserializeObject<List<NumberSwapedWord>>(dummyResponseJsonString);
        // Mock end

        // Test start
        NumWordSwapService nwsService = new NumWordSwapService(mockLogger.Object);

        var response = nwsService.GetSwappedNumWords(dummyRequest);

        Assert.Equal(dummyResponse, response);
        // Test end
    }

    [Fact(DisplayName = "Get Swapped Number Words Method - one multiple word swap")]
    public void GetSwappedNumWordsWithOneMultipleWordSwap()
    {
        // Mock start
        var dummyRequestJsonString = "{\"maxNumber\":10,\"multipleWordSwaps\":[{\"multiple\":3,\"wordSwap\":\"Fizz\"}],\"sortedOrder\":false}";
        var dummyRequest = JsonConvert.DeserializeObject<NumWordSwapRequest>(dummyRequestJsonString);
        var dummyResponseJsonString = "[{\"number\":1,\"swappedWord\":\"1\"},{\"number\":2,\"swappedWord\":\"2\"},{\"number\":3,\"swappedWord\":\"Fizz\"},{\"number\":4,\"swappedWord\":\"4\"},{\"number\":5,\"swappedWord\":\"5\"},{\"number\":6,\"swappedWord\":\"Fizz\"},{\"number\":7,\"swappedWord\":\"7\"},{\"number\":8,\"swappedWord\":\"8\"},{\"number\":9,\"swappedWord\":\"Fizz\"},{\"number\":10,\"swappedWord\":\"10\"}]";
        var dummyResponse = JsonConvert.DeserializeObject<List<NumberSwapedWord>>(dummyResponseJsonString);
        // Mock end

        // Test start
        NumWordSwapService nwsService = new NumWordSwapService(mockLogger.Object);

        var response = nwsService.GetSwappedNumWords(dummyRequest);

        Assert.Equal(dummyResponse, response);
        // Test end
    }



    [Fact(DisplayName = "Get Swapped Number Words Method - more multiple word swap")]
    public void GetSwappedNumWordsWithMoreMultipleWordSwap()
    {
        // Mock start
        var dummyRequestJsonString = "{\"maxNumber\":10,\"multipleWordSwaps\":[{\"multiple\":2,\"wordSwap\":\"Fizz\"},{\"multiple\":3,\"wordSwap\":\"Buzz\"}],\"sortedOrder\":false}";
        var dummyRequest = JsonConvert.DeserializeObject<NumWordSwapRequest>(dummyRequestJsonString);
        var dummyResponseJsonString = "[{\"number\":1,\"swappedWord\":\"1\"},{\"number\":2,\"swappedWord\":\"Fizz\"},{\"number\":3,\"swappedWord\":\"Buzz\"},{\"number\":4,\"swappedWord\":\"Fizz\"},{\"number\":5,\"swappedWord\":\"5\"},{\"number\":6,\"swappedWord\":\"Fizz Buzz\"},{\"number\":7,\"swappedWord\":\"7\"},{\"number\":8,\"swappedWord\":\"Fizz\"},{\"number\":9,\"swappedWord\":\"Buzz\"},{\"number\":10,\"swappedWord\":\"Fizz\"}]";
        var dummyResponse = JsonConvert.DeserializeObject<List<NumberSwapedWord>>(dummyResponseJsonString);
        // Mock end

        // Test start
        NumWordSwapService nwsService = new NumWordSwapService(mockLogger.Object);

        var response = nwsService.GetSwappedNumWords(dummyRequest);

        Assert.Equal(dummyResponse, response);
        // Test end
    }

    [Fact(DisplayName = "Get Swapped Number Words Method - more multiple word swap with Higher multiple first")]
    public void GetSwappedNumWordsWithMoreMultipleWordSwapWithHigherMultipleFirst()
    {
        // Mock start
        var dummyRequestJsonString = "{\"maxNumber\":10,\"multipleWordSwaps\":[{\"multiple\":3,\"wordSwap\":\"Buzz\"},{\"multiple\":2,\"wordSwap\":\"Fizz\"}],\"sortedOrder\":false}";
        var dummyRequest = JsonConvert.DeserializeObject<NumWordSwapRequest>(dummyRequestJsonString);
        var dummyResponseJsonString = "[{\"number\":1,\"swappedWord\":\"1\"},{\"number\":2,\"swappedWord\":\"Fizz\"},{\"number\":3,\"swappedWord\":\"Buzz\"},{\"number\":4,\"swappedWord\":\"Fizz\"},{\"number\":5,\"swappedWord\":\"5\"},{\"number\":6,\"swappedWord\":\"Buzz Fizz\"},{\"number\":7,\"swappedWord\":\"7\"},{\"number\":8,\"swappedWord\":\"Fizz\"},{\"number\":9,\"swappedWord\":\"Buzz\"},{\"number\":10,\"swappedWord\":\"Fizz\"}]";
        var dummyResponse = JsonConvert.DeserializeObject<List<NumberSwapedWord>>(dummyResponseJsonString);
        // Mock end

        // Test start
        NumWordSwapService nwsService = new NumWordSwapService(mockLogger.Object);

        var response = nwsService.GetSwappedNumWords(dummyRequest);

        Assert.Equal(dummyResponse, response);
        // Test end
    }


    [Fact(DisplayName = "Get Swapped Number Words Method - more multiple word swap with Higher multiple first and SortedOrder True")]
    public void GetSwappedNumWordsWithMoreMultipleWordSwapWithHigherMultipleFirstWithSortedOrderTrue()
    {
        // Mock start
        var dummyRequestJsonString = "{\"maxNumber\":10,\"multipleWordSwaps\":[{\"multiple\":3,\"wordSwap\":\"Buzz\"},{\"multiple\":2,\"wordSwap\":\"Fizz\"}],\"sortedOrder\":false}";
        var dummyRequest = JsonConvert.DeserializeObject<NumWordSwapRequest>(dummyRequestJsonString);
        var dummyResponseJsonString = "[{\"number\":1,\"swappedWord\":\"1\"},{\"number\":2,\"swappedWord\":\"Fizz\"},{\"number\":3,\"swappedWord\":\"Buzz\"},{\"number\":4,\"swappedWord\":\"Fizz\"},{\"number\":5,\"swappedWord\":\"5\"},{\"number\":6,\"swappedWord\":\"Buzz Fizz\"},{\"number\":7,\"swappedWord\":\"7\"},{\"number\":8,\"swappedWord\":\"Fizz\"},{\"number\":9,\"swappedWord\":\"Buzz\"},{\"number\":10,\"swappedWord\":\"Fizz\"}]";
        var dummyResponse = JsonConvert.DeserializeObject<List<NumberSwapedWord>>(dummyResponseJsonString);
        // Mock end

        // Test start
        NumWordSwapService nwsService = new NumWordSwapService(mockLogger.Object);

        var response = nwsService.GetSwappedNumWords(dummyRequest);

        Assert.Equal(dummyResponse, response);
        // Test end
    }
    #endregion GetSwappedNumWordsTests
}
