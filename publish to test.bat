echo publish...
set web=\\192.168.0.201\www\bmshmedia-test
set webconfig=\\192.168.0.201\www\bmshmedia-test\web.config

rem robocopy %web%\ %web%_old\ /Mir /NP /TEE /R:0

rem echo .. >> %webconfig%
rem ping 127.0.0.1 -n 5 > Nul

rem del /S /Q %web%\*

robocopy .\publish %web%\ /Mir /TEE /R:0 /NP

pause