   M S B A M L   `   `   `  ���� B  >GESTPRO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:FormularioExamenFormularioExamen  !    FormularioExamen.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:FormularioExamen       � Title$  
MainWindow��$	��450��$	��800��.��� 
�������$��Stretch=�$��Stretch=� � RowDefinitions �� $
��0.1* ��� $��* �.+�]� 
������$��Stretch=�$��Stretch=�.+��� $��0��$��GESTPRO��$��Center=�$��Center=�$��18(�
��������  �� TabStripPlacement$
 Left=�$��10,20q�$��1��
������� � 	Resources  �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius	 �� Padding��%�   '��       �� " ��.���  � �� �� " ��.R�� .+��� #��z��
���   �$��2q�$ 5��$	 5q�._��� $��Header��$��Center=���  � ��
 ������  � ��
 �   �.@��� $��INICIO��
������.��� 
 � ColumnDefinitions
 �� $
��0.4* ��� $
��0.4* ��� $��* �.+��� $��0��.+���  �� Orientation$ Vertical=�$��10, 60,10,0q�$��0��.+��� $��	PROYECTOS��
�������� $ Vertical=�$��
10,20,10,0q�.+��� $��	EMPLEADOS��
�������� $ Vertical=�$��10, 20,10,0q�$��0��.+��� $��
G.ECONOMIA��
�������� $��1��.+��� $ Vertical=�$��
10,60,10,0q�$��1��.+��� $��ESTADÍSTICAS��
�������� $ Vertical=�$��
10,20,10,0q�$��1��.+��� $��USUARIOS��
������]� $��3��.+��� -    ��Name$ imgHoja��
 � Tag$
 Hoja��$��../img/hoja.png��$	��217��$	��171��$
��Left=��� -   $ imgLogo��$
 Logo��$��../img/logoMaestre.png��$��64��$	��203��$��Bottom=��� $	��Top=��� -    ��Name$ itemProyecto��$��PROYECTO��
������.��� $��Stretch=�$��Stretch=�
 �� $��* ��� $
��0.8* � �� $��* ��� $
��0.2* �.+��� $��0��$��0��$ Vertical=�$��Stretch=�$��Stretch=�.+��� -   $��
textBuscar��$��
50,50,50,0q��� -    ��Name$ listProyects��$��
50,10,50,0q�
���   �&   System.Windows.Controls.DataGrid  -   $��dataProyecto��$��7q�   AutoGenerateColumns$ False��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 
IdProyecto��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *id+  $ Codigo Proyecto�� �� *
cod_proy+  $ Nombre�� �� *name+  $ Descripcion�� �� *
dscripcion+  $ Presupuesto�� �� *presupuesto+�� $ Vertical=�$��0��$��1��$��Stretch=�$��Stretch=�.+�]� $��Stretch=�$��Stretch=�.+��� -    ��Name$ btnCargarDat��$��CARGAR DATOS��$	��100��$��0,10,0,0q�
������$
��Left=��� $y�Hidden=�]� $��Stretch=�$��Stretch=�.+��� -   $ imgHoja2��$
 Hoja��$��../img/hoja.png��$��50��$��80��$��0,0,21,0q�$��Right=��� $y�Hidden=�]� $��Stretch=�$��Stretch=�.+��� $��Código Proyecto��$	��100��$
��Left=�$��30,0,0,0q��� $y�Hidden=�]� $��Stretch=�$��Stretch=�.+��� -	    ��Name$ txtCodigoProy��$	��240��$��20��$
��Left=�$��20,0,0,0q��� $y�Hidden=�]� $��Stretch=�$��Stretch=�.+��� $��Nombre��$	��100��$
��Left=�$��30,0,0,0q��� $y�Hidden=�]� $��Stretch=�$��Stretch=�.+��� -
   $ textNombreProy��$	��240��$��20��$
��Left=�$��20,0,0,0q��� $y�Hidden=�]� $��Stretch=�$��Stretch=�.+��� $��Descripcion��$	��100��$
��Left=�$��30,0,0,0q��� $y�Hidden=�]� $��Stretch=�$��Stretch=�.+��� -   $ txtDescProy��$	��240��$��20��$
��Left=�$��20,0,0,0q��� $y�Hidden=�]� $��Stretch=�$��Stretch=�.+��� $��Presupuesto��$	��100��$
��Left=�$��30,0,0,0q��� $y�Hidden=�]� $��Stretch=�$��Stretch=�.+��� -   $ txtPresupuestoProy��$	��240��$��20��$
��Left=�$��20,0,0,0q��� $y�Hidden=��� $ 
Horizontal=�$��1��$��0��$��Stretch=�$��Stretch=�.+��� -   $ imgLogo1��$
 Logo��$��../img/logoMaestre.png��$	��178��$��49��$��0,0,50,0q��� -   $ 
btnAñadir��$	��120��$��20��$��AÑADIR��$��0,0,20,0q�
�������� $ 
Horizontal=�$��1��$��1��$��Stretch=�$��Stretch=�.+��� -   $ btnModificar��$	��120��$��20��$��	MODIFICAR��
�������� -   $ btnEliminar��$	��120��$��20��$��ELIMINAR��$��30,0,0,0q�
�������� $��	EMPLEADOS��
������.��� $��Stretch=�$��Stretch=�
 �� $��* ��� $��* � �� $	��27* ��� $
��255* ��� $	��67* �.+��� $ Vertical=�$��0��$��0��$��
0,0,342,20q�$��2��$��2��.+��� $��0��$��9q�  -     Name$ dtgEmpleados��$ False��$��9q�   $ 
IdEmpleado�� �� *Id+  $ Nombre�� �� *Name+  $ 	Apellidos�� �� *	Apellidos+  $	 CRS�� �� *Crs+�� $ Vertical=�$��0��$��1��$��0,170,342,0q�$	��Top=�$��2��.+��� -   $��chkUser��$��Usuario ya registrado��$	��150��$
��Left=�$��20,0,0,0q��� $��Usuario no registrado��$	��150��$
��Left=�$��20,5,0,0q�]� $��Stretch=�$��Stretch=�.+��� -   $ btnAddEmpleado��$��AÑADIR��$��90��$��20��$��Right=�$��0,0,9,0q�
�������� $y�Hidden=�� $��1��$��1��$��Stretch=�$��Stretch=� �� $��* ��� $
��0.3* �.+��� $ Vertical=�$��0��.+��� $��Nombre��$��Center=�$��0,0,40,0q��� -   $��txtNombreEmpleado��$	��200��$��Center=�$��60,0,0,0q��� $��	Apellidos��$��Center=�$��0,0,30,0q��� -   $��txtApellidoEmpleado��$	��200��$��Center=�$��60,0,0,0q��� $	��ROL��$��Center=�$��0,0,60,0q��� -   $��cbRoles��$	��200��$��Center=�$��60,0,0,0q�  �� SelectedItem � 	StaysOpen��%s  '��       �� " ��.���  � �� �� " ��.R�� .+��� 
������
���   �._�� .+�d� $��ToggleButton��
������ $��0q�$��2��]� .+��� $	��▼��$��Right=�$��0,0,5,0q��� $y�Hidden=��� $��ContentPresenter��#��z $��Center=�$	��5,0q�� $��Popup��$��Bottom=�$ False��.���� 
�������
���   �._��� .���� .+��� .@��� $��PROGRAMADOR_JUNIOR���� $��PROGRAMADOR���� $��PROGRAMADOR_SENIOR���� $��JEFE_PROYECTO���� $	��CSR��$��Center=�$��0,0,60,0q��� -   $��txtCSR��$	��200��$��Center=�$��60,0,0,0q��� $ 
Horizontal=�$��1��$��Stretch=�$��Stretch=�$��0,0,0,0q�.+�]� $��Stretch=�$��Stretch=�.+��� -   $ btnModifyEmpleado��$��	MODIFICAR��$��90��$��20��$	��Top=�$��0,9,0,0q�
�������� $y�Hidden=�]� $��Stretch=�$��Stretch=�.+��� -   $ btnDelEmpleado��$��ELIMINAR��$��90��$��20��$	��Top=�$��9,9,0,0q�
�������� $y�Hidden=��� $ 
Horizontal=�$��0��$��2��$��2��.+��� -   $��
cbUsuarios��$	��130��$��20��$
��Left=�$��60,0,0,0q� ��%s  '��       �� " ��.���  � �� �� " ��.R�� .+��� 
������
���   �._�� .+�d� $��ToggleButton��
������ $��0q�$��2��]� .+��� $	��▼��$��Right=�$��0,0,5,0q��� $y�Hidden=��� $��ContentPresenter��#��z $��Center=�$	��5,0q�� $��Popup��$��Bottom=�$ False��.���� 
�������
���   �._��� .���� .+��� �� $ Vertical=�$��Center=�$��60,0,0,0q�.+��� $��Usuario���� -   $��txtRegUsuario��$	��100���� $ Vertical=�$��Center=�$��60,0,0,0q�.+��� $��Password���� -   $��txtRegPassword��$	��100���� -   $ btnRegistrarUsuario��$��Registrar y recargar��$��25��$��Right=�$��50,0,0,0q�
�������� $��
G.ECONOMIA��
������.��� 
 �� $��* ��� $��* �.+��� $ Vertical=�$��0��.+�  -   $ 
dtgGestion��$ False��$��0,5,0,0q�   $ NombreEmpleado��  $ NombreProyecto��  $ Hours��  $
 Date���� $ 
Horizontal=�$��Bottom=�$��0,0,0,20q�.+�]� $��Stretch=�$��Stretch=�.+��� -   $ btnImputHoras��$��Imputar horas��$��Bottom=�$��90��$��	250,0,0,0q�
�������� $ Vertical=�$��1��.+��� $��Proyecto��$��Center=�$��0,0,40,0q��� -    $��cbProyectos��$	��200��$��Center=�$��60,0,0,0q� ��%s  '��       �� " ��.���  � �� �� " ��.R�� .+��� 
������
���   �._�� .+�d� $��ToggleButton��
������ $��0q�$��2��]� .+��� $	��▼��$��Right=�$��0,0,5,0q��� $y�Hidden=��� $��ContentPresenter��#��z $��Center=�$	��5,0q�� $��Popup��$��Bottom=�$ False��.���� 
�������
���   �._��� .���� .+��� �� $��Empleado��$��Center=�$��0,0,30,0q��� -!   $��cbEmpleados��$	��200��$��Center=�$��60,0,0,0q� ��%s  '��       �� " ��.���  � �� �� " ��.R�� .+��� 
������
���   �._�� .+�d� $��ToggleButton��
������ $��0q�$��2��]� .+��� $	��▼��$��Right=�$��0,0,5,0q��� $y�Hidden=��� $��ContentPresenter��#��z $��Center=�$	��5,0q�� $��Popup��$��Bottom=�$ False��.���� 
�������
���   �._��� .���� .+��� �� $��Fecha��$��Center=�$��0,0,60,0q��� -"   $��txtFecha��$	��200��$��Center=�$��60,0,0,0q��� $��Horas��$��Center=�$��0,0,60,0q��� -#   $��txtHoras��$	��200��$��Center=�$��60,0,0,0q��� $ 
Horizontal=�$��Bottom=�$��0,0,0,20q�$��1��.+��� -$   $ btnModificarGestion��$��	Modificar��$
��Left=�$��90��$��10,0,0,0q�
�������� -%   $ btnEliminarGestion��$��Eliminar��$��90��$��15,0,0,0q�
�������� $��ESTADÍSTICAS��
�������� $��USUARIOS��
������.��� $��Stretch=�$��Stretch=�
 �� $��* ��� $��* � �� $��5* ��� $��* �.+��� $ Vertical=�$��0��.+�  -&   $ dtgUsuarios��$ False��
�������$��Stretch=�$��Stretch=�$��30q�   $ 	IdUsuario�� �� *Id+  $ Nombre�� �� *Name+�� $ 
Horizontal=�$��0��$��1��$��Stretch=�$��Stretch=�.+��� -'   $ 	btnDarAlt��$��Dar de Alta��$	��120��$��20��$��	200,0,0,0q�
������� $��1��$��0��$��Stretch=�$��Stretch=�
 �� $��* ��� $��3* �.+�� $��1��$��Stretch=�$��Stretch=� �� $��* ��� $
��1.6* �.+��� $ Vertical=�$��1��$��Stretch=�$��Stretch=�.+�]� $��Stretch=�$��Stretch=�$��0,10,0,0q�.+��� $��Usuario��$��61��$��27��$
��Left=��� $y�Hidden=�]� $��Stretch=�$��Stretch=�$��0,0,0,10q�.+��� -(   $ 
txtUsuario��$	��200��$
��Left=��� $y�Hidden=�]� $��Stretch=�$��Stretch=�.+��� $��Password��$��61��$��27��$
��Left=��� $y�Hidden=�]� $��Stretch=�$��Stretch=�.+��� -)   $ txtPassword��$	��200��$
��Left=��� $y�Hidden=��� $ 
Horizontal=�$��1��$��1��.+��� -*   $ btnDelUsuario��$��Eliminar��$	��120��$��20��
�������� -+   $ btnActualizarContraseña��$��Actualizar Contraseña��$	��120��$��20��$��20,0,0,0q�
������