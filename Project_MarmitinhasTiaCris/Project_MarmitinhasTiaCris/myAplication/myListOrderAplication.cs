using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
//
using www.myRepository;
using www.myDomain;

namespace www.myAplication
{
    public class myListOrderAplication
    {
        private Context db;

        public List<myListOrderDto> Method_APP_SelectBy_Id(int idOrder_p)
        {
            using (db = new Context())
            {
                var strQuery = string.Format("SELECT * FROM dbo.ListOrder " +
                                             "INNER JOIN dbo.Food ON dbo.Food.id = dbo.ListOrder.idFood " +
                                             "WHERE idOrder={0}", idOrder_p);
                var retornaDataReader = db.Method_RPS_ExecuteCommandWithReturn(strQuery);
                return Method_APP_TransformaReaderEm_ListaDeObjeto(retornaDataReader);
            }
        }

        private List<myListOrderDto> Method_APP_TransformaReaderEm_ListaDeObjeto(SqlDataReader reader)
        {
            var listTemp = new List<myListOrderDto>();
            while (reader.Read())
            {
                var objetctTemp = new myListOrderDto()
                {
                    idOrder = reader["idOrder"].ToString(),
                    idFood = reader["idFood"].ToString(),
                    nameFood = reader["nameFood"].ToString(),
                    quantum = reader["quantum"].ToString(),
                    price = reader["price"].ToString()
                };
                listTemp.Add(objetctTemp);
            }
            reader.Close();
            return listTemp;
        }

    }
}
