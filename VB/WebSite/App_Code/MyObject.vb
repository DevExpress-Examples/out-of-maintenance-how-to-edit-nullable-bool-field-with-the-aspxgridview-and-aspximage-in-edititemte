Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo

Public Class MyObject
	Inherits XPObject
	Public Sub New()
		MyBase.New()
	End Sub

	Public Sub New(ByVal session As Session)
		MyBase.New(session)
	End Sub

	Public Overrides Sub AfterConstruction()
		MyBase.AfterConstruction()
	End Sub

	Protected _Title As String
	Public Property Title() As String
		Get
			Return _Title
		End Get
		Set(ByVal value As String)
			SetPropertyValue(Of String)("Title", _Title, value)
		End Set
	End Property

	Private active_Renamed As Nullable(Of Boolean)
	Public Property Active() As Nullable(Of Boolean)
		Get
			Return active_Renamed
		End Get
		Set(ByVal value As Nullable(Of Boolean))
			SetPropertyValue("Active", active_Renamed, value)
		End Set
	End Property
End Class

