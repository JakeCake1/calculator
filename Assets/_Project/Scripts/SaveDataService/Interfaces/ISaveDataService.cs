namespace _Project.Scripts.SaveDataService.Interfaces
{
  public interface ISaveDataService
  {
    void Load();
    void Write();
    void Save(string subFile, string key, object value);
    T Get<T>(string subFile, string key);
  } 
}