   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5      b ^PresentationFramework.Aero2, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35hKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2Microsoft.Windows.Themes 5          WpfApp2.UrlBar   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:WpfApp2     5      ^ThemesKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2     5        � 	Resources  5         ComboBox.Static.Background �� EndPoint �� 
StartPoint � Color � Offset  ComboBox.Static.Border �� Color ' #ComboBox.Static.Editable.Background # ComboBox.Static.Editable.Border . *ComboBox.Static.Editable.Button.Background * &ComboBox.Static.Editable.Button.Border  ComboBox.MouseOver.Glyph ! ComboBox.MouseOver.Background  ComboBox.MouseOver.Border *	 &ComboBox.MouseOver.Editable.Background &
 "ComboBox.MouseOver.Editable.Border 1 -ComboBox.MouseOver.Editable.Button.Background - )ComboBox.MouseOver.Editable.Button.Border  ComboBox.Pressed.Glyph  ComboBox.Pressed.Background  ComboBox.Pressed.Border ( $ComboBox.Pressed.Editable.Background $  ComboBox.Pressed.Editable.Border / +ComboBox.Pressed.Editable.Button.Background + 'ComboBox.Pressed.Editable.Button.Border  ComboBox.Disabled.Glyph   ComboBox.Disabled.Background  ComboBox.Disabled.Border ) %ComboBox.Disabled.Editable.Background % !ComboBox.Disabled.Editable.Border 0 ,ComboBox.Disabled.Editable.Button.Background , (ComboBox.Disabled.Editable.Button.Border  ComboBox.Static.Glyph  ComboBoxToggleButton �� 
TargetType �� Property �� Value	 �� 
TargetType
 ��Name J� SnapsToDevicePixels F�Name �� Triggers ^� 
