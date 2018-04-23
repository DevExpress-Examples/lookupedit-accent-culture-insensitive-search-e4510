Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.Xpf.Grid.LookUp

Namespace AccentInsensitiveSearch
	Public Class AccentInsensitiveEditSettings
		Inherits LookUpEditSettings
		Protected Overrides Function CreateItemsProvider() As DevExpress.Xpf.Editors.Helpers.ItemsProvider
			Return New AccentInsensitiveItemsProvider(Me)
		End Function
	End Class
End Namespace
