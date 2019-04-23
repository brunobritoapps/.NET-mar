using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
// INTERNAL DLL
using www.myRepository;
using www.myDomain;
using System;

namespace www.myAplication
{
    public class myOrderAplication
    {
        private Context db;

        public double Method_APP_CalcSumPrice(List<int> listTemp)
        {
            double price = 0.00;
            foreach (var idFood in listTemp)
            {
                using (db = new Context())
                {
                    var strQuery = string.Format("SELECT price FROM dbo.[Food] WHERE id={0}", idFood); 
                    var retornaDataReader = db.Method_RPS_ExecuteCommandWithReturn(strQuery);
                    price+=Method_APP_TransformaReaderEm_Double(retornaDataReader, "price");
                }
            }
            return price;
        }

        public void Method_APP_Insert_ListOrder(int newId,List<int> listTemp)
        {
            foreach (var idFood in listTemp)
            {
                var strQuery = "";
                strQuery += "INSERT INTO dbo.[ListOrder] (idOrder,idFood)";
                strQuery += string.Format("VALUES({0},{1})", newId, idFood);
                using (db = new Context())
                {
                    db.Method_RPS_ExecuteCommand(strQuery);
                }
            }
           
        }

        public void Method_APP_Insert_Order(int idClient, string note, double price, List<int> listTemp)
        {
            int newId = Method_APP_Select_NewId();
            Method_APP_Insert_ListOrder(newId, listTemp);
            var strQuery = "";
                strQuery += "INSERT INTO dbo.[Order] (idClient,note,date,price)";
                strQuery += string.Format("VALUES({0},'{1}',GETDATE(),{2})",idClient,note,price);
                using (db = new Context())
                {
                    db.Method_RPS_ExecuteCommand(strQuery);
                }
            

        }

        public int Method_APP_Select_LastId()
        {
            using (db = new Context())
            {
                var strQuery = "SELECT MAX(id) AS id FROM dbo.[Order]";
                var retornaDataReader = db.Method_RPS_ExecuteCommandWithReturn(strQuery);
                return Convert.ToInt32(Method_APP_TransformaReaderEm_Int(retornaDataReader,"id"));
            }
        }

        public int Method_APP_Select_NewId()
        {
            using (db = new Context())
            {
                var strQuery = "SELECT MAX(id+1) AS id FROM dbo.[Order]";
                var retornaDataReader = db.Method_RPS_ExecuteCommandWithReturn(strQuery);
                return Convert.ToInt32(Method_APP_TransformaReaderEm_String(retornaDataReader,"id"));
            }
        }

        public List<myOrderDto> Method_APP_SelectAll()
        {
            using (db = new Context())
            {
                var strQuery = "SELECT * FROM dbo.[Order]" +
                               "INNER JOIN dbo.[Client] ON dbo.[Order].idClient = dbo.[Client].id";
                var retornaDataReader = db.Method_RPS_ExecuteCommandWithReturn(strQuery);
                return Method_APP_TransformaReaderEm_ListaDeObjeto(retornaDataReader);
            }
        }

        public List<myOrderDto> Method_APP_ResetList()
        {
            var listTemp = new List<myOrderDto>();
            var objectTemp = new myOrderDto()
            {
                id = null,
                idClient = null,
                note = null,
                date = null,
                price = null,
            };
            objectTemp.client.firstName = null;
            objectTemp.client.lastName = null;
            objectTemp.client.gender = null;
            objectTemp.client.company = null;
            listTemp.Add(objectTemp);
            return listTemp;
        }

        public List<myFoodDto> Method_APP_Add_StringFor_List(string id_p, string nameFood_p, string quantum_p)
        {
            var listTemp = new List<myFoodDto>();
            var objectTemp = new myFoodDto()
            {
                id = id_p,
                nameFood = nameFood_p,
                quantum = quantum_p,
                price = null
            };
            listTemp.Add(objectTemp);
            return listTemp;
        }


        
        private string Method_APP_TransformaReaderEm_String(SqlDataReader reader, string campoBusca)
        {
            string tempString = null;
            if (reader.Read())
            {
                tempString = reader[campoBusca].ToString();
            }
            reader.Close();
            return tempString;
        }

        private int Method_APP_TransformaReaderEm_Int(SqlDataReader reader, string campoBusca)
        {
            int tempInt = 0;
            if (reader.Read())
            {
                tempInt = Convert.ToInt32(reader[campoBusca].ToString());
            }
            reader.Close();
            return tempInt;
        }

        private double Method_APP_TransformaReaderEm_Double(SqlDataReader reader, string campoBusca)
        {
            double tempDouble = 0.00;
            if (reader.Read())
            {
                tempDouble = Convert.ToDouble(reader[campoBusca].ToString());
            }
            reader.Close();
            return tempDouble;
        }

        private List<myOrderDto> Method_APP_TransformaReaderEm_ListaDeObjeto(SqlDataReader reader)
        {
            var listTemp = new List<myOrderDto>();
            while (reader.Read())
            {
                var objectTemp = new myOrderDto()
                {
                    id = reader["id"].ToString(),
                    idClient = reader["idClient"].ToString(),
                    note = reader["note"].ToString(),
                    date = reader["date"].ToString(),
                    price = reader["price"].ToString(),
                    firstName = reader["firstName"].ToString(),
                    lastName = reader["lastName"].ToString(),
                    gender = reader["gender"].ToString(),
                    company = reader["company"].ToString()
                };
                listTemp.Add(objectTemp);
            }
            reader.Close();
            return listTemp;
        }
    }
}
