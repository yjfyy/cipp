@echo off
for /f "tokens=2 delims=:" %%i in ('ipconfig^|findstr "Address"') do set ip=%%i
echo %ip:~1%>ip\ip.txt
svn ci ip --username yjfyy --password wzdhxzh500ntaocode -m "newip"