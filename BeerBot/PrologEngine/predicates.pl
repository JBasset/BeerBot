/* ------------------------------------------ */	
/* CONSULTING THE FACTS CREATED FROM THE DATABASE */
/* ------------------------------------------ */
:- consult("facts.pl").

/*------------------------------------------*/
/* CREATING THE DYNAMIC VARIABLES USED BY THE EXPERT SYSTEM */
/*------------------------------------------*/
:- dynamic score/2, thisUser/1, advKind/1, minRating/1, minAbv/1, maxAbv/1, minIbu/1, maxIbu/1, minSrm/1, maxSrm/1.

/*------------------------------------------*/
/* PREDICATES USED TO READ AND WRITE IN A TXT FILE */
/*------------------------------------------*/

readFromFile(L) :-
	open('CSToProlog.txt', read, File), % informations from the C# interface
	reader(File,L),
	close(File).

reader(File,L) :-
	read_line_to_codes(File, T),
	(
		T  = end_of_file -> L = [];
		atom_codes(T1, T),
		reader(File,L1), L = [T1 | L1]
	).
	
writeToFile(L) :-
	open('PrologToCS.txt', write, File), % informations sent to the C# interface
	forall(inList(E,L),
	(
		write(File,E),
		nl(File)
	)),
	close(File).

/*------------------------------------------*/
/* PREDICATE USED TO CLEAN THE SETTINGS OF THE PREVIOUS ADVICE */
/*------------------------------------------*/

cleanAdviceSettings :-
	retractall(score(_,_)), retractall(thisUser(_)),
	retractall(advKind(_)), retractall(minRating(_)),
	retractall(minAbv(_)), retractall(maxAbv(_)),
	retractall(minIbu(_)), retractall(maxIbu(_)),
	retractall(minSrm(_)), retractall(maxSrm(_)).

/*------------------------------------------*/
/* PREDICATE USED TO CREATE THE CONDITIONS OF THE ADVICE */
/*------------------------------------------*/

setAdviceConditions :-
	readFromFile(L),
	forall(inList(E,L),
	(
		(
			user(E),
			assert(thisUser(E))
		);
		( % if the kind is not set yet
			not(advKind(_)), assert(advKind(E)) 
		);
		( % if the minimum rating is not set yet
			not(minRating(_)), atom_number(E,X), assert(minRating(X)) 
		);
		(% if the minimum ABV is not set yet
			not(minAbv(_)), atom_number(E,X), assert(minAbv(X)) 
		);
		(% if the maximum ABV is not set yet
			not(maxAbv(_)), atom_number(E,X), assert(maxAbv(X)) 
		);
		(% if the minimum IBU is not set yet
			not(minIbu(_)), atom_number(E,X), assert(minIbu(X)) 
		);
		(% if the maximum IBU is not set yet
			not(maxIbu(_)), atom_number(E,X), assert(maxIbu(X)) 
		);
		(% if the minimum SRM is not set yet
			not(minSrm(_)), atom_number(E,X), assert(minSrm(X)) 
		);
		(% if the maximum SRM is not set yet
			not(maxSrm(_)), atom_number(E,X), assert(maxSrm(X)) 
		)
	)).

/*------------------------------------------*/
/* PREDICATES USED FOR BASIC MANIPULATION OF PROLOG OBJECTS IN THE APPLICATION */
/*------------------------------------------*/

/* sorting a list of beer in descending order of their average rating */
maximumRating([],_,0).
maximumRating([H|T],B,M) :-
	beer(H),
	maximumRating(T,B1,M1),
	(beerAverageRating(H,AR); AR is 0),
	((AR > M1, M is AR, B = H);
	(AR =< M1, M is M1, B = B1)),!.

deleteElement(H,[H|T],T).
deleteElement(E,[H1, H2|T1], [H1|T2]) :-
	deleteElement(E, [H2|T1], T2) , !.

sortByRating([],[]).
sortByRating(L1,[H2|T2]) :-
	maximumRating(L1,H2,_),
	deleteElement(H2,L1,L3),
	sortByRating(L3,T2), !.

