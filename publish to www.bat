echo publish...
set web=\\192.168.0.201\www\bmshmedia
set webconfig=\\192.168.0.201\www\bmshmedia\web.config

robocopy %web%\ %web%_old\ /Mir /NP /TEE /R:0

echo .. >> %webconfig%
ping 127.0.0.1 -n 5 > Nul

rem del /S /Q %web%\*

robocopy .\publish %web%\ /Mir /TEE /R:0 /NP

pause