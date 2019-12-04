using System;

public class Test
{
	public static void Main()
	{
		var numbers = Console.ReadLine().Split(',');
		int index = 0;
		int opCode, a, b, dest;
		while(true) 
		{
			opCode = int.Parse(numbers[index]);
			if (opCode == 99) break;
			a = int.Parse(numbers[index+1]);
			b = int.Parse(numbers[index+2]);
			dest = int.Parse(numbers[index+3]);
			//Console.WriteLine($"{opCode}, {a}, {b}, {dest}");
			if (opCode == 1) {
				int result = int.Parse(numbers[a])+int.Parse(numbers[b]);
				//Console.WriteLine($"Add: {result}");
				numbers[dest]=result.ToString();
			} else if (opCode == 2) {
				int result = int.Parse(numbers[a])*int.Parse(numbers[b]);
				//Console.WriteLine($"Multiply: {result}");
				numbers[dest]=result.ToString();
			}
			index += 4;
		}
		foreach(var n in numbers) {
			Console.WriteLine(n);
		}
	}
}