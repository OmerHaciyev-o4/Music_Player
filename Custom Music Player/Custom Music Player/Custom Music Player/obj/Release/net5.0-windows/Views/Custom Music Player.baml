   M S B A M L   `   `   `  ���� N  JCustom Music Player, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Custom_Music_Player.ViewModelsCustom_Music_Player.ViewModels  9!clr-namespace:Custom_Music_PlayerCustom_Music_Player  3    -Custom_Music_Player.Views.Custom_Music_Player   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ;vm,clr-namespace:Custom_Music_Player.ViewModels     3local!clr-namespace:Custom_Music_Player     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$  Welcome Music Player��$	��709��$	��800�� � WindowStartupLocation$ CenterScreen=� � WindowState$ Normal=� � 
ResizeMode$ NoResize=� � 	Resources *   $Custom_Music_Player.ViewModels.Works   Work �� 
TargetType �� Property �� Value��%V   &	        '��        �� " ��.���  � ��
 �������  � ��
 ��  �.���� 
���   � � DataContext# [  .+��� 	 �� Orientation$	 Vertical=�$	��435��.+��� ���� *	Element+�� $��30��$	 
Horizontal=�.+��� $��78��$��0 0 5 0q�.+��� 
�������$��18(�$��Center=�$��5 0 0 0q����� *Contents[0]+�� $��Center=�.+��� 
 � Minimum$
 0Q�$	��625��$��Center=�
������$��0 3 0 0q� � Maximum �� *ProgressSlider.Maximum+ � Value �� *ProgressSlider.Value+.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ MouseUp��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *
MouseUpBut+�� $��67��$��5 0 0 0q�.+��� 
�������$��18(�$��Center=����� *Contents[1]+ �� UpdateSourceTrigger$ PropertyChanged=��� $��50��$	 
Horizontal=�.+��� $��81��
���   �
�������$��5 0 0 0q�$��4q�
���������� *OpenFileBut+��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ FileMultiple=�$��20��$��20���� ���� *RepeatButton.Content+���� *RepeatButton.Background+���� *RepeatButton.Foreground+���� *RepeatButton.Width+���� *RepeatButton.Margin+���� *RepeatButton.BorderThickness+���� *RepeatButton.BorderBrush+���� *	RepeatBut+�� $��81��
���   �
�������$��5 0 0 0q�$��4q�
���������� *PreviousBut+��  $ PreviousTitle=�$��20��$��20���� $��81��
���   �
�������$��5 0 0 0q�$��4q�
���������� *	StopBut+��  $
 Stop=�$��20��$��20���� $��81��
���   �
�������$��5 0 0 0q�$��4q�
���������� *	PlayBut+��  $
 Play=�$��20��$��20���� $��81��
���   �
�������$��5 0 0 0q�$��4q�
���������� *
PauseBut+��  $ Pause=�$��20��$��20���� $��81��
���   �
�������$��5 0 0 0q�$��4q�
���������� *	NextBut+��  $ 	NextTitle=�$��20��$��20���� $��81��
���   �
�������$��5 0 0 0q�$��4q�
���������� *	MuteBut+��  $
 Mute=�$��20��$��20���� $��81��
���   �
�������$��5 0 0 0q�$��4q�
���������� *
SoundBut+��  $ 
VolumeHigh=�$��20��$��20���� $	 
Horizontal=�$	��150��.+��� $	��145��$	��596��
�������
���   �$��Visible=�$��Visible=�$��5 0 0 0q�$	��Top=�$
��Left=�$��4q�
������ �� SelectedIndex �� *Box.SelectedIndex+ �� SelectedItem �� *Box.SelectedItem+���� *	Box.Items+�� $	 Vertical=�.+��� $��81��
���   �
�������$��5 0 0 0q�$��4q�
���������� *TitleAddBut+��  $ PlayListAdd=�$��22��$��22���� $��81��
���   �
�������$��5 24 0 0q�$��4q�
���������� *TitleRemoveBut+��  $ PlaylistMinus=�$��20��$��20���� $��81��
���   �
�������$��5 24 0 0q�$��4q�
���������� *TitleClearBut+��  $ PlaylistRemove=�$��20��$��20���� $	 
Horizontal=�.+��� $��20��$	��140��
������$��35 0 0 0q� �� Orientation$ Vertical=� �� *Volume.Value+
 �� *Volume.Minimum+ �� *Volume.Maximum+y��� *Volume.Visibility+