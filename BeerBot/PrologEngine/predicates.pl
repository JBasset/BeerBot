/* this line reads the facts in facts.pl, and is used to test the predicates. However, the C#Prolog engine doesn't recognize the consult command, so it must stay commented while not testing. (the main program calls an equivalent of consult, so all the facts are available in the engine) */
:- consult("facts.pl").

/* "dynamic" doesn't exists in C#Prolog, but every predicate / fact can be used as if it were defined as dynamic in the prolog engine. Thus, these lines must stay commented out of testing (C#Prolog will ignore them anyway, but leaving them commented avoid the warning message). */
:- dynamic score/2.

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
	(category(X),findall(B,(rates(U,B,_),beerCategory(B,X)),Z));
	(style(X), findall(B,(rates(U,B,_),beerStyle(B,X)),Z))
	),
	length(Z,N).
/* it would be possible to have the same predicate with a "forall" instead, which would be less complex because it wouldn't need to create a list just for reading its length. However, C#Prolog doesn't know "forall", so this solution can't be used */
	
/* the Average Rating the User gives to the style or category X */
averageRating(U,X,AR) :-
	(
	(category(X),findall(R,(rates(U,B,R),beerCategory(B,X)),Z),!);
	(style(X), findall(R,(rates(U,B,R),beerStyle(B,X)),Z))
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
significativelyKnownBeer(B) :-
	beer(B),
	findall(R, rates(_,B,R), Z),
	length(Z,L),
	L > 4. % We consider the beer to be known enough for at least 5 ratings.

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

advice(User,B) :-
	generateScores(User),
	sortByScore(Lb),
	inList(B,Lb).

/* increment a beer's score */
addScore(Beer,X) :-
	(
		score(Beer,Score),
		retract(score(Beer,Score)),
		NScore is Score + X,
		assert(score(Beer,NScore)),!
	);
	(
		not(score(Beer,_)),
		assert(score(Beer,X))
	).

generateScores(User) :-
	kindScore(User),
	rateScore(3),
	rateScore(4).
	
kindScore(User) :-
	findall(X,(beer(X),
		(
			likesSignificatively(User,Kind),
			beerCategory(X,Kind),
			addScore(X,1)
		)
	),_).

rateScore(Rate) :-
	findall(X,(beer(X),
		(
			beerAverageRating(X,R),
			R >= Rate,
			addScore(X,1)
		)
	),_).