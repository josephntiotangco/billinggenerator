   M S B A M L   `   `   `  ���� T  PBillingStatementGenerator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:BillingStatementGeneratorBillingStatementGenerator  *    $BillingStatementGenerator.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     9local'clr-namespace:BillingStatementGenerator       � Title$  KFPT Billing Generator��$	��900��$	��800�� � WindowState$ 	Maximized=� � WindowStartupLocation$ CenterScreen=� � DataContext ��  �� RelativeSource �� *Self+.���  � RowDefinitions �� $
��Auto ��� $
��Auto ��� .+�� $��0�� �� $
��Auto ��� $
��Auto ��� .+��� $��0��$��0��$.��(---- Setup Header Details Here Here ----��$��Center=�$��Center=�$��5q�� $��1�� � ColumnDefinitions �� $
��Auto ���  �� �� �� �� �� �� �� �� �� �� �� .+��� $��0��$��0��$��Billing No: ��$
��Left=�$��Center=�$��5q��� -    ��Name$ tbBillingReference��$��0��$��1��$	��340��$��30��$
��Left=�$��Center=�$��5q����� *HeaderBillingNo+�� $��1��$��0��$��	Bill To: ��$
��Left=�$��Center=�$��5q��� -   $ tbCustomerName��$��1��$��1��$	��340��$��30��$
��Left=�$��Center=�$��5q����� *HeaderCustomerName+�� $��2��$��0��$��Bill To Address: ��$
��Left=�$��Center=�$��5q��� -   $ tbCustomerAddress��$��2��$��1��$	��340��$��30��$
��Left=�$��Center=�$��5q����� *HeaderCustomerAddress+�� $��3��$��0��$��Bill To Contact: ��$
��Left=�$��Center=�$��5q��� -   $ tbCustomerContact��$��3��$��1��$	��340��$��30��$
��Left=�$��Center=�$��5q����� *HeaderCustomerContact+�� $��4��$��0��$��Bill Date: ��$
��Left=�$��Center=�$��5q�(  "System.Windows.Controls.DatePicker  -     Name$ dtpBillDate��$��4��$��1��$	��150��$
��Left=�	   SelectedDate	 �� *HeaderBillDate+�� $��5��$��0��$��Bill Due Date: ��$
��Left=�$��Center=�$��5q�  -   $ 
dtpDueDate��$��5��$��1��$	��150��$
��Left=�	 �� *HeaderBillDueDate+�� $��6��$��0��$��Biller Name: ��$
��Left=�$��Center=�$��5q��� -   $ tbBillerName��$��6��$��1��$	��340��$��30��$
��Left=�$��Center=�$��5q����� *HeaderBiller+�� $��7��$��0��$��Biller Address: ��$
��Left=�$��Center=�$��5q��� -   $ tbBillerAddress��$��7��$��1��$	��340��$��30��$
��Left=�$��Center=�$��5q����� *HeaderBillerAddress+�� $��8��$��0��$��Biller Contact: ��$
��Left=�$��Center=�$��5q��� -	   $ tbBillerContact��$��8��$��1��$	��340��$��30��$
��Left=�$��Center=�$��5q����� *HeaderBillerContact+�� $��9��$��0��$��Biling Terms: ��$
��Left=�$��Center=�$��5q��� -
   $ tbBillTerms��$��9��$��1��$	��340��$��30��$
��Left=�$��Center=�$��5q����� *HeaderBillerTerm+�� $��10��$��0��$��	Remarks: ��$
��Left=�$��Center=�$��5q��� -   $ tbBillRemarks��$��10��$��1��$	��340��$��30��$
��Left=�$��Center=�$��5q����� *HeaderBillerRemark+�� -   
 ��Name$
 btnSaveHeader��$��2��$��Save Header Details��$��5q�� $��1�� �� $
��Auto ��� $
��Auto ��� .+��� $��0��$��0��$*��$---- Add Items To Billings Here ----��$��Center=�$��Center=�$��5q�� $��1�� �� $
��Auto ���  �� �� �� �� �� �� .+��� $��0��$��0��$��Item Description��$
��Left=�$��Center=�$��5q��� -   $ tbItemDescription��$��0��$��1��$	��200��$��30��$
��Left=�$��Center=�$��5q����� *NewItemDescription+�� $��1��$��0��$��Item Reference��$��Right=�$��Center=�$��5q��� -   $ tbItemReference��$��1��$��1��$	��150��$��30��$
��Left=�$��Center=�$��5q����� *NewItemReference+�� $��2��$��0��$��
Item Price��$��Right=�$��Center=�$��5q��� -   $ tbItemPrice��$��2��$��1��$	��150��$��30��$
��Left=�$��Center=�$��5q����� *NewItemPrice+ �� StringFormat$ 	{0:#,0.0}���� $��3��$��0��$��Item Quantity��$��Right=�$��Center=�$��5q��� -   $ tbItemQuantity��$��3��$��1��$	��150��$��30��$
��Left=�$��Center=�$��5q����� *NewItemQuantity+$ 	{0:#,0.0}���� $��4��$��0��$��Item UOM��$��Right=�$��Center=�$��5q��� -   $ 	tbItemUOM��$��4��$��1��$	��150��$��30��$
��Left=�$��Center=�$��5q����� *
NewItemUOM+�� $��5��$��0��$��
Item Price��$��Right=�$��Center=�$��5q�  -   $ dtpNewItemDate��$��5��$��1��$	��150��$��30��$
��Left=�   SelectedDateFormat$ Short=�$��Center=�$��5q�	 �� *NewItemDate+�� -   $
 btnAddItemToBilling��$��2��$��Add Item To Billing��$��5q�� $��2�� �� $
��Auto ��� �� $
��Auto �.+���  �� Orientation$ 
Horizontal=�$��Right=�.+��� $��Total Amount Due :��$��5q��� $��Right=�$	��150��
���   �$
��Bold"�$��15(����� *TotalAmountDue+$ 	{0:#,0.0}��&   System.Windows.Controls.DataGrid  -     Name$ dgItems��$��1��   AutoGenerateColumns$ False��   AlternatingRowBackground
 �����"   VerticalScrollBarVisibility$
 Auto=����� *newBillingItems+ �� Mode$ TwoWay=� �� SelectedItem �� *SelectedBillingItem+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Id��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+  $ Description�� �� *Description+  $
 Date�� �� *	TransDate+  $ 	Reference�� �� *	Reference+  $ Price�� �� *Price+  $ Quantity�� �� *
Quantity+  $	 UOM�� �� *UOM+  $ Subtotal�� �� *
Subtotal+�� $��2��$ Vertical=�.+��� -   $
 btnSavePrint��$��30��$��Stretch=�$��Center=�$��5q�$��Save and Print to PDF���� -   $
 	btnCancel��$��30��$��Stretch=�$��Center=�$��5q�$��Cancel��