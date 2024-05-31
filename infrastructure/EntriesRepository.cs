using System.Data;
using Dapper;
using Entities;
using MySql.Data.MySqlClient;

namespace infrastructure;

public class EntriesRepository
{
    private readonly IDbConnection _connection;
    private static string server = "localhost";
    private static string dbName = "SimpleInterest";
    private static string userName = "user";
    private static string password = "password";

    string connectionString = $"Server={server};Port=3306;Database={dbName};User={userName};Password={password};";
    
    public EntriesRepository()
    {
        _connection = new MySqlConnection(connectionString);
    }

    public bool AddEntry(Entries entry)
    {
        const string sql = $@"INSERT INTO Entries(EntryId, UserId, Principal, Rate, Time, TotalInterest) " +
                           "VALUES (@EntryId, @UserId, @Principal, @Rate, @Time, @TotalInterest);";
        return _connection.Execute(sql,
            new
            {
                EntryId = entry.EntryId, UserId = entry.UserId, Principal = entry.Principal, Rate = entry.Rate,
                Time = entry.Time, TotalInterest = entry.TotalInterest
            }) == 1;
    }

    public List<Entries> GetEntriesByUserId(int userId)
    {
        const string sql = "SELECT * FROM Entries WHERE UserId = @UserId";
        return _connection.Query<Entries>(sql, new { UserId = userId }).ToList();
    }

    public Entries GetEntryByEntryId(int entryId)
    {
        const string sql = "SELECT * FROM Entries WHERE UserId = @EntryId";
        return _connection.QueryFirstOrDefault<Entries>(sql, new { EntryId = entryId });
    }

    public bool DeleteEntryByEntryId(int entryId)
    {
        const string sql = "DELETE FROM Entries WHERE EntryId = @EntryId";
        return _connection.Execute(sql, new { EntryId = entryId }) == 1;
    }
}