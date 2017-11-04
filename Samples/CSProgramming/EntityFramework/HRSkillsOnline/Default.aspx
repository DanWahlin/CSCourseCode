<!-- Copyright (c) Microsoft Corporation.  All rights reserved. -->
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HRSkillsOnline._Default" %>

<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
    Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>HR Skills Online</title>
</head>
<body>
    <form id="form1" runat="server">
    Enter a skill search term and press Enter.<br />
    (Search is case-sensitive.)<br />
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Skill search: "></asp:Label>
    <asp:TextBox ID="skillsTextBox" runat="server" MaxLength="50" Width="271px" AutoPostBack="True"
        OnTextChanged="skillsTextBox_TextChanged"></asp:TextBox>
        <hr />
    <asp:GridView ID="employeeGridView" runat="server" BackColor="LightGoldenrodYellow"
        BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" 
        OnSelectedIndexChanged="employeeGridView_SelectedIndexChanged"
        Caption="Employees:" CaptionAlign="Top" CellSpacing="1"
        AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" 
        DataSourceID="EmployeeDataSource" DataKeyNames="EmployeeId">
        <FooterStyle BackColor="Tan" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="EmployeeId" HeaderText="EmployeeId" ReadOnly="True" 
                SortExpression="EmployeeId" Visible="False" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" 
                SortExpression="LastName" />
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" 
                SortExpression="FirstName" />
            <asp:BoundField DataField="Alias" HeaderText="Alias" SortExpression="Alias" />
            <asp:HyperLinkField DataNavigateUrlFields="Email" 
                DataNavigateUrlFormatString="mailto:{0}" DataTextField="Email" 
                HeaderText="Email" SortExpression="Email" />
        </Columns>
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" Font-Size="Medium" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
    <asp:EntityDataSource ID="EmployeeDataSource" runat="server" 
        ConnectionString="name=HRSkillsEntities" 
        DefaultContainerName="HRSkillsEntities" EnableDelete="True" EnableInsert="True" 
        EnableUpdate="True" EntitySetName="Employees">
    </asp:EntityDataSource>
    <br />
    <asp:GridView ID="skillsGridView" runat="server" BackColor="LightGoldenrodYellow"
        BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" 
        Caption="Skills for the selected employee:" CaptionAlign="Top" 
        CellSpacing="1" PageSize="5" AutoGenerateColumns="False" DataKeyNames="SkillId" 
        DataSourceID="SkillsDataSource">
        <FooterStyle BackColor="Tan" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="SkillId" HeaderText="SkillId" ReadOnly="True" 
                SortExpression="SkillId" Visible="False" />
            <asp:BoundField DataField="SkillName" HeaderText="SkillName" 
                SortExpression="SkillName" />
            <asp:BoundField DataField="BriefDescription" HeaderText="BriefDescription" 
                SortExpression="BriefDescription" />
            <asp:BoundField DataField="Employees.EmployeeId" 
                HeaderText="Employees.EmployeeId" SortExpression="Employees.EmployeeId" 
                Visible="False" />
        </Columns>
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
    <asp:EntityDataSource ID="SkillsDataSource" runat="server" 
    ConnectionString="name=HRSkillsEntities"
    DefaultContainerName="HRSkillsEntities" EnableDelete="True" EnableInsert="True"
    EnableUpdate="True" EntitySetName="Skills" AutoGenerateWhereClause="false"
    Where="it.Employee.EmployeeID = @EmployeeID">
    <WhereParameters>
        <asp:ControlParameter ControlID="EmployeeGridView" DbType="Guid" 
            Name="EmployeeID" PropertyName="SelectedValue"
            DefaultValue="00000000-0000-0000-0000-000000000000" />
    </WhereParameters>
    </asp:EntityDataSource>
    <asp:GridView ID="skillInfoGridView" runat="server" BackColor="LightGoldenrodYellow"
        BorderColor="Tan" BorderWidth="1px" CaptionAlign="Top" CellPadding="2" CellSpacing="1"
        ForeColor="Black" AutoGenerateColumns="False" Caption="Additional Skills Info:" 
        DataKeyNames="SkillInfoId" DataSourceID="SkillsInfoDataSource">
        <FooterStyle BackColor="Tan" ForeColor="GhostWhite" />
        <Columns>
            <asp:BoundField DataField="SkillInfoId" HeaderText="SkillInfoId" 
                ReadOnly="True" SortExpression="SkillInfoId" Visible="False" />
            <asp:BoundField DataField="Skills.SkillId" HeaderText="Skills.SkillId" 
                SortExpression="Skills.SkillId" Visible="False" />
            <asp:HyperLinkField DataNavigateUrlFields="URL" DataTextField="URL" 
                HeaderText="Website:" />
        </Columns>
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
    <asp:EntityDataSource ID="SkillsInfoDataSource" runat="server" 
        ConnectionString="name=HRSkillsEntities" 
        DefaultContainerName="HRSkillsEntities" EntitySetName="SkillInfoes"
        Where="it.Skill.SkillId = @SkillId">
        <WhereParameters>
            <asp:ControlParameter ControlID="skillsGridView" Name="SkillId" 
                PropertyName="SelectedValue" DbType="Guid" 
                ConvertEmptyStringToNull="False" 
                DefaultValue="00000000-0000-0000-0000-000000000000" />
        </WhereParameters>
    </asp:EntityDataSource>
    <br />
    <asp:GridView ID="referencesGridView" runat="server" BackColor="LightGoldenrodYellow"
        BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" 
        Caption="References" CaptionAlign="Top" CellSpacing="1" PageSize="5" 
        AutoGenerateColumns="False" DataKeyNames="ReferenceId" 
        DataSourceID="ReferencesDataSource">
        <FooterStyle BackColor="Tan" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <Columns>
            <asp:BoundField DataField="ReferenceId" HeaderText="ReferenceId" 
                ReadOnly="True" SortExpression="ReferenceId" Visible="False" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" 
                SortExpression="LastName" />
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" 
                SortExpression="FirstName" />
            <asp:BoundField DataField="Position" HeaderText="Position" 
                SortExpression="Position" />
            <asp:BoundField DataField="Alias" HeaderText="Alias" SortExpression="Alias" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="Employees.EmployeeId" 
                HeaderText="Employees.EmployeeId" SortExpression="Employees.EmployeeId" 
                Visible="False" />
        </Columns>
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
    <asp:EntityDataSource ID="ReferencesDataSource" runat="server" 
        ConnectionString="name=HRSkillsEntities" 
        DefaultContainerName="HRSkillsEntities" EnableDelete="True" EnableInsert="True" 
        EnableUpdate="True" EntitySetName="References"
        Where="it.Employee.EmployeeId = @EmployeeId">
        <WhereParameters>
            <asp:ControlParameter ControlID="employeeGridView" Name="EmployeeId" 
                PropertyName="SelectedValue" DbType="Guid" 
                ConvertEmptyStringToNull="False" 
                DefaultValue="00000000-0000-0000-0000-000000000000" />
        </WhereParameters>
    </asp:EntityDataSource>
    </form>
</body>
</html>
