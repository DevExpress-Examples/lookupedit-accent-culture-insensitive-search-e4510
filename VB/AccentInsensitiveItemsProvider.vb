Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.Xpf.Editors.Helpers
Imports System.Reflection

Namespace AccentInsensitiveSearch
	Public Class AccentInsensitiveItemsProvider
		Inherits ItemsProvider
		Public Sub New(ByVal owner As IItemsProviderOwner)
			MyBase.New(owner)
		End Sub

		Public Overrides Function FindItemIndexByText(ByVal text As String, ByVal isCaseSensitive As Boolean, ByVal autoComplete As Boolean) As Integer
			If text Is Nothing Then
				Return -1
			End If
			Return FindItemIndexByTextInternal(text, isCaseSensitive, autoComplete)
		End Function
		Private Function FindItemIndexByTextInternal(ByVal text As String, ByVal isCaseSensitive As Boolean, ByVal autoComplete As Boolean) As Integer
			If text.Length = 0 Then
				For i As Integer = 0 To Count - 1
					If String.Empty = GetPrimaryText(Me(i)) Then
						Return DataController.GetListSourceRowIndex(i)
					End If
				Next i
			Else
				If (Not isCaseSensitive) Then
					text = text.ToLower()
				End If
				For i As Integer = 0 To Count - 1
					Dim itemText As String = GetPrimaryText(Me(i))
					If itemText Is Nothing Then
						Continue For
					End If
					If (Not isCaseSensitive) Then
						itemText = itemText.ToLower()
					End If
					If autoComplete Then
						itemText = itemText.Substring(0, Math.Min(itemText.Length, text.Length))
					End If
					If String.Compare(text, itemText, System.Globalization.CultureInfo.CurrentCulture, System.Globalization.CompareOptions.IgnoreNonSpace) = 0 Then
						Return DataController.GetListSourceRowIndex(i)
					End If
				Next i
			End If
			Return -1
		End Function
		Private Function GetPrimaryText(ByVal item As Object) As String
			Dim value As Object = GetDisplayValueFromItem(item)
			Return If(value Is Nothing, Nothing, value.ToString())
		End Function
	End Class
End Namespace
