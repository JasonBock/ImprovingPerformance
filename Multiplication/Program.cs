using System.Diagnostics;
using System.Numerics;

//QuickTest();

//NaiveTimeTest(new BigInteger(3), new BigInteger(2));
//NaiveTimeTest(new BigInteger(30), new BigInteger(20));
//NaiveTimeTest(new BigInteger(3000), new BigInteger(2000));
//NaiveTimeTest(new BigInteger(300000), new BigInteger(200000));
NaiveTimeTest(new BigInteger(30000000), new BigInteger(20000000));
//NaiveTimeTest(new BigInteger(30000000), new BigInteger(0));
//NaiveTimeTest(new BigInteger(0), new BigInteger(30000000));

//var data = Generate(50, 4);
//Execute(data, MultiplyViaOperation);
//Execute(data, MultiplyViaAddition);

static BigInteger[] Generate(int count, int maxSize)
{
	var result = new BigInteger[count];
	var random = new Random();

	for (var i = 0; i < count; i++)
	{
		var data = new byte[random.Next(maxSize)];
		random.NextBytes(data);
		result[i] = new BigInteger(data);
	}

	return result;
}

static void Execute(BigInteger[] values,
	Func<BigInteger, BigInteger, BigInteger> f)
{
	GC.Collect();
	GC.WaitForPendingFinalizers();
	GC.Collect();

	result = f(new BigInteger(200), new BigInteger(300));

	var operationTime = new Stopwatch();

	for (var i = 0; i < values.Length / 2; i++)
	{
		var a = values[i];
		var b = values[i + 1];
		operationTime.Start();
		result = f(a, b);
		operationTime.Stop();
	}

	Console.Out.WriteLine($"Execute time: {operationTime.Elapsed}");
}

static void NaiveTimeTest(BigInteger a, BigInteger b)
{
	var operationTime = Stopwatch.StartNew();

	MultiplyViaOperation(a, b);

	operationTime.Stop();

	Console.Out.WriteLine(
		$"NaiveTestTime.MultiplyViaOperation({a}, {b}) time: {operationTime.Elapsed}");

	var additionTime = Stopwatch.StartNew();

	MultiplyViaAddition(a, b);

	additionTime.Stop();

	Console.Out.WriteLine(
		$"NaiveTestTime.MultiplyViaAddition({a}, {b}) time: {additionTime.Elapsed}");
}

static void QuickTest()
{
	Console.Out.WriteLine(
		$"346 * 27 : MultiplyViaOperation is {MultiplyViaOperation(new BigInteger(346), new BigInteger(27))}");
	Console.Out.WriteLine(
		$"346 * 27 : MultiplyViaAddition is {MultiplyViaAddition(new BigInteger(346), new BigInteger(27))}");

	Console.Out.WriteLine(
		$"-346 * 27 : MultiplyViaOperation is {MultiplyViaOperation(new BigInteger(-346), new BigInteger(27))}");
	Console.Out.WriteLine(
		$"-346 * 27 : MultiplyViaAddition is {MultiplyViaAddition(new BigInteger(-346), new BigInteger(27))}");

	Console.Out.WriteLine(
		$"346 * 27 : MultiplyViaOperation is {MultiplyViaOperation(new BigInteger(346), new BigInteger(-27))}");
	Console.Out.WriteLine(
		$"346 * -27 : MultiplyViaAddition is {MultiplyViaAddition(new BigInteger(346), new BigInteger(-27))}");

	Console.Out.WriteLine(
		$"-346 * -27 : MultiplyViaOperation is {MultiplyViaOperation(new BigInteger(-346), new BigInteger(-27))}");
	Console.Out.WriteLine(
		$"-346 * -27 : MultiplyViaAddition is {MultiplyViaAddition(new BigInteger(-346), new BigInteger(-27))}");
}

static BigInteger MultiplyViaOperation(BigInteger a, BigInteger b) => a * b;

static BigInteger MultiplyViaAddition(BigInteger a, BigInteger b)
{
	var result = BigInteger.Zero;

	var value = BigInteger.Abs(a);
	for (var i = BigInteger.Zero; i < BigInteger.Abs(b); i++)
	{
		result += value;
	}

	return a.Sign < 0 ^ b.Sign < 0 ? BigInteger.Negate(result) : result;
}