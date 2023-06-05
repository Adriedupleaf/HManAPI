# HManAPI
HangMan
Jocul Hangman cu funcționalități complete de înregistrare și autentificare, conectat la o bază de date Firebase. 
Aplicația oferă utilizatorilor posibilitatea de a se înregistra și autentifica.
Totodata parola poate fi schimbata din user_menu unde mai putem vedea statistica utilizatorului.
În ceea ce privește secțiunea de joc, aplicația permite utilizatorilor să creeze sau să se alăture unui server dedicat indicand nr de persoane si parola serverului. Alți utilizatori  se pot alătura serverelor existente pentru a juca alături de alții.
Toate informațiile despre joc, progresul utilizatorilor și configurările serverelor vor fi stocate și actualizate în baza de date Firebase. Aceasta asigură persistența datelor și sincronizarea între diferiți utilizatori.
Baza de date poate returna tipul de persoana logata astfel pentru admini sunt afisate date si posipilitati separate precum vizualizarea si stergerea unor utlilizatori.
(in dezvoltare)Pe parcursul jocului, utilizatorii vor încerca să ghicească cuvântul secret selectat aleatoriu. Vor avea la dispoziție o interfață interactivă(tastatura vizuala este deja implementata) unde pot introduce litere pentru a încerca să ghicească cuvântul.
Aplicația va oferi informații despre progresul jocului, cum ar fi numărul de încercări rămase și literele deja încercate.
##Demo
![image](https://github.com/Adriedupleaf/HManAPI/assets/116110246/9358f0e4-b1c5-461a-86d0-9f8917d387f1)
![image](https://github.com/Adriedupleaf/HManAPI/assets/116110246/8f575d94-ee59-4324-89e2-9168cf6f798d)
![image](https://github.com/Adriedupleaf/HManAPI/assets/116110246/59966535-edc1-48bd-a4b2-2e45a9811b93)
![image](https://github.com/Adriedupleaf/HManAPI/assets/116110246/bdd6eb94-8b66-4d02-999c-700271e9f35d)
![image](https://github.com/Adriedupleaf/HManAPI/assets/116110246/b730d793-24d1-4698-b82f-5fc8ebe7b20e)
![image](https://github.com/Adriedupleaf/HManAPI/assets/116110246/bd224741-7c7f-4f65-b919-114188dab929)
![image](https://github.com/Adriedupleaf/HManAPI/assets/116110246/79f9d3e5-f95d-4a29-a950-d98e2424fdd8)



##Development/Setup
pentru a deschide programul -> Solution'HmanAPI' ->Views -> Home -> Index.cshtml -> run IIS Express(Browser)
Pentru a acesta pagina game (deja din browser) trebuie sa fii logat cu un cont sau vei fi automat redirectionat spre pagina de logare.

###Membrii
Schiopu Radu
Mihaila Marin
Novac Adrian
Slicari Eugen
