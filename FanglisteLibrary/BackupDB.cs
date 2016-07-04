using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.SqlServer.Management.Common;

namespace FanglisteLibrary
{
    public class BackupDB
    {
        /// <summary>
        /// Backup a whole database to the specified file.
        /// </summary>
        /// <remarks>
        /// The database must not be in use when backing up
        /// The folder holding the file must have appropriate permissions given
        /// </remarks>
        /// <param name="backUpFile">Full path to file to hold the backup</param>
        public static void BackupDatabase(string backUpFile)
        {
            ServerConnection con = new ServerConnection(SQLCollection.GetConnectionString());
            Server server = new Server(con);
            Backup source = new Backup();
            source.Action = BackupActionType.Database;
            source.Database = "MyDataBaseName";
            BackupDeviceItem destination = new BackupDeviceItem(backUpFile, DeviceType.File);
            source.Devices.Add(destination);
            source.SqlBackup(server);
            con.Disconnect();
        }

        /// <summary>
        /// Restore a whole database from a backup file.
        /// </summary>
        /// <remarks>
        /// The database must not be in use when backing up
        /// The folder holding the file must have appropriate permissions given
        /// </remarks>
        /// <param name="backUpFile">Full path to file to holding the backup</param>
        public static void RestoreDatabase(string backUpFile)
        {
            ServerConnection con = new ServerConnection(@"xxxxx\SQLEXPRESS");
            Server server = new Server(con);
            Restore destination = new Restore();
            destination.Action = RestoreActionType.Database;
            destination.Database = "MyDataBaseName";
            BackupDeviceItem source = new BackupDeviceItem(backUpFile, DeviceType.File);
            destination.Devices.Add(source);
            destination.ReplaceDatabase = true;
            destination.SqlRestore(server);
        }
    }
}
