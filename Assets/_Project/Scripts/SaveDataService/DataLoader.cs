using System.Collections.Generic;
using _Project.Scripts.SaveDataService.Interfaces;
using Newtonsoft.Json;

namespace _Project.Scripts.SaveDataService
{
  public class DataLoader : IDataLoader
  {
    public Dictionary<string, object> ConvertDataForReading(string content) => 
      JsonConvert.DeserializeObject<Dictionary<string, object>>(content);

    public string ConvertDataForSaving(Dictionary<string, object> savedValues) => 
      JsonConvert.SerializeObject(savedValues);
  }
}