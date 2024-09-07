using CR_YPTO_TPF.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CR_YPTO_TPF.Domain;

namespace CR_YPTO_TPF.Api
{
	public interface ICryptoService
	{
		List<crypto> GetFavCryptos(List<String> pLista);

		List<crypto> GetAllCryptos();

		//List<cryptohistoria> Get6MonthHistoryFrom(string cripto);
	}
}
