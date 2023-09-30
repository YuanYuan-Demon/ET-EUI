@echo off
set Workspace=..\..
set Luban_Dll=%Workspace%\Tools\Luban\Luban\Luban.dll
set Conf_Root=%Workspace%\Config\Excel
set Output_Code_Dir=%Workspace%\Unity\Assets\Scripts\Codes\Model\Generate\ClientServer\Config
set Output_Bin_Dir=%Workspace%\Config\Bytes\cs
set Output_Json_Dir=%Workspace%\Config\Json\cs
set Config_Folder=%1

echo ======================= ClientServer GameConfig-%Config_Folder% Code ==========================
dotnet %Luban_Dll% ^
    -t GameConfig-%Config_Folder% ^
    --conf %Conf_Root%\luban.conf ^
    -c cs-bin ^
    --customTemplateDir %Conf_Root%\CustomTemplate ^
    -x outputCodeDir=%Output_Code_Dir%


echo ======================= ClientServer GameConfig Json ==========================
dotnet %Luban_Dll% ^
    -t GameConfig ^
    --conf %Conf_Root%\luban.conf ^
    -d json ^
    -x outputDataDir=%Output_Json_Dir%\GameConfig


echo ======================= ClientServer GameConfig Bytes ==========================
dotnet %Luban_Dll% ^
    -t GameConfig ^
    --conf %Conf_Root%\luban.conf ^
    -d bin ^
    -x outputDataDir=%Output_Bin_Dir%\GameConfig

echo ======================= ClientServer StartConfig %Config_Folder% Json ==========================
dotnet %Luban_Dll% ^
    -t %Config_Folder% ^
    --conf %Conf_Root%\luban.conf ^
    -d json ^
    -x outputDataDir=%Output_Json_Dir%\StartConfig\%Config_Folder%

echo ======================= ClientServer StartConfig %Config_Folder% Bytes ==========================
dotnet %Luban_Dll% ^
    -t %Config_Folder% ^
    --conf %Conf_Root%\luban.conf ^
    -d bin ^
    -x outputDataDir=%Output_Bin_Dir%\StartConfig\%Config_Folder%
