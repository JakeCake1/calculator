using System.Collections.Generic;
using _Project.Scripts.SaveDataService.Interfaces;
using Newtonsoft.Json;
using UnityEngine;

namespace _Project.Scripts.SaveDataService.Collections
{
  /// \class PersistentStack
  /// \brief Класс-стек, коллекция с сохранением значений между сессиями
  public sealed class PersistentStack<T>
  { 
    /// \brief Сервис для сохранения данных
    private readonly ISaveDataService _saveDataService;
    
    /// \brief Флаг инициализации коллекции
    private bool _isInitialized;
    /// \brief Ключ для сохранения коллекции
    private string _key;

    /// \brief Максимальная вместительность коллекции
    private int _maxCapacity = int.MaxValue;
    /// \brief Базовая коллекция-стек
    private Stack<T> _stack;
    
    /// \brief Ключ файла для сохранения
    private string _subFile;

    /// \brief Конструктор стека
    /// \param saveDataService   Сервис для сохранения данных
    public PersistentStack(ISaveDataService saveDataService)
    {
      if (!(typeof(T) == typeof(int) || typeof(T) == typeof(float) || typeof(T) == typeof(bool) || typeof(T) == typeof(string)))
      {
        Debug.LogError("Type is not supported - supported types: int, float, bool, string");
        return;
      }

      _saveDataService = saveDataService;
    }
    
    /// \brief Деструктор стека
    ~PersistentStack() => 
      _isInitialized = false;

    /// \brief Метод настройки максимальной вместимости стека
    /// \param maxCapacity   Максимальная вместимость стека
    public void SetMaxCapacity(int maxCapacity) => 
      _maxCapacity = maxCapacity;
    
    /// \brief Метод загрузки коллекции
    /// \param subFile   Ключ файла для сохранения
    /// \param key   Ключ для сохранения коллекции
    public void Load(string subFile, string key)
    {
      _subFile = subFile;
      _key = key;

      var json = _saveDataService.Get<string>(_subFile, _key);
      _stack = json != null ? JsonConvert.DeserializeObject<Stack<T>>(json) : new Stack<T>();

      Reverse(_stack);
      
      _isInitialized = true;
    }
    
    /// \brief Метод вставки в стек
    /// \param obj   Значение для вставки
    public void Push(T obj)
    {
      if (IsInitialized())
        return;

      if (_stack.Count >= _maxCapacity)
      {
        Debug.LogWarning("Reached maximum for persistent stack - last value will be replaced");
        _stack.Pop();
      }

      _stack.Push(obj);
      WriteStack();
    }
    
    /// \brief Метод удаления из стека
    /// \return Удаленное значение
    public T Pop()
    {
      if (IsInitialized())
        return default;

      T pop = _stack.Pop();
      WriteStack();

      return pop;
    }
    
    /// \brief Метод очистки стека
    public void Clear()
    {
      if (IsInitialized())
        return;

      _stack.Clear();
      WriteStack();
    }
    
    /// \brief Метод взятия значения из стека
    /// \return Значение из стека
    public T Peek()
    {
      if (IsInitialized())
        return default;

      return _stack.Peek();
    }
    
    /// \brief Метод получения количества значений в стеке
    /// \return Количестов значений в стеке
    public int Count()
    {
      if (IsInitialized())
        return default;

      return _stack.Count;
    }

    /// \brief Метод получения массива значений из стека
    /// \return Массив значений
    public T[] ToArray()
    {
      if (IsInitialized())
        return default;

      return _stack.ToArray();
    }
    
    /// \brief Метод получения флага инициализации
    /// \return Флаг инициализации
    private bool IsInitialized()
    {
      if (!_isInitialized)
      {
        Debug.LogError("Trying to use not initialized PersistentStack instance");
        return true;
      }

      return false;
    }
    
    /// \brief Метод записи значений в стек
    private void WriteStack()
    {
      string json = JsonConvert.SerializeObject(_stack);

      _saveDataService.Save(_subFile, _key, json);
      _saveDataService.Write();
    }
    
    /// \brief Метод для переворачивания порядка значений в стеке
    /// \param stack   Базовый стек
    private void Reverse(Stack<T> stack)
    {
      T[] list = new T[stack.Count];

      for (int i = 0; i < list.Length; i++) 
        list[i] = stack.Pop();

      for (var index = 0; index < list.Length; index++) 
        stack.Push(list[index]);
    }
  }
}