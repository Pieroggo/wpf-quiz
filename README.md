<h1>Quiz - wymagania</h1>
W ramach zadania "Quiz" należy przygotować aplikację złożoną z dwóch modułów: generator
quizu, rozwiązywanie quizu.<br/>
Wymagania:
<ul>
<li>Zadanie należy wykonać w parach. Jedna osoba wykonuje aplikację tworzenia quizu, druga
aplikację rozwiązywania quizu.</li>
<li>Należy przedyskutować i zaprojektować odpowiednie klasy składające się na model opisywanego problemu, jak np. klasa Quiz, Question, Answer.</li>
<li>Generator quizu powinien posiadać nastąpujące funkcjonalności:<ul>
<li>tworzenie nowego quizu o zadanej nazwie</li>
<li>dodawanie, usuwanie, modyfikacja pytań należących do danego quizu</li>
<li>zapis quizu do bazy danych Sqlite</li>
<li>wczytanie istniej¡cego quizu z bazy danych Sqlite</li>
<li>przyjazny interfejs chroniący przed popełnieniem pomyłek.</li></ul></li>
<li>Pytanie posiada cztery odpowiedzi, z czego przynajmniej jedna jest poprawna (pytanie
wielokrotnego wyboru).</li>
<li>Aplikacja rozwiązywania quizu powinna posiadać następujące funkcjonalności:<ul>
<li>wczytywanie quizu z bazy danych Sqlite</li>
<li>przyciski "Rozpocznij", "Zakończ" uruchamiające i kończące dany quiz. W zależnoźci
od stanu aplikacji przyciski powinny być włączone lub wyłączone</li>
<li>zegar odmierzający czas rozwiązywania quizu</li>
<li>przyjazny interfejs chroniący przed popełnieniem pomyłek</li>
</ul></li> </ul>
<b>Uwaga:</b> Dane w bazie powinny być szyfrowane.
Za poprawnie wykonany projekt zgodny ze wzorcem MVVM jest możliwość uzyskania 25
punktów. Bez wzorca MVVM co najwyżej 12 punktów.
