using SharpShell.Attributes;
using SharpShell.SharpContextMenu;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AssemblyInformationShellEx
{
    [ComVisible(true)]
    [COMServerAssociation(AssociationType.ClassOfExtension, ".exe")]
    [COMServerAssociation(AssociationType.ClassOfExtension, ".dll")]
    public class ShellExtension : SharpContextMenu
    {
        protected override bool CanShowMenu()
        {
            using (var e = SelectedItemPaths.GetEnumerator())
            {
                if (!e.MoveNext())
                {
                    return false;
                }

                var firstItem = e.Current;
                return firstItem.EndsWith(".exe") || firstItem.EndsWith(".dll");
            }
        }

        protected override ContextMenuStrip CreateMenu()
        {
            var menu = new ContextMenuStrip();

            var assemblyInfoItem = new ToolStripMenuItem(Resource.ApplicationName)
            {
                Image = Resource.Icon
            };

            assemblyInfoItem.Click += LoadAssemblyInfoProcess;

            menu.Items.Add(assemblyInfoItem);

            return menu;
        }

        private void LoadAssemblyInfoProcess(object sender, EventArgs e)
        {
            const string ApplicationFile = "AssemblyInformation.exe";
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fullPath = Path.Combine(basePath, ApplicationFile);
            var firstSelectedFile = "\"" + SelectedItemPaths.First() + "\"";
            var processInfo = new ProcessStartInfo(fullPath)
            {
                Arguments = firstSelectedFile
            };
            var process = Process.Start(processInfo);
        }
    }
}
