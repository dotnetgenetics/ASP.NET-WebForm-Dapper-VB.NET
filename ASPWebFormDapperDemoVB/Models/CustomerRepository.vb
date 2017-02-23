Imports System.Data.SqlClient
Imports Dapper

Public Class CustomerRepository
    Implements ICustomerRepository

    Private _db As IDbConnection

    Public Sub New()
        _db = New SqlConnection(ConfigurationManager.ConnectionStrings("CustomerInformation").ConnectionString)
    End Sub

    Public Function GetAll() As List(Of Customer) Implements ICustomerRepository.GetAll
        Return Me._db.Query(Of Customer)("SELECT * From Customer;").ToList()
    End Function

    Public Function FindById(Id As Integer) As Customer Implements ICustomerRepository.FindById
        Return Me._db.Query(Of Customer)("SELECT * FROM Customer WHERE CustomerID=@Id", New With { _
            Key .Id = Id _
        }).FirstOrDefault()
    End Function

    Public Function AddCustomer(customer As Customer) As Boolean Implements ICustomerRepository.AddCustomer
        Dim parameters As SqlParameter() = {
            New SqlParameter("@CompanyName", customer.CompanyName),
            New SqlParameter("@Address", customer.Address),
            New SqlParameter("@City", customer.City),
            New SqlParameter("@State", customer.State),
            New SqlParameter("@IntroDate", customer.IntroDate),
            New SqlParameter("@CreditLimit", customer.CreditLimit)}

        Dim query As String = "INSERT INTO Customer(CompanyName,Address,City,State,IntroDate,CreditLimit)" + " Values(@CompanyName,@Address,@City,@State,@IntroDate,@CreditLimit)"

        Dim args = New DynamicParameters()
        For Each p As SqlParameter In parameters
            args.Add(p.ParameterName, p.Value)
        Next

        Try
            Me._db.Query(Of Customer)(query, args).SingleOrDefault()
        Catch generatedExceptionName As Exception
            Return False
        End Try

        Return True
    End Function

    Public Function UpdateCustomer(customer As Customer) As Boolean Implements ICustomerRepository.UpdateCustomer
        Dim parameters As SqlParameter() = {
            New SqlParameter("@CustomerID", customer.CustomerID),
            New SqlParameter("@CompanyName", customer.CompanyName),
            New SqlParameter("@Address", customer.Address),
            New SqlParameter("@City", customer.City),
            New SqlParameter("@State", customer.State),
            New SqlParameter("@IntroDate", customer.IntroDate), _
            New SqlParameter("@CreditLimit", customer.CreditLimit)}

        Dim query As String = " UPDATE Customer SET CompanyName = @CompanyName,Address = @Address, " + " City = @City,State = @State,IntroDate = @IntroDate,CreditLimit = @CreditLimit" + " WHERE CustomerID = @CustomerID"

        Dim args = New DynamicParameters()
        For Each p As SqlParameter In parameters
            args.Add(p.ParameterName, p.Value)
        Next

        Try
            Me._db.Execute(query, args)
        Catch generatedExceptionName As Exception
            Return False
        End Try

        Return True
    End Function

    Public Function DeleteCustomer(Id As Integer) As Boolean Implements ICustomerRepository.DeleteCustomer
        Dim deletedCustomer As Integer = Me._db.Execute("DELETE FROM Customer WHERE CustomerID = @Id", New With { _
            Key .Id = Id _
        })
        Return deletedCustomer > 0
    End Function

End Class

