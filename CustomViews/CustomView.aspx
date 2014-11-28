<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomView.aspx.cs" Inherits="UIExtensionSamples.CustomViews.CustomView" %>

<asp:Content ContentPlaceHolderID="FullRegion" runat="server">

   <h1>This has the look and feel of the good old EPiServer administrative interface.</h1>

    Name: <EPiServer:Property runat="server" PropertyName="PageName" CustomTagName="h2" />

</asp:Content>