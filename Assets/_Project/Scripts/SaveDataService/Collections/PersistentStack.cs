using System.Collections.Generic;
using _Project.Scripts.SaveDataService.Interfaces;
using Newtonsoft.Json;
using UnityEngine;

namespace _Project.Scripts.SaveDataService.Collections
{
  public sealed class PersistentStack<T>
  {
    private Stack<T> _stack;
    
    private readonly ISaveDataService _saveDataService;
    
    private string _subFile;
    private string _key;

    private bool _isInitialized;
    
    public PersistentStack(ISaveDataService saveDataService)
    {
      if (!(typeof(T) == typeof(int) || typeof(T) == typeof(float) || typeof(T) == typeof(bool) || typeof(T) == typeof(string)))
      {
        Debug.LogError("Type is not supported - supported types: int, float, bool, string");
        return;
      }
      
      _saveDataService = saveDataService;
    }

    ~PersistentStack() => 
      _isInitialized = false;
    
    public void Load(string subFile, string key)
    {
      _subFile = subFile;
      _key = key;

      string json = _saveDataService.Get<string>(_subFile, _key);
      _stack = json != null ? JsonConvert.DeserializeObject<Stack<T>>(json) : new Stack<T>();

      _isInitialized = true;
    }

    public void Push(T obj)
    {
      if (IsInitialized()) 
        return;

      _stack.Push(obj);
      WriteStack();
    }

    public T Pop()
    {   
      if (IsInitialized()) 
        return default;
      
      T pop = _stack.Pop();
      WriteStack();

      return pop;
    }

    public void Clear()
    {   
      if (IsInitialized()) 
        return;
      
      _stack.Clear();
      WriteStack();
    }

    public T Peek()
    {   
      if (IsInitialized()) 
        return default;
      
      return _stack.Peek();
    }

    public int Count()
    {  
      if (IsInitialized()) 
        return default;
      
      return _stack.Count;
    }

    public T[] ToArray()
    { 
      if (IsInitialized()) 
        return default;
      
      return _stack.ToArray();
    }

    private bool IsInitialized()
    {
      if (!_isInitialized)
      {
        Debug.LogError("Trying to use not initialized PersistentStack instance");
        return true;
      }

      return false;
    }

    private void WriteStack()
    {
      string json = JsonConvert.SerializeObject(_stack);
      
      _saveDataService.Save(_subFile, _key, json);
      _saveDataService.Write();
    }
  }
}