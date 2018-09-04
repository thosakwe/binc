grammar Binc;

compilationUnit:
    directive* declaration*;

directive:
    'import' #ImportDirective;

declaration:
    typeAliasDeclaration | functionDeclaration;

typeAliasDeclaration:
    'type' name = Identifier '=' type;

functionDeclaration:
	'fn' templateParameters? thisParameter? name = Identifier functionSignature functionBody;

thisParameter:
    '(' type name = Identifier ')';

functionSignature:
    parameterList ':' returnType = type;

functionBody:
    block;

parameterList:
    '(' ((parameter ',')* parameter)? ')';

parameter:
    name = Identifier ':' type;

type:
	Identifier #TypeReference
	| left = type '|' right = type #UnionType
	| 'enum' '{' (Identifier ',')* Identifier '}' #EnumType
	| '(' (tupleTypeMember ',')* tupleTypeMember ')' #TupleType
	| templateParameters result = type #TemplateType
	| '(' type ')' #ParenthesizedType
	| callee = type templateArguments #TemplateTypeInstantiation;

templateParameter:
	'val' name = Identifier ':' type #ValueTemplateItem
	| 'type' name = Identifier #TypeTemplateItem;

templateParameters:
	'(' (templateParameter ',')* templateParameter ')';

templateArguments:
	'(' (templateArgument ',')* templateArgument ')';

templateArgument:
	expression #ExpressionTemplateArgument
	| type #TypeTemplateArgument;

tupleTypeMember:
    (name = Identifier ':') type;

block:
    '{' statement* '}';

statement:
	'while' condition = expression block #WhileStatement
	| expression #ExpressionStatement
	| 'return' expression #ReturnStatement;

expression:
	Identifier #IdentifierExpression
    | IntegerLiteral PowerOf10? #IntegerLiteralExpression
	| expression '.' symbol = Identifier #MemberExpression
	| callee = expression '(' ((arguments += expression ',')* arguments += expression) ')' #CallExpression
	| '(' (expression ',')+ expression ')' #TupleExpression
	| expression 'as' type #CastExpression
	| '(' expression ')' #ParenthesizedExpression;

SingleLineComment: '//' (~'\n')* -> skip;
Whitespace: [ \n\r\t]+ -> skip;
IntegerLiteral: [0-9]+;
PowerOf10: [Ee] '-'? [0-9]+;
Identifier: [A-Za-z_] [A-Za-z0-9_]*;