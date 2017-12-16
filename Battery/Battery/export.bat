for /f "tokens=2 delims=:." %%x in ('chcp') do set cp=%%x
chcp 65001>nul
SET guid =Powercfg -getactivescheme 
powercfg -q %guid% >kek.txt
chcp %cp%>nul

