   M S B A M L   `   `   `  ????I  ELinqWPFProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:LinqWPFProjectLinqWPFProject  5   	       LinqWPFProject.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:LinqWPFProject     5   	     ? Title$  
MainWindow??5   	   $	??500??6   $	??800??6)   .??5	      ?  ? ColumnDefinitions 5   
   ?? 5      $	??400 ?6   ?? 5      $	??400 ?6   .+?5   
   ?? $??0??6   .+?5      ??  ?? Orientation$ 
Horizontal=?6   $??5q?62   $??Center=?6=   .+?5      	? -   5         	?Name$ 	radioSale??5      $
??Sale??61   6B   	? 5      -   5        $ 	radioRent??5      $
??Rent??61   $??5,0,0,0q?6@   $??50??6Q   6^   5      ?? 5      $ 
Horizontal=?6   $??5q?62   .+?5      ?? $??Name :??6   $	??100??6*   68   ?? 5      -   5        $??txtName??5      $	??200??6)   67   5      ?? 5      $ 
Horizontal=?6   $??5q?62   .+?5      ?? $??Description :??6   $	??100??61   6?   ?? 5      -   5        $??txtDescription??5      $	??200??60   6>   5      ?? 5       $ 
Horizontal=?6   $??5q?62   .+?5!      ?? $??Price :??6   $	??100??6+   69   ?? 5"      -   5        $??txtPrice??5"      $	??200??6*   68   5#      ?? 5$      $ 
Horizontal=?6   $??5q?62   .+?5%      ?? $??Publish Date :??6   $	??100??62   6@   (  "System.Windows.Controls.DatePicker  5&      -   5        $??datePublish??5&      $	??200??60      Text$ Select Date??6<   6S   5'      ?? 5(      $ 
Horizontal=?6   $??5q?62   .+?5)      ?? $??
Category :??6   $	??100??6.   $??Center=?6:   $??Center=?6W   ?? 5*      -   5        $??cmbCategory??5*      $	??200??6.   5+      ?? 5,      $ 
Horizontal=?6   $??5q?62   .+?5-      ?? $??	Address :??6   $	??100??6-   $??Center=?69   $??Center=?6V   ?? 5.      -   5        $??
cmbAddress??5.      $	??200??6-   5/      ?? 50      $ 
Horizontal=?6   $
??Left=?62   $??10q?6M   {?6Y   ??  ?? ElementName$ 	radioSale?? ?? Path$ 	IsChecked?.+?51      ?? -	   5        $??chckSwap??51      $
??Swap??6+   6=   53      ?? 54      $ 
Horizontal=?6   $
??Left=?62   $??5q?6M   {?6X   ?? $ 	radioRent??$ 	IsChecked?.+?55      ?? $??Rent Kind :??6   $	??100??6/   $
??Left=?6;   $??Center=?6V   	? 56      -
   5        $ radioDay??56      $	??Day??60   $??35,0,0,0q?6>   $??50??6P   6]   	? 57      -   5        $ 	radioWeek??57      $
??Week??61   $??5,0,0,0q?6@   $??50??6Q   6^   	? 58      -   5        $ 
radioMonth??58      $??Month??62   $??5,0,0,0q?6B   $??60??6S   6`   59      ?? 5:      $ 
Horizontal=?6   $??Right=?62   $??	0,10,70,0q?6N   .+?5;      ?? -   5        $??btnSaveProduct??5;      $
??Save??6/   $	??100??6>   $??Right=?6J   $??5q?6f   5<      ?? 5=      $ 
Horizontal=?6   $??Right=?62   $??	0,10,70,0q?6N   .+?5>      ?? -   5        $??btnSaleView??5>      $??
Sales View??6,   $	??100??6A   $??Right=?6M   $??5q?6i   5?      ?? 5@      $ 
Horizontal=?6   $??Right=?62   $??	0,10,70,0q?6N   .+?5A      ?? -   5        $??btnRentView??5A      $??
Rents View??6,   $	??100??6A   $??Right=?6M   $??5q?6i   5B      ?? 5C      $ 
Horizontal=?6   $??Right=?62   $??	0,10,70,0q?6N   .+?5D      ?? -   5        $??btnQueryView??5D      $??
Query View??6-   $	??100??6B   $??Right=?6N   $??5q?6j   5E      5F      ?? 5H   
   $??1??6   .+?5I      ?? $ 
Horizontal=?6   $??	140,5,0,0q?62   .+?5J      ?? $??ADD ADDRESS??6   $	??100??6/   6=   5L      ?? 5M      $ 
Horizontal=?6   $??5q?62   .+?5N      ?? $??Address Name :??6   $	??100??62   6@   ?? 5O      -   5        $??txtAddressName??5O      $	??200??60   6>   5P      ?? 5Q      $ 
Horizontal=?6   $??5q?62   .+?5R      ?? $??	Country :??6   $	??100??6-   $??Center=?69   $??Center=?6V   ?? 5S      -   5        $??
cmbCountry??5S      $	??200??6-   5T      ?? 5U      $ 
Horizontal=?6   $??5q?62   .+?5V      ?? $??City :??6   $	??100??6*   $??Center=?66   $??Center=?6S   ?? 5W      -   5        $??cmbCity??5W      $	??200??6*   5X      ?? 5Y      $ 
Horizontal=?6   $??5q?62   .+?5Z      ?? $??	Address :??6   $	??100??6-   $??Center=?69   $	??Top=?6V   ?? 5[      -   5        $??
txtAddress??5[      $	??100??6,   $	??200??69   5\      ?? 5]      $ 
Horizontal=?6   $??Right=?62   $??	0,10,70,0q?6N   .+?5^      ?? -   5        $??btnSaveAddress??5^      $??Save Address??6/   $	??100??6F   $??Right=?6R   $??0,0,35,0q?6n   5_      5`      5a      5b      