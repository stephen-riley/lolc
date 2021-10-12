// Template generated code from Antlr4BuildTasks.Template v 8.14

grammar LolCode;

program : programStart ( stats += statement )* programEnd ? ;

programStart : O ? HAI ;

programEnd : KTHXBYE ;

statement : assignment
          | func_decl
          | varDecl
          | print
          | if_stat
          | loop_stat
          | loop_exit
          | expression
          ;

assignment : LOL ID R expression ;

func_decl : 'HOW DUZ I' name=ID
            func_param_list_decl ? 
            ( stats+=statement ) * 
            'IF U SAY SO' 
            ( 'AN ITZ A ' funcType=lolType ) ?
          ;

func_param_list_decl : 'WIF YR' paramsList+=func_param_decl ( 'AN YR' paramsList+=func_param_decl ) * ;

func_param_decl : type=lolType name=ID ;

varDecl : I_HAZ_A lolType ITZ ID ;

print : I_SEZ expr=expression BANG ? ;

if_stat : 'IZ' expr=expression '?' if_true_clause ( if_false_clause ) ? 'KTHX' ;

if_true_clause : 'YARLY!' ( stats += statement ) * ;

if_false_clause : 'NOWAI!' ( stats += statement ) * ;

loop_stat : 'IM IN YR' openingId=ID ( stats += statement )* 'IM OUTTA YR' closingId=ID ;

loop_exit : 'GTFO' ( breakId=ID ) ? ;

lolType : NUMBAR
        | NUMBR
        | YARN
        ;

expression : atom
           | func_call
           | left=expression op=operator right=expression
           | '(' inner=expression ')'
           ;

atom : STRING
     | INT
     | FLOAT
     | ID
     ;

func_call : 'WUT U SAY?' funcName=ID ( 'WIF' paramsList+=expression ( 'AN WIF' paramsList+=expression ) * ) ? ;

operator : 'UP'
         | 'NERF'
         | 'TIEMZ'
         | 'OVAR'
         | 'BIGR THAN'
         | 'SMALR THAN'
         | 'LIEK'
         | 'NOTS'
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
