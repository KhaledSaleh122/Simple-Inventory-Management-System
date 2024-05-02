using System.Data.SqlClient;

namespace SimpleInventoryManagementSystem.Domain.DatabaseManagemnt
{
    public interface IDatabaseOpenClose
    {
        void CloseSqlConnection();
        SqlConnection GetSqlConnection();
    }
}