/* Sorting a list of beer from their scores */
maximumScore([],_,0).
maximumScore([H|T],B,M) :-
	beer(H),
	maximumScore(T,B1,M1),
	(score(H,AR); AR is 0),
	((AR > M1, M is AR, B = H);
	(AR =< M1, M is M1, B = B1)),!.

sortByScore([],[]).
sortByScore(L1,[H2|T2]) :-
	maximumScore(L1,H2,_),
	deleteElement(H2,L1,L3),
	sortByScore(L3,T2), !.

/* generates a list of sorted scores */
sortedScores(L) :-
	findall(Beer,score(Beer,_),BeerList),
	sortByScore(BeerList,L).

/* getting the elements of the list */
inList(E,[E|_]).
inList(E,[_|T]) :- inList(E,T).

/* Sum of the elements of the list L */
sum([],0).
sum([H|T],S) :-
	sum(T,S1),
	S is S1 + H.
	
/* distance between X and Y */
dist(X,Y,Dist) :-
	(X-Y >= 0, Dist is X-Y);
	(Y-X > 0, Dist is Y-X).

/*------------------------------------------*/
/* PREDICATES USED FOR TREATMENT ON THE DATA FROM THE FACT.PL FILE */
/*------------------------------------------*/

/* Number of beers rated by the User in the style or category X */
beersRated(U,X,N) :-
	(
		(
			category(X),
			findall(B,(rates(U,B,_),beerCategory(B,X)),Z)
		);
		(
			style(X),
			findall(B,(rates(U,B,_),beerStyle(B,X)),Z)
		)
	),
	length(Z,N).
	
/* Getting the list of all beers rated by the User */
listRatedBeers(User,List) :-
	findall(Beer,rates(User,Beer,_),List).
	
/* the Average Rating the User gives to the style or category X */
averageRating(U,X,AR) :-
	(
		(
			category(X),
			findall(R,(rates(U,B,R),beerCategory(B,X)),Z),
			!
		);
		(
			style(X),
			findall(R,(rates(U,B,R),beerStyle(B,X)),Z)
		)
	),
	length(Z,L),
	L =\= 0, % we might want to avoid dividing by zero
	sum(Z,S),
	AR is S / L.

/* the average rating of a beer */
beerAverageRating(B,AR) :-
	findall(R,rates(_,B,R),L),
	length(L,Length),
	Length =\= 0,
	sum(L,S),
	AR is S / Length.

/* average rating a user gives to a list of beers (known to him) */
arList(User,List,AR) :-
	findall(R,(
		inList(B,List),
		rates(User,B,R)
	),L),
	length(L,Length),
	Length > 0,
	sum(L,Sum),
	AR is Sum / Length.	

/*------------------------------------------*/
/* PREDICATES USED TO CHECK IF AN INFORMATION IS SIGNIFICATIVE AND CAN BE USED IN AN ADVICE PREDICATE */	
/*------------------------------------------*/

/* User likes significatively the category or style X : meaning he rated enough beers in X with a high enough average rating */
likesSignificatively(U,X) :-
	beersRated(U,X,N),
	N > 4, % at least 5 beers must be rated in X
	averageRating(U,X,AR),
	AR >= 2.5. % the average rating the user gives to beers in X is at least 2.5
	
/* User dislikes significatively the category or style X */
dislikesSignificatively(U,X) :-
	beersRated(U,X,N),
	N > 4, % at least 5 beers must be rated in X
	averageRating(U,X,AR),
	AR < 2.5. % the average rating the user gives to beers in X is at most 2.5

/* Is the beer B known significatively, i.e. rated by enough people for the average rating to be trusted */
beerRatingSignificance(B, Sig) :-
	beer(B),
	findall(R, rates(_,B,R), Z),
	length(Z,L),
	((L < 10, Sig is L*0.1,!);(L >= 10, Sig is 1)).
	% under 10 ratings, we can ponderate reating of a beer with its significance

/*------------------------------------------*/
/* PREDICATE USED TO SET THE LIST OF BEER TO SORT FOR ADVICE FROM THE ADVICE CONDITIONS */
/*------------------------------------------*/
	
