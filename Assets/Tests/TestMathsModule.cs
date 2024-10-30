using _Project.Scripts.Maths;
using _Project.Scripts.Maths.Command;
using NUnit.Framework;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Tests
{
  /// \class TestMathsModule
  /// \brief Класс для тестирования математической логики
  [TestFixture]
  public class TestMathsModule
  {
    private IContainerBuilder _builder;
    private LifetimeScope _lifetimeScope;

    [SetUp]
    public void SetUp()
    {
      _lifetimeScope = LifetimeScope.Create(new MathsInstaller().Install);
      _lifetimeScope.Build();
    }

    [TearDown]
    public void TearDown() =>
      Object.DestroyImmediate(_lifetimeScope.gameObject);

    [TestCase("5+5", "5+5=10")]
    [TestCase("10+10.0", "10+10.0=ERROR")]
    [TestCase("8+154", "8+154=162")]
    [TestCase("5+5=", "5+5==ERROR")]
    [TestCase("-5+5", "-5+5=ERROR")]
    [TestCase("-5", "-5=ERROR")]
    [TestCase("3/3", "3/3=ERROR")]
    [TestCase("544564564646456456456456+456456456564566465646456456456455645", "544564564646456456456456+456456456564566465646456456456455645=ERROR")]
    public void TestExpressions(string input, string answer)
    {
      var maths = _lifetimeScope.Container.Resolve<IMaths>();
      string result;
      
      if (maths.TryExecuteExpression(input, out MathCommand mathCommand))
        result = mathCommand.GetResult();
      else
        result = input + "=ERROR";
      
      Assert.AreEqual(result, answer);
    }
  }
}