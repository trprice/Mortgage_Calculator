   M S B A M L   `   `   `  ����  Mortgage_Calculator$    Mortgage_Calculator.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Mortgage Calculator��5   	   $	��370��6%   $	��525��62   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � RowDefinitions 5
   
   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0��6    $��Loan Amount��6-   $
��Left=�6C   $��10,7,0,0q�6^   $	��Top=�6p   $��89��6�   �� 5   
   -   5        $��loanAmountTextBox��5      $��1��6+   $��0��6;   $
��Left=�6H   $��23��6c   $��0,10,0,0q�6o    �� TextWrapping$
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��120��6�   �� 5   
   $��0��6   $��1��6    $��Loan Period in Years��6-   $
��Left=�6L   $��10,7,0,0q�6g   $	��Top=�6y   $	��140��6�   �� 5   
   -   5        $��loanPeriodTextBox��5      $��1��6+   $��1��6;   $
��Left=�6I   $��23��6d   $��0,10,0,0q�6p   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��120��6�   �� 5   
   $��0��6   $��2��6    $��Annual Percentage Rate��6-   $
��Left=�6N   $��10,7,0,0q�6i   $	��Top=�6{   $	��140��6�   �� 5   
   -   5        $��
APRTextBox��5      $��1��6$   $��2��64   $
��Left=�6A   $��23��6\   $��0,10,0,0q�6h   $
 Wrap=�6z   $�� ��6�   $	��Top=�6�   $	��120��6�   �� 5   
   $��0��6   $��3��6    $��
Compute To��6-   $
��Left=�6B   $��10,7,0,0q�6]   $	��Top=�6o   $	��140��6�   �� 5   
   -   5        $��1��5      $��3��6!   $��Nearest Cents��6.   $
��Left=�6F   $��	10,10,0,0q�6a   $	��Top=�6t   $��80��6�   6�   �� 5   
   -   5        $��1��5      $��3��6!   $��Nearest Dollars��6.   $
��Left=�6H   $��
100,10,0,0q�6c   $	��Top=�6w   $��90��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��Results��5      $��0��6"   $��2��62   $��4��6F   $��10,10,10,10q�6S      RowHeaderWidth$ 0Q�6h      CanUserResizeColumns .     CanUserResizeRows .     
IsReadOnly . $	��150��6�   $	��350��6�   5      5      5       