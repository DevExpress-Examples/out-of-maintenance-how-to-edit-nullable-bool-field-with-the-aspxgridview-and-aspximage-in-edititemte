<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxHiddenField" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Xpo.v10.1.Web, Version=10.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Xpo" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Xpo.v10.1, Version=10.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Xpo" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How to edit Nullable&lt;Boolean&gt;
        field with the ASPxGridView and the ASPxImage in the EditItemTemplate</title>
    <link href="sprite.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        var CheckBoxSpriteStyles = ["dxEditors_edtCheckBoxOn_img",
                                    "dxEditors_edtCheckBoxOff_img",
                                    "dxEditors_edtCheckBoxUndefined_img"];

        function OnClick(s, e) {
            var index = s.cpIndex;
            index++;

            if (index >= CheckBoxSpriteStyles.length)
                index = 0;

            s.cpIndex = index;

            s.GetMainElement().className = CheckBoxSpriteStyles[s.cpIndex];

            hf.Set("img", s.cpIndex);
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dx:ASPxHiddenField ID="hf" ClientInstanceName="hf" runat="server">
        </dx:ASPxHiddenField>
        <dx:ASPxGridView ID="grid" runat="server" DataSourceID="xds" AutoGenerateColumns="False"
            ClientInstanceName="grid" KeyFieldName="Oid" OnRowUpdating="grid_RowUpdating"
            OnRowInserting="grid_RowInserting">
            <Columns>
                <dx:GridViewCommandColumn VisibleIndex="0">
                    <EditButton Visible="True">
                    </EditButton>
                    <NewButton Visible="True">
                    </NewButton>
                    <DeleteButton Visible="True">
                    </DeleteButton>
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn FieldName="Oid" ReadOnly="True" VisibleIndex="1" SortOrder="Ascending"
                    SortIndex="0">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Title" VisibleIndex="2">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataCheckColumn FieldName="Active" VisibleIndex="3">
                    <EditItemTemplate>
                        <dx:ASPxImage ID="img" runat="server" OnInit="img_Init">
                            <ClientSideEvents Click="OnClick" Init="function (s, e) { hf.Set('img', s.cpIndex); }" />
                        </dx:ASPxImage>
                    </EditItemTemplate>
                </dx:GridViewDataCheckColumn>
            </Columns>
        </dx:ASPxGridView>
        <dx:XpoDataSource ID="xds" runat="server" TypeName="MyObject">
        </dx:XpoDataSource>
    </div>
    </form>
</body>
</html>
