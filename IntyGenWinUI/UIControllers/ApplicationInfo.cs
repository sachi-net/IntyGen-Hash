using System.Diagnostics;
using System.Reflection;

namespace IntyGenWinUI.UIControllers
{
    internal class ApplicationInfo
    {
        private Assembly assembly = Assembly.GetExecutingAssembly();

        internal string GetAppVersion(string prefix = null, string suffix = null)
        {
            return $"{prefix}{FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion}{suffix}";
        }

        internal string GetFileName()
        {
            return FileVersionInfo.GetVersionInfo(assembly.Location).FileName;
        }

        internal string GetProductName()
        {
            return FileVersionInfo.GetVersionInfo(assembly.Location).ProductName;
        }

        internal int GetProductBuild()
        {
            return FileVersionInfo.GetVersionInfo(assembly.Location).ProductBuildPart;
        }
    }
}
