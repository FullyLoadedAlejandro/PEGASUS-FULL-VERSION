using System;
using System.Runtime.CompilerServices;

// Token: 0x02000006 RID: 6
public class LoyalListViewColumnHeader
{
    // Token: 0x0600001C RID: 28 RVA: 0x00002255 File Offset: 0x00000455
    public LoyalListViewColumnHeader()
    {
    }

    // Token: 0x0600001D RID: 29 RVA: 0x00002265 File Offset: 0x00000465
    public LoyalListViewColumnHeader(string text)
    {
        this.Text = text;
    }

    // Token: 0x0600001E RID: 30 RVA: 0x0000227C File Offset: 0x0000047C
    public LoyalListViewColumnHeader(string text, int width)
    {
        this.Text = text;
        this._width = width;
    }

    // Token: 0x17000007 RID: 7
    // (get) Token: 0x0600001F RID: 31 RVA: 0x0000229A File Offset: 0x0000049A
    // (set) Token: 0x06000020 RID: 32 RVA: 0x000022A2 File Offset: 0x000004A2
    public string Text
    {
        [global::System.Runtime.CompilerServices.CompilerGenerated]
        get
        {
            return this.Text;
        }
        [global::System.Runtime.CompilerServices.CompilerGenerated]
        set
        {
            this.Text = value;
        }
    }

    // Token: 0x17000008 RID: 8
    // (get) Token: 0x06000021 RID: 33 RVA: 0x000022AB File Offset: 0x000004AB
    // (set) Token: 0x06000022 RID: 34 RVA: 0x000022B3 File Offset: 0x000004B3
    public int Width
    {
        get
        {
            return this._width;
        }
        set
        {
            this._width = value;
        }
    }

    // Token: 0x06000023 RID: 35 RVA: 0x000022BC File Offset: 0x000004BC
    public override string ToString()
    {
        return this.Text;
    }

    // Token: 0x04000008 RID: 8
    [global::System.Runtime.CompilerServices.CompilerGenerated]
    private string Text__BackingField;

    // Token: 0x04000009 RID: 9
    private int _width = 60;
}