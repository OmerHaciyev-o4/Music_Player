   M S B A M L   `   `   `  ����N  JCustom Music Player, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Custom_Music_Player.ViewModelsCustom_Music_Player.ViewModels  5   	   9!clr-namespace:Custom_Music_PlayerCustom_Music_Player  5   	   3    -Custom_Music_Player.Views.Custom_Music_Player   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;vm,clr-namespace:Custom_Music_Player.ViewModels     5   	   3local!clr-namespace:Custom_Music_Player     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	     � Title$  Welcome Music Player��5   	   $	��709��5   	   $	��800��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowState$ Normal=�5   	    � 
ResizeMode$ NoResize=�5   	    � 	Resources 5      *   $Custom_Music_Player.ViewModels.Works   Work �� 
TargetType �� Property �� Value��%�   &	        '��        5   
   6   �� 5   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��
 ��  �6+   5      5      .��5      �� 
���   � � DataContext# [  6$   .+�5   
   �� 	 �� Orientation$	 Vertical=�6   $	��435��6,   .+�5      �� ��6   �� *	Element+5      �� 5   
   $��30��6   $	 
Horizontal=�6!   .+�5      �� $��78��6   $��0 0 5 0q�6$   .+�5      �� 
�������$��18(�6L   $��Center=�6Z   $��5 0 0 0q�6u   ��6   �� *Contents[0]+6u   5      �� 5       $��Center=�6   .+�5!      �� 
 � Minimum$
 0Q�5"      $	��625��5%      $��Center=�5&      
������$��0 3 0 0q�5(       � Maximum 5#      �� *ProgressSlider.Maximum+ � Value 5$      �� *ProgressSlider.Value+.  (System.Windows.Interactivity.Interaction   Triggers 5)      /  )System.Windows.Interactivity.EventTrigger  5*         	EventName$ MouseUp��6)   .  (System.Windows.Interactivity.TriggerBase   Actions. 5+      6  0System.Windows.Interactivity.InvokeCommandAction     Command 64   �� *
MouseUpBut+5,      5.      5/      �� 50      $��67��6   $��5 0 0 0q�6$   .+�51      �� 
�������$��18(�6q   $��Center=�6   ��6   �� *Contents[1]+ �� UpdateSourceTrigger$ PropertyChanged=�6   52      53      �� 54   
   $��50��6   $	 
Horizontal=�6!   .+�55      �� $��81��56      
���   �
�������$��5 0 0 0q�59      $��4q�5;      
��������5:      �� *OpenFileBut+��5=      '  !MaterialDesignThemes.Wpf.PackIcon  5>         Kind$ FileMultiple=�6.   $��20��6B   $��20��6M   5@      �� 5A      ��5B      �� *RepeatButton.Content+��5C      �� *RepeatButton.Background+��5D      �� *RepeatButton.Foreground+��5E      �� *RepeatButton.Width+��5F      �� *RepeatButton.Margin+��5G      �� *RepeatButton.BorderThickness+��5H      �� *RepeatButton.BorderBrush+��5I      �� *	RepeatBut+�� 5J      $��81��5K      
���   �
�������$��5 0 0 0q�5N      $��4q�5P      
��������5O      �� *PreviousBut+��5R        5S      $ PreviousTitle=�6.   $��20��6C   $��20��6N   5U      �� 5V      $��81��5W      
���   �
�������$��5 0 0 0q�5Z      $��4q�5\      
��������5[      �� *	StopBut+��5^        5_      $
 Stop=�6.   $��20��6:   $��20��6E   5a      �� 5b      $��81��5c      
���   �
�������$��5 0 0 0q�5f      $��4q�5h      
��������5g      �� *	PlayBut+��5j        5k      $
 Play=�6.   $��20��6:   $��20��6E   5m      �� 5n      $��81��5o      
���   �
�������$��5 0 0 0q�5r      $��4q�5t      
��������5s      �� *
PauseBut+��5v        5w      $ Pause=�6.   $��20��6;   $��20��6F   5y      �� 5z      $��81��5{      
���   �
�������$��5 0 0 0q�5~      $��4q�5�      
��������5      �� *	NextBut+��5�        5�      $ 	NextTitle=�6.   $��20��6?   $��20��6J   5�      �� 5�      $��81��5�      
���   �
�������$��5 0 0 0q�5�      $��4q�5�      
��������5�      �� *	MuteBut+��5�        5�      $
 Mute=�6.   $��20��6:   $��20��6E   5�      �� 5�      $��81��5�      
���   �
�������$��5 0 0 0q�5�      $��4q�5�      
��������5�      �� *
SoundBut+��5�        5�      $ 
VolumeHigh=�6.   $��20��6@   $��20��6K   5�      5�      �� 5�   
   $	 
Horizontal=�6   $	��150��6.   .+�5�      �� $	��145��5�      $	��596��5�      
�������
���   �$��Visible=�5�      $��Visible=�5�      $��5 0 0 0q�5�      $	��Top=�5�      $
��Left=�5�      $��4q�5�      
������ �� SelectedIndex 5�      �� *Box.SelectedIndex+ �� SelectedItem 5�      �� *Box.SelectedItem+��5�      �� *	Box.Items+5�      �� 5�      $	 Vertical=�6   .+�5�      �� $��81��5�      
���   �
�������$��5 0 0 0q�5�      $��4q�5�      
��������5�      �� *TitleAddBut+��5�        5�      $ PlayListAdd=�62   $��22��6E   $��22��6P   5�      �� 5�      $��81��5�      
���   �
�������$��5 24 0 0q�5�      $��4q�5�      
��������5�      �� *TitleRemoveBut+��5�        5�      $ PlaylistMinus=�62   $��20��6G   $��20��6R   5�      �� 5�      $��81��5�      
���   �
�������$��5 24 0 0q�5�      $��4q�5�      
��������5�      �� *TitleClearBut+��5�        5�      $ PlaylistRemove=�62   $��20��6H   $��20��6S   5�      5�      �� 5�      $	 
Horizontal=�6   .+�5�      �� $��20��5�      $	��140��5�      
������$��35 0 0 0q�5�       �� Orientation$ Vertical=�5�       5�      �� *Volume.Value+
 5�      �� *Volume.Minimum+ 5�      �� *Volume.Maximum+y�5�      �� *Volume.Visibility+5�      5�      5�      5�      