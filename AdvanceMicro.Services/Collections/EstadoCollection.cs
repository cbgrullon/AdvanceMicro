using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceMicro.Services
{
    using System.Collections;
    using System.Data;
    using System.Data.SqlClient;
    using Entities;
    public class EstadoCollection : IEnumerable<Estado>
    {
        private SqlConnection Connection;
        private SqlTransaction Transaction;
        private const string InsertQuery = "Insert Into dbo.Estados(IdEstado, Descripcion) Values(@IdEstado, @Descripcion)";
        private const string UpdateQuery= "Update dbo.Estados Set IdEstado = @IdEstado, Descripcion = @Descripcion Where IdEstado= @IdEstadoOld";
        private const string RemoveQuery = "Delete dbo.Estados Where IdEstado = @IdEstado";
        private const string SelectQuery = "Select IdEstado, Descripcion From Estados";
        internal EstadoCollection(SqlConnection Connection,SqlTransaction Transaction)
        {
            this.Connection = Connection;
            this.Transaction = Transaction;
        }
        public void Add(Estado estado)
        {
            if (estado == null)
                throw new Exception("Can't Insert null Estado");
            if (string.IsNullOrEmpty(estado.Descripcion) || string.IsNullOrEmpty(estado.IdEstado))
                throw new Exception("Cannot insert null on a Parameter");
            using(var command = new SqlCommand(InsertQuery,Connection,Transaction))
            {
                command.Parameters.AddWithValue("@IdEstado", estado.IdEstado);
                command.Parameters.AddWithValue("@Descripcion", estado.Descripcion);
                command.ExecuteNonQuery();
            }
        }
        public void Update(string IdEstado,Estado estado)
        {
            if (estado == null)
                throw new Exception("Can't Insert null Estado");
            if (string.IsNullOrEmpty(estado.Descripcion) || string.IsNullOrEmpty(estado.IdEstado))
                throw new Exception("Cannot insert null on a Parameter");
            using (var command = new SqlCommand(UpdateQuery, Connection, Transaction))
            {
                command.Parameters.AddWithValue("@IdEstado", estado.IdEstado);
                command.Parameters.AddWithValue("@Descripcion", estado.Descripcion);
                command.Parameters.AddWithValue("@IdEstadoOld", IdEstado);
                command.ExecuteNonQuery();
            }
        }
        public void Remove(string IdEstado)
        {
            using(var command = new SqlCommand(RemoveQuery, Connection, Transaction))
            {
                command.Parameters.AddWithValue("@IdEstado",IdEstado);
                command.ExecuteNonQuery();
            }
        }
        public IEnumerator<Estado> GetEnumerator()
        {
            using (var commad = new SqlCommand(SelectQuery, Connection,Transaction))
            {
                using (var adapter = new SqlDataAdapter(commad))
                {
                    using (var dt = new DataTable())
                    {
                        adapter.Fill(dt);
                        return dt.AsEnumerable()
                            .Select(dr => new Estado
                            {
                                IdEstado = dr["IdEstado"]?.ToString(),
                                Descripcion = dr["Descripcion"]?.ToString()
                            }).GetEnumerator();
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
