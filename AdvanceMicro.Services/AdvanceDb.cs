using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace AdvanceMicro.Services
{
    using Entities;
    public class AdvanceDb:IDisposable
    {
        private SqlConnection Connection;
        private SqlTransaction Transaction;
        public AdvanceDb()
        {
            Connection = new SqlConnection(Load.CoreDbCString);
            Connection.Open();
            Transaction = Connection.BeginTransaction();
            Estados = new EstadoCollection(Connection, Transaction);
        }
        public EstadoCollection Estados
        {
            get;set;
        }
        public void SaveChanges()
        {
            Transaction.Commit();
        }
        public void RollBack()
        {
            Transaction.Rollback();
        }
        public void Dispose()
        {
            Transaction.Dispose();
            Connection.Close();
            Connection.Dispose();
        }
    }
}
