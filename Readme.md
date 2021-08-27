<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128539767/11.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2318)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# How to edit Nullable<bool> field with the ASPxGridView and ASPxImage in EditItemTemplate
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e2318/)**
<!-- run online end -->


<p><strong>Starting with version 2011.1:<br></strong>I recommend that you use ASPxCheckBox instead of the demonstrated solution since the control supports the <em>Undefined</em> (<em>Grayed</em>) checked state, see <a href="http://community.devexpress.com/blogs/aspnet/archive/2011/04/26/asp-net-check-box-new-render-state-for-multiple-controls-coming-soon-in-2011-volume-1.aspx">ASP.NET Check Box - New Render State For Multiple Controls</a> for details.</p>
<p><br><strong>Prior version 2011.1:</strong><br>The example demonstrates how to edit the Boolean field that allows writing "null" values (Nullable<Boolean>, Boolean?).<br> As the standard checkbox doesn't allow having three states (checked, unchecked and gray), the scenario can be implemented with the ASPxImage and three images. The images are taken from the default CSS sprite used by the ASPxEditors suite.</p>

<br/>


