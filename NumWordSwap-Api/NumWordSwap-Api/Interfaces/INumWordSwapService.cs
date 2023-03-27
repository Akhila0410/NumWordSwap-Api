using System;
using NumWordSwap_Api.Models;

namespace NumWordSwap_Api.Interfaces
{
	public interface INumWordSwapService
	{
        public IEnumerable<NumWordSwap> GetSwappedNumWords(NumWordSwapRequest request);

    }
}

