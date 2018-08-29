<%@ Page Title="Product Details" Language="C#" MasterPageFile="~/ShoppingMaster.Master" AutoEventWireup="true" CodeBehind="ProductDetailsPage.aspx.cs" Inherits="shopping_thing2.ProductDetailsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder1">
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style2">
                            <asp:ImageButton ID="imgBtn_logo" runat="server" Height="113px" ImageUrl="~/userDefinedImages/CompanyLogo2.png" OnClick="imgBtn_logo_Click" Width="164px" />
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
                        <td class="auto-style9">
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
                                    
                                    
                                    </td>
                                    <td class="auto-style34">
                                    
                                    
                                        <asp:Panel ID="panel_label" runat="server" Height="169px" Width="495px">
                                        </asp:Panel>
                                   
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="auto-style27">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style27">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style27">
                                        <asp:Button ID="addBtn" runat="server" OnClick="addBtn_Click" Text="Add to Cart" BackColor="#99FF99" />
                                    
                                    
                                    </td>
                    </tr>
                    <tr>
                        <td class="auto-style17">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style27">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style13">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style27">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style27">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style27">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style11">&nbsp;</td>
                        <td class="auto-style27">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style11">&nbsp;</td>
                        <td class="auto-style27">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style19">
                            &nbsp;</td>
                        <td class="auto-style27">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style25">
                        </td>
                        <td class="auto-style26"></td>
                    </tr>
                    </table>
            </asp:Content>

