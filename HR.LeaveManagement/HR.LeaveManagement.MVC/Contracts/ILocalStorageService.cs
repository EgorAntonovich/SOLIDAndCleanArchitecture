namespace HR.LeaveManagement.MVC.Contracts;

public interface ILocalStorageServices
{
    void ClearStorage(List<string> keys);
    bool Exists(string key);
    T GetStorageValue<T>(string keys);
    void SetStorageValue<T>(string key, T value);
}