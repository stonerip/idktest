@echo off
title GitHub Auto Commit
set bgitpath="C:\Users\bsherow\AppData\Local\GitHub\PortableGit_c2ba306e536fdf878271f7fe636a147ff37326ad\bin"
set gitpath="C:\Users\bsherow\Documents\Idktest"
set "status="
cd %gitpath%
:loop
For /f "tokens=2-4 delims=/ " %%a in ('date /t') do (set mydate=%%c-%%a-%%b)
For /f "tokens=1-2 delims=/:" %%a in ('time /t') do (set mytime=%%a%%b)
echo Last ran at %mytime%
%bgitpath%\git.exe add --all .
%bgitpath%\git.exe commit -m ":floppy_disk: Auto Commit %mydate%_%mytime% :floppy_disk:"
%bgitpath%\git.exe push origin master
timeout /T 300
cls
goto loop