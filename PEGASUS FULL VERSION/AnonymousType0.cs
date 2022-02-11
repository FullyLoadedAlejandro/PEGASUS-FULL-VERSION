using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000002 RID: 2
/// <summary>
/// Defines the <see cref="{}" />.
/// </summary>
/// <typeparam name="">.</typeparam>
[global::System.Runtime.CompilerServices.CompilerGenerated]
internal sealed class <>


f__AnonymousType0 << msgtype > j__TPar, < text > j__TPar >
{
    // Token: 0x17000001 RID: 1
    // (get) Token: 0x06000002 RID: 2 RVA: 0x000020C3 File Offset: 0x000002C3
    public <msgtype>j__TPar msgtype

    {
        get

        {
            return this.< msgtype > i__Field;
        }
    }

    // Token: 0x17000002 RID: 2
    // (get) Token: 0x06000003 RID: 3 RVA: 0x000020CB File Offset: 0x000002CB
    public <text>j__TPar text

    {
        get

        {
            return this.< text > i__Field;
        }
    }

    // Token: 0x06000004 RID: 4 RVA: 0x000020D3 File Offset: 0x000002D3
    [global::System.Diagnostics.DebuggerHidden]
    public <>f__AnonymousType0(< msgtype > j__TPar msgtype, < text > j__TPar text)
	{
        this.< msgtype > i__Field = msgtype;
        this.< text > i__Field = text;
    }

    // Token: 0x06000005 RID: 5 RVA: 0x000093F8 File Offset: 0x000075F8
    [global::System.Diagnostics.DebuggerHidden]
    public override bool Equals(object value)
    {
        var<> f__AnonymousType = value as global::<> f__AnonymousType0 << msgtype > j__TPar, < text > j__TPar >;
        return this == <> f__AnonymousType || (<> f__AnonymousType != null && global::System.Collections.Generic.EqualityComparer << msgtype > j__TPar >.Default.Equals(this.< msgtype > i__Field, <> f__AnonymousType.< msgtype > i__Field) && global::System.Collections.Generic.EqualityComparer << text > j__TPar >.Default.Equals(this.< text > i__Field, <> f__AnonymousType.< text > i__Field));
    }

    // Token: 0x06000006 RID: 6 RVA: 0x000020E9 File Offset: 0x000002E9
    [global::System.Diagnostics.DebuggerHidden]
    public override int GetHashCode()
    {
        return (-1509310118 * -1521134295 + global::System.Collections.Generic.EqualityComparer << msgtype > j__TPar >.Default.GetHashCode(this.< msgtype > i__Field)) * -1521134295 + global::System.Collections.Generic.EqualityComparer << text > j__TPar >.Default.GetHashCode(this.< text > i__Field);
    }

    // Token: 0x06000007 RID: 7 RVA: 0x00009448 File Offset: 0x00007648
    [global::System.Diagnostics.DebuggerHidden]
    public override string ToString()
    {
        global::System.IFormatProvider provider = null;
        string format = "{{ msgtype = {0}, text = {1} }}";
        object[] array = new object[2];
        int num = 0;

        < msgtype > j__TPar < msgtype > j__TPar = this.< msgtype > i__Field;
        array[num] = ((< msgtype > j__TPar != null) ? < msgtype > j__TPar.ToString() : null);
        int num2 = 1;

        < text > j__TPar < text > j__TPar = this.< text > i__Field;
        array[num2] = ((< text > j__TPar != null) ? < text > j__TPar.ToString() : null);
        return string.Format(provider, format, array);
    }

    // Token: 0x04000001 RID: 1
    [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
    private readonly <msgtype>j__TPar<msgtype> i__Field;

    // Token: 0x04000002 RID: 2
    [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
    private readonly <text>j__TPar<text> i__Field;
}