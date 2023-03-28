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

        // This method takes a NumWordSwapRequest and returns the List of Numbers with swapped words
        public IEnumerable<NumberSwapedWord> GetSwappedNumWords(NumWordSwapRequest request)
        {

            // Null Request and Invalid Max Number validation
            if (request == null || request.MaxNumber <= 0)
            {
                return new List<NumberSwapedWord>();
            }

            var result = new NumberSwapedWord[request.MaxNumber];
            try
            {
                // If No NumWordSwaps sent - The below condition is added to avoid validating the (request.NumWordSwaps?.Count == 0)
                //                           condition for every number.
                if (null == request.MultipleWordSwaps || request.MultipleWordSwaps.Count == 0)
                {
                    for (var i = 1; i <= request.MaxNumber; i++)
                    {
                        result[i - 1] = new NumberSwapedWord() { Number = i, SwappedWord = i.ToString() };
                    }
                }
                else if(request.MultipleWordSwaps.Count > 0)
                {
                    // If NumWordSwaps Present
                    for (var i = 1; i <= request.MaxNumber; i++)
                    {
                        var multipleWordSwaps = !!request.SortedOrder ? request.MultipleWordSwaps?.OrderBy(mws => mws.Multiple).ToList() : request.MultipleWordSwaps;

                        result[i - 1] = new NumberSwapedWord() { Number = i, SwappedWord = GetSwapWord(i, multipleWordSwaps) };
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

        // This method takes a number and apply all the multiple word swaps, returns the complete swap word.
        public string GetSwapWord(int currentNumber, List<MultipleWordSwap>? multipleWordSwaps) {
            if (currentNumber == 0 || multipleWordSwaps == null || multipleWordSwaps.Count == 0) return currentNumber.ToString();
            var wordSwapResult = new StringBuilder();
            multipleWordSwaps?.ForEach(nws =>
            {
                if (nws.Multiple > 0 && currentNumber % nws.Multiple == 0)
                {
                    wordSwapResult.Append(nws.WordSwap + " ");
                }
            });

            return (wordSwapResult.Length == 0) ? currentNumber.ToString() : wordSwapResult.ToString().TrimEnd();

        }
    }
}

