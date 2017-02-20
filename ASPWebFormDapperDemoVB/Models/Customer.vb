Public Class Customer

    Public Property CustomerID() As Integer
        Get
            Return m_CustomerID
        End Get
        Set(value As Integer)
            m_CustomerID = Value
        End Set
    End Property
    Private m_CustomerID As Integer

    Public Property CompanyName() As String
        Get
            Return m_CompanyName
        End Get
        Set(value As String)
            m_CompanyName = Value
        End Set
    End Property
    Private m_CompanyName As String

    Public Property Address() As String
        Get
            Return m_Address
        End Get
        Set(value As String)
            m_Address = Value
        End Set
    End Property
    Private m_Address As String

    Public Property City() As String
        Get
            Return m_City
        End Get
        Set(value As String)
            m_City = Value
        End Set
    End Property
    Private m_City As String

    Public Property State() As String
        Get
            Return m_State
        End Get
        Set(value As String)
            m_State = Value
        End Set
    End Property
    Private m_State As String

    Public Property IntroDate() As DateTime
        Get
            Return m_IntroDate
        End Get
        Set(value As DateTime)
            m_IntroDate = Value
        End Set
    End Property
    Private m_IntroDate As DateTime

    Public Property CreditLimit() As Decimal
        Get
            Return m_CreditLimit
        End Get
        Set(value As Decimal)
            m_CreditLimit = Value
        End Set
    End Property
    Private m_CreditLimit As Decimal

End Class
