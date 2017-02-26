set "UNITY_PATH=D:\Program Files\Unity\Editor\Unity.exe"
set "PROJECT_PATH=C:\Users\Public\Documents\Unity Projects\_Serpent"
start /WAIT "Unity editor tests" "%UNITY_PATH%" ^
    -batchmode -nographics -runEditorTests ^
    -projectPath "%PROJECT_PATH%" ^
    -editorTestsResultFile "%TEMP%\serpent_test_results.xml"
echo Exited with code %ERRORLEVEL%
