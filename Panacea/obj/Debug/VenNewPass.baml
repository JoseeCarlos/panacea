   M S B A M L   `   `   `  ����B  >Panacea, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:PanaceaPanacea  5   	       Panacea.VenNewPass   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Panacea     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   -   5           MaterialDesignBody#���   5      $��Regular"�5	      $��13(�5
      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5      ���	#FF99FFFF  MaterialDesignFont#���  5       � Title$ 
VenNewPass��5   	   $��503.693��6   $	��800��6-    � WindowStartupLocation$ CenterScreen=�6P    � AllowsTransparency .  � WindowStyle$
 None=�6�   
���   �$��2q�6�   .��5      � .+�5   
   � $��80��6   $	��Top=�6   
�������.+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��img/log2.png��6   $	��200��6.   $��80��6:   $
��Left=�6G   �� 5      $��Cambio de Password��6   
���   �$��35(�6I   $��Center=�6W   $��Center=�6t   $��Arial Black)�6�   5      5      �� 5   
   -   5         ��Name$ btncambi��5      
���   �$��Cambiar��66   $
��Left=�6H   $��143,363,0,0q�6c   $	��Top=�6x   $	��197��6�   $��54��6�   6�   �� 5   
   $��Nombre de Usuario:��6   $��17(�6-   $
��Left=�6;   $��124,124,0,0q�6V   $	��Top=�6k   $	��200��6�   $��38��6�   $��Arial Black)�6�   �� 5   
   -   5         ��Name$ txtUser��5      $��17(�6#   {�.  $
��Left=�6C   $��37��6^   $��341,114,0,0q�6j   	 �� TextWrapping$
	 Wrap=�6   $	��Top=�6�   $	��144��6�   �� 5   
   $��Contraseña:��6   $
��Left=�6&   $��17(�6A   $��195,251,0,0q�6O   $	��Top=�6d   $��33��6|   $	��129��6�   $��Arial Black)�6�   G� 5   
   -   5        
 G�Name$
 txtpas1��5      $��17(�6'   $
��Left=�65   $��36��6P   $��336,247,0,0q�6\   $	��Top=�6s   $	��168��6�   �� 5   
   $��Repita su Contraseña:��6   $��17(�60   $
��Left=�6>   $��104,291,0,0q�6Y   $	��Top=�6n   $��41��6�   $	��218��6�   $��Arial Black)�6�   G� 5   
   -   5        $
 txtpas2��5      $��17(�6'   $
��Left=�65   $��35��6P   $��334,286,0,0q�6\   $	��Top=�6s   $	��173��6�   �� 5   
   -   5        $ 	btncancel��5      $��Cancelar��6$   $��17(�67   
���   �$
��Left=�6X   $��367,362,0,0q�6s   $	��Top=�6�   $	��181��6�   $��58��6�   6�   �� 5    
   $��Contraseña Actual:��6   $��Arial Black)�6-   $��17(�6F   $
��Left=�6T   $��129,209,0,0q�6o   $	��Top=�6�   $	��186��6�   G� 5!   
   -   5        $
 oldPassword��5!      $
��Left=�6+   $��17(�6F   $��37��6T   $��337,208,0,0q�6`   $	��Top=�6w   $	��170��6�   5#      5$      