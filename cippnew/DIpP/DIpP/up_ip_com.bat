@echo off
REM ��������������������
REM Ӣ��ϵͳһ���ǣ�Local Area Connection
REM set "AdapterName=Local Area Connection"
REM ����ϵͳһ���ǣ���������
set "AdapterName=�������"

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


rem �����
echo %IP%>ip\ip.txt
svn ci ip --username yjfyy --password wzdhxzh500ntaocode -m "newip"
