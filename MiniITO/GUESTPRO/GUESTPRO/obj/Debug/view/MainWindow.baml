   M S B A M L   `   `   `  ����C  ?GUESTPRO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:GUESTPROGUESTPRO  5   	   h dSAPBusinessObjects.WPF.Viewer, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304tRclr-namespace:SAPBusinessObjects.WPF.Viewer;assembly=SAPBusinessObjects.WPF.ViewerSAPBusinessObjects.WPF.Viewer 5   	       GUESTPRO.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:GUESTPRO     5   	   eViewerRclr-namespace:SAPBusinessObjects.WPF.Viewer;assembly=SAPBusinessObjects.WPF.Viewer     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)   .��5
      � 
�������$��Stretch=�6"   $��Stretch=�6>    � RowDefinitions 5   
   �� 5      $
��0.1* �6   �� 5      $��* �6   .+�5   
   ]� 
������$��Stretch=�6(   $��Stretch=�6D   .+�5      �� $��0��6   $��GESTPRO��6%   $��Center=�64   $��Center=�6Q   $��18(�6l   
������6z   5      �� 5   
   -   5         ��Name$ 
tabControl��5   J    �� TabStripPlacement$
 Left=�6   $��10,20q�6.   $��1��6=   
������� � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType	 �� CornerRadius
 �� Padding��%z  '��       �� 5      " ��6   .�5      ��  � �� 5      �� 5      " ��6.   .R�5   "   � .+�5   &   �� #��z��6-   
���   �$��2q�5   2   $	 5��5      $
 5q�6/   ._�5   *   �� $��Header��6;   $��Center=�5   ,   5   '   5    #   5!      5#      �� 5$       � ��
 ����63   �� 5%       � ��
 �   �63   5&      5'      .@�5(      �� $��INICIO��6   
������.��5)      � $��Stretch=�6   $��Stretch=�63    � ColumnDefinitions 5*      �� 5+      $
��0.6* �6+   �� 5,      $
��0.6* �6+   �� 5-      $��* �6+   .+�5/      ��  �� Orientation$ Vertical=�6!   $��0��68   $��Stretch=�6H   $��Stretch=�6d   .+�50      �� -   5         ��Name$ btnProyecto��50   5   $��	PROYECTOS��6!   $��0,90,0,0q�6J   $	��160��6\   
������6|   �� 51      -   5        $ btnEmpleado��51   5   $��	EMPLEADOS��6!   $��0,15,0,0q�6J   $	��160��6\   
������6|   �� 52      -   5        $ 
btnGestion��52   6   $��
G.ECONOMIA��6!   $��0,15,0,0q�6J   $	��160��6]   
������6}   53      �� 54      $��1��6!   $��Stretch=�61   $��Stretch=�6M   .+�55      �� -   5        $ btnEstadisticas��55   8   $��ESTADÍSTICAS��6!   $��0,90,0,0q�6Q   $	��160��6c   
������6�   �� 56      -   5        $ btnUsuarios��56   4   $��USUARIOS��6!   $��0,15,0,0q�6I   $	��160��6[   
������6{   57      � 58      $��3��6   $��Stretch=�6+   $��Stretch=�6G    59      �� 5:      $��* �6,   �� 5;      $
��0.3* �6,   .+�5=      ]� $��0��6$   $��Stretch=�61   $��Stretch=�6M   .+�5>      �� 
 � Tag$
 Hoja��6$   $��../img/hoja.png��6/   $	��160��6H   $��5,0,0,0q�6T   $
��Left=�6e   �� 5?      $y�Hidden=�6(   5@      ]� 5A      $��1��6$   $��Stretch=�61   $��Stretch=�6M   .+�5B      �� $
 Logo��6$   $��../img/logoMaestre.png��6/   $	��250��6O   $��Right=�6[   �� 5C      $y�Hidden=�6(   5D      5E      5F      5G      �� 5H      -   5         ��Name$ itemProyecto��5H   <   $��PROYECTO��6   
������.��5I      � $��Stretch=�6   $��Stretch=�63    5J      �� 5K      $��* �6+   �� 5L      $
��0.8* �6+    5N      �� 5O      $��* �6(   �� 5P      $
��0.2* �6(   .+�5R      �� $��0��6!   $��0��6.   $ Vertical=�6>   $��Stretch=�6U   $��Stretch=�6q   .+�5S      �� -   5         ��Name$ 
textBuscar��5S   6   $��
50,50,50,0q�6"   6J   �� 5T      -	   5         ��Name$ listProyects��5T   6   $��
50,10,50,0q�6"   
���   �6L   &   System.Windows.Controls.DataGrid  5U      -
   5          Name$ dataProyecto��5U   J   $��5q�6#      AutoGenerateColumns .     Columns 5V      0  *System.Windows.Controls.DataGridTextColumn  5W   "   ,  &System.Windows.Controls.DataGridColumn   Header$ 
IdProyecto��65   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6I   �� *
idproyecto+  5X   "   $ Codigo Proyecto��65    6N   �� *
codigoproy+  5Y   "   $ Nombre��65    6E   �� *
nombreproy+  5Z   "   $ Descripcion��65    6J   �� *
descproy+  5[   "   $ Presupuesto��65    6J   �� *presupuesto+5]      5^      �� 5_      $ Vertical=�6!   $��0��68   $��1��6E   $��Stretch=�6U   $��Stretch=�6q   .+�5`      ]� $��Stretch=�6$   $��Stretch=�6@   .+�5a      �� -   5        $ btnCargarDat��5a   x   $��CARGAR DATOS��6%   $	��100��6<   $��	20,10,0,0q�6H   
������$
��Left=�6�   �� 5b      $y�Hidden=�6(   5c      ]� 5d      $��Stretch=�6$   $��Stretch=�6@   .+�5e      �� -   5         ��Name$ imgHoja2��5e   $   $
 Hoja��66   $��../img/hoja.png��6A   $��50��6Z   $��80��6f   $��0,0,21,0q�6q   $��Right=�6�   �� 5f      $y�Hidden=�6(   5g      ]� 5h      $��Stretch=�6$   $��Stretch=�6@   .+�5i      �� $��Código Proyecto��6$   $	��100��6>   $
