@echo off
REM 设置网络适配器的名称
REM 英文系统一般是：Local Area Connection
REM set "AdapterName=Local Area Connection"
REM 中文系统一般是：本地连接
set "AdapterName=宽带连接"

set "FileTmp=%temp%\ipList.txt"
ipconfig /all >"%FileTmp%"
for /f "delims=:" %%i in ('findstr /n /c:"%AdapterName%" "%FileTmp%"') do (
set "SkipRow=%%i"
goto :DoSkip
)

:DoSkip
for /f "tokens=2 delims=:(" %%i in ('more +%SkipRow% "%FileTmp%" ^| findstr /v "IPv6" ^|findstr "IP"') do (
set "IP=%%i"
goto :ShowResult
)

:ShowResult
set "IP=%IP: =%"
echo,%IP%


rem 后添加
echo %IP%>ip\ip.txt
svn ci ip --username yjfyy --password wzdhxzh500ntaocode -m "newip"
