using CR_YPTO_TPF.DTOs;
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
		List<cryptoDTO> GetFavCryptos(List<String> pLista);

		List<cryptoDTO> GetAllCryptos();

		//List<cryptohistoria> Get6MesesHistorial(string cripto);
	}
}
