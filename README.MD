# Simple but powerful calculator

### supported operations:

+ &#43;	addition numeric and concotenation of string operands;
+ &#45;	subtraction and sign changing;
+ &#42;	multiplication;
+ /	dividing;
+ %	modulo calculation;
+ =	assigning
+ ^	power
+ **	power
+ !	factorial
+ ;	end of expression

double slash "//" comments everything to the end of the current line

### Predefined variables:
+ PI		= 3.14159265358979
+ E		= 2.71828182845905
+ DegToRadVal	= 0.0174532925199433
+ RadToDegVal	= 57.2957795130823

### Built-in functions:

+ degtorad(a)	Converts angle from degrees to radians;
+ radtodeg(a)	Converts angle from radians to degrees;
+ sin(a)		Returns the sine of the specified angle measured in radians;
+ cos(a)		Returns the cosine of the specified angle measured in radians;
+ tan(a)		Returns the tangent of the specified angle measured in radians;
+ sec(a)		Returns the secant of the specified angle measured in radians;
+ cosec(a)	Returns the cosecant of the specified angle measured in radians;
+ cotan(a)	Returns the cotangent of the specified angle measured in radians;
+ asin(d)		Returns the angle in radians whose sine is the specified number;
+ acos(d)		Returns the angle in radians whose cosine is the specified number;
+ atan(d)		Returns the angle in radians whose tangent is the specified number;
+ atan2(y, x)	Returns the angle in radians whose tangent is the quotient of two specified numbers;
+ sinh(a)		Returns the hyperbolic sine of the specified angle measured in radians;
+ cosh(a)		Returns the hyperbolic cosine of the specified angle measured in radians;
+ tanh(a)		Returns the hyperbolic tangent of the specified angle measured in radians;
+ hypot(a, b)	Returns the length of the hypotenuse of a right-angle triangle;
+ abs(n)		Returns the absolute value of a number;
+ sign(n)		Returns an integer that indicates the sign of a number;
+ round(n)	Rounds a number to the nearest integral value;
+ ceil(n)		Returns the smallest integral value that is greater than or equal to the number;
+ floor(n)	Returns the largest integer less than or equal to the specified number;
+ sqrt(n)		Returns the square root of a specified number;
+ exp(a)		Returns 'E' raised to the specified power;
+ pow(x, y)	Returns a 'x' raised to the 'y' power;
+ ln(n)		Returns the natural (base e) logarithm of a specified number;
+ log10(n)	Returns the base 10 logarithm of a specified number;
+ log(n, b)	Returns the logarithm of the 'n' in the base 'b';
+ min(a, b)	Returns the smaller of two numbers;
+ max(a, b)	Returns the larger of two numbers;
+ rand()		Returns a random number that is greater than or equal to 0.0, and less than 1.0;
+ ticks()		Gets the number of ticks that represent the date and time of this instance;

Additional libraries must be located in "Lib" folder in plain text format.

Numeric variable declaration example:<br>
n = 5 a = 2

String variable declaration example:<br>
s = "Hello, World!!!"

You can define a function that consists of a single expression<br>
Function declaration example:<br>
h(x)=2 * x + 1<br>
Cos(x) = cos(degtorad(x))

&lt;Code_example&gt;<br>
t = ticks()<br>
t<br>
t * 1<br>
"<br>
19!<br>
19! * 1<br>

""<br>
h(x) = 2 * x + 1<br>
h(h(1))

""<br>
9^3!<br>
""<br>
a = 2<br>
hypot(a + 1, 3 + 1)<br>
"a = " + a<br>

"! Important remark !"<br>
"example below works great"<br>
a<br>
2*(sin(a)+5)

"but below example not works without ';' (end of expression) symbol!"<br>
a;<br>
(sin(a)+5)*2

"Alternatively you can use the '[]' or '{}' brackets."<br>
a<br>
[sin(a)+5]*2<br>
&lt;\Code_example&gt;

while the application is running<br>
press <Enter> to calculate<br>
press <Shift + Enter> for a new line<br>
