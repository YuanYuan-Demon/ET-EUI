set Workspace= ../..
set Luban_Dll=%Workspace%\Tools\Luban\Luban.dll
set Conf_Root=%WORKSPACE%\Unity\Assets\Config\Excel
set Output_Code_Dir=%WORKSPACE%\Unity\Assets\Scripts\Codes\Model\Generate\ClientServer\Config
set Output_Bin_Dir=%WORKSPACE%\Config\Excel\cs
set Output_Json_Dir=%WORKSPACE%\Config\Json\cs
set Config_Folder=%1

echo ====================================== 开始生成数据 ======================================


echo ======================= ClientServer Code ==========================
dotnet %Luban_Dll% ^
    -t all ^
    --conf %Conf_Root%\luban.conf ^
    -c cs-simple-json ^
    -x outputCodeDir=%Output_Code_Dir%
if %ERRORLEVEL% NEQ 0 exit


echo ======================= ClientServer GameConfig Json ==========================
dotnet %Luban_Dll% ^
    -t all ^
    --conf %Conf_Root%\luban.conf ^
    -d json ^
    -e StartMachineConfigCategory,StartProcessConfigCategory,StartSceneConfigCategory,StartZoneConfigCategory ^
    -x outputDataDir=%Output_Json_Dir%\GameConfig
if %ERRORLEVEL% NEQ 0 exit


echo ======================= ClientServer GameConfig Bytes ==========================
dotnet %Luban_Dll% ^
    -t all ^
    --conf %Conf_Root%\luban.conf ^
    -d bin ^
    -e StartMachineConfigCategory,StartProcessConfigCategory,StartSceneConfigCategory,StartZoneConfigCategory ^
    -x outputDataDir=%Output_Bin_Dir%\GameConfig
if %ERRORLEVEL% NEQ 0 exit


echo ======================= ClientServer StartConfig %Config_Folder% Json ==========================
dotnet %Luban_Dll% ^
    -t all ^
    --conf %Conf_Root%\luban.conf ^
    -d json ^
    -o StartMachineConfigCategory,StartProcessConfigCategory,StartSceneConfigCategory,StartZoneConfigCategory ^
    -x outputDataDir=%Output_Json_Dir%\StartConfig\%Config_Folder%
if %ERRORLEVEL% NEQ 0 exit


echo ======================= ClientServer StartConfig %Config_Folder% Bytes ==========================
dotnet %Luban_Dll% ^
    -t all ^
    --conf %Conf_Root%\luban.conf ^
    -d bin ^
    -o StartMachineConfigCategory,StartProcessConfigCategory,StartSceneConfigCategory,StartZoneConfigCategory ^
    -x outputDataDir=%Output_Json_Dir%\StartConfig\%Config_Folder%
if %ERRORLEVEL% NEQ 0 exit