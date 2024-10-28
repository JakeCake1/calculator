using System.Collections.Generic;
using _Project.Scripts.SaveDataService.Interfaces;
using UnityEngine;

namespace _Project.Scripts.SaveDataService
{
  public class DataLoader : IDataLoader
  {
    public Dictionary<string, object> ConvertDataForReading(string content) =>
      JsonUtility.FromJson<Dictionary<string, object>>(content);

    public string ConvertDataForSaving(Dictionary<string, object> savedValues) =>
      JsonUtility.ToJson(savedValues);
  }
}