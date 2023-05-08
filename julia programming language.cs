
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF                =  0, // (EOF)
        SYMBOL_ERROR              =  1, // (Error)
        SYMBOL_WHITESPACE         =  2, // Whitespace
        SYMBOL_MINUS              =  3, // '-'
        SYMBOL_MINUSMINUS         =  4, // '--'
        SYMBOL_EXCLAMEQ           =  5, // '!='
        SYMBOL_PERCENT            =  6, // '%'
        SYMBOL_LPAREN             =  7, // '('
        SYMBOL_RPAREN             =  8, // ')'
        SYMBOL_TIMES              =  9, // '*'
        SYMBOL_TIMESTIMES         = 10, // '**'
        SYMBOL_DIV                = 11, // '/'
        SYMBOL_SEMI               = 12, // ';'
        SYMBOL_LBRACE             = 13, // '{'
        SYMBOL_RBRACE             = 14, // '}'
        SYMBOL_PLUS               = 15, // '+'
        SYMBOL_PLUSPLUS           = 16, // '++'
        SYMBOL_LT                 = 17, // '<'
        SYMBOL_EQ                 = 18, // '='
        SYMBOL_EQEQ               = 19, // '=='
        SYMBOL_GT                 = 20, // '>'
        SYMBOL_CASE               = 21, // Case
        SYMBOL_DIGIT              = 22, // Digit
        SYMBOL_DO                 = 23, // Do
        SYMBOL_DOUBLE             = 24, // double
        SYMBOL_ELSE               = 25, // else
        SYMBOL_ELSEIF             = 26, // elseif
        SYMBOL_END                = 27, // End
        SYMBOL_FLOAT              = 28, // float
        SYMBOL_FOR                = 29, // For
        SYMBOL_FUNCTION           = 30, // Function
        SYMBOL_ID                 = 31, // Id
        SYMBOL_IF                 = 32, // if
        SYMBOL_INT                = 33, // int
        SYMBOL_START              = 34, // Start
        SYMBOL_STRING             = 35, // string
        SYMBOL_SWITCH             = 36, // Switch
        SYMBOL_WHILE              = 37, // While
        SYMBOL_ASSIGN             = 38, // <assign>
        SYMBOL_CONCEPT            = 39, // <concept>
        SYMBOL_COND               = 40, // <cond>
        SYMBOL_DATA               = 41, // <data>
        SYMBOL_DIGIT2             = 42, // <digit>
        SYMBOL_EXP                = 43, // <exp>
        SYMBOL_EXPR               = 44, // <expr>
        SYMBOL_FACTOR             = 45, // <factor>
        SYMBOL_FOR_STATMENT       = 46, // <for_statment>
        SYMBOL_ID2                = 47, // <id>
        SYMBOL_IF_STATMENT        = 48, // <if_statment>
        SYMBOL_IFELSE_STATMENT    = 49, // <ifelse_statment>
        SYMBOL_IFELSEIF_STATMENT  = 50, // <ifelseif_statment>
        SYMBOL_METHOD_CALL        = 51, // <method_call>
        SYMBOL_METHOD_DECLARATION = 52, // <method_declaration>
        SYMBOL_OP                 = 53, // <op>
        SYMBOL_PROGRAM            = 54, // <program>
        SYMBOL_STATMENT_LIST      = 55, // <statment_list>
        SYMBOL_STEP               = 56, // <step>
        SYMBOL_SWITCH_CASE        = 57, // <switch_case>
        SYMBOL_SWITCH_CASE_LIST   = 58, // <switch_case_list>
        SYMBOL_SWITCH_STATMENT    = 59, // <switch_statment>
        SYMBOL_TERM               = 60, // <term>
        SYMBOL_WHILE_STATMENT     = 61  // <while_statment>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM_START_END                                                =  0, // <program> ::= Start <statment_list> End
        RULE_STATMENT_LIST                                                    =  1, // <statment_list> ::= <concept>
        RULE_STATMENT_LIST2                                                   =  2, // <statment_list> ::= <concept> <statment_list>
        RULE_CONCEPT                                                          =  3, // <concept> ::= <assign>
        RULE_CONCEPT2                                                         =  4, // <concept> ::= <if_statment>
        RULE_CONCEPT3                                                         =  5, // <concept> ::= <ifelse_statment>
        RULE_CONCEPT4                                                         =  6, // <concept> ::= <ifelseif_statment>
        RULE_CONCEPT5                                                         =  7, // <concept> ::= <for_statment>
        RULE_CONCEPT6                                                         =  8, // <concept> ::= <while_statment>
        RULE_CONCEPT7                                                         =  9, // <concept> ::= <switch_statment>
        RULE_CONCEPT8                                                         = 10, // <concept> ::= <method_declaration>
        RULE_CONCEPT9                                                         = 11, // <concept> ::= <method_call>
        RULE_ASSIGN_EQ                                                        = 12, // <assign> ::= <id> '=' <expr>
        RULE_ID_ID                                                            = 13, // <id> ::= Id
        RULE_EXPR_PLUS                                                        = 14, // <expr> ::= <expr> '+' <term>
        RULE_EXPR_MINUS                                                       = 15, // <expr> ::= <expr> '-' <term>
        RULE_EXPR                                                             = 16, // <expr> ::= <term>
        RULE_TERM_TIMES                                                       = 17, // <term> ::= <term> '*' <factor>
        RULE_TERM_DIV                                                         = 18, // <term> ::= <term> '/' <factor>
        RULE_TERM_PERCENT                                                     = 19, // <term> ::= <term> '%' <factor>
        RULE_TERM                                                             = 20, // <term> ::= <factor>
        RULE_FACTOR_TIMESTIMES                                                = 21, // <factor> ::= <factor> '**' <exp>
        RULE_FACTOR                                                           = 22, // <factor> ::= <exp>
        RULE_EXP_LPAREN_RPAREN                                                = 23, // <exp> ::= '(' <expr> ')'
        RULE_EXP                                                              = 24, // <exp> ::= <id>
        RULE_EXP2                                                             = 25, // <exp> ::= <digit>
        RULE_DIGIT_DIGIT                                                      = 26, // <digit> ::= Digit
        RULE_IF_STATMENT_IF_LPAREN_RPAREN_START_END                           = 27, // <if_statment> ::= if '(' <cond> ')' Start <statment_list> End
        RULE_IFELSE_STATMENT_IF_LPAREN_RPAREN_START_END_ELSE_END              = 28, // <ifelse_statment> ::= if '(' <cond> ')' Start <statment_list> End else <statment_list> End
        RULE_IFELSEIF_STATMENT_IF_LPAREN_RPAREN_START_END_ELSEIF_END_ELSE_END = 29, // <ifelseif_statment> ::= if '(' <cond> ')' Start <statment_list> End elseif <statment_list> End else <statment_list> End
        RULE_COND                                                             = 30, // <cond> ::= <expr> <op> <expr>
        RULE_OP_LT                                                            = 31, // <op> ::= '<'
        RULE_OP_GT                                                            = 32, // <op> ::= '>'
        RULE_OP_EQEQ                                                          = 33, // <op> ::= '=='
        RULE_OP_EXCLAMEQ                                                      = 34, // <op> ::= '!='
        RULE_FOR_STATMENT_FOR_LPAREN_SEMI_SEMI_RPAREN_LBRACE_RBRACE_END       = 35, // <for_statment> ::= For '(' <data> <assign> ';' <cond> ';' <step> ')' '{' <statment_list> '}' End
        RULE_WHILE_STATMENT_WHILE_DO_LBRACE_RBRACE_END                        = 36, // <while_statment> ::= While <cond> Do '{' <statment_list> '}' End
        RULE_SWITCH_STATMENT_SWITCH_LPAREN_RPAREN_END                         = 37, // <switch_statment> ::= Switch '(' <expr> ')' <switch_case_list> End
        RULE_SWITCH_CASE_LIST                                                 = 38, // <switch_case_list> ::= <switch_case>
        RULE_SWITCH_CASE_LIST2                                                = 39, // <switch_case_list> ::= <switch_case> <switch_case_list>
        RULE_SWITCH_CASE_CASE_LPAREN                                          = 40, // <switch_case> ::= Case '(' <id>
        RULE_SWITCH_CASE_RPAREN_LBRACE_RBRACE                                 = 41, // <switch_case> ::= <digit> ')' '{' <statment_list> '}'
        RULE_DATA_INT                                                         = 42, // <data> ::= int
        RULE_DATA_FLOAT                                                       = 43, // <data> ::= float
        RULE_DATA_DOUBLE                                                      = 44, // <data> ::= double
        RULE_DATA_STRING                                                      = 45, // <data> ::= string
        RULE_STEP_MINUSMINUS                                                  = 46, // <step> ::= '--' <id>
        RULE_STEP_MINUSMINUS2                                                 = 47, // <step> ::= <id> '--'
        RULE_STEP_PLUSPLUS                                                    = 48, // <step> ::= '++' <id>
        RULE_STEP_PLUSPLUS2                                                   = 49, // <step> ::= <id> '++'
        RULE_STEP                                                             = 50, // <step> ::= <assign>
        RULE_METHOD_DECLARATION_FUNCTION_LPAREN_RPAREN_LBRACE_RBRACE_END      = 51, // <method_declaration> ::= Function <id> '(' <id> ')' '{' <statment_list> '}' End
        RULE_METHOD_CALL_LPAREN_RPAREN                                        = 52  // <method_call> ::= <id> '(' <id> ')'
    };

    public class MyParser
    {
        private LALRParser parser;

        public MyParser(string filename)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //'--'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMESTIMES :
                //'**'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE :
                //Case
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT :
                //Digit
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO :
                //Do
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOUBLE :
                //double
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSEIF :
                //elseif
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_END :
                //End
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOAT :
                //float
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //For
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTION :
                //Function
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //Id
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INT :
                //int
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_START :
                //Start
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //string
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH :
                //Switch
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //While
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGN :
                //<assign>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONCEPT :
                //<concept>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COND :
                //<cond>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DATA :
                //<data>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT2 :
                //<digit>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXP :
                //<exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPR :
                //<expr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR_STATMENT :
                //<for_statment>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID2 :
                //<id>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF_STATMENT :
                //<if_statment>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IFELSE_STATMENT :
                //<ifelse_statment>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IFELSEIF_STATMENT :
                //<ifelseif_statment>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_METHOD_CALL :
                //<method_call>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_METHOD_DECLARATION :
                //<method_declaration>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OP :
                //<op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATMENT_LIST :
                //<statment_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STEP :
                //<step>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH_CASE :
                //<switch_case>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH_CASE_LIST :
                //<switch_case_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH_STATMENT :
                //<switch_statment>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<term>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE_STATMENT :
                //<while_statment>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM_START_END :
                //<program> ::= Start <statment_list> End
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATMENT_LIST :
                //<statment_list> ::= <concept>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATMENT_LIST2 :
                //<statment_list> ::= <concept> <statment_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT :
                //<concept> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT2 :
                //<concept> ::= <if_statment>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT3 :
                //<concept> ::= <ifelse_statment>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT4 :
                //<concept> ::= <ifelseif_statment>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT5 :
                //<concept> ::= <for_statment>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT6 :
                //<concept> ::= <while_statment>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT7 :
                //<concept> ::= <switch_statment>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT8 :
                //<concept> ::= <method_declaration>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT9 :
                //<concept> ::= <method_call>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGN_EQ :
                //<assign> ::= <id> '=' <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ID_ID :
                //<id> ::= Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_PLUS :
                //<expr> ::= <expr> '+' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_MINUS :
                //<expr> ::= <expr> '-' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR :
                //<expr> ::= <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_TIMES :
                //<term> ::= <term> '*' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_DIV :
                //<term> ::= <term> '/' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_PERCENT :
                //<term> ::= <term> '%' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM :
                //<term> ::= <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_TIMESTIMES :
                //<factor> ::= <factor> '**' <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR :
                //<factor> ::= <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP_LPAREN_RPAREN :
                //<exp> ::= '(' <expr> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP :
                //<exp> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP2 :
                //<exp> ::= <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIGIT_DIGIT :
                //<digit> ::= Digit
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STATMENT_IF_LPAREN_RPAREN_START_END :
                //<if_statment> ::= if '(' <cond> ')' Start <statment_list> End
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IFELSE_STATMENT_IF_LPAREN_RPAREN_START_END_ELSE_END :
                //<ifelse_statment> ::= if '(' <cond> ')' Start <statment_list> End else <statment_list> End
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IFELSEIF_STATMENT_IF_LPAREN_RPAREN_START_END_ELSEIF_END_ELSE_END :
                //<ifelseif_statment> ::= if '(' <cond> ')' Start <statment_list> End elseif <statment_list> End else <statment_list> End
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COND :
                //<cond> ::= <expr> <op> <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LT :
                //<op> ::= '<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GT :
                //<op> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EQEQ :
                //<op> ::= '=='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EXCLAMEQ :
                //<op> ::= '!='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_STATMENT_FOR_LPAREN_SEMI_SEMI_RPAREN_LBRACE_RBRACE_END :
                //<for_statment> ::= For '(' <data> <assign> ';' <cond> ';' <step> ')' '{' <statment_list> '}' End
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILE_STATMENT_WHILE_DO_LBRACE_RBRACE_END :
                //<while_statment> ::= While <cond> Do '{' <statment_list> '}' End
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SWITCH_STATMENT_SWITCH_LPAREN_RPAREN_END :
                //<switch_statment> ::= Switch '(' <expr> ')' <switch_case_list> End
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SWITCH_CASE_LIST :
                //<switch_case_list> ::= <switch_case>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SWITCH_CASE_LIST2 :
                //<switch_case_list> ::= <switch_case> <switch_case_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SWITCH_CASE_CASE_LPAREN :
                //<switch_case> ::= Case '(' <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SWITCH_CASE_RPAREN_LBRACE_RBRACE :
                //<switch_case> ::= <digit> ')' '{' <statment_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_INT :
                //<data> ::= int
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_FLOAT :
                //<data> ::= float
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_DOUBLE :
                //<data> ::= double
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_STRING :
                //<data> ::= string
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_MINUSMINUS :
                //<step> ::= '--' <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_MINUSMINUS2 :
                //<step> ::= <id> '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_PLUSPLUS :
                //<step> ::= '++' <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_PLUSPLUS2 :
                //<step> ::= <id> '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP :
                //<step> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHOD_DECLARATION_FUNCTION_LPAREN_RPAREN_LBRACE_RBRACE_END :
                //<method_declaration> ::= Function <id> '(' <id> ')' '{' <statment_list> '}' End
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHOD_CALL_LPAREN_RPAREN :
                //<method_call> ::= <id> '(' <id> ')'
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'";
            //todo: Report message to UI?
        }

    }
}
