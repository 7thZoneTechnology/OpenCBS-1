﻿// Octopus MFS is an integrated suite for managing a Micro Finance Institution: 
// clients, contracts, accounting, reporting and risk
// Copyright © 2006,2007 OCTO Technology & OXUS Development Network
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public License along
// with this program; if not, write to the Free Software Foundation, Inc.,
// 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
//
// Website: http://www.opencbs.com
// Contact: contact@opencbs.com

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using OpenCBS.ArchitectureV2;
using OpenCBS.GUI.Database;
using OpenCBS.Services;
using OpenCBS.Shared;
using OpenCBS.Shared.Settings;
using StructureMap;

namespace OpenCBS.GUI
{
    /// <summary>
    /// Application main.
    /// </summary>
    public static class AppMain
    {
        private const string HELP = @"-help : this help 
                                    -date=<DATE> : Use given application date
                                    -user=<USER> : Use this user name
                                    -password=<PASSWORD> : Use this password
                                    -dumpSchema : Create database schema dump
                                    -userSettings : Open userSettings dialog
                                    -setup : Open setup dialog
                                    -registry : Only for developper: initialize general parameters with registry keys
                                    -dumpObjects: Dump database objects";
        private static bool _skipSchemaCheck;

        /// <summary>
        /// Application entry point.
        /// </summary>
        [STAThread]
        static void Main(string[] pArgs)
        {
            try
            {
                _ParseApplicationSettings(pArgs);
#if DEBUG
                TechnicalSettings.EnsureKeyExists();
#endif

                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(UserSettings.Language);
                Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;
                Application.EnableVisualStyles();
                Application.DoEvents();

                var bootstrapper = new Bootstrapper(new Container());
                Application.Run(bootstrapper.GetAppContext());
                
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    MessageBox.Show(ex.InnerException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private const string PARAM_HELP = "-help";
        private const string PARAM_DATE = "-date=";
        private const string PARAM_USER = "-user=";
        private const string PARAM_PASSWORD = "-password=";
        private const string PARAM_DATABASE = "-dumpSchema";
        private const string PARAM_USER_SETTINGS = "-userSettings";
        private const string PARAM_SETUP = "-setup";
        private const string PARAM_DUMP_OBJECTS = "-dumpObjects";
        private const string PARAM_ONLINE_MODE = "-online";

        private static string _user;
        private static string _password;

        private static void _ParseApplicationSettings(IEnumerable<string> pArgs)
        {
            foreach (String arg in pArgs)
            {
                if (arg == PARAM_ONLINE_MODE)
                    TechnicalSettings.UseOnlineMode = true;
                if (arg == PARAM_HELP)
                {
                    MessageBox.Show(HELP, @"OMFS " + TechnicalSettings.SoftwareVersion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Environment.Exit(1);
                }
                else if (arg.StartsWith(PARAM_DATE))
                {
                    TimeProvider.SetToday(DateTime.Parse(arg.Substring(PARAM_DATE.Length)));
                }
                else if (arg.StartsWith(PARAM_USER))
                {
                    _user = arg.Substring(PARAM_USER.Length);
                }
                else if (arg.StartsWith(PARAM_PASSWORD))
                {
                    _password = arg.Substring(PARAM_PASSWORD.Length);
                }
                else if (arg.StartsWith(PARAM_DATABASE))
                {
                    TechnicalSettings.CheckSettings();
                    ServicesProvider.GetInstance().GetDatabaseServices().SaveDatabaseDiagramsInXml(false, TechnicalSettings.DatabaseName);
                    Environment.Exit(1);
                }
                else if (arg == PARAM_SETUP)
                {
                    TechnicalSettings.CheckSettings();
                    Form frm = new FrmDatabaseSettings(FrmDatabaseSettingsEnum.SqlServerConnection, true, true);
                    frm.ShowDialog();
                    Environment.Exit(1);
                }
                else if (arg == PARAM_DUMP_OBJECTS)
                {
                    TechnicalSettings.CheckSettings();
                    ServicesProvider.GetInstance().GetDatabaseServices().DumpObjects(TechnicalSettings.DatabaseName);
                    Environment.Exit(1);
                }
                else if (arg == "--skip-schema-check")
                {
                    _skipSchemaCheck = true;
                }
            }
        }
    }
}
