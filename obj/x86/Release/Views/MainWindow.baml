   M S B A M L   `   `   `  ���� M  IFluent, Version=2.1.0.0, Culture=neutral, PublicKeyToken=3e436e32a8c5546f/$clr-namespace:Fluent;assembly=FluentFluent  J FUnQLiteExplorer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:UnQLiteExplorer.ViewsUnQLiteExplorer.Views &    UnQLiteExplorer.Views.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     7Fluent$clr-namespace:Fluent;assembly=Fluent     8controls#clr-namespace:UnQLiteExplorer.Views     -     � Title$  UnQLite Explorer�� � Icon$ ../Images/icon32.png��   RibbonThemeBrush   Fluent.MetroWindow   RibbonThemeColor# �    � WindowStartupLocation$ CenterScreen=� � WindowState$ 	Maximized=�$��479.3��$	��923�� � 	Resources  �� MergedDictionaries �� Source ! FavoriteDatastoreItemTemplate �� Orientation  FixedImage32��  �� $ ../Themes/Metro.xaml?�%�   &	       7  �� .R��� $ 
Horizontal=�.+��� $��../Images/datastore32.png��8��  �� $ Vertical=�$��10,0,0,0q�.+��� $��17(����� *Name+�� $��13(����� *
FullName+.��� 	 � ColumnDefinitions	 �� $	��31* ��� $
��884* �
 � RowDefinitions
 �� $
��Auto ��� $��* �.+�   Fluent.Ribbon  -     Name$ Ribbon��$��0��$��2��"   IsQuickAccessToolBarVisible .    Menu    Fluent.Backstage     Fluent.RibbonControl   Header$
 FILE��   Content.     Fluent.BackstageTabControl  .@�   Fluent.BackstageTabItem     Header$
 Info��.���� $��30,40,20,20q�.+��� $��Product Information��$��29(��� $ 
Horizontal=�$��10q�.+��� $��../Images/icon32.png��#��[ �� $��UnQLite Explorer��$��25(�$��10,0,0,0q�#���   �� $��version:      1.0��  
TitleLabel#��[ �� $ ��Author:       Wenjie Zhang��#��[ �� $)��#Tech Support: zhangwj@spdbfl.com.cn��#��[    Fluent.Button     IsDefinitive .  {�. $
��5,10q�   Header$ About UnQLiteExplorer��$	��100��$	��100��  ButtonBackstageStyle#���  $
��Left=�   	LargeIcon$ ../Images/Infoicon.png������ *AboutCommand+  $
 Open��.���� $��30,40,20,20q�.+��� $
��Open��$��29(���  ! InnerBackstageTabControlStyle#���  .@��� ���� .R���  �� Padding$ 5q�._��� $ 
Horizontal=�.+��� $��../Images/favorites32.png��#��[ $��10,0,0,0q��� $��Favorite Data Stores��$��17(�$��10,0,0,0q�.���� $��
20,0,20,10q�.+��� -    ��Name$ Title��$��Favorite Data Stores��#��[  $��23(��� -   $��1��  MetroListBox#��[   TransparentBrush#��[ $	��0,5q�$��0,0,0,0q� �� SelectionMode$ Single=� J� SnapsToDevicePixels .  �� BitmapScalingMode$ NearestNeighbor=�}�. #��[  �� SelectedItem �� *SelectedFavoriteDatastore+ �� UpdateSourceTrigger$ PropertyChanged=����� *DatastoreItems+$ PropertyChanged=�  -   $ Close��   QuickAccessItems     Fluent.QuickAccessMenuItem   m� 	IsChecked .    Target ��  �� ElementName$ NewDatastoreButton��   . .   -   $
 Exit��   Icon$ ../Images/exit16.png��    Tabs.  	   Fluent.RibbonTabItem	  ! 	  Header$! UNQLITE��" 	  Groups." 
   Fluent.RibbonGroupBox
  # 
  Header$	# New��.@�  -   $  Name$$ NewDatastoreButton��$ New Data Store��$" ../Images/newdatastore16.png��$" ../Images/newdatastore32.png������ *NewDatastoreCommand+
  $# 
Connection��.@�  $ Connect Data Store��$ ../Images/datastore32.png������ *ConnectDatastoreCommand+   Fluent.DropDownButton  %   Header$% 
Disconnect��&   	LargeIcon$ & ../Images/disconnect32.png��.@�   Fluent.Gallery  '   MaxItemsInRow$' 3��.@�  $ Disconnect Data Store��$  ../Images/disconnect32.png������ *DisconnectCommand+  $ Remove Data Store��$% ../Images/removedatastore32.png������ *RemoveConnectionCommand+
  $# Favorite��.@�  $ Show/Hide Favorites��$ ../Images/showhide32.png������ *ShowFavoritesCommand+  $ Add to favorite��%   Fluent.RibbonAttachedProperties(   RibbonSizeDefinition$( Middle��$ ../Images/add16.png������ * AddToFavoriteConnectionCommand+  $ Remove from favorite��$( Middle��$ ../Images/remove16.png������ *RemoveFromFavoriteCommand+  $ Clear favorites��$( Middle��$ ../Images/cleanall16.png������ *ClearFavoriteCommand+
  $
# Edit��.@�  $ Append New Item��$# ../Images/appendnewitem32.png������ *AppendNewItemCommand+{��� *IsEditEnabled+  $ Delete Item��$  ../Images/deleteitem32.png������ *DeleteItemCommand+{��� *IsEditEnabled+
  $# Refresh��.@�  $ Refresh Items��$% ../Images/updatedatastore32.png������ *RefreshCommand+� $��1��$��2��	 �� $
��Auto �$	��200���� $��* �.+�R� -   ) R�Name$) DatastoreView��$��0��$��5q�$��0q�  MsBackgroundBrush#��[ .@�Q� -	   * Q�Name$* DatastoreRoot������ $ 
Horizontal=�.+��� $��../Images/dscol16.png�� 	 FixedImage16#��[	 �� $��Data Store Collection��$��Normal"��� $��0�� 
 MetroSplitter#��[
 �� $��1��$��10q����� *PresentingContent+