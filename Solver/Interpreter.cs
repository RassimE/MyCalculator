using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Calculator
{
	internal class Interpreter
	{
		Dictionary<string, Func<object>> _builtInFunctions;
		Dictionary<string, Func<object>> _userFunctions;

		Dictionary<string, object> _consts;
		Dictionary<string, object> _libVariables;
		Dictionary<string, object> _variables;

		Dictionary<string, object> _args;
		List<object> _argValues;
		Random _rnd;
		Parser _parser;
		int _level;
		bool _libMode;

		internal Dictionary<string, object> Variables
		{
			get
			{
				return _consts.Union(_libVariables.Union(_variables)).ToDictionary(pair => pair.Key, pair => pair.Value);
			}
		}

		internal Dictionary<string, Func<object>> Functions
		{
			get
			{
				return _builtInFunctions.Union(_userFunctions).ToDictionary(pair => pair.Key, pair => pair.Value);
			}
		}

		void initInterpreter()
		{
			_consts = new Dictionary<string, object>();
			_builtInFunctions = new Dictionary<string, Func<object>>();

			_consts["PI"] = Math.PI;
			_consts["E"] = Math.E;
			_consts["DegToRadVal"] = Math.PI / 180.0;
			_consts["RadToDegVal"] = 180.0 / Math.PI;

			_builtInFunctions["degtorad"] = () => { return Convert.ToDouble(getArgValue(0)) * Math.PI / 180.0; };
			_builtInFunctions["radtodeg"] = () => { return Convert.ToDouble(getArgValue(0)) * 180.0 / Math.PI; };
			_builtInFunctions["sin"] = () => { return Math.Sin(Convert.ToDouble(getArgValue(0))); };
			_builtInFunctions["cos"] = () => { return Math.Cos(Convert.ToDouble(getArgValue(0))); };
			_builtInFunctions["tan"] = () => { return Math.Tan(Convert.ToDouble(getArgValue(0))); };

			_builtInFunctions["sec"] = () => { return 1.0 / Math.Cos(Convert.ToDouble(getArgValue(0))); };
			_builtInFunctions["cosec"] = () => { return 1.0 / Math.Sin(Convert.ToDouble(getArgValue(0))); };
			_builtInFunctions["cotan"] = () => { return 1.0 / Math.Tan(Convert.ToDouble(getArgValue(0))); };

			_builtInFunctions["asin"] = () => { return Math.Asin(Convert.ToDouble(getArgValue(0))); };
			_builtInFunctions["acos"] = () => { return Math.Acos(Convert.ToDouble(getArgValue(0))); };
			_builtInFunctions["atan"] = () => { return Math.Atan(Convert.ToDouble(getArgValue(0))); };
			_builtInFunctions["atan2"] = () => { return Math.Atan2(Convert.ToDouble(getArgValue(1)), Convert.ToDouble(getArgValue(0))); };

			_builtInFunctions["sinh"] = () => { return Math.Sinh(Convert.ToDouble(getArgValue(0))); };
			_builtInFunctions["cosh"] = () => { return Math.Cosh(Convert.ToDouble(getArgValue(0))); };
			_builtInFunctions["tanh"] = () => { return Math.Tanh(Convert.ToDouble(getArgValue(0))); };

			_builtInFunctions["hypot"] = () =>
			{
				double x = Math.Abs(Convert.ToDouble(getArgValue(1)));
				double y = Math.Abs(Convert.ToDouble(getArgValue(0)));

				if (y < x)
				{
					double a = x;
					x = y;
					y = a;
				}

				if (y == 0.0)
					return 0.0;

				if (y - x == y)     // x too small to substract from y
					return y;

				double r = x / y;
				return y * Math.Sqrt(1 + r * r);
			};

			_builtInFunctions["abs"] = () => { return Math.Abs(Convert.ToDouble(getArgValue(0))); };
			_builtInFunctions["sign"] = () => { return Math.Sign(Convert.ToDouble(getArgValue(0))); };
			_builtInFunctions["round"] = () => { return Math.Round(Convert.ToDouble(getArgValue(0))); };
			_builtInFunctions["ceil"] = () => { return Math.Ceiling(Convert.ToDouble(getArgValue(0))); };
			_builtInFunctions["floor"] = () => { return Math.Floor(Convert.ToDouble(getArgValue(0))); };
			_builtInFunctions["sqrt"] = () => { return Math.Sqrt(Convert.ToDouble(getArgValue(0))); };
			//_functions["sqr"] = () => { double x = (double)getArgValue(0); return x * x; };

			_builtInFunctions["exp"] = () => { return Math.Exp(Convert.ToDouble(getArgValue(0))); };
			_builtInFunctions["pow"] = () => { return Math.Pow(Convert.ToDouble(getArgValue(1)), Convert.ToDouble(getArgValue(0))); };
			_builtInFunctions["ln"] = () => { return Math.Log(Convert.ToDouble(getArgValue(0))); };
			_builtInFunctions["log10"] = () => { return Math.Log10(Convert.ToDouble(getArgValue(0))); };
			_builtInFunctions["log"] = () => { return Math.Log(Convert.ToDouble(getArgValue(1)), Convert.ToDouble(getArgValue(0))); };

			_builtInFunctions["min"] = () => { return Math.Min(Convert.ToDouble(getArgValue(1)), Convert.ToDouble(getArgValue(0))); };
			_builtInFunctions["max"] = () => { return Math.Max(Convert.ToDouble(getArgValue(1)), Convert.ToDouble(getArgValue(0))); };

			_builtInFunctions["rand"] = () => { return _rnd.NextDouble(); };
			_builtInFunctions["ticks"] = () => { return DateTime.Now.Ticks; };
		}

		internal Interpreter()
		{
			_parser = new Parser();
			_rnd = new Random((int)DateTime.Now.Ticks);

			_variables = new Dictionary<string, object>();
			_userFunctions = new Dictionary<string, Func<object>>();

			_argValues = new List<object>();
			_args = new Dictionary<string, object>();

			_libMode = false;
			initInterpreter();

			_libVariables = new Dictionary<string, object>();
		}

		internal void LoadLibs(string libPath)
		{
			DirectoryInfo dir = new DirectoryInfo(libPath);
			if (!dir.Exists)
				return;

			FileInfo[] Files = dir.GetFiles("*.txt");

			_libMode = true;

			foreach (FileInfo f in Files)
			{
				string input;
				try
				{
					using (TextReader tr = new StreamReader(f.FullName))
						input = tr.ReadToEnd();
				}
				catch
				{
					continue;
				}

				try
				{
					InterpretLib(input);
				}
				catch
				{
					continue;
				}
			}

			_libMode = false;
		}

		object getArgValue(int a)
		{
			int i = _argValues.Count - 1 - a;
			if (i < 0 || i >= _argValues.Count)
				throw new Exception("Invalid argument count.");

			return _argValues[i];
		}

		const int precalcednum = 13;
		readonly static ulong[] fact =
				{1, 1, 2, 6, 24, 120, 720, 5040, 40320,
				362880, 3628800, 39916800, 479001600};

		static object factorial(double f)
		{
			int n = (int)f;

			if (n < 0 || n != f)
				return double.NaN;

			if (n < precalcednum)
				return fact[n];

			if (n < 21)
			{
				ulong uResult = fact[precalcednum - 1];

				for (uint i = precalcednum; i <= n; ++i)
					uResult *= i;

				return uResult;
			}

			if (n > 170)
				return double.PositiveInfinity;

			double dResult = fact[precalcednum - 1];

			for (int i = precalcednum; i <= n; ++i)
				dResult *= i;

			return dResult;
		}

		object evalNode(Symbol node)
		{
			object left;
			object right;
			//double x;

			switch (node.type)
			{
				case TokenType.number:
				case TokenType.litstring:
					return node.value;

				case TokenType.mod:
					left = evalNode(node.left);
					right = evalNode(node.right);

					if (left is string || right is string)
					{
						string errorString = string.Format("Incompatible types at line {0} position {1}.", node.stRow, node.stCol);
						throw new Exception(errorString);
					}

					//x = Convert.ToDouble(right);
					//if (x == 0)
					//{
					//	string errorString = string.Format("Division by zero at line {0} position {1}.", node.right.stRow, node.right.stCol);
					//	throw new Exception(errorString);
					//}
					//return left % right;
					return Convert.ToDouble(left) % Convert.ToDouble(right);

				case TokenType.mul:
					left = evalNode(node.left);
					right = evalNode(node.right);

					if (left is string || right is string)
					{
						string errorString = string.Format("Incompatible types at line {0} position {1}.", node.stRow, node.stCol);
						throw new Exception(errorString);
					}

					return Convert.ToDouble(left) * Convert.ToDouble(right);

				case TokenType.plus:
					left = evalNode(node.left);
					right = evalNode(node.right);
					if (left is string || right is string)
						return left.ToString() + right.ToString();

					return Convert.ToDouble(left) + Convert.ToDouble(right);

				case TokenType.minus:
					right = evalNode(node.right);
					if (right is string)
					{
						string errorString = string.Format("Incompatible types at line {0} position {1}.", node.stRow, node.stCol);
						throw new Exception(errorString);
					}
					if (node.left == null)
						return -Convert.ToDouble(right);

					left = evalNode(node.left);
					if (left is string)
					{
						string errorString = string.Format("Incompatible types at line {0} position {1}.", node.stRow, node.stCol);
						throw new Exception(errorString);
					}

					return Convert.ToDouble(left) - Convert.ToDouble(right);

				case TokenType.div:
					left = evalNode(node.left);
					right = evalNode(node.right);

					if (left is string || right is string)
					{
						string errorString = string.Format("Incompatible types at line {0} position {1}.", node.stRow, node.stCol);
						throw new Exception(errorString);
					}

					//x = Convert.ToDouble(right);
					//if (x == 0)
					//{
					//	string errorString = string.Format("Division by zero at line {0} position {1}.", node.right.stRow, node.right.stCol);
					//	throw new Exception(errorString);
					//}
					//return x / y;
					return Convert.ToDouble(left) / Convert.ToDouble(right);

				case TokenType.pow:
					left = evalNode(node.left);
					right = evalNode(node.right);

					if (left is string || right is string)
					{
						string errorString = string.Format("Incompatible types at line {0} position {1}.", node.stRow, node.stCol);
						throw new Exception(errorString);
					}

					return Math.Pow(Convert.ToDouble(left), Convert.ToDouble(right));

				case TokenType.fact:
					left = evalNode(node.left);
					if (left is string)
					{
						string errorString = string.Format("Incompatible types at line {0} position {1}.", node.stRow, node.stCol);
						throw new Exception(errorString);
					}

					return factorial(Convert.ToDouble(left));

				case TokenType.identifier:
					object value;
					if (_level > 0)
						if (_args.TryGetValue(node.name, out value))
							return value;

					if (!_consts.TryGetValue(node.name, out value))
						if (!_libVariables.TryGetValue(node.name, out value))
							if (!_variables.TryGetValue(node.name, out value))
							{
								string errorString = string.Format("Undefined ident \"{0}\" at line {1} position {2}.", node.name, node.stRow, node.stCol);
								throw new Exception(errorString);
							}

					return value;

				case TokenType.assign:
					if (_consts.TryGetValue(node.name, out value))
					{
						string errorString = string.Format("Invalid lvalue  \"{0}\" at line {1} position {2}.", node.name, node.stRow, node.stCol);
						throw new Exception(errorString);
					}

					if (_libMode)
						_libVariables[node.name] = evalNode((Symbol)node.value);
					//return _libVariables[node.name];
					else
					{
						if (_libVariables.TryGetValue(node.name, out value))
						{
							string errorString = string.Format("Invalid lvalue  \"{0}\" at line {1} position {2}.", node.name, node.stRow, node.stCol);
							throw new Exception(errorString);
						}

						_variables[node.name] = evalNode((Symbol)node.value);
						//return _variables[node.name];
					}
					return null;

				case TokenType.call:
					bool builtIn = true;
					if (!_builtInFunctions.ContainsKey(node.name))
					{
						if (!_userFunctions.ContainsKey(node.name))
						{
							string errorString = string.Format("Undefined function \"{0}\" at line {1} position {2}.", node.name, node.stRow, node.stCol);
							throw new Exception(errorString);
						}

						builtIn = false;
					}

					foreach (var arg in node.args)
						_argValues.Add(evalNode(arg));

					_level++;
					object ret = builtIn ? _builtInFunctions[node.name]() : _userFunctions[node.name]();
					_level--;

					if (_argValues.Count > node.args.Count)
						_argValues.RemoveRange(_argValues.Count - node.args.Count, node.args.Count);
					else
						_argValues.Clear();

					return ret;

				case TokenType.function:
					if (_libMode)
						_builtInFunctions[node.name] = () =>
						{
							for (var i = 0; i < node.args.Count; i++)
								_args[node.args[i].name] = getArgValue(node.args.Count - 1 - i);

							object result = evalNode((Symbol)node.value);
							_args.Clear();
							return result;
						};
					else
					{
						if (_builtInFunctions.ContainsKey(node.name) || _userFunctions.ContainsKey(node.name))
						{
							//string errorString = string.Format("Function \"{0}\" at line {1} position {2} alredy exist.", node.name, node.stRow, node.stCol);
							string errorString = string.Format("Symbol \"{0}\" at line {1} position {2} alredy defined.", node.name, node.stRow, node.stCol);
							throw new Exception(errorString);
						}

						_userFunctions[node.name] = () =>
						{
							for (var i = 0; i < node.args.Count; i++)
								_args[node.args[i].name] = getArgValue(node.args.Count - 1 - i);

							object result = evalNode((Symbol)node.value);
							_args.Clear();
							return result;
						};
					}
					return null;
			}

			return null;
		}

		void InterpretLib(string input)
		{
			_argValues.Clear();
			_args.Clear();

			List<Symbol> parseTree = _parser.Parse(input);

			_level = 0;

			for (var i = 0; i < parseTree.Count; i++)
				evalNode(parseTree[i]);
		}

		internal string Interpret(string input)
		{
			_variables.Clear();
			_userFunctions.Clear();

			_argValues.Clear();
			_args.Clear();

			List<Symbol> parseTree = _parser.Parse(input);

			_level = 0;
			string result = "";

			for (var i = 0; i < parseTree.Count; i++)
			{
				var value = evalNode(parseTree[i]);

				if (value != null)
					result += value.ToString() + "\r\n";
			}

			return result;
		}
	}
}
