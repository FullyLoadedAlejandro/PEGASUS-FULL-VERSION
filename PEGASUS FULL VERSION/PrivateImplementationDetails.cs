using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Token: 0x020001FE RID: 510
[global::System.Runtime.CompilerServices.CompilerGenerated]
internal sealed class PrivateImplementationDetails
{
    // Token: 0x06000E41 RID: 3649 RVA: 0x0008F900 File Offset: 0x0008DB00
    internal static uint ComputeStringHash(string s)
    {
        uint num = 0;
        if (s != null)
        {
            num = 2166136261U;
            for (int i = 0; i < s.Length; i++)
            {
                num = ((uint)s[i] ^ num) * 16777619U;
            }
        }
        return num;
    }
}