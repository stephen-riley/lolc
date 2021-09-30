// Template generated code from Antlr4BuildTasks.Template v 8.14

grammar LolCode;

program : programStart ( stats += statement )+ programEnd ? ;

programStart : O ? HAI ;

programEnd : KTHXBYE ;

statement : assignment
          | varDecl
          | print
          | if_stat
          ;

assignment : LOL ID R expression ;

varDecl : I_HAZ_A lolType ITZ ID ;

print : I_SEZ expr=expression BANG ? ;

if_stat : 'IZ' expr=expression '?' if_true_clause ( if_false_clause ) ? 'KTHX' ;

if_true_clause : 'YARLY!' ( statement ) * ;

if_false_clause : 'NOWAI!' ( statement ) * ;

lolType : NUMBAR
        | NUMBR
        | YARN
        ;

expression : atom
           | expression op expression
           | '(' expr=expression ')'
           ;

atom : STRING
     | INT
     | FLOAT
     | ID
     ;

op : 'WIF'
   | 'UP'
   | 'NERF'
   | 'TIEMZ'
   | 'OVAR'
   | 'BIGR THAN'
   | 'SMALR THAN'
   | 'LIEK'
;

NUMBAR : 'NUMBAR' ;

NUMBR : 'NUMBR' ;

YARN : 'YARN' ;

STRING : '"' .*? '"' ;

FLOAT : NUMBER ;

INT : UNSIGNED_INTEGER ;

O : 'O' ;

HAI : 'HAI' ;

KTHXBYE : 'KTHXBYE' ;

I_HAZ_A : 'I HAZ A' ;

ITZ : 'ITZ' ;

LOL : 'LOL' ;

R : 'R' ;

I_SEZ : 'I SEZ' ;

BANG : '!' ;

IZ : 'IZ' ;

ID : VALID_ID_START VALID_ID_CHAR* ;

WS : [ \r\n\t] + -> channel(HIDDEN) ;

fragment VALID_ID_START : ('a' .. 'z') | ('A' .. 'Z') | '_' ;
fragment VALID_ID_CHAR : VALID_ID_START | ('0' .. '9') ;
fragment NUMBER : ('0' .. '9') + '.' ('0' .. '9') + ;
fragment UNSIGNED_INTEGER : ('0' .. '9')+ ;
