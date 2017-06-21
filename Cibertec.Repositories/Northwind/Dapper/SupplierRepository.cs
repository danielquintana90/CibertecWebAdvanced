﻿using Cibertec.Models;
using Dapper;
using System.Data.SqlClient;

namespace Cibertec.Repositories.Northwind.Dapper
{
    public class SupplierRepository : RepositoryDapper<Supplier>, ISupplierRepository
    {
        public SupplierRepository(string connectionString) : base(connectionString)
        {

        }

        public Supplier GetByContactName(string contactName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@contactName", contactName);

                return connection.QueryFirst<Supplier>("dbo.SearchByContactName",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}