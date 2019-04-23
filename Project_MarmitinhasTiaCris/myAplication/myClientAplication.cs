using System.Collections.Generic;
using System.Data.SqlClient;

// INTERNAL DLL
using www.myRepository;
using www.myDomain;
using System;

namespace www.myAplication
{
    public class myClientAplication
    {
        private Context db;

        public void Method_APP_Insert_Update(int idClient_p, string firstName_p, string lastName_p, string gender_p,string company_p)
        {
            var strQuery = "";
            strQuery += string.Format("IF NOT EXISTS(SELECT * FROM dbo.[Client] WHERE id={0}) " +
                                      "BEGIN " +
                                            "INSERT INTO dbo.[Client] (firstName,lastName,gender,company) " +
                                            "VALUES('{1}','{2}','{3}','{4}') " +
                                       "END " +
                                       "ELSE " +
                                       "BEGIN " +
                                            "UPDATE dbo.[Client] " +
                                            "SET firstName='{1}', lastName='{2}', gender='{3}' ,company='{4}' " +
                                            "WHERE id={0} " +
                                       "END ", idClient_p, firstName_p, lastName_p, gender_p, company_p);
            using (db = new Context())
            {
                db.Method_RPS_ExecuteCommand(strQuery);
            }
        }

        public void Method_APP_Delete(int id)
        {
            var strQuery = "";
            strQuery += string.Format("DELETE FROM dbo.[Client] WHERE id={0}", id);
            using (db = new Context())
            {
                db.Method_RPS_ExecuteCommand(strQuery);
            }
        }

        public int Method_APP_SelectCount_IfExists(int idFood_p)
        {
            using (db = new Context())
            {
                var strQuery = string.Format("SELECT * FROM dbo.[Client] WHERE id={0}", idFood_p);
                var retornaDataReader = db.Method_RPS_ExecuteCommandWithReturn(strQuery);
                return Method_APP_TransformaReaderEm_ListaDeObjeto(retornaDataReader).Count;
            }
        }

        public int Method_APP_Select_LastId()
        {
            using (db = new Context())
            {
                var strQuery = "SELECT MAX(id) AS id FROM dbo.[Client]";
                var retornaDataReader = db.Method_RPS_ExecuteCommandWithReturn(strQuery);
                return Convert.ToInt32(Method_APP_TransformaReaderEm_Int(retornaDataReader, "id"));
            }
        }

        public int Method_APP_Select_NewId()
        {
            using (db = new Context())
            {
                var strQuery = "SELECT MAX(id+1) AS id FROM dbo.[Client]";
                var retornaDataReader = db.Method_RPS_ExecuteCommandWithReturn(strQuery);
                return Convert.ToInt32(Method_APP_TransformaReaderEm_String(retornaDataReader, "id"));
            }
        }

        //CONSULTA TODOS CLIENTES
        public List<myClientDto> Method_APP_SelectAll()
        {
            using (db = new Context())
            {
                var strQuery = "SELECT id,firstName,lastName,company,gender FROM dbo.Client ORDER BY firstName";
                var retornaDataReader = db.Method_RPS_ExecuteCommandWithReturn(strQuery);
                return Method_APP_TransformaReaderEm_ListaDeObjeto(retornaDataReader);
            }
        }

        //POPULA COMBO COMPANY
        public List<string> Method_APP_SelectAll_Company()
        {
            using (db = new Context())
            {
                var strQuery = "SELECT DISTINCT company FROM dbo.Client ORDER BY company";
                var retornaDataReader = db.Method_RPS_ExecuteCommandWithReturn(strQuery);
                return Method_APP_TransformaReaderEm_ListaDeString(retornaDataReader, "company");
            }
        }

        //RESETA LISTA
        public List<myClientDto> Method_APP_ResetList()
        {
            var listTemp = new List<myClientDto>();
            var objectTemp = new myClientDto()
            {
                id = null,
                firstName = null,
                lastName = null,
                gender=null,
                date=null,
            };
            listTemp.Add(objectTemp);
            return listTemp;
        }

        // CONSULTA POR FIRSTNOME E RETORNA UMA LISTA OU UNICO OBJETO DE USUARIO
        public List<myClientDto> Method_APP_SelectBy_Name(string firstName_p)
        {
            using (db = new Context())
            {
                var strQuery = string.Format("SELECT * FROM dbo.Client WHERE firstName LIKE '%{0}%' ", firstName_p);
                var retornaDataReader = db.Method_RPS_ExecuteCommandWithReturn(strQuery);
                return Method_APP_TransformaReaderEm_ListaDeObjeto(retornaDataReader);
            }
        }

        public List<myClientDto> Method_APP_SelectBy_Id(int id_p)
        {
            using (db = new Context())
            {
                var strQuery = string.Format("SELECT * FROM dbo.Client WHERE id={0}", id_p);
                var retornaDataReader = db.Method_RPS_ExecuteCommandWithReturn(strQuery);
                return Method_APP_TransformaReaderEm_ListaDeObjeto(retornaDataReader);
            }
        }

        // CONSULTA POR COMPANY E RETORNA UMA LISTA DE USUARIOS EM OBJETOS
        public List<myClientDto> Method_APP_SelectBy_Company(string company_p)
        {
            using (db = new Context())
            {
                var strQuery = string.Format("SELECT * FROM dbo.Client WHERE company='{0}' ORDER BY firstName", company_p);
                var retornaDataReader = db.Method_RPS_ExecuteCommandWithReturn(strQuery);
                return Method_APP_TransformaReaderEm_ListaDeObjeto(retornaDataReader);
            }
        }

        //CONSULTA POR FIRST NAME E COMPANY E RETORNA UMA LISTA OU UNICO OBJETO DE USUARIO
        public List<myClientDto> Method_APP_SelectBy_NameAndCompany(string company_p, string firstName_p)
        {
            using (db = new Context())
            {
                var strQuery = string.Format("SELECT * FROM dbo.Client WHERE  firstName='{0}' AND company='{1}'", company_p, firstName_p);
                var retornaDataReader = db.Method_RPS_ExecuteCommandWithReturn(strQuery);
                return Method_APP_TransformaReaderEm_ListaDeObjeto(retornaDataReader);
            }
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

        private List<string> Method_APP_TransformaReaderEm_ListaDeString(SqlDataReader reader, string campoBusca)
        {
            var campoList = new List<string>();
            while (reader.Read())
            {
                string tempString = null;
                tempString = reader[campoBusca].ToString();
                campoList.Add(tempString);
            }
            reader.Close();
            return campoList;
        }

        private List<myClientDto> Method_APP_TransformaReaderEm_ListaDeObjeto(SqlDataReader reader)
        {
            var listTemp = new List<myClientDto>();
            while (reader.Read())
            {
                var objetctTemp = new myClientDto()
                {
                    id = reader["id"].ToString(),
                    firstName = reader["firstName"].ToString(),
                    lastName = reader["lastName"].ToString(),
                    gender = reader["gender"].ToString(),
                    company = reader["company"].ToString(),
                };
                listTemp.Add(objetctTemp);
            }
            reader.Close();
            return listTemp;
        }

    }
}
