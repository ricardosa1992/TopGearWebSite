using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGear.Api
{
    public static class TopGearApiDataAccess<T>
    {
        public static T Get(string relativePath)
        {
            var result = TopGearApi<T>.Get(relativePath);
            if (result.Sucesso)
            {
                return result.Dados;
            }
            return default(T);

        }

        public static T Post(T objeto, string relativePath)
        {
            var result = TopGearApi<T>.Post(objeto, relativePath);
            if (result.Sucesso)
            {
                return result.Dados;
            }
            return default(T);

        }

        public static T Put(T objeto, int id ,string relativePath)
        {
            var result = TopGearApi<T>.Put(objeto, id ,relativePath);
            if (result.Sucesso)
            {
                return result.Dados;
            }
            return default(T);
        }

        public static T Delete(int id, string relativePath)
        {
            var result = TopGearApi<T>.Delete(id, relativePath);
            if (result.Sucesso)
            {
                return result.Dados;
            }
            return default(T);
        }

    }
}
