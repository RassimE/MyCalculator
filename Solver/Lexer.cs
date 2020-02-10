using System;
using System.Collections.Generic;

namespace Calculator
{
	internal static class Lexer
	{
		const string operators = "%()*+,-/=^![]{};";

		internal static List<Symbol> GetTokens(string input)
		{
			List<Symbol> result = new List<Symbol>();
			int i = 0;
			int lin = 1, chr = 1;
			bool isComment = false;

			Func<char> getChar = () =>
			{
				if (++i >= input.Length)
					return '\0';

				if (input[i] != '\n')
					chr++;
				if (input[i] == '\r')
				{
					lin++;
					chr = 0;
				}

				return input[i];
			};

			Func<char> peekChar = () =>
			{
				if (i + 1 >= input.Length)
					return '\0';

				return input[i + 1];
			};

			while (i < input.Length)
			{
				char c = input[i];
				int sRow = lin, sCol = chr;

				if (isComment)
				{
					isComment = c != '\r';
					getChar();
				}
				else if (c == '/' && peekChar() == '/')
				{
					isComment = true;
					getChar(); getChar();
				}
				else if (char.IsWhiteSpace(c))
					getChar();
				else if (c == '*' && peekChar() == '*')
				{
					getChar(); getChar();
					result.Add(new Symbol { type = TokenType.pow, stRow = sRow, stCol = sCol, enRow = lin, enCol = chr, i = i });
				}
				else if (operators.IndexOf(c) >= 0)
				{
					result.Add(new Symbol { type = (TokenType)c, stRow = sRow, stCol = sCol, enRow = sRow, enCol = sCol, i = i });
					getChar();
				}
				else if (c == '"')
				{
					string str = "";
					while ((c = getChar()) != '"' && c != '\r')
						str += c;

					getChar();

					result.Add(new Symbol { type = TokenType.litstring, value = str, stRow = sRow, stCol = sCol, enRow = lin, enCol = chr, i = i });
				}
				else if (char.IsDigit(c))
				{
					string num = c.ToString();

					while (char.IsDigit(c = getChar()))
						num += c;

					if (c == '.')
					{
						do num += c;
						while (char.IsDigit(c = getChar()));
					}

					// Read scientific notation (suffix)
					if ((c | 32) == 'e')
					{
						num += c;
						c = getChar();
						if (c == '+' || c == '-')
						{
							num += c;
							c = getChar();
						}

						while (char.IsDigit(c))
						{
							num += c;
							c = getChar();
						}
					}

					if (!double.TryParse(num, out double fTmp))
					{
						string errorString = string.Format("Invalid number \"{0}\" at line {1} position {2}.", num, sRow, sCol);
						throw new Exception(errorString);
					}

					result.Add(new Symbol { type = TokenType.number, value = fTmp, stRow = sRow, stCol = sCol, enRow = lin, enCol = chr, i = i });
				}
				else if (char.IsLetter(c) || c == '_')
				{
					string idn = c.ToString();
					while (char.IsLetterOrDigit(c = getChar()) || c == '_')
						idn += c;

					result.Add(new Symbol { type = TokenType.identifier, name = idn, stRow = sRow, stCol = sCol, enRow = lin, enCol = chr, i = i });
				}
				else
				{
					string errorString = string.Format("Unrecognized token \"{0}\" at line {1} position {2}.", c, sRow, sCol);
					throw new Exception(errorString);
				}
			}

			result.Add(new Symbol { type = TokenType.end, stRow = lin, stCol = chr, enRow = lin, enCol = chr, i = i });

			return result;
		}
	}
}
