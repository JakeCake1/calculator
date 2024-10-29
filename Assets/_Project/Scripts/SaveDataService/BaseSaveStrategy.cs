using System.Collections.Generic;

namespace _Project.Scripts.SaveDataService
{
  public abstract class BaseSaveStrategy
  {
    public abstract Dictionary<string, string> Load();
    public abstract void Write(string fileKey, string content);
  }
}