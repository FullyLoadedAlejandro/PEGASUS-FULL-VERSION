using System;
using System.Net.Mime;
using System.Runtime.CompilerServices;

// Token: 0x02000005 RID: 5
public class LoyalListViewSubItem
{
    // Token: 0x17000006 RID: 6
    // (get) Token: 0x06000017 RID: 23 RVA: 0x00002225 File Offset: 0x00000425
    // (set) Token: 0x06000018 RID: 24 RVA: 0x0000222D File Offset: 0x0000042D
    public string Text
    {
        [global::System.Runtime.CompilerServices.CompilerGenerated]
        get
        {
            return this.ToString();
        }
        [global::System.Runtime.CompilerServices.CompilerGenerated]
        set
        {
            this.Text = value;
        }
    }

    // Token: 0x06000019 RID: 25 RVA: 0x00002236 File Offset: 0x00000436
    public override string ToString()
    {
        return this.Text;
    }

    // Token: 0x0600001A RID: 26 RVA: 0x0000223E File Offset: 0x0000043E
    public LoyalListViewSubItem()
    {
    }

    // Token: 0x0600001B RID: 27 RVA: 0x00002246 File Offset: 0x00000446
    public LoyalListViewSubItem(string text)
    {
        this.Text = text;
    }
}