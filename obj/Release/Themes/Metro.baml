   M S B A M L   `   `   `  ���� M  IFluent, Version=2.1.0.0, Culture=neutral, PublicKeyToken=3e436e32a8c5546f/$clr-namespace:Fluent;assembly=FluentFluent  J FUnQLiteExplorer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:UnQLiteExplorer.ConvertersUnQLiteExplorer.Converters W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4  �� MergedDictionaries �� Source   
WhiteBrush �� Color  MsBackgroundBrush �� 
StartPoint �� EndPoint � Color � Offset  MetroToolBar �� 
TargetType �� Property	 �� Value  RibbonBorderBrush  DarkMetroToolBar
 �� BasedOn  DarkBackgroundBrush  MetroButton �� 
TargetType �Name ��Name ��Name �� Triggers P� Property P� Value �� 
TargetName   ButtonHoveredBackgroundBrush   ButtonPressedBackgroundBrush 	 TransparentMetroButton 
 MetroTreeToggleStyle ��Name  TransparentBrush ��Name  FixedImage16 ]� 
Conditions �� Property �� Value   MetroTreeViewItemFocusVisual �� StrokeDashArray J� Opacity �� Path �� RelativeSource �� AncestorType  DefaultFontBrush �� Mode �� UpdateSourceTrigger �� FallbackValue  � 	Resources>   8UnQLiteExplorer.Converters.LeftMarginMultiplierConverter!    Length  Key" �� Padding  lengthConverter# �� 	Converter$ � ColumnDefinitions% d�Name& �� 	ClickMode' d� 	IsChecked( ��Name  TreeViewItemSelectedBrush) �� 
SourceName  TreeViewItemHoverBrush  MetroContextMenu* J� Effect3  -System.Windows.Media.Effects.DropShadowEffect+   Color,   ShadowDepth-   Opacity.   
BlurRadius/ K� IsItemsHost-  'System.Windows.Input.KeyboardNavigation0   DirectionalNavigation1 m� IsSubmenuOpen2 � AllowsTransparency3 J� SnapsToDevicePixels  ItemSelectedBrush4 P� 
SourceName  DisabledForegroundBrush5 z� SharedSizeGroup6 ��Name7 m� InputGestureText8 � HorizontalOffset  MetroMenuItem9 �� Triggers : m� TopLevelHeaderTemplateKey; m� TopLevelItemTemplateKey< m� SubmenuHeaderTemplateKey= m� SubmenuItemTemplateKey  MetroSplitter> �� BitmapScalingMode  MetroMessageBox"  Xceed.Wpf.Toolkit.MessageBox  RibbonThemeBrush0  *Xceed.Wpf.Toolkit.Primitives.WindowControl  MetroWarningMessageBox  MetroErrorMessageBox  MetroInformationMessageBox�� F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     /Fluent$clr-namespace:Fluent;assembly=Fluent  7
converters(clr-namespace:UnQLiteExplorer.Converters  4xctk)http://schemas.xceed.com/wpf/xaml/toolkit    �� $ Generic.xaml?��� $E ?pack://application:,,,/Fluent;Component/Themes/Metro/White.xaml?�%(  &	        &	      &	 k     7  7   &	 
    7  7  &	 .    7   7   7  7  7   &		 9    7  &	
 c    7  7  7  &	 �    'Q�     7  7  7  7 
 7  7  7  &	 .    7  7   (�� r    *MenuItem.SeparatorStyleKey+)7  (�� �    *$"MenuItem.TopLevelHeaderTemplateKey+)7   7  7  7  (�� b    *" MenuItem.TopLevelItemTemplateKey+)7  7  (�� I    *!MenuItem.SubmenuItemTemplateKey+)7   7  7  7  (�� �    *#!MenuItem.SubmenuHeaderTemplateKey+)7   7  7  7  &	 d    7: 7; 7< 7= &	 �    7  7  &	 �    7   7  7  7  7   7  &	 �    7  &	 ;    7  &	 �    7  �� $ 	#FFFFFFFF���� $	 0,0&�$	 0,1&�.��� $ 	#FFFFFFFF��$ 0Q�� $ 	#FFF0F0F0��$ 1Q��� " ��.���  �@J�SnapsToDevicePixels	 . ��  � }�	 . ��  � ��8	   ��  � ��$	 1q���  �@��Padding$	 5q���  � ��8	  �� " ��8
   .���  � ��8	  �� " ��.���  � ��8	   ��  � ��8	  ��  � ��$	 0q���  � ��	 �� " ��.R�� $ MetroButtonRoot��.+��� $ MetroButtonBackground��#��z��#��z���� $ MetroButtonContent��$��Center=�$��Center=�#��z��#��z�� P�  �@J�IsMouseOver . . ��� $ MetroButtonBackground��8	   � ��P�  � �� . . ��� $ MetroButtonBackground��8	   � ��P�  � {� .  . ��� $ MetroButtonBackground��8	   � ���� $ MetroButtonRoot�� �@J�Opacity$		 0.5Q��� " ��8
   .���  � ��
	 ���� �� " d�.���  � |�	 .  ��  � ��	 �� " d�.R��� $ ToggleBorder��8��  8�� $��0q�._��� $ ToggleImage��$%��../Images/ToggleCollapsed16.png��8��  P�  �@d�	IsChecked$
 TrueY�. ��� $ ToggleImage�� � ��$$	 ../Images/ToggleExpanded16.png��]�  ��  �@J�IsMouseOver . ��  �@d�	IsChecked$
 TrueY�./��� $ ToggleImage�� � ��$)	 #../Images/ToggleExpandHovered16.png��]�  ��  �@J�IsMouseOver . ��  �@d�	IsChecked$ FalseY�./��� $ ToggleImage�� � ��$+	 %../Images/ToggleCollapseHovered16.png���� .���  � ��	 �� .R��� ._��� $��0,0,0,0q�$��5��
���   �$	 1 2R�$ 0Q��� " Q�.���  � ��
	 ���� ��  �@Q�
IsExpanded	 . ��  � ��$	 0,1,0,1q���  � ��	 �� $  HorizontalContentAlignment� �� " ����  � ��	 �� $ VerticalContentAlignment� �� " ����  � ��$	 1,0,0,0q���  � ��8	   ��  �@�FocusVisualStyle8	  ��  �@Q�
IsSelected	 �� $ 
IsSelected�$ TwoWay=�$ PropertyChanged=�$ False����  � ��	 �� " Q�  ��   $! 19Q�lengthConverter .R��� .+��� $��Bd��#��z��#��z��#��z��#" z��._�� ���� 8#   �� *TemplatedParent+$ �� $��19 ��� .+�d� $% Expander��8�� $& Press=�' �� $ 
IsExpanded� �� *TemplatedParent+�� $ PART_Header��$��1��$��Header��#��z���� $( 	ItemsHost�� P�  �@Q�
IsExpanded .  . ��� $ 	ItemsHost�� � y�$	 	Collapsed=�P�  �@��HasItems .  . ��� $ Expander�� � y�$	 Hidden=�]�  ��  � �� .  ��  � ��$
 Auto��./��� $ PART_Header�� � ��$	 75��]�  ��  � �� .  ��  � ��$
 Auto��./��� $ PART_Header�� � ��$	 19��P�  �@Q�
IsSelected . . ��� $ Bd��8	   � ���� 8	   � ��]�  ��  �@Q�
IsSelected .  �� $) Bd�� �@J�IsMouseOver . ./��� $ Bd��8	   � ���� " ��.���  �@J�SnapsToDevicePixels	 . ��  �@�OverridesDefaultStyle	 . ��  �@�IsSharedSizeScope	 . ��  �@��HasDropShadow	 . ��  � ��	 �� " ��.R��� $ Bd��8��  8�� $" 1q�$��10q�$��1q�*   $+ 	#FF808080��$, 0Q�$	- 0.5Q�$. 5Q�._��� / . $0 Cycle=��� " ��.���  � ��$	 1����  � ��$	 0,4,0,4q���  � ��	 �� " ��.R��� 8��  $��1q��� " m�.R��� $��Border��._�� .+��� $��6,3,6,3q�$��Header����. � $��Popup��$��Bottom=�#��z1 2 . |�.  $
��Fade=�.���� $��SubmenuBorder��3 . 8��  8�� $��1q�._��� ��. .���� / . $0 Cycle=� P� " �@m�IsSuspendingPopupAnimation . . ��� $ Popup�� � ��$
	 None=�P�  �@m�IsHighlighted . . ��� $ Border��8	   � ���� $ Border�� � ��
	 ���� P� $4 Popup�� �@�AllowsTransparency . . ��� $ SubmenuBorder�� �@��CornerRadius$	 0,0,4,4���� $ SubmenuBorder�� �@��Padding$	 0,0,0,3q�P�  � {� .  . ��� 8	   � ���� " m�.R��� $��Border��._�� .+��� $��6,3,6,3q�$��Header����.  P�  �@m�IsHighlighted . . ��� $ Border��8	    � ���� $ Border�� � ��
	 ���� P�  � {� .  . ��� 8	   � ���� " m�.R��� $��Border��$" 2q�._�� $ �� $
��Auto �$
5 Icon���� $��* ��� $
��Auto �$5 Shortcut���� $��13 �.+��� $
��Icon��$��6,0,6,0q�$��Center=�$
��Icon���� $��Check��$��13��$��13��$y�	Collapsed=�$��6,0,6,0q�8��  $��1q�8�� ._�F� $��	CheckMark��$��7��$��7��$y�Hidden=�3 .  ���#777777$��2��+����        ���j ��j �    ��j ���j     	�� $��
HeaderHost��$��1��$��Header��$��Center=���. �� $6 InputGestureText��$��2��#��z7 $��5,2,0,2q�$��Right=� P�  Z�  �@m�Icon. ��� $
 Icon�� � y�$	 Hidden=�P�  �@m�	IsChecked . . ��� $ 	CheckMark�� � y�$	 Visible=�P�  �@m�IsCheckable . . ��� $ Check�� � y�$	 Visible=��� $
 Icon�� � y�$	 Hidden=�P�  �@m�IsHighlighted . . ��� $ Border��8	   � ��P�  � {� .  . ��� 8	   � ���� " m�.R��� $��Border��$" 2q�._�� $ �� $
��Auto �$
5 Icon���� $��* ��� $
��Auto �$5 Shortcut���� $��13 �.+��� $
��Icon��$��6,0,6,0q�$��Center=�$
��Icon���� $��
HeaderHost��#��z��$��1��$��Header��$��Center=���. �� $6 InputGestureText��$��2��#��z7 $��5,2,2,2q�$��Right=�F� $��3��$��Center=�$��Center=�"����        �    ��j � 	= �g5 	���#777777� $��Popup��$��Right=�$8 -4��#��z1 2 . |�.  $
��Fade=�.���� $��SubmenuBorder��3 . 8��  8�� $��1q�._��� / . $0 Cycle=� P�  Z�  �@m�Icon. ��� $
 Icon�� � y�$	 	Collapsed=�P�  �@m�IsHighlighted . . ��� $ Border��8	   � ��P� $4 Popup�� �@�AllowsTransparency . . ��� $ SubmenuBorder�� �@��CornerRadius$	 4���� $ SubmenuBorder�� �@��Padding$	 0,3,0,3q�P�  � {� .  . ��� 8	   � ���� " m�.���  �@�OverridesDefaultStyle	 . 9 P�  �@m�Role$ TopLevelHeader=�. ���  � ��8	   ��  �@�IsSharedSizeScope	 . P�  �@m�Role$ TopLevelItem=�. ���  � ��8	  P�  �@m�Role$ SubmenuHeader=�. ���  � ��8	  P�  �@m�Role$ SubmenuItem=�. ���  � ��8	  �� " ��.���  � ��$	 0,0,0,0q���  � ��8	   ��  � ��$	 0q���  �@�Cursor$	 SizeWE����  � }�	 . ��  �@J�SnapsToDevicePixels	 . ��  � ��	 �� .R��� $��1��$��0,0,1,0��3 . 
������ $> NearestNeighbor=�8�� �� "  .���  � ��8	   ��  � ��8	  ��  � ��8	  ��  �@ CaptionForeground8	  ��  �@ WindowBackground8	  ��  �@ WindowBorderBrush8	  ��  �@ WindowBorderThickness$	 1q���  �@ WindowOpacity$
	 0.99Q���  �@ CaptionIcon$	 ../Images/icon32.png���� 8
   "  .���  �@ ImageSource$ 	 ../Images/AlertWarning.PNG���� 8
   "  .���  �@ ImageSource$	 ../Images/erroricon.PNG���� 8
   "  .���  �@ ImageSource$	 ../Images/Infoicon.PNG��