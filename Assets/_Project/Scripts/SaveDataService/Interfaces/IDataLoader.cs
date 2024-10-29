using System.Collections.Generic;

namespace _Project.Scripts.SaveDataService.Interfaces
{
  public interface IDataLoader
  {
    Dictionary<string, object> ConvertDataForReading(string content);
    string ConvertDataForSaving(Dictionary<string, object> savedValues);
  }
}