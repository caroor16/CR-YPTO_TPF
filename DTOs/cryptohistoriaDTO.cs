using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CR_YPTO_TPF.Domain;

namespace CR_YPTO_TPF.DTOs
{
	public class cryptohistoriaDTO
	{
		public string idCrypto { get; set; }
		public string PriceUSD { get; set; }
		public DateTime Time { get; set; }
	}

}
