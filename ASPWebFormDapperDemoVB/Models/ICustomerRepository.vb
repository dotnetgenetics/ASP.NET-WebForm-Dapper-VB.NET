Public Interface ICustomerRepository

    Function GetAll() As List(Of Customer)
    Function FindById(Id As Integer) As Customer
    Function AddCustomer(customer As Customer) As Boolean
    Function UpdateCustomer(customer As Customer) As Boolean
    Function DeleteCustomer(Id As Integer) As Boolean

End Interface