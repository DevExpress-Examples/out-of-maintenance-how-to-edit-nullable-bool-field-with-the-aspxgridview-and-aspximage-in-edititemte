using System;
using System.Web.UI;
using DevExpress.Xpo;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;

public partial class _Default : System.Web.UI.Page {
    Session session = XpoHelper.GetNewSession();

    static String[] CheckBoxSpriteStyles = new String[] {
                                        "dxEditors_edtCheckBoxOn_img",
                                        "dxEditors_edtCheckBoxOff_img",
                                        "dxEditors_edtCheckBoxUndefined_img"
                                    };
    protected void Page_Init(object sender, EventArgs e) {
        xds.Session = session;
    }
    protected void img_Init(object sender, EventArgs e) {
        ASPxImage img = sender as ASPxImage;
        GridViewEditItemTemplateContainer container = img.NamingContainer as GridViewEditItemTemplateContainer;

        Object value = DataBinder.Eval(container.DataItem, container.Column.FieldName);

        Boolean? b = null;

        if (value != null)
            b = Convert.ToBoolean(value);

        img.JSProperties["cpIndex"] = b.ToInt32();
        img.CssClass = CheckBoxSpriteStyles[b.ToInt32()];

        img.ImageUrl = DevExpress.Web.ASPxClasses.EmptyImageProperties.GetGlobalEmptyImage(Page).Url;
    }
    protected void grid_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e) {
        Int32 i = Convert.ToInt32(hf["img"]);
        e.NewValues["Active"] = i.ToNullableBoolean();
    }
    protected void grid_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e) {
        Int32 i = Convert.ToInt32(hf["img"]);
        e.NewValues["Active"] = i.ToNullableBoolean();
    }
}

public static class NullableBooleanExtensions {
    public static Boolean? ToNullableBoolean(this Int32 i) {
        if (i == 0)
            return true;
        else if (i == 1)
            return false;
        else
            return null;
    }
    public static Int32 ToInt32(this Boolean? b) {
        if (!b.HasValue)
            return 2;
        else if (b.Value == true)
            return 0;
        else if (b.Value == false)
            return 1;

        return 2;
    }
}