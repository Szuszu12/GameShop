   M S B A M L   `   `   `  ����F  BGameShopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:GameShopAppGameShopApp  5   	        GameShopApp.CategoryWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:GameShopApp     5   	   -   5          � Title$  	Game Shop��5   	   $	��450��6   $	��800��6(   .��5
      � 
������� � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Lista Kategorii��6   $
��Left=�6*   $	��Top=�6E   $��10,0,0,0q�6]   $
��Bold"�6o   �� 5   
   -   5         ��Name$ categoriesListBox��5      $	��Top=�5      $	��200��5      $	��300��5      $��
10,26,10,0q�5      ��5      �� 5      .R�5      �� 
�������$��0,0,0,1q�64   ._�5      ��  �� Padding$ 5q�6B   ��6$   �� *CategoryName+6B   5      5      5      �� 5    
   $��1��6   $��10q�6%   .+�5"      �� -   5        $��Dodaj nową kategorię��5"      ���#4CAF50
�������$��0,0,0,10q�5&      �� 5(      -   5        $&�� Zmień nazwę wybranej kategorii��5(      ���#2196F3
�������$��0,0,0,10q�5,      �� 5.      -   5        $��Usuń wybraną kategorię��5.      ���#F44336
�������$��0,0,0,10q�52      53      54      55      