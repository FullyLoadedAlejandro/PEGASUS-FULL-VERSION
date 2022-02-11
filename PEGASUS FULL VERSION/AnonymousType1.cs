using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000003 RID: 3
[global::System.Runtime.CompilerServices.CompilerGenerated]
internal sealed class <>f__AnonymousType1<<content>j__TPar>
{
	// Token: 0x17000003 RID: 3
	// (get) Token: 0x06000008 RID: 8 RVA: 0x0000211E File Offset: 0x0000031E
	public <content>j__TPar content
	{
		get
		{
			return this.<content>i__Field;
		}
	}

	// Token: 0x06000009 RID: 9 RVA: 0x00002126 File Offset: 0x00000326
	[global::System.Diagnostics.DebuggerHidden]
	public <>f__AnonymousType1(<content>j__TPar content)
	{
		this.<content>i__Field = content;
	}

	// Token: 0x0600000A RID: 10 RVA: 0x000094B8 File Offset: 0x000076B8
	[global::System.Diagnostics.DebuggerHidden]
	public override bool Equals(object value)
	{
		var <>f__AnonymousType = value as global::<>f__AnonymousType1<<content>j__TPar>;
		return this == <>f__AnonymousType || (<>f__AnonymousType != null && global::System.Collections.Generic.EqualityComparer<<content>j__TPar>.Default.Equals(this.<content>i__Field, <>f__AnonymousType.<content>i__Field));
	}

	// Token: 0x0600000B RID: 11 RVA: 0x00002135 File Offset: 0x00000335
	[global::System.Diagnostics.DebuggerHidden]
	public override int GetHashCode()
	{
		return 585356709 * -1521134295 + global::System.Collections.Generic.EqualityComparer<<content>j__TPar>.Default.GetHashCode(this.<content>i__Field);
	}

	// Token: 0x0600000C RID: 12 RVA: 0x000094F0 File Offset: 0x000076F0
	[global::System.Diagnostics.DebuggerHidden]
	public override string ToString()
	{
		global::System.IFormatProvider provider = null;
		string format = "{{ content = {0} }}";
		object[] array = new object[1];
		int num = 0;
		<content>j__TPar <content>j__TPar = this.<content>i__Field;
		array[num] = ((<content>j__TPar != null) ? <content>j__TPar.ToString() : null);
		return string.Format(provider, format, array);
	}

	// Token: 0x04000003 RID: 3
	[global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
	private readonly <content>j__TPar <content>i__Field;
}
