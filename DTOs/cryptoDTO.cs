using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CR_YPTO_TPF.DTOs
{
	public class CryptoDTO
	{
		// DTO
		//modelo de dominio: Cypto representa una criptomoneda y contiene las propiedades relevantes
		private string iId;
		private string iName;
		private string iRank;
		private string iPriceUSD;
		private string iSymbol;
		private string iChangePercent24hs;

		public CryptoDTO(string pid, string pName, string pRank, string pPriceUSD, string pSymbol, string pChangePercent)
		{
			iId = pid;
			iName = pName;
			iRank = pRank;
			iPriceUSD = pPriceUSD;
			iSymbol = pSymbol;
			iChangePercent24hs = pChangePercent;
		}
		public string id
		{
			get { return iId; }
			set { iId = value; }
		}
		public string name
		{
			get { return iName; }
			set { iName = value; }
		}
		public string rank
		{
			get { return iRank; }
			set { iRank = value; }
		}
		public string priceUSD
		{
			get { return iPriceUSD; }
			set { iPriceUSD = value; }
		}
		public string symbol
		{
			get { return iSymbol; }
			set { iSymbol = value; }
		}
		public string changePercent24hs
		{
			get { return iChangePercent24hs; }
			set { iChangePercent24hs = value; }
		}


	}
}