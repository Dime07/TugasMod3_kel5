<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hobi.aspx.cs" Inherits="TugasModul3.Hobi" EnableEventValidation = "false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:LinkButton  ID="btnMahasiswa" runat="server" PostBackUrl="Mahasiswa.aspx"><span style="margin-right: 30px;">Mahasiswa</span></asp:LinkButton>
            <asp:LinkButton ID="btnHobi" runat="server" PostBackUrl="Hobi.aspx"><span style="margin-right: 30px;">Hobi</span></asp:LinkButton>
            <asp:LinkButton ID="btnOrtu" runat="server" PostBackUrl="OrangTua.aspx"><span style="margin-right: 30px;">Orang Tua</span></asp:LinkButton>
            <asp:LinkButton ID="btnrecycle" runat="server" PostBackUrl="Recycle.aspx">Recycyle Bin</asp:LinkButton>
            <table>
                <tr>
                <td class="auto-style1">ID :</td>
                <td class="auto-style1"><asp:TextBox ID="txtIdHobi" runat="server"></asp:TextBox> </td>
                </tr>
                <tr>
                <td>Nama Hobi :</td>
                <td><asp:TextBox ID="txtHobi" runat="server"></asp:TextBox> </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    <asp:Button ID="btnAdd" runat="server" Text="ADD" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnDelete" runat="server" Text="DELETE" OnClick="btnDelete_Click" />
                    <asp:Button ID="btnUpdate" runat="server" Text="UPDATE" OnClick="btnUpdate_Click" style="height: 26px" />
                    <asp:Button ID="btnClear" runat="server" Text="CLEAR" OnClick="btnClear_Click" style="height: 26px" />

                    </td>
                </tr>
            </table>
        </div>
        <asp:GridView ID="GridViewJoin" runat="server" DataKeyNames="id_hobi, nama_hobi" OnRowDataBound="GridViewJoin_RowDataBound" OnSelectedIndexChanged="GridViewJoin_SelectedIndexChanged">
        </asp:GridView>
        </div>
    </form>
</body>
</html>
