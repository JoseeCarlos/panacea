   M S B A M L   `   `   `  ����B  >Panacea, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:PanaceaPanacea  5   	       Panacea.ViewVenta   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Panacea     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5           MaterialDesignBody#���   5	      $��Regular"�5
      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5       � Title$ 	ViewVenta��5   	   $��734.523��6   $��1159.139��6,    � WindowStartupLocation$ CenterScreen=�6T   
���   �$��2q�6�    � AllowsTransparency .  � WindowStyle$
 None=�6�   .��5      � .+�5   
   � ���#99FFFF$��80��6$   $	��Top=�60   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Realizar Venta��6   $��30(�62   $��Center=�6@   $��Showcard Gothic)�6[   5      �� 5      $��
img/vi.jpg��6   $��
0,0,-0.2,0q�6(   $��Right=�6<   �� 5      $��img/em2.jpg��6   $��0,0,114.2,0q�6)   $��Right=�6>   5      � 5   
   $	��343��6   $
��Left=�6   $��0,80,0,-0.4q�66   .+�5      �� $ Vertical=�6   .+�5      �� -   5         ��Name$ 
bntCliente��5      $��Nuevo Cliente��6-   $	��140��6E   $	��0,5q�6Q   
���   �6q   �� 5      -   5         ��Name$ comboCliente��5      $
��0 15q�5      	 �� 
IsEditable	 .    MaterialDesignFilledComboBox#��[ 5      )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 Seleccione el Cliente��5       $	��256��5!      5#      �� 5$      $��Seleccione El Producto��6   $��32,0,35.2,0q�6:   �� 5%      -   5         ��Name$ 	txtProduc��5%       * &MaterialDesignOutlinedTextFieldTextBox#��[ 5&      $	��200��5'      $��40��5(       �� AcceptsReturn .  �� TextWrapping$
 Wrap=�5*      " �� VerticalScrollBarVisibility$
 Auto=�5+      $
 Producto��5,      $��10q�6/   6;   &   System.Windows.Controls.DataGrid  5-      -   5          Name$ dataProduct��5-      $	��330��60   $	��240��6<      CanUserAddRows .  
���   �$��1q�6t   6�   �� 5.      -   5         ��Name$ imageProduct��5.      $	��200��6.   $	��150��6:   $��5q�6G   �� 5/      -   5        $��Agregar Al Carrito��5/      $	��200��66   $��5q�6B   
���   �$��1q�6v   
���   �6�   52      53      � 54   
   $��345,82,2,515.4q�6   .+�55      �� $ 
Horizontal=�6   .+�57      �� -   5        $ 
txtcliente��57      #��[ 58      $	��200��59      $��40��5:       . $
 Wrap=�5<      $
 Auto=�5=      $
 Cliente��5>      $��70,10,40,10q�6.   �� 5@      -	   5        $ txtUser��5@      {�.  #��[ 5A      $	��200��5B      $��40��5C       . $
 Wrap=�5E      $
 Auto=�5F      $
 Usuario��5G      $��70,10,40,10q�6.   �� 5H      -
   5        $ txtTotal��5H      #��[ 5I      $	��157��5J      $��40��5K       . $
 Wrap=�5M      $
 Auto=�5N      $
 Total a Pagar��5O      $��10,47,10,46.6q�64   5P      5Q      � 5R   
   $��350,182,3,0.4q�6   .+�5S      �� $ Vertical=�6   .+�5T        -   5        $ 
dtProductl��5T      $	��374��6/   $��10,10,10.2,10q�6<      AutoGenerateColumns .   .  
���   �$��1q�6�   ��6�   �� *
products+   Columns 5U      0  *System.Windows.Controls.DataGridTextColumn  5V      -   5        dgcproductid��,  &System.Windows.Controls.DataGridColumn   Header$ Id��5V   C   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6O   �� *
IdProducto+  5W      -   5        
dgcnamepro��$ Producto��5W   A    6S   �� *NombreProducto+  5X      -   5        	dgcprecio��$ Precio��5X   @    6P   �� *Precio+  5Y      -   5        dgcCantidad��$ Cantidad��5Y   B    6T   �� *
Cantidad+ � ContextMenu 5\      �� 5]      .@�5^      m� -   5         m�Name$ 	btnquitar��5^   '   $��Quitar��6:   6J   5`      5b      �� 5c      $ 
Horizontal=�6   $��0,50,0,0q�66   $��Center=�6H   .+�5d      �� -   5        $ btnlim��5d      $��Vaciar Carrito��6-   $
��20,0q�6F   
���   �6g   �� 5e      -   5        $ btnVenta��5e      $��VENDER ��6/   $
��20,0q�6A   
���   �6f   �� 5f      -   5        $ BtExist��5f      $��CANCELAR��6.   $
��20,0q�6A   
���   �6e   5g      5h      5i      5l      5m      