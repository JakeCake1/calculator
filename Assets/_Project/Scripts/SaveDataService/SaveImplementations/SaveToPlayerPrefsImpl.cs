using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.SaveDataService.SaveImplementations
{
  public class SaveToPlayerPrefsImpl : BaseSaveStrategy
  {
    private const string PlayerPrefsKeys = ".PlayerPrefsKeys";
    
    private List<string> _keyList;

    public override Dictionary<string, string> Load()
    {
      string jsonKeyList = PlayerPrefs.GetString(PlayerPrefsKeys);

      _keyList = JsonUtility.FromJson<List<string>>(jsonKeyList);

      Dictionary<string, string> content = new Dictionary<string, string>();

      if (_keyList != null)
      {
        foreach (var key in _keyList)
          content.Add(key, PlayerPrefs.GetString(key));
      }
      else
        _keyList = new List<string>();

      return content;
    }

    public override void Write(string fileKey, string content)
    {
      PlayerPrefs.SetString(fileKey, content);

      if (!_keyList.Contains(fileKey))
      {
        _keyList.Add(fileKey);
        PlayerPrefs.SetString(PlayerPrefsKeys, JsonUtility.ToJson(_keyList));
      }
    }
  }
}