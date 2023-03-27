using System;
using System.Text;
using NumWordSwap_Api.Controllers;
using NumWordSwap_Api.Interfaces;
using NumWordSwap_Api.Models;

/**
 * NumWordSwapService - This service generates the num word swaps for a JSON NumWordSwap request
 * 
 * @author Akhila Rachupalli
 */

namespace NumWordSwap_Api.Services
{
	public class NumWordSwapService: INumWordSwapService
    {
        private readonly ILogger<NumWordSwapService> _logger;
        public NumWordSwapService(ILogger<NumWordSwapService> logger)
		{
            _logger = logger;
		}

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
                // If No NumWordSwaps sent - The below condition is added to avoid validating the (request.NumWordSwaps?.Count == 0)
                //                           condition for every number.
                if (request.NumWordSwaps?.Count == 0)
                {
                    for (var i = 1; i <= request.MaxNumber; i++)
                    {
                        result[i - 1] = new NumWordSwap() { Number = i, WordSwap = i.ToString() };
                    }
                }
                else
                {
                    // If NumWordSwaps Present
                    for (var i = 1; i <= request.MaxNumber; i++)
                    {
                        var numWordSwaps = !!request.SortedOrder ? request.NumWordSwaps?.OrderBy(nws => nws.Number).ToList() : request.NumWordSwaps;

                        result[i - 1] = new NumWordSwap() { Number = i, WordSwap = GetSwapWord(i, numWordSwaps) };
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Get NumWordSwaps request error:" + ex);
                throw new Exception("Get NumWordSwaps request error:" + ex);
            }

            return result;
        }

        private string GetSwapWord(int currentNumber, List<NumWordSwap> numWordSwaps) {
            var wordSwapResult = new StringBuilder();
            numWordSwaps?.ForEach(nws =>
            {
                if (currentNumber % nws.Number == 0)
                {
                    wordSwapResult.Append(nws.WordSwap + " ");
                }
            });

            return (wordSwapResult.Length == 0) ? currentNumber.ToString() : wordSwapResult.ToString().TrimEnd();

        }
    }
}

