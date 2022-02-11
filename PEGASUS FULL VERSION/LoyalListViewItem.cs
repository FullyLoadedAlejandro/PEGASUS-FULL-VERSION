using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

// Token: 0x02000004 RID: 4
public class LoyalListViewItem
{
    // Token: 0x17000004 RID: 4
    // (get) Token: 0x0600000D RID: 13 RVA: 0x00002153 File Offset: 0x00000353
    // (set) Token: 0x0600000E RID: 14 RVA: 0x0000215B File Offset: 0x0000035B
    [global::System.ComponentModel.DesignerSerializationVisibility(global::System.ComponentModel.DesignerSerializationVisibility.Content)]
    public global::System.Collections.Generic.List<global::LoyalListViewSubItem> SubItems
    {
        get
        {
            return this._subItems;
        }
        set
        {
            this._subItems = value;
        }
    }

    // Token: 0x0600000F RID: 15 RVA: 0x00002164 File Offset: 0x00000364
    public LoyalListViewItem()
    {
        this.uniqueId = global::System.Guid.NewGuid();
    }

    // Token: 0x06000010 RID: 16 RVA: 0x00002182 File Offset: 0x00000382
    public LoyalListViewItem(string text)
    {
        this.uniqueId = global::System.Guid.NewGuid();
        this.Text = text;
    }

    // Token: 0x06000011 RID: 17 RVA: 0x000021A7 File Offset: 0x000003A7
    public LoyalListViewItem(string text, global::System.Collections.Generic.List<global::LoyalListViewSubItem> subitems)
    {
        this.uniqueId = global::System.Guid.NewGuid();
        this.Text = text;
        this.SubItems = subitems;
    }

    // Token: 0x06000012 RID: 18 RVA: 0x000021D3 File Offset: 0x000003D3
    public override bool Equals(object obj)
    {
        return obj.GetType() == typeof(global::LoyalListViewItem) && ((global::LoyalListViewItem)obj).uniqueId == this.uniqueId;
    }

    // Token: 0x06000013 RID: 19 RVA: 0x00002204 File Offset: 0x00000404
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    // Token: 0x17000005 RID: 5
    // (get) Token: 0x06000014 RID: 20 RVA: 0x0000220C File Offset: 0x0000040C
    // (set) Token: 0x06000015 RID: 21 RVA: 0x00002214 File Offset: 0x00000414
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

    // Token: 0x06000016 RID: 22 RVA: 0x0000221D File Offset: 0x0000041D
    public override string ToString()
    {
        return this.Text;
    }

    // Token: 0x04000004 RID: 4
    private global::System.Collections.Generic.List<global::LoyalListViewSubItem> _subItems = new global::System.Collections.Generic.List<global::LoyalListViewSubItem>();

    // Token: 0x04000005 RID: 5
    protected global::System.Guid uniqueId;

    // Token: 0x04000006 RID: 6
    [global::System.Runtime.CompilerServices.CompilerGenerated]
    private string Textk__BackingField;
}