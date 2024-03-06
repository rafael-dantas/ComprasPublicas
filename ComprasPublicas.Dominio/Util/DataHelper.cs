

namespace ComprasPublicas.Dominio.Util
{
    public static class DataHelper
    {
        public static DateTime Iso8601(this DateTime dateTime)
        {
            return Convert.ToDateTime(dateTime.ToUniversalTime().ToString("u").Replace(" ", "T"));
        }
    }
}
