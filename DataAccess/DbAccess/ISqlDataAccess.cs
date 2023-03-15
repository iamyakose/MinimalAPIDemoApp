namespace DataAccess.DbAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storeProcedure, U parameters, string connnectionId = "Default");
        Task SaveData<T>(string storeProcedure, T parameters, string connnectionId = "Default");
    }
}