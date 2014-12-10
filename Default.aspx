<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="Infragistics4.Web.v14.2, Version=14.2.20142.1028, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>testing</title>
    <script type="text/javascript" id="igClientScript">
<!--
     
        function addChildRow() {
            var grid = $find("WebHierarchicalDataGrid1");
            var childBand = grid.get_gridView().get_rows().get_row(grid.get_gridView().get_rows().get_length() - 1).get_rowIslands()[0];
            var childRow = new Array("", "text", "12");
            childBand.get_rows().add(childRow);
        }
        function ajaxResponse(sender, e) {
            var grid = $find("WebHierarchicalDataGrid1");
            if (sender.get_id() == grid.get_gridView().get_id()) {    
                setTimeout("addChildRow();", 200);
            }
                    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <ig:WebHierarchicalDataGrid ID="WebHierarchicalDataGrid1" runat="server" Height="350px"
            Width="400px" DataKeyFields="ID" AutoGenerateColumns="False"  EnableAjax="true"
            AutoGenerateBands="False" InitialDataBindDepth="-1" InitialExpandDepth="-1" 
            onrowadding="WebHierarchicalDataGrid1_RowAdding">
            <ClientEvents  AJAXResponse="ajaxResponse"/>
            <Columns>
                <ig:BoundDataField DataFieldName="ID" Key="ID">
                    <Header Text="ID" />
                </ig:BoundDataField>
                <ig:BoundDataField DataFieldName="Name" Key="Name">
                    <Header Text="Name" />
                </ig:BoundDataField>
                <ig:BoundDataField DataFieldName="Sum" Key="Sum">
                    <Header Text="Sum" />
                </ig:BoundDataField>
            </Columns>
            <Bands>
                <ig:Band DataMember="Child" AutoGenerateColumns="false">
                    <Columns>
                        <ig:BoundDataField DataFieldName="ID" Key="ID">
                            <Header Text="ID" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="Address" Key="Address">
                            <Header Text="Address" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="Count" Key="Count">
                            <Header Text="Count" />
                        </ig:BoundDataField>
                    </Columns>
                </ig:Band>
            </Bands>
            <Behaviors>
                <ig:EditingCore EnableInheritance="true" AutoCRUD="false" >
                    <Behaviors>
                        <ig:RowAdding EnableInheritance="true">
                        </ig:RowAdding>
                    </Behaviors>
                </ig:EditingCore>
            </Behaviors>
        </ig:WebHierarchicalDataGrid>       
    </div>
    </form>
</body>
</html>
