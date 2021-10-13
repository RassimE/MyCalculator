using System;
using System.Collections.Generic;

namespace Calculator
{
	internal class Parser
	{
		int _i;
		List<Symbol> _tokens;
		Dictionary<TokenType, Symbol> _symbols;

		void putSymbol(TokenType id, Func<Symbol, Symbol> nud = null, int lbp = 0, Func<Symbol, Symbol> led = null)
		{
			if (_symbols.TryGetValue(id, out Symbol sym))
			{
				if (led != null) sym.led = led;
				if (nud != null) sym.nud = nud;
				sym.lbp |= lbp;

				_symbols[id] = sym;
			}
			else
				_symbols[id] = new Symbol()
				{
					lbp = lbp,
					nud = nud,
					led = led
				};
		}

		Symbol getNextSymbol()
		{
			if (_i >= _tokens.Count)
			{
				string errorString = string.Format("Unexpected end at line {0} position {1}.", _tokens[_tokens.Count - 1].stRow, _tokens[_tokens.Count - 1].stCol);
				throw new Exception(errorString);
			}

			var sym = _tokens[_i++];

			sym.lbp = _symbols[sym.type].lbp;
			sym.nud = _symbols[sym.type].nud;
			sym.led = _symbols[sym.type].led;

			return sym;
		}

		void infix(TokenType id, int lbp, int rbp = 0, Func<Symbol, Symbol> led = null)
		{
			rbp = rbp | lbp;

			if (led == null)
				led = (Symbol a) =>
				{
					return new Symbol()
					{
						type = id,
						left = a,
						right = evalExpression(rbp)
					};
				};

			putSymbol(id, null, lbp, led);
		}

		void prefix(TokenType id, int rbp)
		{
			putSymbol(id, (Symbol a) =>
				{
					return new Symbol()
					{
						type = id,
						right = evalExpression(rbp)
					};
				});
		}

		internal Parser()
		{
			_symbols = new Dictionary<TokenType, Symbol>();

			putSymbol(TokenType.comma);
			putSymbol(TokenType.rightPar);
			putSymbol(TokenType.rightPar1);
			putSymbol(TokenType.rightPar2);

			putSymbol(TokenType.end);
			putSymbol(TokenType.ende);
			putSymbol(TokenType.number, (Symbol a) => { return a; });
			putSymbol(TokenType.litstring, (Symbol a) => { return a; });

			putSymbol(TokenType.identifier, (Symbol a) =>
					{
						if (_tokens[_i].type == TokenType.leftPar)
						{
							List<Symbol> args = new List<Symbol>();

							if (_tokens[_i + 1].type == TokenType.rightPar)
								_i++;
							else
							{
								do
								{
									_i++;
									args.Add(evalExpression(2));
								} while (_tokens[_i].type == TokenType.comma);

								if (_tokens[_i].type != TokenType.rightPar)
								{
									string errorString = string.Format("Expected closing parenthesis ')' at line {0} position {1}.", _tokens[_i].stRow, _tokens[_i].stCol);
									throw new Exception(errorString);
								}
							}
							_i++;

							return new Symbol()
							{
								type = TokenType.call,
								args = args,
								name = a.name,
							};
						}

						return a;
					});

			putSymbol(TokenType.leftPar, (Symbol a) =>
					{
						var value = evalExpression(2);
						if (_tokens[_i].type != TokenType.rightPar)
						{
							string errorString = string.Format("Expected closing parenthesis ')' at line {0} position {1}.", _tokens[_i].stRow, _tokens[_i].stCol);
							throw new Exception(errorString);
						}

						_i++;

						return value;
					});

			putSymbol(TokenType.leftPar1, (Symbol a) =>
					{
						var value = evalExpression(2);
						if (_tokens[_i].type != TokenType.rightPar1)
						{
							string errorString = string.Format("Expected closing bracket ']' at line {0} position {1}.", _tokens[_i].stRow, _tokens[_i].stCol);
							throw new Exception(errorString);
						}

						_i++;

						return value;
					});

			putSymbol(TokenType.leftPar2, (Symbol a) =>
				   {
					   var value = evalExpression(2);
					   if (_tokens[_i].type != TokenType.rightPar2)
					   {
						   string errorString = string.Format("Expected closing bracket '}' at line {0} position {1}.", _tokens[_i].stRow, _tokens[_i].stCol);
						   throw new Exception(errorString);
					   }

					   _i++;

					   return value;
				   });

			putSymbol(TokenType.fact, null, 8, (Symbol a) =>
					{
						return new Symbol()
						{
							type = TokenType.fact,
							left = a
						};
					});

			prefix(TokenType.minus, 6);

			infix(TokenType.pow, 7, 5);
			infix(TokenType.mul, 4);
			infix(TokenType.div, 4);
			infix(TokenType.mod, 4);
			infix(TokenType.plus, 3);
			infix(TokenType.minus, 3);

			infix(TokenType.assign, 1, 2, (Symbol left) =>
					{
						if (left.type == TokenType.call)
						{
							for (var i = 0; i < left.args.Count; i++)
								if (left.args[i].type != TokenType.identifier)
								{
									string errorString = string.Format("Invalid argument \"{0}\" at line {1} position {2}.", left.args[i].type, left.args[i].stRow, left.args[i].stCol);
									throw new Exception(errorString);
								}

							return new Symbol
							{
								type = TokenType.function,
								name = left.name,
								args = left.args,
								value = evalExpression(2)
							};
						}
						else if (left.type == TokenType.identifier)
						{
							return new Symbol
							{
								type = TokenType.assign,
								name = left.name,
								value = evalExpression(2)
							};
						}
						else
						{
							string errorString = string.Format("Invalid lvalue at line {0} position {1}.", left.stRow, left.stCol);
							throw new Exception(errorString);
						}
					});
		}

		Symbol evalExpression(int rbp)
		{
			Symbol t = getNextSymbol();
			while (t.type == TokenType.ende)
				t = getNextSymbol();

			if (t.type == TokenType.end)
				return t;

			if (t.nud == null)
			{
				string errorString = string.Format("Unexpected token \"{0}\" at line {1} position {2}.", t.type, t.stRow, t.stCol);
				throw new Exception(errorString);
			}

			Symbol left = t.nud(t);
			left.stRow = t.stRow;
			left.stCol = t.stCol;

			t = getNextSymbol();

			while (rbp < t.lbp)
			{
				if (t.led == null)
				{
					string errorString = string.Format("Unexpected token \"{0}\" at line {1} position {2}.", t.type, t.stRow, t.stCol);
					throw new Exception(errorString);
				}

				left = t.led(left);
				left.stRow = t.stRow;
				left.stCol = t.stCol;

				t = getNextSymbol();
			}
			_i--;
			return left;
		}

		// Entry point into parser.
		internal List<Symbol> Parse(string input)
		{
			_tokens = Lexer.GetTokens(input);
			_i = 0;

			List<Symbol> result = new List<Symbol>();

			while (_i < _tokens.Count)
				result.Add(evalExpression(0));

			return result;
		}
	}
}