namespace BT_COMMONS.Database
{
    public interface IAPIAccess
    {
        Task<APIResponse<T>> Get<T>(string url);
        Task<APIResponse<T>> Post<T, U>(string url, U data);
        void UpdateWithToken(string token);
        void UpdateWithUrl(string url);
    }
}