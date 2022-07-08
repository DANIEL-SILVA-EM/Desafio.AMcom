using System.Globalization;
using System.Linq;

namespace Desafio.AMcom
{
    public static class MetodosExtensao
    {
		public static bool PesquisaPartes(this string a, string b)
		{
			if (string.IsNullOrEmpty(b))
			{
				return true;
			}

			if (string.IsNullOrEmpty(a))
			{
				return false;
			}

			string[] partes = b.Split(' ');

			CompareInfo compareInfo = CultureInfo.InvariantCulture.CompareInfo;

			return partes.All(parte => compareInfo.IndexOf(a, parte.Trim(), CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) > -1);
		}
	}
}
