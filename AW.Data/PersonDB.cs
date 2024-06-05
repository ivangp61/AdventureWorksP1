using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using AW.Entities;

namespace AW.Data
{
    public class PersonDB
    {
        private SqlConnection AWConnection()
        {
            //string strConnString = ConfigurationManager.ConnectionStrings["AWDb"].ConnectionString;

            string strConnString = "server=.; database=AdventureWorks2017;trusted_connection=true; Integrated Security=true";

            SqlConnection AWconn = new SqlConnection(strConnString);

            return AWconn;
        }

        private string AssignStringValue(SqlDataReader drRow, string fieldName)
        {
            if (!DBNull.Value.Equals(drRow[fieldName]))
                return drRow[fieldName].ToString();
            else
                return string.Empty;
        }
        private int AssignIntValue(SqlDataReader drRow, string fieldName)
        {
            if (!DBNull.Value.Equals(drRow[fieldName]))
                return (int)drRow[fieldName];
            else
                return 0;
        }
        private decimal AssignDecimalValue(SqlDataReader drRow, string fieldName)
        {
            if (!DBNull.Value.Equals(drRow[fieldName]))
                return (decimal)drRow[fieldName];
            else
                return decimal.Zero;
        }

        public DateTime AssignDateValue(SqlDataReader drRow, string fieldName)
        {
            if (!DBNull.Value.Equals(drRow[fieldName]))
                return (DateTime)drRow[fieldName];
            else
                return DateTime.MinValue;
        }

        public List<Person> GetPersons()
        {
            SqlConnection cnPersons = AWConnection();
            SqlCommand cmdGetPersons = new SqlCommand("SELECT top 10 * FROM Person.Person", cnPersons);

            cmdGetPersons.CommandType = System.Data.CommandType.Text;

            List<Person> lstPersons = new List<Person>();

            

            try
            {
                cnPersons.Open();

                SqlDataReader drPersons = cmdGetPersons.ExecuteReader();

                while (drPersons.Read())
                {
                    Person aPerson = new Person();

                    aPerson.BusinessEntityID = this.AssignIntValue(drPersons, "BusinessEntityID");
                    aPerson.PersonType = this.AssignStringValue(drPersons, "PersonType");

                    aPerson.FirstName = this.AssignStringValue(drPersons, "FirstName");
                    aPerson.LastName = this.AssignStringValue(drPersons, "LastName");
                    aPerson.ModifiedDate = this.AssignDateValue(drPersons, "ModifiedDate");

                    lstPersons.Add(aPerson);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cnPersons.Close();
            }

            return lstPersons;
        }
            



    }
}
