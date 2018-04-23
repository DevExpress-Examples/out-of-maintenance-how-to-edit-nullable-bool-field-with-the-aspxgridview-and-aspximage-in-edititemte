Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Xpo
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView
Imports System.Runtime.CompilerServices

Partial Public Class _Default
    Inherits System.Web.UI.Page
    Private Shadows session As Session = XpoHelper.GetNewSession()

    Private Shared CheckBoxSpriteStyles() As String = {"dxEditors_edtCheckBoxOn_img", "dxEditors_edtCheckBoxOff_img", "dxEditors_edtCheckBoxUndefined_img"}

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
        xds.Session = session
    End Sub

    Protected Sub img_Init(ByVal sender As Object, ByVal e As EventArgs)
        Dim img As ASPxImage = TryCast(sender, ASPxImage)
        Dim container As GridViewEditItemTemplateContainer = TryCast(img.NamingContainer, GridViewEditItemTemplateContainer)

        Dim value As Object = DataBinder.Eval(container.DataItem, container.Column.FieldName)

        Dim b As Nullable(Of Boolean) = Nothing

        If value IsNot Nothing Then
            b = Convert.ToBoolean(value)
        End If

        img.JSProperties("cpIndex") = b.ToInt32()
        img.CssClass = CheckBoxSpriteStyles(b.ToInt32())

        img.ImageUrl = DevExpress.Web.ASPxClasses.EmptyImageProperties.GetGlobalEmptyImage(Page).Url
    End Sub

    Protected Sub grid_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        Dim i As Int32 = Convert.ToInt32(hf("img"))
        e.NewValues("Active") = i.ToNullableBoolean()
    End Sub

    Protected Sub grid_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
        Dim i As Int32 = Convert.ToInt32(hf("img"))
        e.NewValues("Active") = i.ToNullableBoolean()
    End Sub
End Class

<Extension()> _
Module ExtensionMethods
    <Extension()> _
    Public Function ToNullableBoolean(ByVal i As Int32) As Nullable(Of Boolean)
        If i = 0 Then
            Return True
        ElseIf i = 1 Then
            Return False
        Else
            Return Nothing
        End If
    End Function

    <System.Runtime.CompilerServices.Extension()> _
    Public Function ToInt32(ByVal b As Nullable(Of Boolean)) As Int32
        If (Not b.HasValue) Then
            Return 2
        ElseIf b.Value = True Then
            Return 0
        ElseIf b.Value = False Then
            Return 1
        End If

        Return 2
    End Function
End Module
