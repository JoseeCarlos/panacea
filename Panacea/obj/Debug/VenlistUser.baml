   M S B A M L   `   `   `  ����B  >Panacea, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:PanaceaPanacea  5          Panacea.VenlistUser   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Panacea     5      V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      -   5           MaterialDesignBody#���   5
      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper N� 
Background# �  5        MaterialDesignFont N� 
FontFamily# �  5       N� Title$ VenlistUser��5      .��5      � 
�������$��0,0,-322,-301.4q�6   .+�5   
   � ���#99FFFF$��80��6$   $	��Top=�60   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Regitro De Usuarios��6   $��30(�67   $��Center=�6E   $��Showcard Gothic)�6`   5      �� 5      $��
img/vi.jpg��6   $��
0,0,-0.2,0q�6(   $��Right=�6<   �� 5      $��img/em2.jpg��6   $��0,0,114.2,0q�6)   $��Right=�6>   5      � 5   
   $	��376��6   $
��Left=�6   $��0,84,0,-0.4q�66   .+�5      �� $	��Top=�6   $��40��61   $	��370��6=   .+�5      �� $��Modificar un Usuario��6   $��20(�67   $
��Left=�6E   $	��Top=�6`   $��Center=�6x   $��40��6�   $	��364��6�   $��Segoe UI Black)�6�   5      �� 5      $	��Top=�6   $��70��61   $��	-3,49,3,0q�6=   .+�5       �� -   5         ��Name$ 	txtnombre��5        ( $MaterialDesignFilledTextFieldTextBox#��[ 6-   $��17(�6k   $	��400��6z   $��70��6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Nombre Usuario��6�   $��69��6�   $��	76,0,71,0q�6�   5!      �� 5"      $	��Top=�6   $��70��61   $��
1,124,-1,0q�6=   .+�5#      �� -   5        $ txtpApe��5#      #��[ 6+   $��17(�6i   $	��400��6x   $ P. Apellido��6�   $��68��6�   $��	68,0,76,0q�6�   5$      �� 5%      $	��Top=�6   $��70��61   $��
2,201,-2,0q�6=   .+�5&      �� -   5        $ txtSape��5&      #��[ 6+   $��17(�6i   $	��400��6x   $ S. Apellido��6�   $��68��6�   $��	68,0,76,0q�6�   5'      �� 5(      $	��Top=�6   $��70��61   $��
1,278,-1,0q�6=   .+�5)      �� -   5        $ txtfecha��5)      #��[ 6,   $��17(�6j   $	��400��6y   $ F. Nacimiento��6�   $��68��6�   $��	68,0,76,0q�6�   5*      �� 5+      $	��Top=�6   $��70��61   $��
1,354,-1,0q�6=   .+�5,      �� -   5        $ 	txtgenero��5,      #��[ 6-   $��17(�6k   $	��400��6z   $ Genero��6�   $��68��6�   $��	68,0,76,0q�6�   5-      �� 5.      $	��Top=�6   $��70��61   $��
1,419,-1,0q�6=   .+�5/      �� -   5        $ txtemail��5/      #��[ 6,   $��17(�6j   $	��400��6y   $ Email��6�   $��68��6�   $��	68,0,76,0q�6�   50      �� 51      $	��Top=�6   $��70��61   $��
2,491,-2,0q�6=   .+�52      �� -   5        $ txtrol��52      #��[ 6*   $��17(�6h   $	��400��6w   $
 Role��6�   $��68��6�   $��	68,0,76,0q�6�   53      �� 54      $	��Top=�6   $��70��61   $��
-3,566,3,0q�6=   .+�55      �� -	   5         ��Name$ btnmodificar��55      
���   ����#99FFFF$��	Modificar��6Y   $��Center=�6m   $	��Top=�6�   $	��200��6�   $��50��6�   6�   57      58      &   System.Windows.Controls.DataGrid  5=   
   -
   5        	  Name$	 	datalist1��5=      $
��Left=�6&   $	��503��6A   $��413,143,0,0q�6N   $	��Top=�6c   $	��667��6{   6�   �� 5>   
   $��Usuarios��6   $��25(�6#   
���   �$
��Left=�6D   $��663,100,0,0q�6_   $	��Top=�6t   $	��147��6�   $��Arial Black)�6�   �� 5?   
   -   5        $ 	btnElimin��5?      $��Eliminar��6$   $��17(�67   
���   �$
��Left=�6X   $��624,665,0,0q�6s   $	��Top=�6�   $	��255��6�   $��40��6�   6�   5D      5E      