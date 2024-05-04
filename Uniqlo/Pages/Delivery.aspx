﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Uniqlo.Master" AutoEventWireup="true" CodeBehind="Delivery.aspx.cs" Inherits="Uniqlo.Pages.Delivery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <header>
        <link href="../css/delivery.css" rel="stylesheet" />
        <link href="../css/style.css" rel="stylesheet" />
        <link href="../css/style1.css" rel="stylesheet" />
    </header>

    <div class="body">
        <div class="container-fluid pt-5">
        <section class="step-wizard">
            <ul class="step-wizard-list">
                <li class="step-wizard-item current-item">
                    <span class="progress-count">1</span>
                    <span class="progress-label">Customer Information</span>
                </li>
                <li class="step-wizard-item">
                    <span class="progress-count">2</span>
                    <span class="progress-label">Payment Method</span>
                </li>
                <li class="step-wizard-item">
                    <span class="progress-count">3</span>
                    <span class="progress-label">Confirmation</span>
                </li>
                <li class="step-wizard-item">
                    <span class="progress-count">4</span>
                    <span class="progress-label">Invoice</span>
                </li>
            </ul>
        </section>
        <div class="row px-xl-5">
            <form class="d-flex">
                <div class="col-lg-8">
                    <div class="mb-4">
                        <br /><br />

                        <h4 class="font-weight-semi-bold mb-4">Delivery Address<i class="fas fa-map-marker-alt" onclick="openGoogleMaps()" data-bs-toggle="tooltip" title="Click to auto-detect your current location"></i></h4>
                        <div class="row">

                            <div class="col-md-6 form-group">
                                <label>Name</label>
                                <asp:TextBox class="form-control" ID="name" value="Tan Choo Jun" ReadOnly="true" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-6 form-group">
                                <label>E-mail</label>
                                <asp:TextBox class="form-control" ID="gmail" value="cjtan@gmail.com" ReadOnly="true" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-6 form-group">
                                <label>Contact No</label>
                                <asp:TextBox class="form-control" ID="contact" value="0148169029" ReadOnly="true" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-6 form-group">
                                <label>Country</label>
                                <input class="form-control" name="country" type="text" value="Malaysia" required>
                            </div>
                            <div class="col-md-6 form-group">
                                <label>Address Line</label>
                                <input class="form-control" name="address" type="text" placeholder="123 Street" value="1, Jalan Lembah Permai" required>
                            </div>
                            <div class="col-md-6 form-group">
                                <label>Post Code</label>
                                <input class="form-control" name="postcode" type="text" placeholder="11500" pattern="[0-9]{5}" oninput="this.value=this.value.replace(/[^0-9]/g,'');" maxlength="5" value="11900" required>
                            </div>
                            <div class="col-md-6 form-group">
                                <label>State</label>
                                <input class="form-control" name="state" type="text" placeholder="George Town" value="Penang" required>
                            </div>
                            <div class="col-md-6 form-group">
                                <label>City</label>
                                <input class="form-control" name="city" type="text" placeholder="Penang" value="Tanjung Bungah" required>
                            </div>


                            <div class="col-md-12 form-group">
    <label>
        <br />
        Delivery Instruction (If Any)</label>
    <input class="form-control" name="city" type="text" placeholder="" required>
</div>
                        </div>

                    </div>

                </div>
                <div class="col-lg-4">
                    <br /><br />
                    <div class="card border-secondary mb-5">
                        <div class="card-header bg-secondary border-0">
                            <h4 class="font-weight-semi-bold m-0">Summary</h4>
                        </div>
                        <div class="card-body">
                            <h5 class="font-weight-medium mb-3">Products</h5>

                            

                            <div class="d-flex justify-content-between">
                                <p>AIRism Cotton Short Sleeve T-Shirt, White, M x 1</p>
                                <p>RM 30.00</p>
                            </div>

                            <div class="d-flex justify-content-between">
    <p>Sweat Cargo Pants, Pink, M x 1</p>
    <p>RM 79.90</p>
</div>
                          

                            <hr class="mt-0">
                            <div class="d-flex justify-content-between mb-3 pt-1">
                                <h6 class="font-weight-medium">Total Price</h6>
                                <h6 class="font-weight-medium">  RM 109.90</h6>
                            </div>
                            <div class="d-flex justify-content-between">
                                <h6 class="font-weight-medium">Delivery Charges</h6>
                                <h6 class="font-weight-medium">  RM 15</h6>
                            </div>
                                                        
                        </div>
                        <div class="card-footer border-secondary bg-transparent">
                            <div class="d-flex justify-content-between mt-2">
                                <h5 class="font-weight-bold">Total</h5>
                                <h5 class="font-weight-bold">RM 124.90</h5>
                            </div>
                        </div>
                    </div>

                        <!--VIEWMORE BUTTON-->
                        <div class="viewMoreSection">
                            <a href="Payment.aspx" class="viewMoreButton">Next</a>
                        </div>

                </div>
            </form>          
        </div>
    </div>
        </div>

</asp:Content>
