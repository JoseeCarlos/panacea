   M S B A M L   `   `   `  ����B  >Panacea, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:PanaceaPanacea  5   	   d `Microsoft.Maps.MapControl.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPFMicrosoft.Maps.MapControl.WPF 5   
       Panacea.VentanaProve   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Panacea     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   ZmRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPF  5   
   -   5           MaterialDesignBody#���   5	      $��Regular"�5
      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5       � Title$ VentanaProve��5   	   $��634.718��6   $��1078.516��6/    � AllowsTransparency .  � WindowStyle$
 None=�6q    � WindowStartupLocation$ CenterScreen=�6�   .��5      � $��
0,0,2,-0.2q�6   .+�5   
   � ���#99FFFF$��80��6$   $	��Top=�60   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Lista de Proveedores��6   $��30(�68   $��Center=�6F   $��Showcard Gothic)�6a   5      �� 5      $��
img/vi.jpg��6   $��
0,0,-0.2,0q�6(   $��Right=�6<   �� 5      $��img/em2.jpg��6   $��0,0,114.2,0q�6)   $��Right=�6>   5      � 5   
   $	��300��6   $
��Left=�6   $��0,82,0,0q�66   .+�5      �� $��Center=�6   $ Vertical=�66   $��
0,0,0,-0.4q�6M   .+�5      �� $��Modificar Proveedor ��6   $��25(�68   $��10q�6F   
���   � �� TextAlignment$ Center=�6e   $��Arial Black)�6|   �� 5      -   5         ��Name$ 	combopais��5      $
��0 15q�5         MaterialDesignFilledComboBox#��[ 5      )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Seleccione el Pais��5!      $	��256��5"      5$      �� 5%      -   5        $ combociudad��5'      #��[ 5&      $	 Seleccione la Ciudad��5)      $	��256��5*      5,      �� 5-      -   5        
 ��Name$
 	txtnombre��5-       ( $MaterialDesignFilledTextFieldTextBox#��[ 6.   $��17(�6l   $	��400��6{   $��70��6�   $	 Nombre Proveedor��6�   $��69��6�   $��
12,10,18,0q�6�   �� 5.      -   5        $
 txtdirec��5.      #��[ 6-   $��17(�6k   $	��400��6z   $��70��6�   $	 	Direccion��6�   $��69��6�   $��
16,10,15,0q�6�   �� 5/      -   5        $
 txtTelefono��5/      #��[ 60   $��17(�6n   $	��400��6}   $��70��6�   $	 Telefono��6�   $��69��6�   $��
16,10,12,0q�6�   �� 50      -   5         ��Name$ btnmodificar��50      
���   �$��	Modificar��6B   $��Center=�6V   $��10q�6s   $	��101��6�   6�   �� 51      -   5        $ 	btnCancel��51      
���   �$��Cancelar��6?   $��Center=�6R   $	��103��6q   $��1��6}   6�   52      53      � 54   
   $��327,82,360,-0.2q�6   .+�55      �� $ Vertical=�6   .+�56      �� $��	Ubicacion��6   $��19(�6-   $ Center=�6;   
���   �$��Arial Black)�6e   '  !Microsoft.Maps.MapControl.WPF.Map  57      -	   5          Name$ myMap��57      $	��400��6'   +  %Microsoft.Maps.MapControl.WPF.MapCore   CredentialsProviderT  NMicrosoft.Maps.MapControl.WPF.Design.ApplicationIdCredentialsProviderConverter$F @AlRJpzgX-PTCB1V_d9mNmyezG45V1rwt6khgeBKas3DxDqe2RuNV0o9Hjtqpz1gw 64      	ZoomLevel$ 12Q�6�      Center<  6Microsoft.Maps.MapControl.WPF.Design.LocationConverter$ -17.387324 ,-66.166499 6�   6�   �� 58      $ 
Horizontal=�6   $
��0,20q�66   .+�59      �� -
   5        $ btnsatelite��59      
���   �$��Satelite��6E   $	��100��6X   $��	40 0 10 0q�6d   6w   �� 5:      -   5        $ 	btncalles��5:      
���   �$��Calles��6C   $	��100��6T   6`   �� 5;      -   5        $ btnmas��5;      
���   �$��+��6@   $��10q�6L   6X   �� 5<      -   5        $ btnmenos��5<      
���   �$��-��6B   6N   5=      5?      5@      � 5A   
   $	��354��6   $��Right=�6   $��0,80,0,0q�67   .+�5B      �� $ Vertical=�6   .+�5C      �� $��Proveedores��6   $��20(�6/   
���   �$ Center=�6P   $��Arial Black)�6g   &   System.Windows.Controls.DataGrid  5D      -   5          Name$ 	datagrid1��5D      $	��400��6.   $��16,10,20.6,10q�6;   6R   �� 5E      $ 
Horizontal=�6   $��10q�66   .+�5F      �� -   5        $ btnEliminar��5F      
���   �$��	Eliminar ��6E   $
��50,5q�6Y   6g   �� 5G      -   5        $ btnCancelar��5G      
���   �$��Cancelar��6E   6X   5H      5I      5J      5L      5M      