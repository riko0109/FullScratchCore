   M S B A M L   `   `   `  ����J  FFullScratchCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:FullScratchCore.ModelsFullScratchCore.Models  5      G(clr-namespace:FullScratchCore.ViewModelsFullScratchCore.ViewModels  5      =#clr-namespace:FullScratchCore.ViewsFullScratchCore.Views  5	      &     FullScratchCore.Views.CustomList   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2m$clr-namespace:FullScratchCore.Models     5      7vm(clr-namespace:FullScratchCore.ViewModels     5      5local#clr-namespace:FullScratchCore.Views     5	      -   5          >�Name$  CustomListView��5       � 	Resources 5      ,   &FullScratchCore.Models.ByteSIConverter   ByteSIConverter��%   &	          5   
   6   5       � DataContext 5      4   .FullScratchCore.ViewModels.CustomListViewModel  5   
   .��5      �� -   5         ��Name$ ListView��5      $��Stretch=�6B   $��15(�6�   ��6!   �� *
FileList+ �� SelectedItem 6`   �� *SelectedListItem+ 5   
    �� 
TargetType �� Property �� Value m� Command	 m� CommandParameter��%�   '��       �� 5      " ��6   .�5      ��  �@�ContextMenu 5      �� 5      .@�5      m� $
��Open��6'    65   �� *
ExecuteCmd+	 5   5   �� *SelectedListItem.FullPath+5      5      5      5       
 �� View
 5!   
   �� 5"      .P�5#      ��  �� Width$
 Auto��6K    �� DisplayMemberBinding 6!   �� *
FileName+.��5$      �� $
��Name��6+   $��Stretch=�6:   5%      �� 5&      $
 Auto��6L    6!   �� *	Extention+.��5'      �� $��	Extension��6+   $��Stretch=�6?   5(      �� 5)      $
 Auto��6O    6!   �� *CreationTime+.��5*      �� $��CreationTime��6+   $��Stretch=�6B   5+      �� 5,      $
 Auto��6Q    6!   �� *LastUpdateTime+.��5-      �� $��LastAccessTime��6+   $��Stretch=�6D   5.      �� 5/      $
 Auto��6v    6!   �� *
FileSize+ �� 	Converter# [  .��50      �� $
��Size��6+   $��Stretch=�6:   51      52      54      55      