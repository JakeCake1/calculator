using _Project.Scripts.SaveDataService.Collections;
using _Project.Scripts.SaveDataService.Interfaces;

namespace _Project.Scripts.SaveDataService.Factories
{
  public class PersistentStackFactory<T>
  {
    private readonly ISaveDataService _saveDataService;

    public PersistentStackFactory(ISaveDataService saveDataService) => 
      _saveDataService = saveDataService;

    public PersistentStack<T> Create(string subFile, string key)
    {
      var persistentStack = new PersistentStack<T>(_saveDataService);
      persistentStack.Load(subFile, key);

      return persistentStack;
    }
  }
}