using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prolog.Model;
using Prolog.Exception;

namespace Prolog
{
    public class Parser
    {
        private enum TokenType
        {
            Identifier      = 0,
            Arrow           = 1,
            And             = 38,
            LeftBracket     = 40,
            RightBracket    = 41
        }

        private (TokenType, string) IdentiferOrArrow(string identifier)
        {
            if (identifier == '->')
            {
                return (TokenType.Arrow, null);
            }
            return (TokenType.Identifier, identifier);
        }

        private IEnumerable<(TokenType Type, string Value)> Tokenize(IEnumerable<char> code)
        {
            var currentIdentifier = new StringBuilder();
            foreach(var c in code)
            {
                if (c== '(' || c == ')' || c == '&')
                {
                    if (currentIdentifier.Length > 0)
                    {
                        yield return IdentiferOrArrow(currentIdentifier.ToString());
                        currentIdentifier.Clear();
                    }
                    yield return ((TokenType) c, null);
                }
                else if (char.IsWhiteSpace(c) || c == ',')
                {
                    if (currentIdentifier.Length > 0)
                    {
                        yield return IdentiferOrArrow(currentIdentifier.ToString());
                        currentIdentifier.Clear();
                    }
                }
                else
                {
                    currentIdentifier.Append(c);
                }
            }

            if (currentIdentifier.Length > 0)
            {
                yield return IdentiferOrArrow(currentIdentifier.ToString());
            }
        }

        private Fact ParseFact(IEnumerator<(TokenType Type, string Value)> tokens, Dictionary<string, Variable> variables)
        {
            if (!tokens.MoveNext())
            {
                throw new PrologException("3- Unexpected end of code");
            }
            
            if (tokens.Current.Type != TokenType.Identifier) 
            {
                throw new PrologException($"4- Identifier expected, was {tokens.Current.Type}");
            }

            var fact = new Fact(tokens.Current.Value);

            if (!tokens.MoveNext())
            {
                throw new PrologException("4- Unexpected end of code");
            }
            
            if (tokens.Current.Type != TokenType.LeftBracket)
            {
                throw new PrologException($"5- LeftBraket expected, was {tokens.Current.Type}");
            }

            while (tokens.MoveNext() && tokens.Current.Type != TokenType.RightBracket)
            {
                if (tokens.Current.Type != TokenType.Identifier)
                { 
                    throw new PrologException($"6- Identifier expected, was {tokens.Current.Type}");
                }

                if (tokens.Current.Value.Any(c => !char.IsUpper(c)))
                {
                    fact.AddParameter(new Atom(tokens.Current.Value));
                }
                else
                {
                    fact.AddParameter(
                        variables.ContainsKey(tokens.Current.Value) ? 
                        variables[tokens.Current.Value] : 
                        variables[tokens.Current.Value] = new Variable(tokens.Current.Value));
                }
            }

            return fact;
        }

        public Expression Parse(string code)
        {
            var variables = new Dictionary<string, Variable>();
            var tokens = Tokenize(code).GetEnumerator();

            var fact = ParseFact(tokens, variables);

            if (!tokens.MoveNext())
            {
                return fact;
            }

            Expression left = fact;
            
            while (tokens.Current.Type == TokenType.And)
            {
                left = new BinaryExpression(left, ParseFact(tokens, variables));

                if (!tokens.MoveNext()) throw new PrologException("1- Unexpected end of code");
            }

            if (tokens.Current.Type != TokenType.Arrow) 
            {
                throw new PrologException($"2- Arrow expected, was {tokens.Current.Type}");
            }

            return new Rule(left, ParseFact(tokens, variables));
            
        }
    }
}