if exist %SYSTEMROOT%\Microsoft.NET\Framework\v4.0.30319 set MSBUILDPATH=%SYSTEMROOT%\Microsoft.NET\Framework\v4.0.30319
if exist "%ProgramFiles%\MSBuild\14.0\Bin" set MSBUILDPATH="%ProgramFiles%\MSBuild\14.0\Bin"
if exist "%ProgramFiles(x86)%\MSBuild\14.0\Bin" set MSBUILDPATH="%ProgramFiles(x86)%\MSBuild\14.0\Bin"

set MSBUILD=%MSBUILDPATH%\msbuild.exe

%MSBUILD% /nologo /m /p:BuildInParallel=true /p:Configuration=Release /p:Platform="Any CPU" UpdateACH.sln

copy bin\Release\UpdateACH.exe UpdateACH.exe
