   M S B A M L   `   `   `  ����?  ;Quiz, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WPFQuizWPFQuiz  5   	   5clr-namespace:WPFQuiz.ViewModelWPFQuiz.ViewModel  5   	       WPFQuiz.Quiz   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   !localclr-namespace:WPFQuiz  5   	   (vmclr-namespace:WPFQuiz.ViewModel  5   	     � Title$
  Quiz��5
   	   $	��450��6   $	��800��6#   y�6/   �� *QuizVisibility+ � DataContext 5      %  WPFQuiz.ViewModel.QuizViewModel  5   
   -   5        quizViewModel��5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��6* �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ quizListTitle��5      $��0��6'   $��0��67   $��Arial)�6D   $��25(�6W   $��Lista Quizów��6e   $��Center=�6|   $��Center=�6�   $
��Bold"�6�   �� 5   
   $��0��6   $��1��6"   
�����_���6F   �� *
QuizList+ �� SelectedItem 6g   �� *SelectedQuiz+.  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5         	EventName$ SelectionChanged��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction  	   Command	 6,   �� *OnSelectionChanged+5      5       � 5!   
   $��1��6   $��0��6    5"      �� 5#      $��3* �6#   �� 5$      $��* �6#   .+�5&      �� $��0��6   $��Arial)�6$   $��25(�67   $��Center=�6p   $
��Bold"�6�   $��Center=�6�   ��6E   �� *	QuizTitle+
 �� Mode$
 OneWay=�6�   �� 5(      $��1��6   $��Zakończ Quiz��6%   $��Center=�6{   $��	20,0,20,0q�6�   ��6<   �� *
StopQuiz+{�6Y   �� *StopEnabled+6�   5*      � 5,   
   $��1��6   $��1��6   
�������{�6C   �� *
QuizInPlay+ 5-      �� 5.      �� 5/      $��5* �6#   �� 50      �� 51      $��* �6#   �� 52      $��5* �6#   �� 53      �� 54       56      �� 57      $	��10* �6    �� 58      $��8* �6    �� 59      $��2* �6    �� 5:      $��8* �6    �� 5;      �� 5<      $��5* �6    �� 5=      .+�5?      �� $��1��6   $��0��6(   $��5��65   $��Center=�6n   $��	20,0,20,0q�6�   $��Center=�6�   ��6I   �� *CurrentQuestionText+6�   �� 5@      $��1��6   $��1��6(   $��Center=�6U   $��	20,0,20,0q�6p   $��Center=�6�   ��65   �� *CurrentAnswerA+6�   �� 5A      $��2��6   $��1��6'   $��Center=�6S   $��Center=�6p    d� 	IsChecked 64   �� *
CheckedA+6p   �� 5B      $��4��6   $��1��6(   $��Center=�6U   $��	20,0,20,0q�6p   $��Center=�6�   ��65   �� *CurrentAnswerB+6�   �� 5C      $��5��6   $��1��6'   $��Center=�6S   $��Center=�6p    64   �� *
CheckedB+6p   �� 5D      $��1��6   $��3��6(   $��Center=�6U   $��	20,0,20,0q�6p   $��Center=�6�   ��65   �� *CurrentAnswerC+6�   �� 5E      $��2��6   $��3��6'   $��Center=�6S   $��Center=�6p    64   �� *
CheckedC+6p   �� 5F      $��4��6   $��3��6(   $��Center=�6U   $��	20,0,20,0q�6p   $��Center=�6�   ��65   �� *CurrentAnswerD+6�   �� 5G      $��5��6   $��3��6'   $��Center=�6S   $��Center=�6p    64   �� *
CheckedD+6p   �� 5H      $��1��6   $��5��6%   $��2��62   $��Sprawdź Odpowiedź��6F   $��Right=�6�   $��Center=�6�   $��0,0,0,0q�6�   ��6b   �� *CheckQuestion+6�   �� 5I      $��4��6   $��5��6%   $��Następne Pytanie��62   $
��Left=�6u   $��Center=�6�   $��0,0,30,0q�6�   ��6M   �� *NextQuestionCommand+6�   5K      � 5L   
   -   5        $��Button_Grid��5L      $��0��6"   $��2��62    5M      �� 5N      $��* �6    .+�5Q      �� $��0��6   $��Rozpocznij Quiz��6"   $��Center=�6<   $��	20,0,20,0q�6W   {�6j   �� *StartEnabled+��6�   �� *	StartQuiz+5R      � 5S   
   $��1��6   $��2��6    5T      �� 5U      $��* �6#   �� 5V      $��* �6#   .+�5X      �� $��0��6   $��Center=�6K   $��Center=�6f   $��Arial)�6�   $
��Bold"�6�   $��25(�6�   ��6$   �� *Score+$
 OneWay=�6�   �� 5Y      $��1��6   $��Center=�6A   $��Center=�6\   $��Arial)�6y   $
��Bold"�6�   $��25(�6�   ��6$   �� *
QuizTime+6�   5Z      5[      5\      