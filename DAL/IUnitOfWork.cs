﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CR_YPTO_TPF.DAL.framework;

namespace CR_YPTO_TPF.DAL
{
	public interface IUnitOfWork : IDisposable
	{
		IUsuarioRepository UsuarioRepository { get; }
		IAlertaRepository AlertaRepository { get; }
		void Complete();
	}
}