��Left=�6J   $��30,0,0,0q�6`   �� 5j      $y�Hidden=�6(   5k      ]� 5l      $��Stretch=�6$   $��Stretch=�6@   .+�5m      �� -   5        $ txtCodigoProy��5m   &   $	��240��6=   $��20��6I   $
��Left=�6U   $��20,0,0,0q�6k   �� 5n      $y�Hidden=�6(   5o      ]� 5p      $��Stretch=�6$   $��Stretch=�6@   .+�5q      �� $��Nombre��6$   $	��100��65   $
��Left=�6A   $��30,0,0,0q�6W   �� 5r      $y�Hidden=�6(   5s      ]� 5t      $��Stretch=�6$   $��Stretch=�6@   .+�5u      �� -   5        $ txtNombreProy��5u   &   $	��240��6=   $��20��6I   $
��Left=�6U   $��20,0,0,0q�6k   �� 5v      $y�Hidden=�6(   5w      ]� 5x      $��Stretch=�6$   $��Stretch=�6@   .+�5y      �� $��Descripcion��6$   $	��100��6:   $
��Left=�6F   $��30,0,0,0q�6\   �� 5z      $y�Hidden=�6(   5{      ]� 5|      $��Stretch=�6$   $��Stretch=�6B   .+�5}      �� -   5        $ txtDescProy��5}   &   $	��240��6;   $��20��6G   $
��Left=�6S   $��20,0,0,0q�6i   �� 5~      $y�Hidden=�6(   5      ]� 5�      $��Stretch=�6$   $��Stretch=�6@   .+�5�      �� $��Presupuesto��6$   $	��100��6:   $
��Left=�6F   $��30,0,0,0q�6\   �� 5�      $y�Hidden=�6(   5�      ]� 5�      $��Stretch=�6$   $��Stretch=�6@   .+�5�      �� -   5        $ txtPresupuestoProy��5�   &   $	��240��6B   $��20��6N   $
��Left=�6Z   $��20,0,0,0q�6p   �� 5�      $y�Hidden=�6(   5�      5�      �� 5�      $ 
Horizontal=�6!   $��1��6:   $��0��6G   $��Stretch=�6W   $��Stretch=�6s   .+�5�      �� -   5        $ imgLogo1��5�       $
 Logo��62   $��../img/logoMaestre.png��6=   $	��178��6]   $��49��6i   $��0,0,50,0q�6u   �� 5�      -   5        $ 
btnAñadir��5�   !   $	��120��64   $��20��6@   $��AÑADIR��6L   $��0,0,20,0q�6]   
������6�   5�      �� 5�      $ 
Horizontal=�6!   $��1��6:   $��1��6G   $��Stretch=�6W   $��Stretch=�6s   .+�5�      �� -   5        $ btnModificar��5�   !   $	��120��67   $��20��6C   $��	MODIFICAR��6O   
������6~   �� 5�      -   5        $ btnEliminar��5�   !   $	��120��66   $��20��6B   $��ELIMINAR��6N   $��30,0,0,0q�6a   
������6�   5�      5�      5�      �� 5�      $��	EMPLEADOS��6   
������.��5�      � $��Stretch=�6   $��Stretch=�63    5�      �� 5�      $��2* �6+   �� 5�      $��* �6+    5�      �� 5�      $��5* �6(   �� 5�      $��* �6(   .+�5�      � $��0��6   $��Stretch=�6,   $��Stretch=�6H    5�      �� 5�      $��4* �6,   �� 5�      $��1* �6,   .+�5�      �� $��0��6"   $��9q�6/     5�      -   5        $ dtgEmpleados��5�   L   $��0��6#    .  $��9q�6b    5�        5�   "   $ 
IdEmpleado��65    6I   �� *
idempleado+  5�   "   $ Nombre��65    6E   �� *	nombreemp+  5�   "   $ 	Apellidos��65    6H   �� *	apellidos+  5�   "   $	 CSR��65    6B   �� *csr+  5�   "   $	 Rol��65    6B   �� *nombrerolemple+5�      �� 5�      $ Vertical=�6%   $��1��6<   $��Stretch=�6I   $��Stretch=�6e   .+�5�      �� -   5         ��Name$ chkUser��5�   �   $��Usuario no registrado��6'   $	��150��6G   $
��Left=�6S   $��20,0,0,0q�6n   6�   ]� 5�      $��Stretch=�6(   $��Stretch=�6D   .+�5�   "   �� -   5        $ btnAddEmpleado��5�   �   $��AÑADIR��6)   $��90��6:   $��20��6E   $��Right=�6Q   $��0,0,9,0q�6h   
������6�   �� 5�   "   $y�Hidden=�6,   5�      5�      5�      � 5�      $��1��6   $��0��6+   $��Stretch=�68   $��Stretch=�6T    5�      �� 5�      $��* �6,   �� 5�      $
��0.3* �6,   .+�5�      �� $ Vertical=�6%   $��0��6<   .+�5�      �� $��Nombre��6$   �� 5�      -   5        $ txtNombreEmple��5�   2   $	��200��6&   62   �� 5�      $��	Apellidos��6$   �� 5�      -   5        $ txtApellidoEmple��5�   2   $	��200��6&   62   �� 5�      $	��ROL��6$   �� 5�      -   5         ��Name$ cbRoles��5�   3   $	��200��6'   63   �� 5�      $	��CSR��6$   �� 5�      -   5        $ txtCsr��5�   2   $	��200��6&   62   5�      �� 5�      $ 
Horizontal=�6%   $��1��6>   $��Stretch=�6K   $��Stretch=�6g   $��0,0,0,0q�6�   .+�5�      ]� $��Stretch=�6(   $��Stretch=�6D   .+�5�   "   �� -   5        $ btnModifyEmpleado��5�   �   $��	MODIFICAR��6)   $��90��6=   $��20��6H   $	��Top=�6T   $��0,24,0,0q�6i   
������6�   �� 5�   "   $y�Hidden=�6,   5�      ]� 5�      $��Stretch=�6(   $��Stretch=�6D   .+�5�   "   �� -   5        $ btnDelEmpleado��5�   �   $��ELIMINAR��6)   $��90��6<   $��20��6G   $	��Top=�6S   $��9,24,0,0q�6h   
������6�   �� 5�   "   $y�Hidden=�6,   5�      5�      5�      �� 5�      $ 
Horizontal=�6!   $��0��6:   $��2��6J   $��2��6^   .+�5�      �� -   5        $ 
cbUsuarios��5�   i   $	��130��6#   $��20��6/   $
��Left=�6;   $��	60,10,0,0q�6V   6i   �� 5�      $ Vertical=�6%   $��Center=�6<   $��60,0,0,0q�6Y   .+�5�      �� -   5         ��Name$ 	lbUsuario��5�   6   $��Usuario��6$   66   �� 5�      -    5        $ txtRegUsuario��5�   2   $	��100��6&   62   5�      �� 5�      $ Vertical=�6%   $��Center=�6<   $��60,0,0,0q�6Y   .+�5�      �� -!   5        $ 
lbPassword��5�   7   $��Password��6$   67   �� 5�      -"   5        $ txtRegPassword��5�   2   $	��100��6&   62   5�      �� 5�      -#   5        $ btnRegistrarUsuario��5�   �   $��Registrar y recargar��6!   $��25��6@   $��Right=�6L   $��50,7,0,0q�6h   
������6�   5�      5�      5�      �� 5�      $��
G.ECONOMIA��6   
������.��5�      � $��Stretch=�6   $��Stretch=�63    5�      �� 5�      $
��2.2* �6+   �� 5�      $��* �6+    5�      �� 5�      $
��1.6* �6(   �� 5�      $��* �6(   .+�5�      �� $ Vertical=�6!   $��0��68   $��Stretch=�6H   $��Stretch=�6d   .+�5�        -$   5        $ 
dtgGestion��5�   ?    .  $��0,10,0,0q�6S    5�        5�   "   $ NombreProyecto��65    6M   �� *nombreproygestion+  5�   "   $ NombreEmpleado��65    6M   �� *nombreempgestion+  5�   "   $ Fecha��65    6D   �� *fecha+  5�   "   $ Costes��65    6E   �� *costes+  5�   "   $ Horas��65    6D   �� *horas+5�      5�      �� 5�      $ 
Horizontal=�6!   $��0��6:   $��1��6J   $��Stretch=�6W   $��Stretch=�6u   $��0,0,0,10q�6�   .+�5�      �� -%   5        $ btnImputHoras��5�   �   $��Imputar horas��6!   $	��120��69   $��20��6E   $��80,0,0,0q�6Q   
������6�   �� 5�      -&   5        $ btnModificarGestion��5�   �   $��	Modificar��6!   $	��120��66   $��20��6B   $��10,0,0,0q�6N   
������6�   �� 5�      -'   5        $ btnEliminarGestion��5�      $��Eliminar��6!   $	��120��64   $��20��6@   $��10,0,0,0q�6L   
������6�   5�      �� 5�      $ Vertical=�6!   $��1��68   $��Stretch=�6H   $��Stretch=�6f   .+�5�      �� $��Proyecto��6    �� 5�      -(   5        $ cbProyectos��5�   /   $	��200��6#   6/   �� 5�      $��Empleado��6    �� 5�      -)   5        $ cbEmpleados��5�   /   $	��200��6#   6/   �� 5�      $��Fecha��6    �� 5�      -*   5        $ txtFecha��5�   .   $	��200��6"   6.   �� 5�      $��Horas��6    �� 5�      -+   5        $ txtHoras��5�   .   $	��200��6"   6.   5      5     5     �� 5     $��ESTADÍSTICAS��6   
������.��5     � $��Stretch=�6   $��Stretch=�63    5     �� 5     $��* �6(   �� 5     $��6* �6(   .+�5
     �� $ 
Horizontal=�6!   $��0��6;   $��Stretch=�6H   $��Stretch=�6d   .+�5     �� -,   5        $ 
cbInformes��5  #   $	��150��67   $��20��6C   $��90,0,0,0q�6O   .@�5     �� .��6+   TOTAL POR MES6:   �� 5     .��6+   INFORMACION PROYECTO6A   5     �� 5     --   5        $ btnCargarInforme��5  !   $	��120��6;   $��20��6G   $��CARGAR INFORME��6S   $��20,0,0,0q�6l   6~   5     8  2SAPBusinessObjects.WPF.Viewer.CrystalReportsViewer  5     -.   5          Name$ visor��5  ?   $��1��62   $��Stretch=�6N   $��Stretch=�6j   5     5     �� 5     $��USUARIOS��6   
������.��5     � $��Stretch=�6   $��Stretch=�65    5     �� 5     $��* �6+   �� 5     $��* �6+    5     �� 5     $��5* �6(   �� 5     $��* �6(   .+�5     �� $ Vertical=�6!   $��0��68   .+�5        -/   5        $ dtgUsuarios��5   ?    .  
�������$��Stretch=�6k   $��Stretch=�6�   $��30q�6�    5!       5"  "   $ 	IdUsuario��65    6H   �� *	idusuario+  5#  "   $ Nombre��65    6E   �� *nombreusuario+5%     5&     �� 5'     $ 
Horizontal=�6!   $��0��6:   $��1��6J   $��Stretch=�6W   $��Stretch=�6s   .+�5(     �� -0   5        $ 	btnDarAlt��5(  {   $��Dar de Alta��6!   $	��120��67   $��20��6C   $��	200,0,0,0q�6O   
������6�   5)     � 5*     $��1��6   $��0��6+   $��Stretch=�68   $��Stretch=�6V    5+     �� 5,     $��* �6/   �� 5-     $��3* �6/   .+�5/     � $��1��6    $��Stretch=�60   $��Stretch=�6L    50     �� 51  "   $��* �60   �� 52  "   $
��1.6* �60   .+�54     �� $ Vertical=�6)   $��1��6@   $��Stretch=�6M   $��Stretch=�6k   .+�55  "   ]� $��Stretch=�6,   $��Stretch=�6H   $��0,10,0,0q�6f   .+�56  &   �� $��Usuario��6,   $��61��6>   $��27��6I   $
��Left=�6U   �� 57  &   $y�Hidden=�60   58  #   ]� 59  "   $��Stretch=�6,   $��Stretch=�6J   $��0,0,0,10q�6f   .+�5:  &   �� -1   5        $ 
txtUsuario��5:  ;   $	��200��6.   $
��Left=�6O   �� 5;  &   $y�Hidden=�60   5<  #   ]� 5=  "   $��Stretch=�6,   $��Stretch=�6J   .+�5>  &   �� $��Password��6,   $��61��6?   $��27��6J   $
��Left=�6V   �� 5?  &   $y�Hidden=�60   5@  #   ]� 5A  "   $��Stretch=�6,   $��Stretch=�6J   .+�5B  &   �� -2   5        $ txtPassword��5B  :   $	��200��6.   $
��Left=�6O   �� 5C  &   $y�Hidden=�60   5D  #   5E     5F     5G     �� 5H     $ 
Horizontal=�6!   $��1��6:   $��1��6J   .+�5I     �� -3   5        $ btnDelUsuario��5I  i   $��Eliminar��6!   $	��120��64   $��20��6@   
������6�   �� 5J     -4   5        $ btnActualizarContraseña��5J  �   $��Actualizar Contraseña��6!   $	��120��6A   $��20��6M   $��20,0,0,0q�6Y   
������6�   5K     5L     5M     5N     5O     5P     