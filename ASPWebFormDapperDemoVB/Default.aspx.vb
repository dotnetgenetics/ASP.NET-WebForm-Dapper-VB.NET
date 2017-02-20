Imports Dapper

Public Class _Default
    Inherits System.Web.UI.Page

    Private customer As Customer
    Private result As Boolean = False
    Private customerService As New CustomerService()


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindGrid()
        End If
    End Sub

    Protected Sub OnRowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim item As String = e.Row.Cells(0).Text
            For Each button As Button In e.Row.Cells(6).Controls.OfType(Of Button)()
                If button.CommandName = "Delete" Then
                    button.Attributes("onclick") = "if(!confirm('Do you want to delete record?')){ return false; };"
                End If
            Next
        End If
    End Sub

    Protected Sub OnRowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Dim CustomerId As Integer = Convert.ToInt32(gvCustomer.DataKeys(e.RowIndex).Values(0))
        result = customerService.DeleteCustomer(CustomerId)
        If result Then
            lblMessage.Text = String.Empty
            lblMessage.Text = "Successfully deleted the reccord!"
        End If

        BindGrid()
    End Sub

    Protected Sub OnRowEditing(sender As Object, e As GridViewEditEventArgs)
        gvCustomer.EditIndex = e.NewEditIndex
        Me.BindGrid()
    End Sub

    Protected Sub OnRowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        customer = New Customer()
        Dim row As GridViewRow = gvCustomer.Rows(e.RowIndex)
        customer.CustomerID = Convert.ToInt32(gvCustomer.DataKeys(e.RowIndex).Values(0))
        customer.Address = TryCast(row.FindControl("txtAddress1"), TextBox).Text
        customer.City = TryCast(row.FindControl("txtCity1"), TextBox).Text
        customer.State = TryCast(row.FindControl("txtState1"), TextBox).Text
        customer.CompanyName = TryCast(row.FindControl("txtCompanyName1"), TextBox).Text
        customer.IntroDate = Convert.ToDateTime(TryCast(row.FindControl("txtIntroDate1"), TextBox).Text)
        customer.CreditLimit = Convert.ToDecimal(TryCast(row.FindControl("txtCreditLimit1"), TextBox).Text)
        result = customerService.UpdateCustomer(customer)

        If result Then
            lblMessage.Text = String.Empty
            lblMessage.Text = "Successfully updated the reccord"
        End If

        gvCustomer.EditIndex = -1
        BindGrid()
    End Sub

    Protected Sub gvCustomer_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvCustomer.PageIndex = e.NewPageIndex
        BindGrid()
    End Sub

    Protected Sub OnRowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        gvCustomer.EditIndex = -1
        Me.BindGrid()
    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs)

        customer = New Customer()
        customer.Address = txtAddress.Text
        customer.City = txtCity.Text
        customer.CompanyName = txtCompanyName.Text
        customer.State = txtState.Text
        customer.CreditLimit = Convert.ToDecimal(txtCreditLimit.Text)
        customer.IntroDate = Convert.ToDateTime(txtIntroDate.Text)
        result = customerService.AddCustomer(customer)

        If result Then
            lblMessage.Text = "Successfully added a new reccord"
        End If

        BindGrid()
    End Sub

    Private Sub BindGrid()
        gvCustomer.DataSource = customerService.GetAll()
        gvCustomer.DataBind()
    End Sub

End Class