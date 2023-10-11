using Calculator.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Calculator
{
	public partial class MainForm : Form
	{
		Interpreter _interpreter;

		string _fileName;

		const string initialString =
				"\"\tHello!\"\r\n" +
			"\"Press 'i' button for help!\"";

		#region MainForm

		public MainForm()
		{
			InitializeComponent();
			splitContainer1.Font = new System.Drawing.Font(splitContainer1.Font.FontFamily.Name, Settings.Default.FontSize);

			int x = Settings.Default.ltX;
			int y = Settings.Default.ltY;

			if (x >= -40 && y >= -40)
			{
				StartPosition = FormStartPosition.Manual;
				Location = new System.Drawing.Point(x, y);
			}

			int clW = Settings.Default.clW;
			int clH = Settings.Default.clH;

			if (clW >= 0 && clH >= 0)
				ClientSize = new System.Drawing.Size(clW, clH);

			int dis = Settings.Default.mainSpDist;
			if (dis > 0)
				splitContainer1.SplitterDistance = dis;

			dis = Settings.Default.leftSpDist;
			if (dis > 0)
				splitContainer2.SplitterDistance = dis;

			dis = Settings.Default.rightSpDist;
			if (dis > 0)
				splitContainer3.SplitterDistance = dis;

			int w = Settings.Default.varNameW;
			if (w > 0)
				chVarName.Width = w;

			w = Settings.Default.varValueW;
			if (w > 0)
				chVarValue.Width = w;

			_interpreter = new Interpreter();
			string libPath = Path.GetDirectoryName(Application.ExecutablePath)+"\\Lib\\";
			_interpreter.LoadLibs(libPath);

			lvFunctions.Items.Clear();
			foreach (var fc in _interpreter.Functions)
				lvFunctions.Items.Add(fc.Key + " ( )");

			lvVariables.Items.Clear();
			foreach (var vr in _interpreter.Variables)
				lvVariables.Items.Add(new ListViewItem(new string[] { vr.Key, vr.Value.ToString() }));

			_fileName = "";

			string input = initialString;

			string iniFile = Path.ChangeExtension(Application.ExecutablePath, "ini");
			if (File.Exists(iniFile))
			{
				try
				{
					using (TextReader tr = new StreamReader(iniFile))
						input = tr.ReadToEnd();

					_interpreter.Interpret(input);
				}
				catch
				{
					input = initialString;
				}
			}

			inputText.Text = input;
			inputText.Select(0, 0);
			inputText.Focus();         // Keep focus on the input
		}

		private void MainForm_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F1)
				new AboutBoxForm().ShowDialog();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Settings.Default.FontSize = splitContainer1.Font.Size;

			if (Left >= -40 && Top >= -40)
			{
				Settings.Default.ltX = Left;
				Settings.Default.ltY = Top;
			}

			if (ClientSize.Width > 0 && ClientSize.Height > 0)
			{
				Settings.Default.clW = ClientSize.Width;
				Settings.Default.clH = ClientSize.Height;
			}

			if (splitContainer1.SplitterDistance > 0)
				Settings.Default.mainSpDist = splitContainer1.SplitterDistance;

			if (splitContainer2.SplitterDistance > 0)
				Settings.Default.leftSpDist = splitContainer2.SplitterDistance;

			if (splitContainer3.SplitterDistance > 0)
				Settings.Default.rightSpDist = splitContainer3.SplitterDistance;

			if (chVarName.Width > 0)
				Settings.Default.varNameW = chVarName.Width;

			if (chVarValue.Width > 0)
				Settings.Default.varValueW = chVarValue.Width;

			Settings.Default.Save();

			bool ok = true;
			string input = inputText.Text;

			try
			{
				_interpreter.Interpret(input);
			}
			catch
			{
				ok = false;
			}

			if (ok)
			{
				try
				{
					string iniFile = Path.ChangeExtension(Application.ExecutablePath, "ini");
					using (TextWriter tw = new StreamWriter(iniFile))
						tw.Write(input);
				}
				catch { }
			}
		}

		#endregion

		string calculate(string input)
		{
			try
			{
				var result = _interpreter.Interpret(input);

				lvFunctions.Items.Clear();
				foreach (var fc in _interpreter.Functions)
					lvFunctions.Items.Add(fc.Key + " ( )");

				lvVariables.Items.Clear();
				foreach (var vr in _interpreter.Variables)
					lvVariables.Items.Add(new ListViewItem(new string[] { vr.Key, vr.Value.ToString() }));

				return result;
			}
			catch (Exception e)
			{
				return e.Message;
			}
		}

		#region inputText events

		bool Shift = false;

		private void inputText_KeyDown(object sender, KeyEventArgs e)
		{
			Shift = e.Shift;
		}

		private void inputText_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.Shift)
				Shift = false;
		}

		private void inputText_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 13 && !Shift)
			{
				CalcButton_Click(null, null);
				e.Handled = true;
			}
		}

		#endregion

		#region Lists events

		private void lvFunctions_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (lvFunctions.SelectedItems.Count == 0)
				return;

			int selectionStart = inputText.SelectionStart;
			string funcStr = lvFunctions.SelectedItems[0].Text;
			inputText.Text = inputText.Text.Insert(selectionStart, funcStr);
			inputText.SelectionStart = selectionStart + funcStr.Length;
		}

		private void lvVariables_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (lvVariables.SelectedItems.Count == 0)
				return;

			int selectionStart = inputText.SelectionStart;
			string constStr = lvVariables.SelectedItems[0].Text + " ";
			inputText.Text = inputText.Text.Insert(selectionStart, constStr);
			inputText.SelectionStart = selectionStart + constStr.Length;
		}

		#endregion

		#region Menu events

		private void loadToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() != DialogResult.OK)
				return;

			_fileName = openFileDialog1.FileName;

			try
			{
				using (TextReader tr = new StreamReader(_fileName))
					inputText.Text = tr.ReadToEnd();

				saveFileDialog1.FileName = _fileName;
			}
			catch (Exception ex)
			{
				outputText.Text = ex.Message;
				inputText.Focus();
			}
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				using (TextWriter tw = new StreamWriter(_fileName))
					tw.Write(inputText.Text);
			}
			catch (Exception ex)
			{
				outputText.Text = ex.Message;
				inputText.Focus();
			}
		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (saveFileDialog1.ShowDialog() != DialogResult.OK)
				return;

			_fileName = saveFileDialog1.FileName;

			try
			{
				using (TextWriter tw = new StreamWriter(_fileName))
					tw.Write(inputText.Text);

				openFileDialog1.FileName = _fileName;
			}
			catch (Exception ex)
			{
				outputText.Text = ex.Message;
				inputText.Focus();
			}
		}

		private void saveResultToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (saveFileDialog2.ShowDialog() != DialogResult.OK)
				return;

			try
			{
				using (TextWriter tw = new StreamWriter(saveFileDialog2.FileName))
					tw.Write(outputText.Text);
			}
			catch (Exception ex)
			{
				outputText.Text = ex.Message;
				inputText.Focus();
			}
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new AboutBoxForm().ShowDialog();
		}

		#endregion

		#region Buttons events

		private void CalcButton_Click(object sender, EventArgs e)
		{
			outputText.Text = calculate(inputText.Text);
			inputText.Focus();         // Keep focus on the input
		}

		private void ClearButton_Click(object sender, EventArgs e)
		{
			outputText.Text = "";
			inputText.Focus();         // Keep focus on the input
		}

		private void FontButton_Click(object sender, EventArgs e)
		{
			if (sender == FontPlusButton)
			{
				if (splitContainer1.Font.Size < 50)
					splitContainer1.Font = new System.Drawing.Font(splitContainer1.Font.FontFamily.Name, splitContainer1.Font.Size + 1);
			}
			else if (splitContainer1.Font.Size > 8)
				splitContainer1.Font = new System.Drawing.Font(splitContainer1.Font.FontFamily.Name, splitContainer1.Font.Size - 1);
		}

		private void InfoButton_Click(object sender, EventArgs e)
		{
			outputText.Text =
"supported operations:\r\n\r\n" +

"+	addition numeric and concotenation of string operands;\r\n" +
"-	subtraction and sign changing;\r\n" +
"*	multiplication;\r\n" +
"/	dividing;\r\n" +
"%	modulo calculation;\r\n" +
"=	assigning\r\n" +
"^	power\r\n" +
"**	power\r\n" +
"!	factorial\r\n" +
";	end of expression\r\n\r\n" +

"double slash \"//\" comments everything to the end of the current line\r\n\r\n" +

"Predefined constants:\r\n" +
"PI = 3.14159265358979\r\n" +
"E = 2.71828182845905\r\n" +
"DegToRadVal = 0.0174532925199433\r\n" +
"RadToDegVal = 57.2957795130823\r\n\r\n" +

"built-in functions:\r\n\r\n" +

"degtorad(a)	Converts angle from degrees to radians;\r\n" +
"radtodeg(a)	Converts angle from radians to degrees;\r\n" +
"sin(a)		Returns the sine of the specified angle measured in radians;\r\n" +
"cos(a)		Returns the cosine of the specified angle measured in radians;\r\n" +
"tan(a)		Returns the tangent of the specified angle measured in radians;\r\n" +
"sec(a)		Returns the secant of the specified angle measured in radians;\r\n" +
"cosec(a)		Returns the cosecant of the specified angle measured in radians;\r\n" +
"cotan(a)		Returns the cotangent of the specified angle measured in radians;\r\n" +
"asin(d)		Returns the angle in radians whose sine is the specified number;\r\n" +
"acos(d)		Returns the angle in radians whose cosine is the specified number;\r\n" +
"atan(d)		Returns the angle in radians whose tangent is the specified number;\r\n" +
"atan2(y, x)		Returns the angle in radians whose tangent is the quotient of two specified numbers;\r\n" +
"sinh(a)		Returns the hyperbolic sine of the specified angle measured in radians;\r\n" +
"cosh(a)		Returns the hyperbolic cosine of the specified angle measured in radians;\r\n" +
"tanh(a)		Returns the hyperbolic tangent of the specified angle measured in radians;\r\n" +
"hypot(a, b)		Returns the length of the hypotenuse of a right - angle triangle;\r\n" +
"abs(n)		Returns the absolute value of a number;\r\n" +
"sign(n)		Returns an integer that indicates the sign of a number;\r\n" +
"round(n)		Rounds a number to the nearest integral value;\r\n" +
"ceil(n)		Returns the smallest integral value that is greater than or equal to the number;\r\n" +
"floor(n)		Returns the largest integer less than or equal to the specified number;\r\n" +
"sqrt(n)		Returns the square root of a specified number;\r\n" +
"exp(a)		Returns 'E' raised to the specified power;\r\n" +
"pow(x, y)		Returns a 'x' raised to the 'y' power;\r\n" +
"ln(n)		Returns the natural(base e) logarithm of a specified number;\r\n" +
"log10(n)		Returns the base 10 logarithm of a specified number;\r\n" +
"log(n, b)		Returns the logarithm of the 'n' in the base 'b';\r\n" +
"min(a, b)		Returns the smaller of two numbers;\r\n" +
"max(a, b)		Returns the larger of two numbers;\r\n" +
"rand()		Returns a random number that is greater than or equal to 0.0, and less than 1.0;\r\n" +
"ticks()		Gets the number of ticks that represent the date and time of this instance;\r\n" +
"print(a...)		Prints the parameter(s) value(s).\r\n\r\n" +

"Additional libraries must be located in \"Lib\" folder in plain text format.\r\n\r\n" +

"Numeric variable declaration example:\r\n" +
"n = 5\r\n\r\n" +

"String variable declaration example:\r\n" +
"s = \"Hello, World!!!\"\r\n\r\n" +

"You can define a function that consists of a single expression\r\n" +
"Function declaration example:\r\n" +
"h(x) = 2 * x + 1\r\n" +
"Cos(x) = cos(degtorad(x))\r\n\r\n" +

"<Code example>\r\n" +
"t = ticks()\r\n" +
"t\r\n" +
"t * 1\r\n" +
"\"\"\r\n" +
"19!\r\n" +
"19!*1\r\n" +
"\"\"\r\n" +
"h(x) = 2 * x + 1\r\n" +
"h(h(1))\r\n\r\n" +
"\"\"\r\n" +
"a = 2\r\n" +
"hypot(a + 1, 3 + 1)\r\n" +
"\"a = \" + a\r\n" +
"\"! Important remark !\"\r\n" +
"\"example below works great\"\r\n" +
"a\r\n" +
"2 * (sin(a) + 5)\r\n" +
"\"\"\r\n" +
"\"but below example not works without ';' (end of expression) symbol!\"\r\n" +
"a;\r\n" +
"	(sin(a) + 5) * 2\r\n" +
"\"\"\r\n" +
"\"Alternatively you can use the '[]' or '{}' brackets.\"\r\n" +
"a\r\n" +
"[sin(a) + 5] * 2\r\n" +
"<\\Code example>\r\n\r\n" +
//"while the application is running\r\n" +
"press < Enter > to calculate\r\n" +
"press < Shift + Enter > for a new line\r\n";
		}

		#endregion
	}
}
