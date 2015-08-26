<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="FisiksAppWeb.WebForm1" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">


<script runat="server">
void Page_Load() {
  if (!Page.IsPostBack)
  {
    AccordionPane ap1 = new AccordionPane();
    ap1.HeaderContainer.Controls.Add(new LiteralControl("Using Markup"));
    ap1.ContentContainer.Controls.Add(new LiteralControl("Adding panes using markup is really simple."));
    AccordionPane ap2 = new AccordionPane();
    ap2.HeaderContainer.Controls.Add(new LiteralControl("Using Code"));
    ap2.ContentContainer.Controls.Add(new LiteralControl("Adding panes using code is really flexible."));

    acc1.Panes.Add(ap1);
    acc1.Panes.Add(ap2);
  }
}
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <title>Control Toolkit</title>
  <style type="text/css">
  .header {background-color: blue;}
  .content {border: solid;}
  </style>
</head>
<body>
  <form id="form1" runat="server">
    <asp:ScriptManager ID="asm" runat="server" />
    <div>
      <ajaxToolkit:Accordion ID="acc1" runat="server" 
        HeaderCssClass="header" ContentCssClass="content" Width="300px" FadeTransitions="true">
      </ajaxToolkit:Accordion>
    </div>
  </form>
</body>
</html>

