using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileData
{
    internal static class InputValidatorExtension
    {
        //Does not check if the file exists on the system, but check if the string specified is a valid path to the file
        internal static string GetValidFilePath(this IEnumerable<string> args)
        {
            Uri pathUri;
            var cehckResult = args.Where(x => Uri.TryCreate(x, UriKind.Absolute, out pathUri) && pathUri != null);

            var resultLenght = cehckResult.Count();

            return (cehckResult != null && resultLenght != 0 && resultLenght == 1) ? cehckResult.FirstOrDefault() : null;
        }

        //Validate length of the supplied arguments
        internal static bool ValidateArgumentSize(this IEnumerable<string> args, int expectedMinArgumentLength, int expectedMaxArgumentLenght)
        {
            var argumentCount = args.Count();
            if (argumentCount >= expectedMinArgumentLength && argumentCount <= expectedMaxArgumentLenght)
            {
                return true;
            }
            return false;
        }

        internal static IEnumerable<string> GetValidArguments(this IEnumerable<string> args, IEnumerable<string> expectedPatterns)
        {
            return args.Where(x => string.Join(" ", expectedPatterns).IndexOf(x, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        internal static IEnumerable<string> GetInvalidArguments(this IEnumerable<string> args, IEnumerable<string> expectedPatterns)
        {
            return args.Where(x => string.Join(" ", expectedPatterns).IndexOf(x, StringComparison.OrdinalIgnoreCase) < 0);
        }
    }
}
