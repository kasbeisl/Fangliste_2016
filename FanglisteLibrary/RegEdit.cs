using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Win32;

namespace FanglisteLibrary
{
    public class RegEdit
    {
        /// <summary>
        /// Beschreibung in der Methode
        /// </summary>
        public void Hinzufügen()
        {
            //In diesem Quellcode werden als erstes die Dateiendung (Mit Punkt), der Pfad zur Anwendung und der Name des Dateitypes definiert. Anschließend werden die Zuordnungen für die Datei, das Symbol und den Befehl fürs Drucken eingetragen. Bitte beachten Sie, das diese Operationen unter Umständen adminitrative berechtigungen brauchen. Beim Druckenbefehl öffne ich ebenfalls das Programm zum öffnen, übergebe aber noch den Parameter /print. Diesen Parameter muss das Programm dann selbstständig verarbeiten.

            //Beim setzen des Icons gebe ich den Pfad zur Anwendung gefolgt von einem Komma und einer Zahl an. Die Zahl ist der Index des Icons. Sie können auch einfach eine ICO-Datei angeben und ,0 daran hängen. Das erste Icon bei einer Anwendung ist das Symbol, welches bei der EXE-Datei im Explorer angezeigt wird.

            //Hinweis: das %1 ist der Platz an dem der Pfad eingefügt wird. Wenn Der Befehl also Text.exe %1 /d lautet dann ersetzt sich dieser zu Test.exe Datei.abc /d.

            //Es sind noch folgende 2 Namespaces zu importieren:

            string extension = ".test01234567890b";
            string path = Process.GetCurrentProcess().MainModule.FileName;
            string fileTypeName = "TestDatei_test01234567890b";

            //Erweiterung mit Dateityp verknüpfen
            Registry.ClassesRoot.CreateSubKey(extension).SetValue("", fileTypeName, Microsoft.Win32.RegistryValueKind.String);
            //Dateiassoziation
            Registry.ClassesRoot.CreateSubKey(fileTypeName + "\\shell\\open\\command").SetValue("", path + " %1 ", Microsoft.Win32.RegistryValueKind.ExpandString);
            //Symbol für Datei
            Registry.ClassesRoot.CreateSubKey(fileTypeName + "\\DefaultIcon").SetValue("", path + " ,0 ", Microsoft.Win32.RegistryValueKind.ExpandString);
            //Befehl fürs Drucken aus Windowsexplorer-Kontextmenü
            Registry.ClassesRoot.CreateSubKey(fileTypeName + "\\shell\\print\\command").SetValue("", path + " /print %1 ", Microsoft.Win32.RegistryValueKind.ExpandString);
        }
    }
}
