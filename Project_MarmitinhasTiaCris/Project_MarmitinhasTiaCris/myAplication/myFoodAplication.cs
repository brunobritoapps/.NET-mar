using System.Collections.Generic;
using System.Data.SqlClient;
// INTERNAL DLL
using www.myRepository;
using www.myDomain;
using System;

namespace www.myAplication
{
    public class myFoodAplication
    {
        private Context db;

        public void Method_APP_Insert_Update(int idFood_p, string nameFood_p, string quantum_p, double price_p)
        {
            var strQuery = "";
            strQuery += string.Format("IF NOT EXISTS(SELECT * FROM dbo.[Food] WHERE id={0}) " +
                                      "BEGIN " +
                                            "INSERT INTO dbo.[Food] (nameFood,quantum,price) " +
                                            "VALUES('{1}','{2}',{3}) " +
                                       "END " +
                                       "ELSE " +
                                       "BEGIN " +
                                            "UPDATE dbo.[Food] " +
                                            "SET nameFood='{1}',quantum='{2}', price={3} " +
                                            "WHERE id={0} " +
                                       "END ",idFood_p, nameFood_p, quantum_p, price_p );
            using (db = new Context())
            {
                db.Method_RPS_ExecuteCommand(strQuery);
            }
        }

        public void Method_APP_Delete(int id)
        {
            var strQuery = "";
            strQuery += string.Format("DELETE FROM dbo.[Food] WHERE id={0}", id);
            using (db = new Context())
            {
                db.Method_RPS_ExecuteCommand(strQuery);
            }
        }

        public int Method_APP_SelectCount_IfExists(int idFood_p)
        {
            using (db = new Context())
            {
                var strQuery = string.Format("SELECT * FROM dbo.[Food] WHERE id={0}",idFood_p);
                var retornaDataReader = db.Method_RPS_ExecuteCommandWithReturn(strQuery);
                return Method_APP_TransformaReaderEm_ListaDeObjeto(retornaDataReader).Count;
            }
        }

        public int Method_APP_Select_LastId()
        {
            using (db = new Context())
            {
                var strQuery = "SELECT MAX(id) AS id FROM dbo.[Food]";
                var retornaDataReader = db.Method_RPS_ExecuteCommandWithReturn(strQuery);
                return Convert.ToInt32(Method_APP_TransformaReaderEm_Int(retornaDataReader, "id"));
            }
        }

        public int Method_APP_Select_NewId()
        {
            using (db = new Context())
            {
                var strQuery = "SELECT MAX(id+1) AS id FROM dbo.[Food]";
                var retornaDataReader = db.Method_RPS_ExecuteCommandWithReturn(strQuery);
                return Convert.ToInt32(Method_APP_TransformaReaderEm_String(retornaDataReader, "id"));
            }
        }


        public List<myFoodDto> Method_APP_SelectAll()
        {
            using (db = new Context())
            {
                var strQuery = "SELECT * FROM dbo.Food ORDER BY nameFood ";
                var retornaDataReader = db.Method_RPS_ExecuteCommandWithReturn(strQuery);
                return Method_APP_TransformaReaderEm_ListaDeObjeto(retornaDataReader);
            }
        }

        public List<myFoodDto> Method_APP_ResetList()
        {
            var listTemp = new List<myFoodDto>();
            var objectTemp = new myFoodDto()
            {
                id = null,
                nameFood = null,
                quantum = null,
                price = null
            };
            listTemp.Add(objectTemp);
            return listTemp;
        }

        public List<myFoodDto> Method_APP_SelectBy_Id(string id)
        {
            using (db = new Context())
            {
                var strQuery = string.Format("SELECT * FROM dbo.Food WHERE id = {0}", id);
                var retornaDataReader = db.Method_RPS_ExecuteCommandWithReturn(strQuery);
                return Method_APP_TransformaReaderEm_ListaDeObjeto(retornaDataReader);
            }
        }

        public List<myFoodDto> Method_APP_SelectBy_NameFood(string nameFood)
        {
            using (db = new Context())
            {
                var strQuery = string.Format("SELECT * FROM dbo.Food WHERE nameFood LIKE '%{0}%'", nameFood);
                var retornaDataReader = db.Method_RPS_ExecuteCommandWithReturn(strQuery);
                return Method_APP_TransformaReaderEm_ListaDeObjeto(retornaDataReader);
            }
        }

        public List<myFoodDto> Method_APP_SelectBy_Portion(string quantum_p)
        {
            using (db = new Context())
            {
                var strQuery = string.Format("SELECT * FROM dbo.Food WHERE quantum LIKE '%{0}%'", quantum_p);
                var retornaDataReader = db.Method_RPS_ExecuteCommandWithReturn(strQuery);
                return Method_APP_TransformaReaderEm_ListaDeObjeto(retornaDataReader);
            }
        }
        
        public List<myFoodDto> Method_APP_Add_StringForList(string id_p, string nameFood_p, string quantum_p)
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

        private List<myFoodDto> Method_APP_TransformaReaderEm_ListaDeObjeto(SqlDataReader reader)
        {
            var listTemp = new List<myFoodDto>();
            while (reader.Read())
            {
                var objectTemp = new myFoodDto()
                {
                    id = reader["id"].ToString(),
                    nameFood = reader["nameFood"].ToString(),
                    quantum = reader["quantum"].ToString(),
                    price = reader["price"].ToString()
                };
                listTemp.Add(objectTemp);
            }
            reader.Close();
            return listTemp;
        }
    }
}
