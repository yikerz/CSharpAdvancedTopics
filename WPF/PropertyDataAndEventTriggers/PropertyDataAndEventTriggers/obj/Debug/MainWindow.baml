   M S B A M L   `   `   `  ����W  SPropertyDataAndEventTriggers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:PropertyDataAndEventTriggersPropertyDataAndEventTriggers  5   	   -    'PropertyDataAndEventTriggers.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:PropertyDataAndEventTriggers     5   	     � Title$  
MainWindow��5   	   $	��350��6   $
��525 ��6)   .��5	      �� .+�5
   
   � .+�5      �� $��32(�6   $��Center=�5      $��Center=�5      ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value
 � � �5   !    �� Triggers 5      P� 5       P� Property �@J�IsMouseOver P� Value . . �5   "   ��  � ��
 �  ��5   )   �� 5   "    � ��$ 	Underline{�5   )   5      5      Hello, beloved world!5      5      � 5    
   .+�5!      �� $��24(�6   $��Center=�5"      $��Center=�5#      ��5$      �� 5%      " ��6    5&      :� 5'       :� RoutedEvent$ 
MouseEnter��6+   [�5(   "   �� 5)   &   .��5*   *   �� .��5+   .   W�  g� Duration$ 	0:0:0.500D�6>   	 �� TargetProperty$	 FontSize�5,   >   	
 W� To$
 72X�5-   >   5.   +   5/   '   51      :� 52      $ 
MouseLeave��6+   .[�53   "   �� .��54   &   �� .��55   *   W� $ 0:0:0.1D�6:   $	 FontSize�56   :   $
 24X�57   :   58   '   59   #   5:      5<      Hello, Buddy!5?      5@      �� 5A   
   $��Center=�6   $��Center=�60   .+�5B      �� -   5        $��checkBox��5B      $��Is someone there?��6'   �� 5C      $��Center=�6   $��Center=�63   $��32(�6P   ��5D      �� 5E      " ��6   .�5F      ��  � ��$ No��61   �� 5G       � ��
 �  ��5H   !    5I      �� 5J       �� Binding 6*   ��  �� ElementName$ checkBox�� �� Path$ 	IsChecked� �� Value True6c   .a�5K   "   ��  � ��$	 Yes��69   �� 5L   "    � ��
 � � �6?   5M      5O      5Q      5R      5S      5T      