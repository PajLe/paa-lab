# Laboratorijske vežbe iz predmeta "Projektovanje i analiza algoritama"

##Poređenje stringova

Implementirati Rabin-Karp i Knut-Moris-Prat algoritme za traženje podstringova, kao i SoundEx i Levenstein algoritme za traženje stringova po sličnosti.

Svaki od njih treba da prođe kroz ceo string, nađe sva pojavljivanja traženog podstringa i snimi ih u poseban fajl – u slučaju Rabin-Karpovog i Knut-Moris-Pratovog algoritma treba da vrati tačna poklapanja, u slučaju SoundEx-a reči sa istim kodom, a u slučaju Levenstein algoritma, reči koje su <= 3 udaljene od podstringa koji se traži.

Pripremiti fajlove sa stringovima u kojima se traže podstringovi. Fajlovi treba da imaju 100, 1000, 10 000 i 100 000 reči.

Podržati slučajeve kada je string kroz koji se traži sastavljen:

-          Samo od hex cifara (azbuka sa 16 slova)

-          Cele ASCII tabele (256 znakova)

Testirati ponašanje za podstingove dužine 5, 10, 20 i 50 karaktera. Podstring mora da bude napisan istom azbukom kao i string učitan iz fajla.

Uporediti performanse algoritama za sve navedene slučajeve po vremenu izvršenja.


Potrebno je predati urađeni zadatak zajedno sa svim pomoćnim fajlovima u zadatak Laboratorijska vežba 1 u okviru sekcije Laboratorijske vežbe, najkasnije do ponedeljka 13. aprila, u 10h. Odbrana laboratorijske vežbe biće održana u utorak 14. aprila u 17h, koriščenjem platforme MS Teams.
