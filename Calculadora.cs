
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
        SYMBOL_EOF        =  0, // (EOF)
        SYMBOL_ERROR      =  1, // (Error)
        SYMBOL_WHITESPACE =  2, // Whitespace
        SYMBOL_MINUS      =  3, // '-'
        SYMBOL_LPAREN     =  4, // '('
        SYMBOL_RPAREN     =  5, // ')'
        SYMBOL_TIMES      =  6, // '*'
        SYMBOL_DIV        =  7, // '/'
        SYMBOL_CARET      =  8, // '^'
        SYMBOL_PLUS       =  9, // '+'
        SYMBOL_10CARET    = 10, // '10^'
        SYMBOL_ENTERO     = 11, // Entero
        SYMBOL_NENTERO    = 12, // NEntero
        SYMBOL_NREAL      = 13, // NReal
        SYMBOL_REAL       = 14, // Real
        SYMBOL_E          = 15, // <E>
        SYMBOL_F          = 16, // <F>
        SYMBOL_H          = 17, // <H>
        SYMBOL_T          = 18  // <T>
    };

    enum RuleConstants : int
    {
        RULE_E_PLUS          =  0, // <E> ::= <E> '+' <T>
        RULE_E_MINUS         =  1, // <E> ::= <E> '-' <T>
        RULE_E               =  2, // <E> ::= <T>
        RULE_T_TIMES         =  3, // <T> ::= <T> '*' <H>
        RULE_T_DIV           =  4, // <T> ::= <T> '/' <H>
        RULE_T               =  5, // <T> ::= <H>
        RULE_H_10CARET       =  6, // <H> ::= '10^' <F>
        RULE_H_CARET         =  7, // <H> ::= <F> '^' <F>
        RULE_H               =  8, // <H> ::= <F>
        RULE_F_LPAREN_RPAREN =  9, // <F> ::= '(' <E> ')'
        RULE_F_ENTERO        = 10, // <F> ::= Entero
        RULE_F_REAL          = 11, // <F> ::= Real
        RULE_F_NENTERO       = 12, // <F> ::= NEntero
        RULE_F_NREAL         = 13  // <F> ::= NReal
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

            parser.OnReduce += new LALRParser.ReduceHandler(ReduceEvent);
            parser.OnTokenRead += new LALRParser.TokenReadHandler(TokenReadEvent);
            parser.OnAccept += new LALRParser.AcceptHandler(AcceptEvent);
            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            parser.Parse(source);

        }

        private void TokenReadEvent(LALRParser parser, TokenReadEventArgs args)
        {
            try
            {
                args.Token.UserObject = CreateObject(args.Token);
            }
            catch (Exception e)
            {
                args.Continue = false;
                //todo: Report message to UI?
            }
        }

        private Object CreateObject(TerminalToken token)
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

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CARET :
                //'^'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_10CARET :
                //'10^'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ENTERO :
                //Entero
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NENTERO :
                //NEntero
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NREAL :
                //NReal
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_REAL :
                //Real
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_E :
                //<E>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_F :
                //<F>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_H :
                //<H>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_T :
                //<T>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        private void ReduceEvent(LALRParser parser, ReduceEventArgs args)
        {
            try
            {
                args.Token.UserObject = CreateObject(args.Token);
            }
            catch (Exception e)
            {
                args.Continue = false;
                //todo: Report message to UI?
            }
        }

        public static Object CreateObject(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_E_PLUS :
                //<E> ::= <E> '+' <T>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_E_MINUS :
                //<E> ::= <E> '-' <T>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_E :
                //<E> ::= <T>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_T_TIMES :
                //<T> ::= <T> '*' <H>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_T_DIV :
                //<T> ::= <T> '/' <H>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_T :
                //<T> ::= <H>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_H_10CARET :
                //<H> ::= '10^' <F>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_H_CARET :
                //<H> ::= <F> '^' <F>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_H :
                //<H> ::= <F>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_F_LPAREN_RPAREN :
                //<F> ::= '(' <E> ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_F_ENTERO :
                //<F> ::= Entero
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_F_REAL :
                //<F> ::= Real
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_F_NENTERO :
                //<F> ::= NEntero
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_F_NREAL :
                //<F> ::= NReal
                //todo: Create a new object using the stored user objects.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void AcceptEvent(LALRParser parser, AcceptEventArgs args)
        {
            //todo: Use your fully reduced args.Token.UserObject
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
