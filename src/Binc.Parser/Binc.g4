grammar Binc;

compilationUnit: directive* declaration*;

directive:
    'import' #ImportDirective
;

declaration:
    'func' name=Identifier functionSignature functionBody #FunctionDeclaration
;

functionSignature: parameterList ':' returnType=type;

functionBody: block;

parameterList: '(' ((parameter ',')* parameter)? ')';

parameter: name=Identifier ':' type;

type:
    Identifier #TypeReference
;

block: '{' statement* '}';

statement:
    expression #ExpressionStatement
    | 'return' expression #ReturnStatement
;

expression:
    Identifier
;

Whitespace: [ \n\r\t]+ -> skip;
Identifier: [A-Za-z_] [A-Za-z0-9_]*;