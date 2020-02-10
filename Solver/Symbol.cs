using System;
using System.Collections.Generic;

namespace Calculator
{
	enum TokenType
	{
		identifier,
		function,
		call,
		number,
		litstring,
		mod = '%',
		leftPar = '(',
		rightPar = ')',
		leftPar1 = '[',
		rightPar1 = ']',
		leftPar2 = '{',
		rightPar2 = '}',
		mul = '*',
		plus = '+',
		comma = ',',
		minus = '-',
		div = '/',
		assign = '=',
		pow = '^',
		fact = '!',
		ende = ';',	//end of expression
		end
	}

	class Symbol
	{
		public TokenType type;
		public string name;
		public object value;

		public List<Symbol> args;

		public Symbol left;
		public Symbol right;

		public int lbp;
		public Func<Symbol, Symbol> nud;
		public Func<Symbol, Symbol> led;
		public int i, stCol, stRow;
		public int enCol, enRow;

		public override string ToString()
		{
			string name_ = name != null ? ": '" + name + "'" : "";
			string value_ = value != null ? ": "+value.ToString() : "";

			return string.Format("{0}{1}{2}", type, name_, value_);
		}
	}
}
