using System.Data;

namespace Model.Interface
{
    public interface IAbstractDAO
    {
        IDbConnection GetConnection();
        void ReleaseConnection(IDbConnection connection);
    }
}