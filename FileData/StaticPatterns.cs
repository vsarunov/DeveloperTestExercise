using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileData
{
    internal static class StaticPatterns
    {
        // Would read this from a config file appsetting or etc. So we could define the possible values, not hardcode it.
        internal static readonly List<string> VersionPatterns = new List<string>()
        {
            "-v",
            "–v",
            "--v",
            "/v",
            "--version"
        };

        internal static readonly List<string> SizePatterns = new List<string>()
        {
            "-s",
            "–s",
            "--s",
            "/s",
            "--size"
        };

    }
}
