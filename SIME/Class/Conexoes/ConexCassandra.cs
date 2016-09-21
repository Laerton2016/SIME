using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cassandra;

namespace SIME.Class.Conexoes
{
    public class ConexCassandra
    {
        private Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
        private ISession session;
        private static ConexCassandra instance;

        private ConexCassandra()
        {
            session = cluster.Connect("sime");
        }

        public static ConexCassandra Instance()
        {
            if (instance == null)
            {
                instance = new ConexCassandra();
            }
            return instance;
        }

        public ISession GetSession()
        {
            return session;
        }

    }
}