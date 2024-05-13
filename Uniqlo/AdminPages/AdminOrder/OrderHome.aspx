﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="OrderHome.aspx.cs" Inherits="Uniqlo.AdminPages.AdminOrder.OrderHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <link href="../../css/Admin/adminOrder.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Lato&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@20..48,100..700,0..1,-50..200" />

    <style>
        .dropdown-container {
            margin-left: -180px;
        }

        .price {
            flex-basis: 15%;
        }

        @media screen and (min-width: 992px) {
            .product-imgs {
                display: flex;
                flex-direction: column;
                justify-content: flex-start;
            }
        }

        .confirmationClearFix {
            width: 100%;
            margin-top: 90px;
        }

        /* Add a color to the cancel button */
        .confirmationCancelbtn, .confirmationDeletebtn {
            border: 2px solid black;
            padding: 20px 150px 20px 150px;
            background: none;
            outline: none;
            font-weight: bold;
            cursor: pointer;
            transition: all 0.5s ease;
            width: 100%;
            text-decoration: none;
            color: black;
            width: calc((100% / 2) - 20px);
        }

            .confirmationDeletebtn:hover,
            .confirmationCancelbtn:hover {
                background-color: black;
                color: white;
            }


        /* Add padding and center-align text to the container */
        .confirmationContainer {
            padding: 16px;
            text-align: center;
        }

        /* The Modal (background) */
        .confirmationModal {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 2; /* Sit on top */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
            padding-top: 50px;
            margin-top: 100px;
        }

        /* Modal Content/Box */
        .confirmation-modal-content {
            background-color: #fefefe;
            margin: 5% auto 15% auto; /* 5% from the top, 15% from the bottom and centered */
            border: 1px solid #888;
            width: 80%; /* Could be more or less, depending on screen size */
            height: 400px;
        }


            .confirmation-modal-content h1 {
                margin-top: 60px;
            }

            .confirmation-modal-content p {
                margin-top: 30px;
            }

        /* The Modal Close Button (x) */
        .confirmationClose {
            float: right;
            font-size: 40px;
            font-weight: bold;
            color: #f1f1f1;
        }

            .confirmationClose:hover,
            .confirmationClose:focus {
                color: black;
                cursor: pointer;
            }

        /* Clear floats */
        .confirmationClearFix::after {
            content: "";
            clear: both;
            display: table;
        }

        /* Change styles for cancel button and delete button on extra small screens */
        @media screen and (max-width: 300px) {
            .confirmationCancelbtn, .confirmationDeletebtn {
                width: 100%;
            }
        }
    </style>

    <div class="productBody">

        <asp:ScriptManager ID="ScriptManagerProduct" runat="server" />
        <asp:UpdatePanel ID="UpdatePanelProduct" runat="server">
            <ContentTemplate>
                <h2>UNIQLO ORDER MANAGEMENT</h2>

                <div class="crudProduct">
                    <div class="wrap-items-search-buttons">
                        <div class="search">
                            <span class="material-symbols-outlined">search</span>
                            <asp:TextBox ID="searchBox" runat="server" CssClass="search-input" AutoPostBack="true" OnTextChanged="searchBox_TextChanged"  placeholder="Search Customer Name"></asp:TextBox>
                        </div>

                        <div class="dropdown-wrapper" style="margin-left: -300px;">
                            <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" CssClass="dropdown-display">
                                <asp:ListItem Value="">Status</asp:ListItem>
                                <asp:ListItem Value="Paid">Paid</asp:ListItem>
                                <asp:ListItem Value="Unpaid">Unpaid</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="btnExcel-Add">
                            <asp:Button ID="excelExport" runat="server" Text="Export" CssClass="excel-export" OnClick="btnExport_Click"/>
                        </div>
                    </div>
                </div>




                <asp:Repeater ID="orderRepeater" runat="server" ViewStateMode="Disabled">

                    <HeaderTemplate>
                        <table class="table" style="width: 100%">
                            <!-- Header -->
                            <tr class="row">
                                <td class="col productid">Order ID</td>
                                <td class="col name">Customer Name</td>
                                <td class="col price">Total Item</td>
                                <td class="col gender">Total Amount</td>
                                <td class="col category">Date</td>
                                <td class="col wear">Status</td>
                                <td class="col eclipse-container">
                                    <asp:Button ID="Button1" runat="server" Text="Button" Visible="False" />
                                </td>
                            </tr>
                    </HeaderTemplate>

                    <ItemTemplate>
                        <tr class="row">
                            <td class="col productid"><%# Eval("OrderId") %></td>
                            <td class="col name"><%# Eval("CustomerName") %></td>
                            <td class="col price"><%# Eval("OrderListTotalItems") %></td>
                            <td class="col gender"><%# Eval("PaymentTotalAmount") %></td>
                            <td class="col category"><%# Eval("PaymentDate", "{0:dd/MM/yyyy}") %></td>
                            <td class="col wear"><%# Eval("PaymentStatus") %></td>
                            <td class="col eclipse-container" onclick="toggleDropdown('dropdownList<%# Eval("OrderId") %>', 'dropdownDisplay<%# Eval("OrderId") %>')">
                                <div class="eclipse-display" id="dropdownDisplay<%# Eval("OrderId") %>" style="border: none;"><i class="fa fa-ellipsis-v" aria-hidden="true"></i></div>
                                <div class="eclipse-list" id="dropdownList<%# Eval("OrderId") %>">
                                    <div>
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "OrderItem.aspx?OrderID=" + Eval("OrderId") %>' Text="View More" Style="text-decoration: none; color: #6F6F6F"></asp:HyperLink>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>

                </asp:Repeater>

            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlStatus" EventName="SelectedIndexChanged" />
                <asp:PostBackTrigger ControlID="excelExport" />
            </Triggers>


        </asp:UpdatePanel>

        <div style="margin-bottom: 80px;">
        </div>
    </div>

    <footer>
        <script src="../../Javascript/productBtnEclipse.js"></script>
        <script src="../../Javascript/productAdminDDL.js"></script>
        <script>
            document.getElementById('<%= searchBox.ClientID %>').onkeyup = function () {
                     __doPostBack('<%= searchBox.ClientID %>', '');
            };
        </script>
    </footer>
</asp:Content>
