using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CR_YPTO_TPF
{
	public class log
	{
		private string Path = "";


		public log(string Path)
		{
			this.Path = Path;
		}

		public void logger(string mensaje)  //método para guardar los mensajes
		{
			string path = System.IO.Path.Combine(Environment.CurrentDirectory,"log.txt");

			log oLog = new log(path);
			oLog.Add(mensaje);
		}

		public void Add(string sLog)
		{
			CreateDirectory();
			string nombre = GetNameFile();
			string cadena = "";

			cadena += DateTime.Now + " - " + sLog + Environment.NewLine;

			StreamWriter sw = new StreamWriter(Path + "/" + nombre, true);
			sw.Write(cadena);
			sw.Close();

		}

		#region HELPER
		private string GetNameFile()
		{
			string nombre = "";

			nombre = "log_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + ".txt";

			return nombre;
		}

		private void CreateDirectory()
		{
			try
			{
				if (!Directory.Exists(Path))
					Directory.CreateDirectory(Path);


			}
			catch (DirectoryNotFoundException ex)
			{
				throw new Exception(ex.Message);

			}
		}
		#endregion
	}
}
