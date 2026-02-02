<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormDetail.master"
    AutoEventWireup="true"
    ValidateRequest="false"
    CodeFile="RS301000.aspx.cs"
    Inherits="Page_RS301000"
    Title="Equipment Maintenance" %>

<%@ MasterType VirtualPath="~/MasterPages/FormDetail.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" runat="Server">

    
    <px:PXDataSource 
        ID="ds" 
        runat="server"
        TypeName="RentalServiceSetA.RSEquipmentMaint"
        PrimaryView="Equipment">

        <CallbackCommands>
            <px:PXDSCallbackCommand Name="Save" CommitChanges="True" />
            <px:PXDSCallbackCommand Name="Insert" CommitChanges="True" />
            <px:PXDSCallbackCommand Name="Delete" CommitChanges="True" />
            <px:PXDSCallbackCommand Name="First" />
            <px:PXDSCallbackCommand Name="Previous" />
            <px:PXDSCallbackCommand Name="Next" />
            <px:PXDSCallbackCommand Name="Last" />
        </CallbackCommands>

    </px:PXDataSource>

    
    <px:PXFormView 
        ID="form" 
        runat="server"
        DataSourceID="ds"
        DataMember="Equipment"
        Width="100%"
        Caption="Equipment Information">

        <Template>
            <px:PXLayoutRule runat="server" StartColumn="True" />

           
            <px:PXTextEdit ID="edEquipmentCD" runat="server" DataField="EquipmentCD" />
            <px:PXTextEdit ID="edDescription" runat="server" DataField="Description" />
            <px:PXSelector ID="edCategoryID" runat="server" DataField="CategoryID" />
            <px:PXDropDown ID="edStatus" runat="server" DataField="Status" />

            <px:PXLayoutRule runat="server" StartRow="True" />

         
            <px:PXTab ID="tab" runat="server" Width="100%">

                <Items>
                    
                    <px:PXTabItem Text="General Info">
                        <Template>
                            <px:PXLayoutRule runat="server" StartColumn="True" />
                            <px:PXDateTimeEdit ID="edPurchaseDate" runat="server" DataField="PurchaseDate" />
                            <px:PXNumberEdit ID="edPurchaseCost" runat="server" DataField="PurchaseCost" />
                            <px:PXNumberEdit ID="edDaysOwned" runat="server" DataField="DaysOwned" Enabled="False" />
                        </Template>
                    </px:PXTabItem>

                   
                    <px:PXTabItem Text="Rental Rates">
                        <Template>
                            <px:PXLayoutRule runat="server" StartColumn="True" />
                            <px:PXNumberEdit ID="edDailyRate" runat="server" DataField="DailyRate" />
                            <px:PXNumberEdit ID="edWeeklyRate" runat="server" DataField="WeeklyRate" />
                            <px:PXNumberEdit ID="edMonthlyRate" runat="server" DataField="MonthlyRate" />
                        </Template>
                    </px:PXTabItem>
                </Items>

            </px:PXTab>

        </Template>
    </px:PXFormView>

    
    <px:PXGrid 
    ID="gridEquipment"
    runat="server"
    DataSourceID="ds"
    Width="100%"
    Height="300px"
    AllowPaging="True"
    AllowSearch="True">

    <Levels>
        <px:PXGridLevel DataMember="Equipment">
            <Columns>
                <px:PXGridColumn DataField="EquipmentCD" Width="120px" />
                <px:PXGridColumn DataField="Description" Width="200px" />
                <px:PXGridColumn DataField="CategoryID" Width="120px" />
                <px:PXGridColumn DataField="Status" Width="80px" />
            </Columns>
        </px:PXGridLevel>
    </Levels>

</px:PXGrid>


</asp:Content>
