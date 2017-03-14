% this line reads the facts in facts.pl, and is used to test the predicates. However, the C#Prolog engine doesn't recognize the consult command, so it must stay commented while not testing. (the main program calls an equivalent of consult, so all the facts are available in the engine)
%:- consult("facts.pl").

% "dynamic" doesn't exists in C#Prolog, but every predicate / fact can be used as if it were defined as dynamic in the prolog engine. Thus, these lines must stay commented out of testing (C#Prolog will ignore them anyway, but leaving them commented avoid the warning message).
%:- dynamic count/1.

/* the Number N of beers rated by the User U in the Category U */
beersRatedInCategory(U,C,N) :-
	retractall(count(_)),
	assert(count(0)),
	forall((rates(U,B,_),beerCategory(B,C)),
		(count(X),
		retract(count(X)),
		Y is X+1, assert(count(Y)))),
	count(N).

/* this function works in SWI-Prolog, but C#Prolog doesn't know forall... FML */