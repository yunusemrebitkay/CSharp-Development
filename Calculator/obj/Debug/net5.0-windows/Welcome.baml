   M S B A M L   `   `   `  ����E  ACalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:FinalProjectFinalProject  5   	       FinalProject.Welcome   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:FinalProject     5   	     � Title$  Welcome��5   	   $	��480��6   $	��750��6&    � WindowStartupLocation$ CenterScreen=�62   $	��480��6W   $	��750��6g    � 
ResizeMode$ NoResize=�6v   ��5	      �� 5
   
    �� ImageSource$ /Images/BG_Welcome.png��6   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��125 �6   �� 5      $	��125 �6   �� 5      $	��125 �6   �� 5      $	��125 �6   �� 5      $	��125 �6   �� 5      $	��125 �6    � RowDefinitions 5   
   �� 5      $	��120 �6   �� 5      $	��120 �6   �� 5      $	��120 �6   �� 5      $	��120 �6   .+�5   
   �� -   5        $��BtnGetStarted��5      $��1q�6'   $��Get Started��6W   $	��Top=�6m   $��40��6�   $	��140��6�   $��2��6�   $��2��6�   $��2��6�   ���	#7F000000
�������
�������$��14(�6   �� 	IsDefault$
 True��6   K� ZIndex$ 2��6+  $��Arial)�6<  $��2��6P  $��
55,95,55,0q�6a   � 	Resources 5      	 �� 
TargetType
 �� Property �� Value��%^   '��       �� 5      "	 ��6   .�5      �� 
 �@��CornerRadius$ 3��65   5      5       5!      �� 5"   
   $��/Images/Logo_White.png��6   $��2��60   $��Center=�6@   $��60��6]   $	��Top=�6i   $��60��6�   $��2��6�   $��0,50,0,0q�6�   �� 5#   
   $��Welcome��6   $��2��6"   $��Center=�62   $��Center=�6O   $��48��6j   $	��186��6v   
�������$��42(�6�   $��2��6�   4  .System.Windows.Automation.AutomationProperties   Name$ Message_Welcome��6�   $��Center=�6�   $��Center=�6  $��1��6)  $��Bahnschrift)�66  �� 5$   
   $��1��6   $��Center=�6$   $��2��6A   $
��Wrap=�6N   $	��Top=�6b   
�������$��4��6�   $��56��6�   $	��374��6�    �� TextAlignment$ Center=�6�   $��18(�6�   $��Bahnschrift Condensed)�6�   $��0,10,0,0q�6  $
��Bold"�6  �� 6&  $�'You may not be aware it,��6*  �� 6M  �� 6Y  $0�*but artificial intelligence is everywhere'��6]  6�  �� 5%   
   $��2��6   $��Center=�6$   $��3��6A   $<��6Copyright ©2020 Yunus Emre Bitkay All Rights Reserved��6N   $
��Wrap=�6�   $ Center=�6�   $	��Top=�6�   
�������$��2��6�   $	��249��6�   $��9(�6  $��0,60,0,0q�6  5'      5(      