Conditions �� Binding �� RelativeSource �� AncestorType �� Value �� 
TargetName P� Property P� Value  ComboBoxTemplate �Name � ColumnDefinitions �Name � AllowsTransparency �� Mode5  /Microsoft.Windows.Themes.SystemDropShadowChrome  Name   Color �� MaxDropDownHeight �� ElementName ��Name  �� ClearTypeHint! ��Name" ��Name# ��Name-  'System.Windows.Input.KeyboardNavigation$   DirectionalNavigation% d�Name& d� 	IsChecked' ��Name( �� SelectionBoxItemTemplate) �� SelectionBoxItem#* �� SelectionBoxItemStringFormat+ �� ContentStringFormat, J� IsHitTestVisible- P� 
SourceName. ]� 
Conditions/ �� Property  TextBox.Static.Background  ComboBoxEditableTextBox   ComboBoxEditableTemplate0 ��Name1 �� 
IsReadOnly ! ComboBoxStyle1 " FocusVisual2 �� Triggers��%-  &	        &	 �     &	 �     &	 �     &	     &	 *    &	 O    &	 r    &	     &		 1    &	
 T    &	 w    &	     &	 6    &	 Y    &	 �    &	     &	 ;    &	 ^    &	 �    &	     &	 @    &	 c    &	 �    &	 �    &	 �    &	 �    &	     &	 9    7  7   7  7  7  7  7  7  7  7  7 	 7 
 7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  &	 W    7  &	 �    &	 �    &	      7  7  7  &	! ~(    7 " 7   7  7  7   �� 5   
   $	 0,1&�6A   $	 0,0&�6P   .��5      � $ 	#FFF0F0F0��6   $	 0.0Q�6-   � 5      $ 	#FFE5E5E5��6   $	 1.0Q�6-   5      �� 5   
   $ 	#FFACACAC��69   �� 5   
   $ 	#FFFFFFFF��6F   �� 5   
   $ 	#FFABADB3��6B   �� 5   
   $ Transparent��6M   �� 5   
   $ Transparent��6I   �� 5   
   $ 	#FF000000��6;   �� 5   
   $	 0,1&�6D   $	 0,0&�6S   .��5      � $ 	#FFECF4FC��6   $	 0.0Q�6-   � 5      $ 	#FFDCECFC��6   $	 1.0Q�6-   5      �� 5   
   $ 	#FF7EB4EA��6<   �� 5   
   $ 	#FFFFFFFF��6I   �� 5   
   $ 	#FF7EB4EA��6E   �� 5   
   $	 0,1&�6T   $	 0,0&�6c   .��5      � $ 	#FFEBF4FC��6   $	 0.0Q�6-   � 5       $ 	#FFDCECFC��6   $	 1.0Q�6-   5!      �� 5"   
   $ 	#FF7EB4EA��6L   �� 5#   
   $ 	#FF000000��69   �� 5$   
   $	 0,1&�6B   $	 0,0&�6Q   .��5%      � $ 	#FFDAECFC��6   $	 0.0Q�6-   � 5&      $ 	#FFC4E0FC��6   $	 1.0Q�6-   5'      �� 5(   
   $ 	#FF569DE5��6:   �� 5)   
   $ 	#FFFFFFFF��6G   �� 5*   
   $ 	#FF569DE5��6C   �� 5+   
   $	 0,1&�6R   $	 0,0&�6a   .��5,      � $ 	#FFDAEBFC��6   $	 0.0Q�6-   � 5-      $ 	#FFC4E0FC��6   $	 1.0Q�6-   5.      �� 5/   
   $ 	#FF569DE5��6J   �� 50   
   $ 	#FFBFBFBF��6:   �� 51   
   $ 	#FFF0F0F0��6?   �� 52   
   $ 	#FFD9D9D9��6;   �� 53   
   $ 	#FFFFFFFF��6H   �� 54   
   $ 	#FFBFBFBF��6D   �� 55   
   $ Transparent��6O   �� 56   
   $ Transparent��6K   �� 57   
   $ 	#FF606060��68   �� 58   
   " d�6-   .�59      ��  �@�OverridesDefaultStyle . 66   �� 5:       � �� .  6*   �� 5;       � |� .  6*   �� 5<       �@��	ClickMode$ Press=�6*   �� 5=       � �� 5>      �� 5?      "	 d�6&   .R�5@      �� $
 templateRoot��6!   8��  #��z��6m   8��  . ._�5A      �� $
 splitBorder��6%   
������ $��1q�6T   $��Right=�6h   $��0q�6�    . #��� r�6�   ._�5B   "   F� $ arrow��6'   F����        ���( ��( јaQ     јaQ P����̰( � �    P����        8�� $��Center=�6�   $��0q�6�   $��Center=�6�   5C      5D       5E      ^� 5F       5G   "   �� 5H   &    60   �� *
IsEditable+ �� " �� true6�   �� 5I   &    60   �� *IsMouseOver+ �� *Self+	 false6v   �� 5J   &    60   �� *	IsPressed+ �� *Self+	 false6t   �� 5K   &    60   �� *	IsEnabled+ �� *Self+ true6t   .0�5M   "   �� $ templateRoot��6?   8   � ��6Y   �� 5N   "   $ templateRoot��6@   8   � ��6Z   �� 5O   "   $ splitBorder��6?   8   � ��6X   �� 5P   "   $ splitBorder��6@   8   � ��6Y   5Q      P� 5R       �@J�IsMouseOver . . �5S   "   �� $ arrow��69   8   � ��6L   5T      ^� 5U       5V   "   �� 5W   &    60   �� *IsMouseOver+ �� *Self+ true6v   �� 5X   &    60   �� *
IsEditable+ �� " ��	 false6�   .0�5Z   "   �� $ templateRoot��6?   8   � ��6Y   �� 5[   "   $ templateRoot��6@   8 	  � ��6Z   5\      ^� 5]       5^   "   �� 5_   &    60   �� *IsMouseOver+ �� *Self+ true6v   �� 5`   &    60   �� *
IsEditable+ �� " �� true6�   .0�5b   "   �� $ templateRoot��6?   8 
  � ��6Y   �� 5c   "   $ templateRoot��6@   8   � ��6Z   �� 5d   "   $ splitBorder��6?   8   � ��6X   �� 5e   "   $ splitBorder��6@   8   � ��6Y   5f      P� 5g       � �� . . �5h   "   �� $ arrow��69   8   � ��6L   5i      ^� 5j       5k   "   �� 5l   &    60   �� *	IsPressed+ �� *Self+ true6t   �� 5m   &    60   �� *
IsEditable+ �� " ��	 false6�   .0�5o   "   �� $ templateRoot��6?   8   � ��6Y   �� 5p   "   $ templateRoot��6@   8   � ��6Z   5q      ^� 5r       5s   "   �� 5t   &    60   �� *	IsPressed+ �� *Self+ true6t   �� 5u   &    60   �� *
IsEditable+ �� " �� true6�   .0�5w   "   �� $ templateRoot��6?   8   � ��6Y   �� 5x   "   $ templateRoot��6@   8   � ��6Z   �� 5y   "   $ splitBorder��6?   8   � ��6X   �� 5z   "   $ splitBorder��6@   8   � ��6Y   5{      P� 5|       � {� .  . �5}   "   �� $ arrow��69   8   � ��6L   5~      ^� 5       5�   "   �� 5�   &    60   �� *	IsEnabled+ �� *Self+	 false6t   �� 5�   &    60   �� *
IsEditable+ �� " ��	 false6�   .0�5�   "   �� $ templateRoot��6?   8   � ��6Y   �� 5�   "   $ templateRoot��6@   8   � ��6Z   5�      ^� 5�       5�   "   �� 5�   &    60   �� *	IsEnabled+ �� *Self+	 false6t   �� 5�   &    60   �� *
IsEditable+ �� " �� true6�   .0�5�   "   �� $ templateRoot��6?   8   � ��6Y   �� 5�   "   $ templateRoot��6@   8   � ��6Z   �� 5�   "   $ splitBorder��6?   8   � ��6X   �� 5�   "   $ splitBorder��6@   8   � ��6Y   5�      5�      5�      5�      �� 5�   
   "	 ��63   .R�5�      � $ templateRoot��6    .  5�      �� 5�      $��* �6'   �� 5�      #��� r�6'   $��0 �6z   .+�5�      � $ 
PART_Popup��6    . $��2��6F   $��1q�6�   #��� .�6�   $��Bottom=�6  ��6Z   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+.��5�        $ shadow��64   $ Transparent��6D   #��z 6X   ��6�   �� *ActualWidth+$ templateRoot��._�5�      �� $
 dropDownBorder��6!   #��� ��69   $��1q�6�   #��� ��6�   ._�5�      �� $ DropDownScrollViewer��6+   .��5�   "   � $
 grid��6'   $  Enabled=�65   .+�5�   &   �� $! canvas��6-   $
��Left=�6=   $��0��6X   $	��Top=�6c   $��0��6{   .+�5�   *   �� $" 
opaqueRect��64   ��6H   �� *
Background+$ dropDownBorder����6�   �� *ActualHeight+$ dropDownBorder����6�   �� *ActualWidth+$ dropDownBorder��5�   '   �� 5�   &   $# ItemsPresenter��65   $$ 	Contained=�6M   # z 6�   5�   #   5�      5�      5�      5�      d� 5�      $% toggleButton��6   #��z��65   #��z��6a   #��z��6�   $��2��6�   8��  & 6�   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+66  �� 5�      $' contentPresenter��6#   #��z( 6=   #��z��6z   #��z) 6�   #+ z* 6�   #��z��6-  , .  #��z��6�  # z 6�  #��z��6�  5�       5�      P� 5�      $- 
PART_Popup��63    �@�HasDropShadow . . �5�      �� $ shadow��6/    � ��$ 0,0,5,5q�6C   �� 5�      $ shadow��6.    �@ Color$ 	#71000000��6B   5�      P� 5�       �@��HasItems .  . �5�      �� $ dropDownBorder��6/    � ��$ 95��6K   5�      ]� 5�      . 5�      �� 5�      / �@��
IsGrouping . 6:   �� 5�      "/ �@%�IsVirtualizingWhenGrouping .  6\   ./�5�      ��  � �� .  6F   5�      P� 5�      $- DropDownScrollViewer��6C    � �� .  . �5�      �� $ 
opaqueRect��63    6K   �� *VerticalOffset+$ DropDownScrollViewer�� �@��Top�� 5�      $ 
opaqueRect��64    6L   �� *HorizontalOffset+$ DropDownScrollViewer�� �@��Left5�      5�      �� 5�   
   $ 	#FFFFFFFF��6<   �� 5�   
   " ��60   .�5�      ��  �@�OverridesDefaultStyle . 66   �� 5�       �@J�	AllowDrop . 6*   �� 5�       � ��$ 0��6)   �� 5�       � ��$ 0��6*   �� 5�       �@�FocusVisualStyle 61   Z� �� 5�       �@��PanningMode$ VerticalFirst=�69   �� 5�       �@��IsFlicksEnabled .  67   �� 5�       � �� 5�      �� 5�      "	 ��6&   .R�5�      �� $ PART_ContentHost��6'   
������ |�.  $��Hidden=�6l   $��Hidden=�6�   5�      5�      5�      �� 5�   
   "	 ��6;   .R�5�      � $ templateRoot��6    .  5�      �� 5�      $��* �6'   �� 5�      #��� r�6'   $��0 �6z   .+�5�      � $ 
PART_Popup��6    . $��2��6F   $��Bottom=�6�   ��6Z   �� *IsDropDownOpen+ �� *TemplatedParent+.��5�        $ shadow��64   $ Transparent��6D   #��z 6X   ��6�   �� *ActualWidth+$ templateRoot��._�5�      �� $
 dropDownBorder��6!   #��� ��69   $��1q�6�   #��� ��6�   ._�5�      �� $ DropDownScrollViewer��6+   .��5�   "   � $
 grid��6'   $  Enabled=�65   .+�5�   &   �� $! canvas��6-   $
��Left=�6=   $��0��6X   $	��Top=�6c   $��0��6{   .+�5�   *   �� $" 
opaqueRect��64   ��6H   �� *
Background+$ dropDownBorder����6�   �� *ActualHeight+$ dropDownBorder����6�   �� *ActualWidth+$ dropDownBorder��5�   '   �� 5�   &   $# ItemsPresenter��65   $$ 	Contained=�6M   # z 6�   5�   #   5�      5�      5�      5�      d� 5�      $% toggleButton��6   #��z��65   #��z��6a   #��z��6�   $��2��6�   8��  & 6�   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+66  �� 5�      $
 border��6   8�� #��z��6a   ._�5�      �� $0 PART_EditableTextBox��6   #��z��6<   #��z��6�   8�� #��z��6-  1 6�   �� *
IsReadOnly+ �� *TemplatedParent+6-  5�      5�       5�      P� 5�       � {� .  . �5�      �� $ border��60    �@J�Opacity$
 0.56Q�6D   5�      P� 5�       �@J�IsKeyboardFocusWithin . . �5�      ��  � ��
 �   �63   5�      P� 5�      $- 
PART_Popup��63    �@�HasDropShadow . . �5�      �� $ shadow��6/    � ��$ 0,0,5,5q�6C   �� 5�      $ shadow��6.    �@ Color$ 	#71000000��6B   5�      P� 5�       �@��HasItems .  . �5�      �� $ dropDownBorder��6/    � ��$ 95��6K   5�      ]� 5�      . 5�      �� 5�      / �@��
IsGrouping . 6:   �� 5�      "/ �@%�IsVirtualizingWhenGrouping .  6\   ./�5�      ��  � �� .  6F   5      P� 5     $- DropDownScrollViewer��6C    � �� .  . �5     �� $ 
opaqueRect��63    6K   �� *VerticalOffset+$ DropDownScrollViewer�� �@��Top�� 5     $ 
opaqueRect��64    6L   �� *HorizontalOffset+$ DropDownScrollViewer�� �@��Left5     5     �� 5  
   " ��6'   .�5     ��  �@�FocusVisualStyle8   61   �� 5	      � ��8  6+   �� 5
      � ��8  6,   �� 5      � ��# � ��6+   �� 5      � ��$ 1q�60   �� 5      � ��$
 Auto=�6K   �� 5      � ��$
 Auto=�6I   �� 5      � ��$ 6,3,5,3q�6(   �� 5      � �� . 6>   �� 5      �@��PanningMode$
 Both=�69   �� 5      �@��IsFlicksEnabled .  67   �� 5      � ��8  6)   2 5     P� 5      �@��
IsEditable . . �5     ��  � �� .  62   �� 5      � ��$ 2q�60   �� 5      � ��8  61   5     5     5     .��5     �  5  
   �� 5     $��1 �6   �� 5      $��34 �6   �� 5!     $	��29* �6   �� 5"     $	��28* �6   �� 5#     $	��31* �6   �� 5$     $��70 �6   �� 5%     $��35 �6   �� 5&     $��35 �6   �� 5'     $��* �6   3 � RowDefinitions3 5*  
   �� 5+     $��3 �6   �� 5,     $��29 �6   �� 5-     $��* �6   .+�50  
   �� -   5        $" 	rectangle��50     $��3��6'   $��8��68   $��31��6L   $��1��6X   
�������
�������6y   �� 51  
   $��1��6   $��1��6   $��0q�6/   
�������
�������6V   �� 55  
   $A��;Search the Internet with Islamic values and very high speed��6   $��1��6W   $��2��6d   $��4��6u   $��Center=�56     
���   �$��14(�6B   $��3q�6P   $��Italic$�6[   �� 57  
   -   5        4 ��Name$4 urlComboBox��57     $��1��6(   $��2��65   $��4��6F   $��0q�6Z   $��Center=�6e   $��1q�58     $��16(�6(   $��Calibri)�66   5 �� 
IsEditable5 . 6 J� 	AllowDrop6 . |�. 7 �� StaysOpenOnEdit7 . &8 �� ShouldPreserveUserEnteredPrefix8 . #��� ! 5:  b   �� 5<  
   -   5        9 ��Name$9 btn_Navigate��5<     $��1��6'   $��6��64   $��0q�6D   
������� # ButtonStyle1#��� # 6k   : J� OpacityMask: 5=     �� 5>     ; j� Stretch$; Uniform=�6   < �� ImageSource$< btn Forward.png��6/   ��5@     �� 5A     $< btn Forward.png��6   $; Uniform=�6;   5C     �� 5D  
   $��1��6   $��7��6   $��0q�6/   
�������
�������$��0,0,1,0q�6i   5E     5F     