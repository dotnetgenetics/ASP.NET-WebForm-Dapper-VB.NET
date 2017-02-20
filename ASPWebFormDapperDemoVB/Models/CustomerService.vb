Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Public Class CustomerService
    Private _repository As ICustomerRepository

    Public Sub New()
        _repository = New CustomerRepository()
    End Sub

    Public Function GetAll() As List(Of Customer)
        Return _repository.GetAll()
    End Function

    Public Function FindById(Id As Integer) As Customer
        Return _repository.FindById(Id)
    End Function

    Public Function AddCustomer(customer As Customer) As Boolean
        Return _repository.AddCustomer(customer)
    End Function

    Public Function UpdateCustomer(customer As Customer) As Boolean
        Return _repository.UpdateCustomer(customer)
    End Function

    Public Function DeleteCustomer(Id As Integer) As Boolean
        Return _repository.DeleteCustomer(Id)
    End Function
End Class
