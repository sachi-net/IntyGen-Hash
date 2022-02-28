using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class HashTypes
{
    internal enum HashType
    {
        MD5 = 1,
        SHA1 = 2,
        SHA256 = 3
    }

    internal static IEnumerable<HashType> Load()
    {
        var types = Enum.GetValues(typeof(HashType)).Cast<HashType>();
        return types;
    }
}