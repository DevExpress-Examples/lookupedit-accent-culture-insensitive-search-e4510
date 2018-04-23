Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.Xpf.Grid.LookUp
Imports DevExpress.Xpf.Editors.Settings

Namespace AccentInsensitiveSearch
	Public Class CustomLookUpEdit
		Inherits LookUpEdit
		Protected Overrides Function CreateEditorSettings() As BaseEditSettings
			Return New AccentInsensitiveEditSettings()
		End Function
	End Class
End Namespace
