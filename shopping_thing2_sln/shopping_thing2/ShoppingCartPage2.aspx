<%@ Page Title="Shopping Cart" Language="C#" MasterPageFile="~/ShoppingMaster.Master" AutoEventWireup="true" CodeBehind="ShoppingCartPage2.aspx.cs" Inherits="shopping_thing2.ShoppingCartPage2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style35 {
            height: 95px;
            text-align: left;
            background-color: #E6E6FF;
            width: 692px;
        }
        .auto-style36 {
            color: #000000;
            width: 692px;
        }
        .auto-style37 {
            height: 48px;
            width: 692px;
        }
        .auto-style38 {
            height: 26px;
            width: 692px;
        }
        .auto-style39 {
            color: #000000;
            height: 1033px;
            width: 692px;
        }
        .auto-style40 {
            color: #000000;
            width: 692px;
            height: 23px;
        }
        .auto-style41 {
            color: #000000;
            width: 692px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder1">
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style2">
                            <asp:ImageButton ID="imgBtn_logo" runat="server" Height="113px" ImageUrl="~/userDefinedImages/CompanyLogo2.png" Width="164px" OnClick="imgBtn_logo_Click" />
                        </td>
                        <td class="auto-style10">
                            <h4>
                            <asp:TextBox ID="txt_search" runat="server" Width="871px" Height="33px"></asp:TextBox>
                            <br class="auto-style24" />
                            <span class="auto-style24">Filter By Sport:&nbsp; </span>
                            <asp:DropDownList ID="ddl_sport" runat="server">
                                <asp:ListItem>No Selection</asp:ListItem>
                                <asp:ListItem Value="B">Baseball</asp:ListItem>
                                <asp:ListItem Value="F">Football</asp:ListItem>
                                <asp:ListItem Value="H">Hockey</asp:ListItem>
                                <asp:ListItem Value="L">Lacrosse</asp:ListItem>
                            </asp:DropDownList>
                                <span class="auto-style24">&nbsp;Sort by Price:&nbsp; </span> <asp:DropDownList ID="ddl_price" runat="server">
                                    <asp:ListItem Value="0">No Selection</asp:ListItem>
                                    <asp:ListItem Value="L2H">Low to High</asp:ListItem>
                                    <asp:ListItem Value="H2L">High to Low</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<asp:ImageButton ID="imgBtn_search" runat="server" ImageUrl="~/Pictures/searchImage.png" Width="30px" OnClick="imgBtn_search_Click" />
                            </h4>
                        </td>
                        <td class="auto-style35">
                            <span class="auto-style24">&nbsp;&nbsp;&nbsp;
                            </span>
                            <asp:ImageButton ID="img_shoppingCart" runat="server" Height="46px" ImageUrl="~/userDefinedImages/shoppingCartBlue.jpg" Width="55px" CssClass="auto-style24" OnClick="img_shoppingCart_Click" />
                        &nbsp;<br class="auto-style24" />
                            <span class="auto-style24">&nbsp;&nbsp; </span></td>
                    </tr>
                    <tr>
                        <td valign="top" class="auto-style4" rowspan="13"="top" >
                            <h3><span class="newStyle2">
                            
                            <span class="auto-style24">Home</span><br class="auto-style24" />
                            <br class="auto-style24" />
                            <span class="auto-style24">About</span><br class="auto-style24" />
                            <br class="auto-style24" />
                            <span class="auto-style24">Press</span><br class="auto-style24" />
                            <br class="auto-style24" />
                            <span class="auto-style24">Careers</span><br class="auto-style24" />
                            <br class="auto-style24" />
                            <span class="auto-style24">Contacts</span></span></h3>
                            <span class="auto-style24">&nbsp;</span></td>

                        <td class="auto-style11" rowspan="9">
                            <table class="auto-style1">
                                <tr>
                                    <td class="auto-style34">
                                        <asp:Panel ID="panel_test" runat="server" Height="169px" Width="285px">
                                        </asp:Panel>
                                    
                                    
                                        <h3>
                                            <asp:Label ID="checkoutLbl" runat="server" Font-Names="Arial" Font-Size="Small" Text="Label" Visible="False"></asp:Label>
                                        </h3>
                                    
                                    
                                    </td>
                                    <td class="auto-style34">
                                    
                                    
                                        <asp:Panel ID="panel_label" runat="server" Height="169px" Width="495px">
                                        </asp:Panel>
                                   
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="auto-style36">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style36">
                            <h4>Subtotal: 
                                <asp:Label ID="lbl_sTotal" runat="server" Text="lbl_sTotal"></asp:Label>
                                &nbsp;</h4>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style36">
                            <h4>Tax:
                                <asp:Label ID="lbl_tax" runat="server" Text="lbl_tax"></asp:Label>
                            </h4>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style37">
                            <h4>Total:
                                <asp:Label ID="lbl_total" runat="server" Text="lbl_total"></asp:Label>
                            </h4>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style40"></td>
                    </tr>
                    <tr>
                        <td class="auto-style38">
                            <asp:Button ID="btn_checkout" runat="server" BackColor="#99FF99" Height="40px" OnClick="btn_checkout_Click" Text="Checkout" Width="150px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style36">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style36">
                            <asp:Button ID="btn_cancel" runat="server" BackColor="#FF3E3E" Height="40px" OnClick="btn_cancel_Click" Text="Cancel Purchase" Width="150px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style41">
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style11">&nbsp;</td>
                        <td class="auto-style36">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style11">&nbsp;</td>
                        <td class="auto-style36">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style19">
                            &nbsp;</td>
                        <td class="auto-style36">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style25">
                        </td>
                        <td class="auto-style39"></td>
                    </tr>
                    </table>
            </asp:Content>

