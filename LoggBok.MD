2026-09-17
Lär mig att använda github och förstå vad uppgiften går ut på. Detta kommer bli spännande att få ihop

2026-09-29 kl. 10:00
Jag har bestämt mig för att köra en array med garageplatser, jag kommer att börja med att tilldela 100 platser värdet av lediga, sedan tänker jag att jag gör en stor loop 
med meny där vi sätter massor med loopar/if satser så att vi kan ändra tilldelningen av lediga till antingen en car eller en MC eller 2 MC. 

2026-09-29 kl. 13:00
Okej nu tänker jag att jag ska göra metoder, tänker en metod som skriver ut samtliga lediga platser och även en metod där man kan kolla en specifik plats.
Tanken är att den ska vara en del av menyn. Tänker att metoderna ska användas i loopen som ska vara min meny. Mer metoder kommer att behövas.

2026-09-29 kl. 15:00
Har fått till 2 metoder, ena som ska visa tillgängliga platser, man får välja själv om man vill se specifika platser annars kommer metoden visa samtliga platser. 
Den andra metoden är att man kan se en specifik plats. 
Näst på tur är att börja menyn, där kommer jag säkert märka mer metoder jag kommer behöva tror jag. 

2026-09-29 kl. 19:00
Nu har jag fått till att det blir grönt på lediga platser/gult platser med 1 MC/ rött upptagna platser när man använder sig av metoderna för att se
samtliga plats samt för att se specifik plats. 
Har även ändrat mig med att göra en stor loop för menyvalet, valde att göra en metod istället som självklart också inkluderar en loop, men kommer inte 
vara i "Main" som tänkt från början, jag kom på att metoderna kan använda sig av varandra så det borde gå bra detta.

2026-09-30 kl. 10:00
Har bestämt mig för att göra om metoden parkingSpots, det den ska göra nu är att den ska visa samtliga parkeringsplatser.

2026-09-30 kl. 11:00
Angående anteckningen innan, jag ändrade mig igen, nu har jag gjort om parkingSpots så att användaren får själv välja mellan vilka platser
de vill se tillgängliga platser. Var riktigt skönt eftersom att jag gjorde den helt solo utan hjälp, märker dock att jag kanske får lugna ner
mig, ju mer jag gör desto mer vill jag implementera. 

2026-09-30 kl. 15:30
Så nu har jag gjort 2 metoder till, en som tilldelar fordonstypen och en som validerar regnumret, jag är faktiskt riktigt nöjd hittills, jag vet att jag kommer stötta
på problem så vill inte vara för kaxig men jag behöver googla fram mindre saker för varje gång. Känns faktiskt riktigt bra just nu. 
Nästa steg är att kombinera mina 2 metoder som jag gjorden nyss så att jag får ett komplett regnummer kombinerat med fordonstypen och sen en ytterliga metod för att
parkera själva fordonet, känns som att det kommer vara det svåra. Tycker om att göra metoder så att "Main" ska se så rent ut som möjligt. 
Det enda jag skulle vilja göra är att göra så att regnumret endast kan vara 6 siffror men uppgiften säger 10 så jag håller mig till det, 
dock lägger jag till ytterligare en if statement så att användaren kan se vad de har skrivit för regnummer inann de bekräftar. 

2026-09-30 kl. 19:20
Okej jag har kommit halvvägs med själva Parkera fordon metoden, har fått till hur jag ska parkera en bil dock märker jag att MC kommer att vara mycket jobbigare.
Den här delen var faktiskt mycket svårare att få till än de andra metoderna, fick ta mer hjälp till denna del av metoden. Får fortsätta imorgon, har en ide
om hur jag kanske kan göra MC delen, får se om det fungerar.

2026-10-01 kl. 13:30
Klar med parkera fordon metoden, den var faktiskt riktigt jobbig jämfört med de andra metoderna, men den gav mycket också. Ska börja med TaBort fordon metoden näst. 

2026-10-01 kl. 15:30
Har påbörjat RemoveVehicle metoden, car delen är klar men MC delen är lite mer klurig, behöver använda split metod vet dock bara inte hur jag ska använda den än.
Vi fortsätter senare. 

2026-10-01 kl. 23:30
Nu är RemoveVehicle metoden klar! finns lite småsaker jag vill fixa i utskriften men jag tar det imorgon! Programmet börjar kännas rätt komplett. 

2026-10-02 kl. 12:00
Att skapa metoden för att manuellt flytta bilen är sjukt svår, har gjort en del men fastnar hela tiden.

2026-10-02 kl. 22:30
NU ska metoden för att manuellt flytta bilen vara klar, det var det svåraste jag har gjort i detta projekt. Men jag har testat och det ska fungera nu... 
Det mesta är klar, ska gå igenom imorgon för att se om jag kan förbättra något. 
Hittade en bugg, om man flyttar på fordon manuellt till en plats som inte finns typ 101 så krashar programmet. 

2026-10-03 kl. 10:00
Nu är buggen fixad genom att sätta med villkor. Det enda som är kvar är sökfunktion men det ska nog gå att lösa med alla metoder jag har skapat. 

2026-10-03 kl. 11:30
Jag tänkte börja göra med VG uppgifter men måste börja på lektion 9, så jag lämnar in uppgiften som den är så kanske jag kan optimera mer i framtiden
för skojs skull. 
SLUTSATS: 
Otroligt rolig projekt, lärde mig mycket genom att göra detta, var t.ex. väldigt förvirrad med nestlade for loopar och även brytorden som t.ex. 
break, continue och return. Men efter att ha använt de så mycket i detta projekt känner jag att jag har koll på det nu. Hade jag haft tid 
och ork hade jag nog gjort det här projektet på ett lite annorlunda sätt genom fler små metoder som är kopplade till varandra men jag känner mig
ändå väldigt nöjd med detta projekt. Skulle även funnits lite fler funktioner jag hade lagt till typ som att göra projektet till en
lista så att användaren själv kan välja antal platser så att systemet skulle kunna användas i vilket garage som helst men uppgiften var
att det skulle vara 100 platser så en array blev bra. Har även blivit mer bekväm med att välja när jag ska använda while loopar och for loopar samt
när jag ska använda switch satser och if satser. Har egentligen blivit mer bekväm med allt som det här programmet innehåller, jag vet sedan tidigare
att jag är en sådan människa som lär mig bäst genom att göra och inte läsa alldeles för mycket (glömmer ofta bort det om jag inte använder det). 




