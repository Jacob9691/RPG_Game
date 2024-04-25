# RPG_Game
OOP RPG Afleveringsopgave
### kodeopbygning
Jeg har lavet et RPG console spil, som er bygget op på en sten saks papir (bow, sword, shield) flow.
Spillet bruger factories, som laver items og unit udfra Interfaces.
Man starter spillet med at give sit navn, derefet hvilken sværhedsgrad. Som bestemmer hvor meget liv man starter med.
Derefter kan man se ens states, combat, heal, upgrade weapons eller end spillet. 

Når man ser ens states, kalder man en metode inde i player klasse objektet, som printer ud all deres states. Man sender også info omkring sine våben med, så de også kan printes.

Når man går til combat, blever en metode i sin egen klasse kaldt, som håndtere kampen. Her kalder den player og enemy klasserne, for deres info og metoder.
Man kan skrive, bow, sword eller shield. Bow slår sword, sword slår shield, og shield slår bow. Våbenene har en min. og max. damage, som danner et skade udfra en Random .Next().
Enemy input er random genereret, udfra et metode kald fra en anden helper klasse. Hver gang man får et slag ind, får man en healing orb. Man kan vælge at bruge dem,
hvor der blever dannet tasks for hver orb, der går ind ligger på player objektets liv. Der er sat en lock på, for at undgå muglige konflikter.
Du taber spillet hvis du mister alt dit liv, men vinder hvis enemys liv er væk. Dermed får man penge og exp der bliver lagt på player objektet. 

Når man vælger heal, skal man have en hvis mængde penge, for at komme på max liv.

Når man vil opgradere sine våben, skal man også betale penge, hvor deres min. og max. damage stiger.
Disse muligheder får går i en while(true) loop, hvor en switch går igennem player input.

Min UnitFactory, opretter nye player og enemy objekter, ud fra deres interfaces. Enemy bruger IUnit, men player bruger IPlayer, som nedarver fra IUnit.
Grunden til ditte, er fordi player har nogle værdier og metoder, som enemy ikke skal bruger. Så derfor bruger Jeg IUnit some den basale Interface,
mens player har sin IPlayer som er nedarvet fra IUnit.

Min WeaponFactory, opretter mine weapons. Men i stedet for at have 3 metoder, der opretter et nyt objekt udfra et Interface, for hver våben.
Så gøre jeg mit factory generic, så jeg har kun behov for en metode, som bruger \<T\>. Dermed kan jeg kalde factory metoden med de klasser jeg vil have.

