   M S B A M L   `   `   `  ����I  EDataGridPerson, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:DataGridPersonDataGridPerson  5   	       DataGridPerson.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:DataGridPerson     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� $
��Name��6   $
��Left=�6   $��	24,23,0,0q�6:   $	��Top=�6M   �� 5   
   -   5        $��nameText��5   �   $
��Left=�6   $��	56,49,0,0q�6-    �� TextWrapping$
 Wrap=�6@   $�� ��6T   $	��Top=�6\   $	��120��6t   6�   �� 5   
   $��Surname��6   $
��Left=�6"   $��	24,72,0,0q�6=   $	��Top=�6P   �� 5   
   -   5        $��surnameText��5   �   $
��Left=�6   $��	56,98,0,0q�6-   $
 Wrap=�6@   $�� ��6T   $	��Top=�6\   $	��120��6t   6�   �� 5   
   $	��Age��6   $
��Left=�6   $��
24,116,0,0q�69   $	��Top=�6M   �� 5   
   -   5        $��ageText��5   �   $
��Left=�6   $��
56,138,0,0q�6-   $
 Wrap=�6A   $�� ��6U   $	��Top=�6]   $	��120��6u   6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��
dataPerson��5   G      AutoGenerateColumns$ false��6   $��206,10,159,152q�6/      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Name+  5      $ Surname��6%    66   �� *	SurName+  5      $	 Age��6%    62   �� *Age+5      �� 5   
   -   5        $��
btnAgregar��5   �   $��
Add Person��6   $
��Left=�6&   $��
56,309,0,0q�6A   $	��Top=�6U   $��40��6m   $	��146��6y   6�   �� 5   
   -   5        $��btnModificar��5   �   $��Modify��6   $
��Left=�6"   $��202,309,0,0q�6=   $	��Top=�6R   $��40��6j   $	��146��6v   6�   �� 5   
   -   5        $��btnEliminar��5   �   $��Delete��6   $
��Left=�6"   $��348,309,0,0q�6=   $	��Top=�6R   $��40��6j   $	��146��6v   6�   5      5      