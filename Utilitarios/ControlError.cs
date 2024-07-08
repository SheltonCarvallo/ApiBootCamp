using Azure.Core;

namespace EjemploEntity.Utilitarios
{
    public class ControlError
    {

        public void LogErrorMetodos(string clase, string error, string metodo)

        {
			var ruta = string.Empty;
			var archivo = string.Empty;
			DateTime fecha = DateTime.Now;
			try
			{
				ruta = "C:\\Proyecto integrador\\Logs";
				archivo = $"Log_{fecha.ToString("dd-MM-yyyy")}";

				if (!Directory.Exists(ruta))
				{
					Directory.CreateDirectory(ruta);
				}

				StreamWriter writ = new StreamWriter($"{ruta}\\{archivo}", true );
				writ.WriteLine($"Se presento una novedad en la clase: {clase} en el metodo: {metodo}, con el siguiete error: {error}");
				writ.Close();

            }
			catch (Exception ex)
			{

				throw;
			}
        }

    }
}
