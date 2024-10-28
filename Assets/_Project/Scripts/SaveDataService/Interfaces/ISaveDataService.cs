namespace _Project.Scripts.SaveDataService.Interfaces
{
  public interface ISaveDataService
  {
    void Load();
    void Write();
    
    void SaveString(string subFile, string key, string value);
    void SaveInt(string subFile, string key, int value);
    void SaveFloat(string subFile, string key, float value);
    void SaveBool(string subFile, string key, bool value);

    string GetString(string subFile, string key);
    int GetInt(string subFile, string key);
    float GetFloat(string subFile, string key);
    bool GetBool(string subFile, string key);
  } 
}