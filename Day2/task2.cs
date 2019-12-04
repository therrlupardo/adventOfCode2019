using System;

public class Test
{
	public static void Main()
	{
		var numbersBase = Console.ReadLine().Split(',');
		var copy = CopyArray(numbersBase);
		int noun = 0;
		int verb = 0;
		while(Calculate(copy) != 19690720) {
			copy = CopyArray(numbersBase);
			verb++;
			if (verb > 99) {
				verb = 0;
				noun++;
			}
			copy[1]=noun.ToString();
			copy[2]=verb.ToString();
		}
		Console.WriteLine(100*noun+verb);
		
	}
	
	private static string[] CopyArray(string[] array) {
		var newArray = new string[array.Length];
		for (int i = 0; i < array.Length; i++) {
			newArray[i] = array[i];
		}
		return newArray;
	}
	
	private static int Calculate(string[] numbers) {
		int opCode, a, b, dest;
		int index = 0;
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
		return int.Parse(numbers[0]);
	}
}