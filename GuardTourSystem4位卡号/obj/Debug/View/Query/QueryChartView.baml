   M S B A M L   `   `   `  ����A  =Patrol, Version=2.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:GuardTourSystem.SelectorGuardTourSystem.Selector  5      ;"clr-namespace:GuardTourSystem.ViewGuardTourSystem.View  5	      )    #GuardTourSystem.View.QueryChartView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      ;selector&clr-namespace:GuardTourSystem.Selector     5      l hTelerik.Windows.Controls.Chart, Version=2014.3.1202.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7b ^Telerik.Windows.Data, Version=2014.3.1202.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7o kTelerik.Windows.Controls.GridView, Version=2014.3.1202.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Data, Version=2014.3.1202.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7l	 hTelerik.Windows.Documents.Core, Version=2014.3.1202.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7l
 hTelerik.Windows.Controls.Input, Version=2014.3.1202.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7f bTelerik.Windows.Controls, Version=2014.3.1202.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.Navigation, Version=2014.3.1202.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7g cTelerik.Windows.Documents, Version=2014.3.1202.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7| xTelerik.Windows.Documents.FormatProviders.Html, Version=2014.3.1202.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Qtelerik1http://schemas.telerik.com/2008/xaml/presentation
     	 
     5      ?view"clr-namespace:GuardTourSystem.View
     	 
     5	      .��5      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   .+�5      �� $��0��5      $��查询日期��5          
TitleLabel#��[  5!      0 
 *Telerik.Windows.Controls.RadDateTimePicker  5"      $��1��5#      $��10,3,0,3q�5$        RadDatePicker#��[ 5&         SelectedDate 5%      �� *DateQueryInfo.Begin+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� StringFormat$ 
yyyy/MM/dd��5&      �� 5'      $��2��5(      $	��至��5)      #��[  5*        5+      $��3��5,      $��0,3,10,3q�5-      #��[ 5/       5.      �� *DateQueryInfo.End+$ TwoWay=�$ PropertyChanged=�$ 
yyyy/MM/dd��5/      �� 50      $��4��51        
AlarmLabel#��[ 53      ��52      �� *Error+53      �� 54      $��5��55      $��80��56        FlatGreenSolidBrush#��[ 57      $��统计��59        BlueBtn#��[ 5:      ��58      �� *CCount+5:      �� 5;      $��6��5<      $��统计信息��5=      #��[  5>      �� 5@      $��7��5A      $��80��5B      $��3q�5C       �� DisplayMemberPath$ ShowName��5D      ��5E      �� *
CountTypes+ �� SelectedItem 5F      �� *SelectCountType+5G      �� 5H   
   -   5         ��Name$ ContentControl��5I      $��1��5J      ��5K      �� *	Content+�� 5L   
   $��2��5M      $��RightToLeft=�5N      	 �� Orientation$	 
Horizontal=�5O      .+�5P      ��   CloseBtn#��[ 6   �� 5Q      -   5          ExportExcelBtn#��[ 5Q   1   �� 5R      -   5          PrintBtn#��[ 5R   0   5S      5T      5U      