setList(L) :-
	findall(Beer,
	(
		beer(Beer),
		thisUser(User),
		not(rates(User,Beer,_)), % we don't advice beers the user already rated
		(
			advKind(Kind),
			(
				(
					((category(Kind),beerCategory(Beer,Kind));
					(style(Kind),beerStyle(Beer,Kind)))
				);
				not(category(Kind);style(Kind))
			)
		),
		(
			minRating(R),
			((R =\= -1, beerAverageRating(Beer,Ar), Ar >= R);
			R == -1)
		),
		(
			minAbv(MinAbv),
			((MinAbv =\= -1, abv(Beer,BeerAbv), BeerAbv =\= -1, BeerAbv >= MinAbv);
			MinAbv == -1)
		),
		(
			maxAbv(MaxAbv),
			((MaxAbv =\= -1, abv(Beer,BeerAbv), BeerAbv =\= -1, BeerAbv =< MaxAbv);
			MaxAbv == -1)
		),
		(
			minIbu(MinIbu),
			((MinIbu =\= -1, ibu(Beer,BeerIbu), BeerIbu =\= -1, BeerIbu >= MinIbu);
			MinIbu == -1)
		),
		(
			maxIbu(MaxIbu),
			((MaxIbu =\= -1,ibu(Beer,BeerIbu), BeerIbu =\= -1, BeerIbu =< MaxIbu);
			MaxIbu == -1)
		),
		(
			minSrm(MinSrm),
			((MinSrm =\= -1, srm(Beer,BeerSrm), BeerSrm =\= -1, BeerSrm >= MinSrm);
			MinSrm == -1)
		),
		(
			maxSrm(MaxSrm),
			((MaxSrm =\= -1,srm(Beer,BeerSrm), BeerSrm =\= -1, BeerSrm =< MaxSrm);
			MaxSrm == -1)
		)
	),L).
	
/*------------------------------------------*/
/* MAIN PREDICATES OF THE APPLICATION : ADVICE PREDICATES */
/*------------------------------------------*/	

adviceFromCS :-
	consult("facts.pl"), % the fact file can have been modified by the program since last execution
	cleanAdviceSettings, % we need first to clean the previous advices
	setAdviceConditions,
	setList(L), % getting the beers corresponding the conditions
	thisUser(User),
	advice(User,L,AdvicedLB),
	writeToFile(AdvicedLB).
	
advice(User,LB,AdvicedLB) :-
	generateScores(User,LB),
	sortedScores(AdvicedLB).

/*------------------------------------------*/
/* PREDICATE USED TO SET SCORES OF A LIST OF BEERS */
/*------------------------------------------*/	
	
generateScores(User,LB) :-
	forall(inList(Beer,LB),% we increment the score of the beer
	(
		incScore(Beer,0), % we initialize the score of each beer to 0
		(kindScore(User,Beer);true), % if the beer is of a kind the user likes
		(ratingScore(Beer);true),
		(abvScore(User,Beer);true),
		(ibuScore(User,Beer);true),
		(srmScore(User,Beer);true),
		(ageScore(User,Beer);true)
	)).

/*------------------------------------------*/	
/* PREDICATES USED TO CALCULATE A BEER'S SCORE */
/*------------------------------------------*/	
	
/* increment a beer's score */
incScore(Beer, Inc) :-
	(
		score(Beer,Score),
		retract(score(Beer,Score)),
		NScore is Score + Inc,
		assert(score(Beer,NScore)),!
	);
	(
		not(score(Beer,_)),
		assert(score(Beer,Inc))
	).	

/* we increment the score if the beer is in a category or style the user likes, and decrement it if the beer is in a category or style the user dislikes */
kindScore(User,Beer) :-
	(
		(
			(
				beerCategory(Beer,Cat),
				likesSignificatively(User,Cat),
				averageRating(User,Cat,Ar)
			); % no '!' ; if the beer is of a category AND a style the user likes, we increment twice (same for decrement)
			(
				beerStyle(Beer,Sty),
				likesSignificatively(User,Sty),
				averageRating(User,Sty,Ar)
			)
		),
		Inc is Ar / 5,
		incScore(Beer,Inc)
	);
	(
		(
			(
				beerCategory(Beer,Cat),
				dislikesSignificatively(User,Cat),
				averageRating(User,Cat,Ar)
			);
			(
				beerStyle(Beer,Sty),
				dislikesSignificatively(User,Sty),
				averageRating(User,Sty,Ar)
			)
		),
		Inc is -((5 - Ar) / 5),
		incScore(Beer,Inc)
	).
	
