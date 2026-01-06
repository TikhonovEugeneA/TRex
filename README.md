**Инструкция по сборке и развертыванию приложения. Выполнил Тихонов Е.А.**
# 1. Требуемый инструментарий для сборки приложения из исходного кода:
Для сборки приложения из исходного кода нужно установить:
1. ***Git;***
2. ***Unityhub*** (Для самостоятельной сборки приложения под разные платформы).
## 1.1 Из терминала
### 1.1.1 Для Windows (winget)
Открыть терминал и запустить команды:
`winget install --id Git.Git -e --source winget`
`winget install Unity.UnityHub --silent` 
### 1.1.2 Для Linux (snap)
Открыть терминал и запустить команды:
`sudo apt update`
`sudo apt install git -y`
`sudo snap install unity-hub --classic`
## 1.2 Через официальные сайты Git и Unity
Перейти на сайты и скачать ПО под свою платформу  
1. Git `https://git-scm.com/install`
2. Unity `https://unity.com/ru/download`
# 2. Сборка проекта из исходного кода
Для сборки проекта нужно клонировать репозиторий:
`git clone https://github.com/TikhonovEugeneA/TRex`
`cd TRex`
## 2.1 Сборка через Unity Editor
Для сборки приложения через редактор ***Unity Editor*** требуется:
1. Запустить приложение ***Unity Hub***;
2. Перейти ***Installs -> Manage -> Add Modules*** установить платформы, под которые нужно собрать приложение;
3. Перейти на вкладку ***Projects*** запустить проект ***TRex***;
4. Открыть вкладку ***File -> Build Profiles*** и выбрать платформу в списке ***Platforms*** и нажать кнопку ***Switch Platform***;
5. Перейти на вкладку ***Player Settings***, если поля не заполнены автоматически
- Company Name;
- Product Name;
- Version.  
  
&emsp;То ввести, например: 
- DefaultCompany, 
- TRex,
- 1.0  
6. (Данный шаг можно пропустить, но тогда иконка приложения будет по умолчанию, т.е. как у приложения ***Unity***)  
- В этой же вкладке выбрать под какую платформу хотите собрать приложение, например, для (***Windows, Mac, Linux***)
- открыть вкладку ***Icon***, поставить галочку ***Override for Windows, Mac, Linux*** и вставить туда иконку приложения;
7. После того, как платформа станет активной, нажать на кнопку ***Build*** и выбрать папку, в которую хотите поместить сборку.
## 2.2 Сборка через командную строку
Для сборки приложения через командную строку нужно ввести команду в зависимости от платформы имеются следующие возможные решения: 
### 2.2.1 Для Windows:
`& "/path/to/Unity" -batchmode -nographics -projectPath "/path/to/project" -buildWindowsPlayer "/path/to/build/MyGame" -logfile "/path/to/build.log" -quit` 
> **Примечание:** Обычно при установке UnityHub путь до Unity.exe:
`"C:\Program Files\Unity\Hub\Editor\Ваша_версия_Unity\Editor\Unity.exe"`
### 2.2.2 Для Linux:
`/path/to/Unity -batchmode -nographics -projectPath "/path/to/project" -buildLinux64Player "/path/to/build/MyGame" -logFile "/path/to/build.log" -quit`
### 2.2.3 Для Android
`/path/to/Unity -batchmode -nographics -projectPath "/path/to/project" -buildTarget Android -buildPath "/path/to/build/app.apk" -logFile "/path/to/build.log" -quit`