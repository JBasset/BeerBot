/* consulting the facts created from the database */
:- consult("facts.pl").

:- dynamic score/2, thisUser/1, advKind/1, minRating/1, minAbv/1, maxAbv/1, minIbu/1, maxIbu/1, minSrm/1, maxSrm/1.

/* predicates used to clean the settings of the previous advice */
cleanAdviceSettings :-
	retractall(score(_,_)), retractall(thisUser(_)),
	retractall(advKind(_)), retractall(minRating(_)),
	retractall(minAbv(_)), retractall(maxAbv(_)),
	retractall(minIbu(_)), retractall(maxIbu(_)),
	retractall(minSrm(_)), retractall(maxSrm(_)).

/* predicates used to create the conditions of the advice */
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
	

/* predicates used to read and write in a txt file */

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
	(write(File,E),nl(File))),
	close(File).


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

/* Predicates used to check if an information is significative and can be used in an advice predicate */	

/* User likes significatively the category or style X : meaning he rated enough beers in X with a high enough average rating */
likesSignificatively(U,X) :-
	beersRated(U,X,N),
	N > 4, % at least 5 beers must be rated in X
	averageRating(U,X,AR),
	AR > 3. % the average rating the user gives to beers in X is at least 3

/* Is the beer B known significatively, i.e. rated by enough people for the average rating to be trusted */
beerRatingSignificance(B, Sig) :-
	beer(B),
	findall(R, rates(_,B,R), Z),
	length(Z,L),
	((L < 10, Sig is L*0.1,!);(L >= 10, Sig is 1)).
	% under 10 ratings, we can ponderate reating of a beer with its significance

/* advice given on the users liked categories or styles */
adviceOnKind(U,B) :-
	(
	findall(B1,
	(
		likesSignificatively(U,K),
		beerCategory(B1,K),
		not(rates(U,B1,_))
	),L),
	sortByRating(L,SL),
	inList(B,SL)
	).

/* gives a list of all known enough beers in order of average ratings ; the higher the average rating the higher the beer in the list */
/* this predicate will be used as a default predicates if not enough information are known on the user */
adviceOnRating(U,B,R) :-
	findall(B1,(significativelyKnownBeer(B1),beerAverageRating(B1,_),not(rates(U,B1,_))),L),
	sortByRating(L,SL),
	inList(B,SL),
	beerAverageRating(B,R).

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

setList(L) :-
	findall(Beer,
	(
		beer(Beer),
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
			((R =\= -1, beerAverageRating(Beer,Ar), Ar >= R,!);
			R == -1)
		),
		(
			minAbv(MinAbv),
			((MinAbv =\= -1, abv(Beer,BeerAbv), BeerAbv >= MinAbv,!);
			MinAbv == -1)
		),
		(
			maxAbv(MaxAbv),
			((MaxAbv =\= -1, abv(Beer,BeerAbv), BeerAbv =< MaxAbv,!);
			MaxAbv == -1)
		),
		(
			minIbu(MinIbu),
			((MinIbu =\= -1, ibu(Beer,BeerIbu), BeerIbu >= MinIbu,!);
			MinIbu == -1)
		),
		(
			maxIbu(MaxIbu),
			((MaxIbu =\= -1,ibu(Beer,BeerIbu), BeerIbu =< MaxIbu,!);
			MaxIbu == -1)
		),
		(
			minSrm(MinSrm),
			((MinSrm =\= -1, srm(Beer,BeerSrm), BeerSrm >= MinSrm,!);
			MinSrm == -1)
		),
		(
			maxSrm(MaxSrm),
			((MaxSrm =\= -1,srm(Beer,BeerSrm), BeerSrm =< MaxSrm,!);
			MaxSrm == -1)
		)
	),L).
	
adviceFromCS :-
	cleanAdviceSettings, % we need first to clean the previous advices
	setAdviceConditions,
	setList(L), % getting the beers corresponding the conditions
	thisUser(User),
	advice(User,L,AdvicedLB),
	writeToFile(AdvicedLB).
	
advice(User,LB,AdvicedLB) :-
	generateScores(User,LB),
	sortedScores(AdvicedLB).

generateScores(User,LB) :-
	forall(inList(Beer,LB),% we increment the score of the beer
	(
		(kindScore(User,Beer);true), % if the beer is of a kind the user likes
		(ratingScore(Beer);true)
	)).
	
kindScore(User,Beer) :-
	(
		(beerCategory(Beer,Cat), likesSignificatively(User,Cat));
		(beerStyle(Beer,Sty), likesSignificatively(User,Sty))
	),
	incScore(Beer,1).
	
ratingScore(Beer) :-
	beerAverageRating(Beer,Ar),
	beerRatingSignificance(Beer,Sig),
	Inc is (Sig * Ar) / 2,
	incScore(Beer,Inc).