   M S B A M L   `   `   `  ����B  >Panacea, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:PanaceaPanacea  5   	       Panacea.Producto   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Panacea     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   -   5           MaterialDesignBody#���   5	      $��Regular"�5
      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5       � Title$ Producto��5   	   $��671.295��6   $��856.739��6+    � AllowsTransparency .  � WindowStyle$
 None=�6l    � WindowStartupLocation$ CenterScreen=�6   $��2q�6�   
���   �.��5      � .+�5   
   � ���#99FFFF$��80��6$   $	��Top=�60   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��5q�62   .+�5      �� -   5         ��Name$ 	txtTitulo��5      $��Agregar Producto��6/   $��30(�6G   $��Center=�6U   $��Showcard Gothic)�6p   5      �� 5      $��
img/vi.jpg��6   $��
0,0,-0.2,0q�6(   $��Right=�6<   �� 5      $��img/em2.jpg��6   $��0,0,114.2,0q�6)   $��Right=�6>   5      � 5   
   $	��272��6   $
��Left=�6   $��
165,82,0,0q�66   .+�5      �� $ 
Horizontal=�6   .+�5      �� $ Vertical=�6   .+�5      �� -   5         ��Name$ ComboProveedor��5      $��33,15,32.6,15q�5         MaterialDesignFilledComboBox#��[ 5      )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Seleccione el Proveedor��5      $	��200��6V   
 J� RenderTransformOrigin$
 
0.614,1.41&�6b   5      �� 5       -   5         ��Name$ 	txtnombre��5        ( $MaterialDesignFilledTextFieldTextBox#��[ 62   $��14(�6p   $	��300��6   $��70��6�   $	 Nombre del Producto��6�   $��63��6�   $��17,0,15.6,0q�6�   �� 5!      -   5        $ 	txtPrecio��5!      #��[ 61   $	 Precio��6o   $��
0,5,17.6,5q�6�   $��68��6�   $��Right=�6�   $	��236��6�   �� 5"      -   5        $ 	txtdescri��5"       * &MaterialDesignOutlinedTextFieldTextBox#��[ 5#      $	��Top=�5$      $	��100��5%       �� AcceptsReturn .  �� TextWrapping$
 Wrap=�5'      " �� VerticalScrollBarVisibility$
 Auto=�5(      $	 Descripcion��5)      $��11q�62   �� 5*      -   5        $ ComboCategoria��5,      $��1q�5*      #��[ 5+      $	 Seleccione la Categoria��5,      $	��200��6V   $
 
0.614,1.41&�6b   (  "System.Windows.Controls.DatePicker  5-      -   5          Name$ datepik1��5-   !   $	 Fecha de Vencimiento��5.      $��17(�69   
���   � ( $MaterialDesignFloatingHintDatePicker#��[ 5/      $	��240��6A   $��10q�6M   �� 50      -	   5         ��Name$ 
btnGuardar��50      $��Guardar��63   $��10q�6E   
���   �6j   �� 51      -
   5        $ btnExit��51      $��Salir��6.   $��10q�6>   
���   �6`   53      56      � 57      $��277,0,-237,-0.4q�6   .+�58      �� $��5q�6   .+�59      �� -   5        $ txtcanti��59      #��[ 61   $��14(�6o   $	��300��6~   $��70��6�   $	 Cantidad��6�   $��64��6�   $��17,10,15.4,0q�6�   �� 5:      $��Seleccione la Imagen��6   $��Center=�6;   $��5q�6X   $��17(�6c   �� 5;      -   5        $ btnfile��5;      $	��...��6.   $	��100��6<   $��5q�6H   
���   �6h   �� 5<      -   5         ��Name$ 	imgProduc��5<      $	��200��6/   $	��200��6;   5=      5?      5F      5I      5J      