using _Project.Scripts.Calculator.View;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Calculator.Factories
{
  /// \interface ICalculatorUIFactory
  /// \brief Интерфейс, описывающий методы создания и уничтожения объектов UI калькулятора
  public interface ICalculatorUIFactory
  {  
    /// \brief Метод создания объекта UI калькулятора
    /// \return UniTask который можно подождать до завершения процесса создания объекта
    UniTask<ICalculatorMainView> CreateCalculatorMainView();
    /// \brief Метод уничтожения объекта UI калькулятора
    void ClearCalculatorMainView();
  }
}