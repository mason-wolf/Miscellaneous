using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using MySql.Data;
using MySql.Data.MySqlClient;
using Base_Oversight_Accumulator.Launch;

namespace Base_Oversight_Accumulator
{
    /// <summary>
    /// dbconnect -- Uses MySql library for communicating with database server. Currently does not support Data Source binding,
    /// must manually populate DataGridView and other controls. 
    /// 
    ///             ------------------------------------------------------------------------
    /// Usage:      INSERTING
    ///             ------------------------------------------------------------------------
    ///             
    ///             dbconnect mysql = new dbconnect();
    ///             mysql.InsertQuery("INSERT INTO 'table' ('items') VALUES ('values')");
    ///             
    ///             ------------------------------------------------------------------------
    ///             SELECTING
    ///             ------------------------------------------------------------------------
    ///             
    ///             mysql.SelectQuery("SELECT * from 'table'");
    ///             while(mysql.Result.Read()) {
    ///             var item = mysql.Reader('item');
    ///             }
    ///             mysql.CloseConnection();
    ///             
    ///             ------------------------------------------------------------------------
    ///             DELETING
    ///             ------------------------------------------------------------------------
    ///             
    ///             mysql.InsertQuery("DELETE FROM 'table' WHERE id=''");
    ///             
    ///             ------------------------------------------------------------------------
    ///             UPDATING
    ///             ------------------------------------------------------------------------
    ///             
    ///             mysql.InsertQuery("UPDATE 'table' SET 'row'='' WHERE id=''");
    /// 
    ///             ------------------------------------------------------------------------
    ///             COUNTING
    ///             ------------------------------------------------------------------------
    ///             
    ///             mysql.CountQuery("SELECT COUNT(*) FROM 'table'");
    ///             mysql.SumCurrencyQuery("SELECT SUM(value) FROM 'table'");
    ///             
    /// </summary>
    class dbconnect
    {
        private MySqlConnection Connection;
        private string ConnectionString;
        public MySqlDataReader Result;
        public string CurrencySum;
        public bool ExceptionThrown;

        public dbconnect()
        {
            initialize();
        }

        private void initialize()
        {
        }

        /// <summary>
        /// OpenConnection -- Attempts to establish connection to MySql server, if connection fails handle the exception once. Without the ExceptionThrown boolean,
        /// ErrorDetailView shows up twice.
        /// </summary>
        /// <returns>
        /// True if connection was successful. False if it fails.
        /// </returns>
        public bool OpenConnection() 
        {
            try
            {
                string server = Properties.Settings.Default.ServerAddress;
                ConnectionString = "HOST=" + server + "; DATABASE=boa;" + "user=wolf;" + "PASSWORD=wolf; pooling=false;";
                Connection = new MySqlConnection(ConnectionString);
                Connection.Open();
                return true;
            }
            catch (MySqlException ConnectionException)
            {
                if (ExceptionThrown == false)
                {
                    ErrorDetailView ErrorDetailView = new ErrorDetailView();
                    ErrorDetailView.ErrorMessage = "Unable to contact database server.";
                    ErrorDetailView.ErrorDetails = ConnectionException.ToString();
                    ErrorDetailView.Show();
                    Connection.Close();
                    ExceptionThrown = true;
                }
                else
                {
                    
                }
                return false;
            }
        }

        /// <summary>
        /// CloseConnection() -- Without ClearAllPools() or Dipose(), the server connection pool overloads, used to prevent connection leaks.
        /// When connection is closed, by default MySql puts the connection in 'SLEEP' mode. View processes via the 
        /// show processlist(); command.
        /// </summary>
        /// <returns></returns>
        public bool CloseConnection()
        {

            Connection.Close();
            MySqlConnection.ClearAllPools();
            Connection.Dispose();
            return true;

        }

        public void InsertQuery(string query)
        {

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, Connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        /// <summary>
        /// SelectQuery -- OpenConnection() is called because the ExecuteReader() method relies on a while loop to read table contents.
        /// Connection needs to be closed after rows are retrieved.
        /// </summary>
        /// <param name="query"></param>
        public void SelectQuery(string query)
        {
            OpenConnection();
            MySqlCommand Select = Connection.CreateCommand();
            Select.CommandText = query;
            Select.Connection = Connection;
            Result = Select.ExecuteReader();
         }

        public string CountQuery(string query)
        {
            int c;
            MySqlCommand CountQuery = new MySqlCommand(query, Connection);
            c = int.Parse(CountQuery.ExecuteScalar().ToString());
            Connection.Close();
            return c.ToString();
        }

        /// <summary>
        /// SumCurrencyQuery -- Used to count total currency value of assets. The ToString argument "N0" is specified to properly 
        /// format and insert commas when neccessary. 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public string SumCurrencyQuery(string query)
        {
            Connection.Open();

            try
            {
                MySqlCommand SumQuery = new MySqlCommand(query, Connection);
                CurrencySum = "$" + double.Parse(SumQuery.ExecuteScalar().ToString()).ToString("N0");
            }
            catch { }
            Connection.Close();
            return CurrencySum;
        }

        public string Reader(string row)
        {
            string FetchedRow = Convert.ToString(Result[row]);
            return FetchedRow;
        }


    }
    }
