<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recycle.aspx.cs" Inherits="TugasModul3.Recycle" EnableEventValidation = "false"%>

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

            <h3>Recycle</h3>
            <asp:GridView ID="gvRecycle" runat="server" DataKeyNames="nim,nama_mhs,id_hobi,id_ortu" OnRowDataBound="gvRecycle_RowDataBound" OnSelectedIndexChanged="gvRecycle_SelectedIndexChanged" >
            </asp:GridView>

        </div>
    </form>
</body>
</html>
