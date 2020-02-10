using System;
using System.Collections.Generic;

namespace Calculator
{
	internal class Parser
	{
		int _i;
		List<Symbol> _tokens;
		Dictionary<TokenType, Symbol> _symbols;

		void symbol(TokenType id, Func<Symbol, Symbol> nud = null, int lbp = 0, Func<Symbol, Symbol> led = null)
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
						right = expression(rbp)
					};
				};

			symbol(id, null, lbp, led);
		}

		void prefix(TokenType id, int rbp)
		{
			symbol(id, (Symbol a) =>
				{
					return new Symbol()
					{
						type = id,
						right = expression(rbp)
					};
				});
		}

		internal Parser()
		{
			_symbols = new Dictionary<TokenType, Symbol>();

			symbol(TokenType.comma);
			symbol(TokenType.rightPar);
			symbol(TokenType.rightPar1);
			symbol(TokenType.rightPar2);

			symbol(TokenType.end);
			symbol(TokenType.ende);
			symbol(TokenType.number, (Symbol a) => { return a; });
			symbol(TokenType.litstring, (Symbol a) => { return a; });

			symbol(TokenType.identifier, (Symbol a) =>
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
									args.Add(expression(2));
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

			symbol(TokenType.leftPar, (Symbol a) =>
					{
						var value = expression(2);
						if (_tokens[_i].type != TokenType.rightPar)
						{
							string errorString = string.Format("Expected closing parenthesis ')' at line {0} position {1}.", _tokens[_i].stRow, _tokens[_i].stCol);
							throw new Exception(errorString);
						}

						_i++;

						return value;
					});

			symbol(TokenType.leftPar1, (Symbol a) =>
					{
						var value = expression(2);
						if (_tokens[_i].type != TokenType.rightPar1)
						{
							string errorString = string.Format("Expected closing bracket ']' at line {0} position {1}.", _tokens[_i].stRow, _tokens[_i].stCol);
							throw new Exception(errorString);
						}

						_i++;

						return value;
					});

			symbol(TokenType.leftPar2, (Symbol a) =>
				   {
					   var value = expression(2);
					   if (_tokens[_i].type != TokenType.rightPar2)
					   {
						   string errorString = string.Format("Expected closing bracket '}' at line {0} position {1}.", _tokens[_i].stRow, _tokens[_i].stCol);
						   throw new Exception(errorString);
					   }

					   _i++;

					   return value;
				   });

			symbol(TokenType.fact, null, 8, (Symbol a) =>
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
								value = expression(2)
							};
						}
						else if (left.type == TokenType.identifier)
						{
							return new Symbol
							{
								type = TokenType.assign,
								name = left.name,
								value = expression(2)
							};
						}
						else
						{
							string errorString = string.Format("Invalid lvalue at line {0} position {1}.", left.stRow, left.stCol);
							throw new Exception(errorString);
						}
					});
		}

		Symbol getToken()
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

		Symbol expression(int rbp)
		{
			Symbol t = getToken();
			while (t.type == TokenType.ende)
				t = getToken();

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

			t = getToken();

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

				t = getToken();
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
				result.Add(expression(0));

			return result;
		}
	}
}