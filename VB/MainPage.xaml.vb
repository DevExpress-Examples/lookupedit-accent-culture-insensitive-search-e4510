Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes

Namespace AccentInsensitiveSearchSample
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
			Dim list = New List(Of String) (New String() {"Côté"})
			accentInsensitivelookUpEdit.ItemsSource = list
		End Sub
	End Class
End Namespace
