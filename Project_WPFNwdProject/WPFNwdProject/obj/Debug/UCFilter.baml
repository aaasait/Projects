   M S B A M L   `   `   `  ????H  DWPFNwdProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WPFNwdProjectWPFNwdProject  5          WPFNwdProject.UCFilter   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:WPFNwdProject     5      
???????.??5	      ?   ? RowDefinitions  5
   
   ?? 5      $??70 ?6   ?? 5      $	??628 ?6   .+?5   
   ?? $??0??6   .+?5      ?? $
??Left=?6   $??Center=?64   $
??1000??6O   $??60??6\   .+?5      ?? -   5        $??cmbFilterQuery??5       ?? SelectedIndex$ 0??62   $
??Left=?6D   $	??Top=?6?   $??	50,20,0,0q?6?   $	??170??6?   $??30??6?   ?? 5      -   5         ??Name$ 	txtFilter??5      $??-350,-30,0,0q?6-   $	??150??6C   $??30??6O   6[   (  "System.Windows.Controls.DatePicker  5      -   5        $??	datestart??5      $	??200??6.      Text$ Select Date??6:   $??31??6M   $??
50,-30,0,0q?6Y   6o     5      -   5        $??
datefinish??5      $	??200??6/   $ Select Date??6;   $??31??6N   $??460,-30,0,0q?6Z   6q   ?? 5      -   5         ??Name$ btnDate??5      $??Filter Date??6*   $??800,-33,0,0q?6@   $	??100??6U   $??31??6a   5      5      ?? 5   
   -   5         ??Name$ stackPaneUpdate??5   6   $??1??6   
???????.+?5      ?? $
??Left=?6   $	??600??64   $
??1040??6A   $??-30,0q?6N   .+?5      ?? -   5         ??Name$ 	QueryList??5      $	??570??6.   $	??900??6;   $??30,30q?6G   
???   ?$y?Visible=?6k    ?? View 5       ?? 5!      P?5"      ?? 5#   "   $??OrderID??61    ?? DisplayMemberBinding 6B   ?? *	OrderID+6m   ?? 5$   "   $??Customer ID??61    6F   ?? *
CustomerID+6t   ?? 5%   "   $??Employee ID??61    6F   ?? *
EmployeeID+6t   ?? 5&   "   $??	OrderDate??61    6D   ?? *	OrderDate+6q   ?? 5'   "   $??RequiredDate??61    6G   ?? *RequiredDate+6w   ?? 5(   "   $??ShippedDate??61    6F   ?? *ShippedDate+6u   ?? 5)   "   $??
Shipper ID??61    6E   ?? *	ShipVia+6p   ?? 5*   "   $??Freight??61    6B   ?? *	Freight+6m   ?? 5+   "   $??ShipName??61    6C   ?? *
ShipName+6o   ?? 5,   "   $??ShipAddress??61    6F   ?? *ShipAddress+6u   ?? 5-   "   $??ShipCity??61    6C   ?? *
ShipCity+6o   ?? 5.   "   $??
ShipRegion??61    6E   ?? *
ShipRegion+6s   ?? 5/   "   $??ShipPostalCode??61    6I   ?? *ShipPostalCode+6{   ?? 50   "   $??ShipCountry??61    6F   ?? *ShipCountry+6u   53      55      58      59      5<      5=      