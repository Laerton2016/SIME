using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using SIME.Class.primitivo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace SIME.Class.Conexoes
{
    public class ConexRedis
    {
        
        private readonly static string host = "localhost";

        public static void GravaCarrinhoRedis(int idUser, NetVenda carrinho, int minutos )
        {
            using (RedisClient rc  = new RedisClient(host))
            {
                IRedisTypedClient<NetVenda> vendas = rc.As<NetVenda>();
                //Thread.Sleep(5000);
                vendas.SetEntry(idUser.ToString(), carrinho,TimeSpan.FromMinutes(minutos));
                //vendas.ExpireIn(idUser, System.TimeSpan.FromMinutes(minutos));

            }
        }

        public static NetVenda ResgataCarrinhRedis(int idUser)
        {
            NetVenda r = null;
            using (RedisClient rc = new RedisClient(host))
            {
                r = rc.Get<NetVenda>(idUser.ToString());
            }

            if (r == null)
            {
                r = new NetVenda(idUser);
            }
            return r;
        }

        public static void LimpaCarrinho(int idUser)
        {
            using (RedisClient rc = new RedisClient(host))
            {
                IRedisTypedClient<NetVenda> vendas = rc.As<NetVenda>();
                Thread.Sleep(5000);
                vendas.SetEntry(idUser.ToString(), new NetVenda(idUser), TimeSpan.FromMinutes(45));
                vendas.ExpireIn(idUser,System.TimeSpan.FromSeconds(30));
            }
        }



    }
}