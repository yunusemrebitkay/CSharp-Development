   M S B A M L   `   `   `  ����G  CFinalProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:FinalProjectFinalProject  5   	       FinalProject.Login   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )myclr-namespace:FinalProject     5   	     � Title$  Login��5   	   $	��480��6   $	��750��6$    � 
ResizeMode$ NoResize=�60    � WindowStartupLocation$ CenterScreen=�6F   ��5	      �� 5
   
    �� ImageSource$ /Images/BG_Login.png��6   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $	��175 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��175 �6   �� 5      $	��100 �6    � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��80 �6   �� 5      $	��150 �6   �� 5      $��60 �6   �� 5      $	��120 �6   .+�5   
   �� -   5        $��Login_username��5      $	��1.5q�6)   $
��Left=�6?   $��	10,35,0,0q�6Z    �� TextWrapping$
 Wrap=�6m   $	��Top=�6�   $	��150��6�   $��30��6�   
���   �$��2��6�   $��1��6�   $��Bahnschrift)�6�   $��Normal$�6  $
��Left=�6$   J� RenderTransformOrigin$ 0.498,0.224&�6F  
���   �$��20,7,0,0q�6~   �� SelectionTextBrush
 �   �	 �� SelectionBrush
	 �   �
 �� MaxLines$	
 256��6�   �� AcceptsReturn$
 True��6�   �� TextAlignment$
 Left=�6�  ��6�   Z� 6�  �� 5   
   $��/Images/profile-user.png��6   $��1��62   $
��Left=�6B   $��14��6]   $��	16,43,0,0q�6i   $��2��6|   $	��Top=�6�   $��14��6�   G� 5    
   -   5        $��Login_password��5       $	��1.5q�6,   $
��Left=�6B   $��
10,100,0,0q�6]   $	��Top=�6q   $	��150��6�   $��30��6�   
���   �$��2��6�   $��1��6�   ���	#FF0B0B0C G� SelectionBrush �	#FF060606 G� SelectionTextBrush
 �   �$��Bahnschrift Condensed)�65  $��20,7,0,0q�6X  ��6  Z� 6X  �� 5!   
   $"��/Images/profile-password.png��6   $��1��66   $
��Left=�6F   $��14��6a   $��
16,108,0,0q�6m   $��2��6�   $	��Top=�6�   $��14��6�   �� 5#   
   -   5        $��BtnLogin��5#      $	��0.1q�68    �� 	IsDefault$
 true��6N   $��Sign In��6_   $
��Left=�6q   $	��Top=�6�   $��34��6�   $	��150��6�   $��3��6�   $��1��6�   
���   �
�������$��Bahnschrift Condensed)�6   $��17(�6#  $��10,0,0,0q�61   � 	Resources 5$       �� 
TargetType �� Property �� Value��%_   '��       �� 5%      " ��6   .�5&      ��  �@��CornerRadius$ 15��65   5'      5(      ��5)      �� 5*       �� EndPoint$
 -1,0&�6&    �� 
StartPoint$	 0,0&�66    � SpreadMethod$ Reflect=�6G    � MappingMode$ RelativeToBoundingBox=�6^   .��5+      �  � Color$ 	#FF34E89E��6#   � 5,      $ 	#FF0F3443��6#    � Offset$ 1Q�65   5-      5/      �� 50   
   -   5        $��BtnRegister��50      $	��0.1q�6$   $��Sign Up��6T   $��Center=�6f   $	��Top=�6�   $��34��6�   $	��144��6�   $��4��6�   $��3��6�   $��Bahnschrift Condensed)�6�   $��17(�6�   
�������
���   � 51      ��%_   '��       �� 52      " ��6   .�53      ��  �@��CornerRadius$ 15��65   54      55      ��56      �� 57      $ -1,-1&�6&   $
 0,-1&�67   $ Reflect=�6I   .��58      � $ 	#FFFFC371��6#   $ 1Q�65   � 59      $ 	#FFFF5F6D��6#   $ 0Q�65   5:      5<      �� 5=   
   $��Sign In��6   $��1��6"   $
��Left=�62   $��1��6M   $��Center=�6Z   $��Bahnschrift Condensed)�6u   $
��Bold"�6�   $��50(�6�   $ 0.657,0.544&�6�   �� 5>   
   $��Username��6   $��1��6#   $
��Left=�63   $��	0,5,105,0q�6N   $��2��6a   $	��Top=�6n   $��Bahnschrift Condensed)�6�   $��Normal"�6�   $��60��6�   $��25��6�   $��15(�6�   �� 5?   
   $��Password��6   $��1��6#   $��	0,70,75,0q�63   $��2��6F   $	��Top=�6S   $��Bahnschrift Condensed)�6k   $��Normal"�6�   $��90��6�   $��25��6�   $��15(�6�   $
��Left=�6�   �� 5@   
   $��/Images/Logo_White.png��6   $��4��60   $��Center=�6@   $��60��6]   $��1��6i   $��Center=�6v   $��60��6�   �� 5A   
   $&�� /Images/DontHave_Typrography.png��6   $��4��6:   $��Center=�6J   $	��150��6g   $��2��6t   $��Center=�6�   $	��175��6�   �� 5B   
   $
��Left=�6   $��1��60   $��4,69,0,0q�6;   $��1��6M   
���   �$	��Top=�6i   $	��119��6�   $��1��6�   5E      5F      