# Calculator Pro

## Обзор

Проект создан c использованием Unity 2022.3.19f1 в рамках тестового задания по реализации проекта на MVP архитектуре

## Как запустить

1. Открыть проект через Unity 
2. Открыть сцену Assets/_Project/Scenes/Main.unity
3. Нажать Play

Основной скрипт для запуска: Bootstrapper.cs
<br/>Из него можно начать изучать проект и зависимости

## Документация

В проекте есть сгенерированная документация Doxygen:
<br/>Файл *\docs\html\index.html можно открыть через адресную строку браузера и 
кликнуть вкладку Classes

## Тесты
Через General -> TestRunner можно запустить UnitTest для математического модуля Maths
<br/>Путь к скрипту с тест-кейсами: Assets/Tests/TestMathsModule.cs

## Дополнительно

Дополнительно через PackageManager установлены зависимости:

UniTask
<br/>Addressables
<br/>VContainer
<br/>Newtonsoft Json