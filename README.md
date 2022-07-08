# RandomGameStarter

På rad #1 I Program.cs behöver du byta ut "string startFolder = @"E:\SteamLibrary\steamapps\common";" till en sökväg som passar din dator.

När du startar appen så kommer den att stoppa alla dina spel i en lista, sen slumpa fram ett spel och starta det.
Än så länge är inte appen smart nog att filtrera bort "updater, debug, patcher, installer" etc, utan den letar bara efter exe filer. 
