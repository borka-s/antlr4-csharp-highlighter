parser grammar CSharpParser;

@parser::header {#pragma warning disable 3021}

options { tokenVocab=CSharpLexer; }

prog: highlight+;

highlight
    : keyword
    | literal
    | comment
    | rest
    ;

rest
    : WHITESPACES
    | IDENTIFIER
    | OPEN_BRACE
    | CLOSE_BRACE
    | SMTH ;

literal
	: boolean_literal
	| string_literal
	| numeric_literal
	| CHARACTER_LITERAL
	;

numeric_literal
    : INTEGER_LITERAL
	| HEX_INTEGER_LITERAL
	| BIN_INTEGER_LITERAL
	| REAL_LITERAL
    ;

boolean_literal
	: TRUE
	| FALSE
	;

string_literal
	: INTERPOLATED_REGULAR_STRING
	| INTERPOLATED_REGULAR_STRING
	| REGULAR_STRING
	| VERBATIUM_STRING
	;

//B.1.7 Keywords
keyword
	: ABSTRACT
	| AS
	| ASYNC
    | AWAIT
	| BASE
	| BOOL
	| BREAK
	| BYTE
	| CASE
	| CATCH
	| CHAR
	| CHECKED
	| CLASS
	| CONST
	| CONTINUE
	| DECIMAL
	| DEFAULT
	| DELEGATE
	| DO
	| DOUBLE
	| DYNAMIC
	| ELSE
	| ENUM
	| EVENT
	| EXPLICIT
	| EXTERN
	| FALSE
	| FINALLY
	| FIXED
	| FLOAT
	| FOR
	| FOREACH
	| FROM
	| GOTO
	| GROUP
	| IF
	| IMPLICIT
	| IN
	| INTO
	| INT
	| INTERFACE
	| INTERNAL
	| IS
	| JOIN
    | LET
    | LOCK
	| LONG
    | NAMEOF
    | NAMESPACE
	| NEW
	| NULL_
	| OBJECT
	| OPERATOR
    | ON
	| OUT
    | ORDERBY
	| OVERRIDE
	| PARAMS
    | PARTIAL
	| PRIVATE
	| PROTECTED
	| PUBLIC
	| READONLY
	| REF
	| RETURN
	| SBYTE
	| SEALED
	| SELECT
	| SHORT
	| SIZEOF
	| STACKALLOC
	| STATIC
	| STRING
	| STRUCT
	| SWITCH
	| THIS
	| THROW
	| TRUE
	| TRY
	| TYPEOF
	| UINT
	| ULONG
	| UNCHECKED
	| UNMANAGED
	| UNSAFE
	| USHORT
	| USING
	| VAR
    | VIRTUAL
	| VOID
	| VOLATILE
	| WHEN
    | WHERE
    | WHILE
    | YIELD
	;

comment
    : SINGLE_LINE_DOC_COMMENT
    | EMPTY_DELIMITED_DOC_COMMENT
    | DELIMITED_DOC_COMMENT
    | SINGLE_LINE_COMMENT
    | DELIMITED_COMMENT;
