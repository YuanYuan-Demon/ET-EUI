@echo off
set Workspace=..\..
set Luban_Dll=%Workspace%\Tools\Luban\Luban\Luban.dll
set Conf_Root=%Workspace%\Config\Excel
set Output_Code_Dir=%Workspace%\Unity\Assets\Scripts\Codes\Model\Generate\Client\Config
set Output_Bin_Dir=%Workspace%\Config\Bytes\c
set Output_Json_Dir=%Workspace%\Config\Json\c

echo ======================= Client GameConfig Code/Json ==========================
dotnet %Luban_Dll% ^
    -t Client ^
    --conf %Conf_Root%\luban.conf ^
    -c cs-bin ^
    --customTemplateDir CustomTemplate ^
    -x outputCodeDir=%Output_Code_Dir% ^
    -d bin ^
    -x outputDataDir=%Output_Bin_Dir%\GameConfig


echo ======================= Client GameConfig Bytes ==========================
dotnet %Luban_Dll% ^
    -t Client ^
    --conf %Conf_Root%\luban.conf ^
    -d json ^
    -x outputDataDir=%Output_Json_Dir%\GameConfig
