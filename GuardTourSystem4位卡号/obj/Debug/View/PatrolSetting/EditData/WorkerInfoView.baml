   M S B A M L   `   `   `  ����A  =Patrol, Version=2.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:GuardTourSystem.ConverterGuardTourSystem.Converter  5      ;"clr-namespace:GuardTourSystem.ViewGuardTourSystem.View  5      )    #GuardTourSystem.View.WorkerInfoView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      5c'clr-namespace:GuardTourSystem.Converter     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      R NMahApps.Metro.IconPacks, Version=1.6.0.0, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	      l hMicrosoft.Practices.Prism.Composition, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35m iMicrosoft.Practices.Prism.Mvvm.Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n	 jMicrosoft.Practices.Prism.Interactivity, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35-prismhttp://www.codeplex.com/prism   	 5
      h
 dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Av9http://schemas.microsoft.com/expression/2010/interactions 
 5      -view"clr-namespace:GuardTourSystem.View 
 5        +� FocusedElement  5      ��  �� ElementName$ WorkerNameTextBox��.��5      � $��
20,20,20,0q�6   $��Center=�6    � 	Resources 5   
   4  .GuardTourSystem.Converter.BoolReverseConverter   BoolReverser<  6GuardTourSystem.Converter.ReadDeviceIdVisibleConverter  VisibleConverter��%:   &	        &	        5      6%     5      6-   5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��5      $��5,5,5,0q�5      $
��Left=�5       �� Orientation$ 
Horizontal=�5      .+�5       �� -   5         ��Name$ 	NameLabel��5!      $	��100��5"      $��管理卡名称��5#        ContentLabel#��[ 5$      �� 5%      -   5         ��Name$ WorkerNameTextBox��5&      $	��150��5'       �� 	MaxLength$ 5��5(       �� MaxLines$ 1��5)        ContentTextBox#��[ 5*      ��5+      �� *Worker.Name+	 �� UpdateSourceTrigger$	 PropertyChanged=�5,      �� 5F   
   $��1��5G      $��5,5,5,0q�5H      $
��Left=�5I      $ 
Horizontal=�5J      .+�5K      �� $	��100��5L      $��管理卡钮号��5M      #��[ 5N      �� 5P      $	��150��5Q      $ 4��5R      #��[ 5S      ��5T      �� *Worker.Card+$	 PropertyChanged=�5U      �� 5W   
   $��2��5X        
AlarmLabel#��[ 5Z      ��5Y      �� *	ErrorInfo+5Z      A� 5\   
   $��3��5]      $��0,20,0,0q�5^      
 A� Columns$
 2��5_      .+�5`      �� $��10q�6     
ConfirmBtn#��[ 6!   �� 5a      $��10q�5b      $��取消��5c        CloseBtn#��[ 5d      5e      5f      5g      