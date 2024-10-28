using System.Collections.Generic;
using _Project.Scripts.SaveDataService.Interfaces;
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
    
    public PersistentStack(ISaveDataService saveDataService) => 
      _saveDataService = saveDataService;

    ~PersistentStack() => 
      _isInitialized = false;
    
    public void Load(string subFile, string key)
    {
      _subFile = subFile;
      _key = key;
      
      _stack = JsonUtility.FromJson<Stack<T>>(_saveDataService.GetString(_subFile, _key)) ?? new Stack<T>();

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
      _saveDataService.SaveString(_subFile, _key, JsonUtility.ToJson(_stack));
      _saveDataService.Write();
    }
  }
}