   M S B A M L   `   `   `  ����B  >Panacea, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:PanaceaPanacea  5   	       Panacea.Productolist   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Panacea     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
      MaterialDesignBody#���   5	      $��Regular"�5
      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5       � Title$ Productolist��5   	   $��659.918��6   $��1139.171��6/    � WindowStartupLocation$ CenterScreen=�6@    � AllowsTransparency .  � WindowStyle$
 None=�6   
���   �$��1q�6�   .��5      � .+�5   
   � ���#99FFFF$��80��6$   $	��Top=�60   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��	Productos��6   $��30(�6-   $��Center=�6;   $��Showcard Gothic)�6V   5      �� 5      $��
img/vi.jpg��6   $��
0,0,-0.2,0q�6(   $��Right=�6<   �� 5      $��img/em2.jpg��6   $��0,0,114.2,0q�6)   $��Right=�6>   5      � 5   
   $	��583��6   $
��Left=�6   $��
5,87,0,1.8q�67   .+�5      �� $ Vertical=�6   .+�5      �� $ 
Horizontal=�6   $��Center=�66   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Search=�6.   $��50��6<   $��30��6G   ���	#FF1809096l   �� 5      -   5         ��Name$ 	txtbuscar��5      $	��200��61   $��1q�6a   5      &   System.Windows.Controls.DataGrid  5"      -   5        	  Name$	 	datagrid1��5"      $	��450��6.   
   CanUserAddRows
 .     
IsReadOnly . $��5q�6d    � ContextMenu 5#      �� 5$      .@�5%      m� -   5         m�Name$ productoNuevo��5%   '   $��Nuevo��6>   m� 5&      -   5        $ productUpdate��5&   '   $��	Modificar��6>   6Q   m� 5'      -   5        $ 
ItemDelete��5'   '   $��Dar de Baja��6;   5)      5+      �� 5,      $;��5Click Derecho Sobre Un Producto para ver las Opciones��6   $��Center=�6Y   5-      5/      � 50   
   $	��260��6   $��Center=�6   $��620,84,251,4q�68   .+�51      �� $ Vertical=�6   $��	-9,0,22,0q�60   .+�52      �� $��Datos del Producto��6   $��17(�66   $��Center=�6D   �� 53      -   5        $ 	txtnombre��53      {�.   ( $MaterialDesignFilledTextFieldTextBox#��[ 6?   $��12(�6}   $	��400��6�   $��70��6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Nombre Producto��6�   $��62��6�   $��12,10,17.6,0q�6�   
����� �6�   �� 54      -   5        $ 	txtprecio��54      {�.  #��[ 6?   $��12(�6}   $	��400��6�   $��70��6�   $ Precio��6�   $��62��6�   $��12,10,17.6,0q�6�   
����� �6�   �� 55      -   5        $ 	txtdescri��55      {�.  #��[ 6@   $��12(�6~   $	��400��6�   $��70��6�   $ Descripcion��6�   $��62��6�   $��12,10,17.6,0q�6�   
����� �6�   �� 56      -	   5        $ txtfecha��56      {�.  #��[ 6>   $��12(�6|   $	��400��6�   $��70��6�   $ Fecha de Vencimiento��6�   $��62��6�   $��12,10,17.6,0q�6�   
����� �6  �� 57      -
   5        $ txtstock��57      {�.  #��[ 6>   $��12(�6|   $	��400��6�   $��70��6�   $ Stock��6�   $��62��6�   $��12,10,17.6,0q�6�   
����� �6�   �� 58      -   5        $ txtcategoria��58      {�.  #��[ 6B   $��12(�6�   $	��400��6�   $��70��6�   $ 	Categoria��6�   $��62��6�   $��12,10,17.6,0q�6�   
����� �6�   �� 59      -   5        $ txtproveedor��59      {�.  #��[ 6B   $��12(�6�   $	��400��6�   $��70��6�   $ 	Proveedor��6�   $��62��6�   $��12,10,17.6,0q�6�   
����� �6�   5:      5>      � 5?   
   $	��250��6   $��Right=�6   $��0,87,4.8,4.8q�67   .+�5@      �� $ Vertical=�6   .+�5A      �� -   5         ��Name$ imagePro��5A      $	��200��6*   $	��300��66   $��10q�6C   �� 5B      -   5         ��Name$ btnExit��5B      $��SALIR��6*   $	��100��6:   $��Stretch=�6F   $��75,0,74.6,0q�6d   
���   �6�   5C      5E      5G      5H      