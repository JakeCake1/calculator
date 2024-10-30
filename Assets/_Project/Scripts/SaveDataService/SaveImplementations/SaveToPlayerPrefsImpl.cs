using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace _Project.Scripts.SaveDataService.SaveImplementations
{ 
  /// \class SaveToPlayerPrefsImpl
  /// \brief Класс, отвечающий за сохранение данных в PlayerPrefs 
  public class SaveToPlayerPrefsImpl : BaseSaveStrategy
  {  
    /// \brief Ключ для сохранения коллекции JSON строк
    private const string PlayerPrefsKeys = ".PlayerPrefsKeys";
    
    /// \brief Ключи для сохранения JSON строк
    private List<string> _keyList;
    
    /// \brief Метод загрузки коллекции сохраненных значений
    /// \param content   Строка в JSON формате
    /// \return Коллекция сохраненных значений
    public override Dictionary<string, string> Load()
    {
      string jsonKeyList = PlayerPrefs.GetString(PlayerPrefsKeys);

      _keyList = JsonConvert.DeserializeObject<List<string>>(jsonKeyList);

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
    
    /// \brief Метод записи коллекции сохраненных значений
    /// \param fileKey   Ключ файла для сохранения
    /// \param content   Строка в JSON формате
    public override void Write(string fileKey, string content)
    {
      PlayerPrefs.SetString(fileKey, content);

      if (!_keyList.Contains(fileKey))
      {
        _keyList.Add(fileKey);
        PlayerPrefs.SetString(PlayerPrefsKeys, JsonConvert.SerializeObject(_keyList));
      }
    }
  }
}