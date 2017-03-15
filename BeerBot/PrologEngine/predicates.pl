/* this line reads the facts in facts.pl, and is used to test the predicates. However, the C#Prolog engine doesn't recognize the consult command, so it must stay commented while not testing. (the main program calls an equivalent of consult, so all the facts are available in the engine) */
%:- consult("facts.pl").

/* "dynamic" doesn't exists in C#Prolog, but every predicate / fact can be used as if it were defined as dynamic in the prolog engine. Thus, these lines must stay commented out of testing (C#Prolog will ignore them anyway, but leaving them commented avoid the warning message). */

/* Sum of the elements of the list L */
sum([],0).
sum([H|T],S) :-
	sum(T,S1),
	S is S1 + H.

/* Number of beers rated by the User in the style or category X */
beersRated(U,X,N) :-
	(
	(category(X),findall(B,(rates(U,B,_),beerCategory(B,X)),Z),!);
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
	
/* User likes significatively the category or style X : meaning he rated enough beers in X with a high enough average rating */
likesSignificatively(U,X) :-
	beersRated(U,X,N),
	N > 4, % at least 5 beers must be rated in X
	averageRating(U,X,AR),
	AR > 3. % the average rating the user gives to beers in X is at least 3