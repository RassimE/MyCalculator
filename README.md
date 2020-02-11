# Simple but powerful calculator

## supported operations:

+ &#43;	addition numeric and concotenation of string operands;<br>
+ &#45;	subtraction and sign changing;<br>
+ &#42;	multiplication;<br>
+ /	dividing;<br>
+ %	modulo calculation;<br>
+ =	assigning<br>
+ ^	power<br>
+ **	power<br>
+ !	factorial<br>
+ ;	end of expression<br><br>

double slash "//" comments everything to the end of the current line<br><br>

Predefined variables:<br>
+ PI		= 3.14159265358979<br>
+ E		= 2.71828182845905<br>
+ DegToRadVal	= 0.0174532925199433<br>
+ RadToDegVal	= 57.2957795130823<br><br>

built-in functions:<br><br>

+ degtorad(a)	Converts angle from degrees to radians;<br>
+ radtodeg(a)	Converts angle from radians to degrees;<br>
+ sin(a)		Returns the sine of the specified angle measured in radians;<br>
+ cos(a)		Returns the cosine of the specified angle measured in radians;<br>
+ tan(a)		Returns the tangent of the specified angle measured in radians;<br>
+ sec(a)		Returns the secant of the specified angle measured in radians;<br>
+ cosec(a)	Returns the cosecant of the specified angle measured in radians;<br>
+ cotan(a)	Returns the cotangent of the specified angle measured in radians;<br>
+ asin(d)		Returns the angle in radians whose sine is the specified number;<br>
+ acos(d)		Returns the angle in radians whose cosine is the specified number;<br>
+ atan(d)		Returns the angle in radians whose tangent is the specified number;<br>
+ atan2(y, x)	Returns the angle in radians whose tangent is the quotient of two specified numbers;<br>
+ sinh(a)		Returns the hyperbolic sine of the specified angle measured in radians;<br>
+ cosh(a)		Returns the hyperbolic cosine of the specified angle measured in radians;<br>
+ tanh(a)		Returns the hyperbolic tangent of the specified angle measured in radians;<br>
+ hypot(a, b)	Returns the length of the hypotenuse of a right-angle triangle;<br>
+ abs(n)		Returns the absolute value of a number;<br>
+ sign(n)		Returns an integer that indicates the sign of a number;<br>
+ round(n)	Rounds a number to the nearest integral value;<br>
+ ceil(n)		Returns the smallest integral value that is greater than or equal to the number;<br>
+ floor(n)	Returns the largest integer less than or equal to the specified number;<br>
+ sqrt(n)		Returns the square root of a specified number;<br>
+ exp(a)		Returns 'E' raised to the specified power;<br>
+ pow(x, y)	Returns a 'x' raised to the 'y' power;<br>
+ ln(n)		Returns the natural (base e) logarithm of a specified number;<br>
+ log10(n)	Returns the base 10 logarithm of a specified number;<br>
+ log(n, b)	Returns the logarithm of the 'n' in the base 'b';<br>
+ min(a, b)	Returns the smaller of two numbers;<br>
+ max(a, b)	Returns the larger of two numbers;<br>
+ rand()		Returns a random number that is greater than or equal to 0.0, and less than 1.0;<br>
+ ticks()		Gets the number of ticks that represent the date and time of this instance;<br><br>

Additional libraries must be located in "Lib" folder in plain text format.<br><br>

Numeric variable declaration example:<br>
n = 5 a = 2<br><br>

String variable declaration example:<br>
s = "Hello, World!!!"<br><br>

You can define a function that consists of a single expression<br>
Function declaration example:<br>
Cos(x) = cos(degtorad(x))<br>
h(x)=2 * x + 1<br><br>

&lt;Code example&gt;<br>
t = ticks()<br>
t<br>
t * 1<br>
" <br>
19!<br>
19! * 1<br><br>
""<br>
h(x) = 2 * x + 1 <br>
h(h(1))<br><br>
"" <br>
9^3!<br>
"" <br>
a = 2<br>
hypot(a + 1, 3 + 1)<br>
"a = " + a<br>
""<br><br>
"! Important remark !"<br>
"example below works great:"<br>
a<br>
2*(sin(a)+5)<br>
""<br><br>
"but below example not works without ';' (end of expression) symbol!"<br>
a;<br>
(sin(a)+5)*2<br>
""<br><br>
"Alternatively you can use the '[]' or '{}' brackets:"<br>
a<br>
[sin(a)+5]*2<br>
&lt;\Code example&gt;<br><br>
while the application is running <br>
press &lt;Enter&gt; to calculate <br>
press &lt;Shift + Enter&gt; for a new line<br>
