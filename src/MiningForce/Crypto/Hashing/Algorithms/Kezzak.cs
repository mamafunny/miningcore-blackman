﻿using System.Linq;
using MiningForce.Extensions;
using MH = MiningForce.Crypto.Hashing.LibMultiHash;

namespace MiningForce.Crypto.Hashing.Algorithms
{
    public unsafe class Kezzak : IHashAlgorithm
    {
		public byte[] Digest(byte[] data, ulong nTime)
		{
			// concat nTime as hex string to data
			var dataEx = data.Concat(
				nTime.ToString("X").HexToByteArray()).ToArray();

		    var result = new byte[32];

			fixed (byte* input = dataEx)
		    {
			    fixed (byte* output = result)
			    {
				    MH.kezzak(input, output, (uint) data.Length);
			    }
			}

		    return result;
	    }
    }
}