/* we increment the score if the beer is well rated in average, and decrement it if the beer is badly rated in average */
ratingScore(Beer) :-
	beerAverageRating(Beer,Ar),
	beerRatingSignificance(Beer,Sig), % we ponderate the result by the significance of the average rating of the beer : a beer with only a few ratings will have a less decisive ratingScore
	((
		Ar >= 2.5,
		Inc is (Sig * Ar) / 2
	);
	(
		Ar < 2.5,
		Inc is -(Sig * (5 - Ar)) / 2
	)),
	incScore(Beer,Inc).
	
/* the score increases if the user likes beers with a close ABV, and decreases if the user dislikes beers with a close ABV */
abvScore(User,Beer) :-
	abv(Beer,ThisAbv),
	listRatedBeers(User,L),
	findall(B,(
		inList(B,L),
		abv(B,Abv),
		Abv =\= -1,
		dist(ThisAbv,Abv,Dist),
		Range is ThisAbv / 5,
		Dist < Range
	),AbvList),
	arList(User,AbvList,AR),
	((
		AR >= 2.5,
		Inc is AR / 5,
		incScore(Beer,Inc)
	);
	(
		AR < 2.5,
		Inc is -((5 - AR) / 5),
		incScore(Beer,Inc)
	)).
	
/* the score increases if the user likes beers with a close IBU */
ibuScore(User,Beer) :-
	ibu(Beer,ThisIbu),
	listRatedBeers(User,L),
	findall(B,(
		inList(B,L),
		ibu(B,Ibu),
		Ibu =\= -1,
		dist(ThisIbu,Ibu,Dist),
		Range is ThisIbu / 5,
		Dist < Range
	),IbuList),
	arList(User,IbuList,AR),
	((
		AR >= 2.5,
		Inc is AR / 5,
		incScore(Beer,Inc)
	);
	(
		AR < 2.5,
		Inc is -((5 - AR) / 5),
		incScore(Beer,Inc)
	)).
	
/* the score increases if the user likes beers with a close SRM */
srmScore(User,Beer) :-
	srm(Beer,ThisSrm),
	listRatedBeers(User,L),
	findall(B,(
		inList(B,L),
		srm(B,Srm),
		Srm =\= -1,
		dist(ThisSrm,Srm,Dist),
		Range is ThisSrm / 5,
		Dist < Range
	),SrmList),
	arList(User,SrmList,AR),
	((
		AR >= 2.5,
		Inc is AR / 5,
		incScore(Beer,Inc)
	);
	(
		AR < 2.5,
		Inc is -((5 - AR) / 5),
		incScore(Beer,Inc)
	)).
	
/* we increment the score if the beer is liked in average by user of the same generation than the user (+/- 3 years) */
ageScore(User,Beer) :-
	birthDate(User,ThisBD),
	findall(U,(
		user(U),
		U \== User,
		birthDate(U,BD),
		dist(ThisBD,BD,Dist),
		Dist < 3
	),L), % we look for all user at +/- 3 years from the actual user
	findall(R,(
		inList(U,L),
		rates(U,Beer,R)
	),ARL), % we get all the ratings these users give to 'Beer'
	length(ARL,Length),
	Length > 4, % if less than 5 users rated the beer, the result is considered not significative enough and we don't change the score
	sum(ARL,Sum),
	AR is Sum / Length, % We get the average rating of these ratings
	((
		AR >= 2.5,
		Inc is AR / 5,
		incScore(Beer,Inc)
	);
	(
		AR < 2.5,
		Inc is -((5 - AR) / 5),
		incScore(Beer,Inc)
	)).