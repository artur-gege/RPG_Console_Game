namespace WalkerGame
{
	class Program
	{
		static void Main(string[] args) 
		{
		    char[,] map =
		    {
			{'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#','#', '#', '#', '#',},
			{'#', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'X', '#',},
			{'#', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#',},
			{'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#',},
			{'#', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#',},
			{'#', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#',},
			{'#', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', '#', '#', '#', '#', '#', ' ', ' ', '#',},
			{'#', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', '*', '#', ' ', ' ', '#',},
			{'#', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', 'X', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', '#', ' ', ' ', '#',},
			{'#', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', '#', '#', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', '#', ' ', ' ', '#',},
			{'#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', '#', ' ', ' ', '#',},
			{'#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', '#', ' ', ' ', '#',},
			{'#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', '#', ' ', ' ', '#',},
			{'#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', '#', ' ', ' ', '#',},
			{'#', ' ', '#', '#', '#', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#',},
			{'#', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', '*', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#',},
			{'#', ' ', ' ', ' ', 'X', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#',},
			{'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#',},
		    };

		    Console.CursorVisible = false;
		    int userX = 6, userY = 6, counter = 0;
		    char userModel = '@';
		    char[] bag = new char[1];

		    while (true)
		    {
			PrintMap(map);

			PrintScore(map, ref counter);

			PrintBag(map, bag);

			ChangeModelPosition(map, ref userX, ref userY, ref userModel);

			if (map[userY, userX] == 'X')
			{
			    bag = AddElementBag(bag, ref counter, 'X');
			    map[userY, userX] = ' ';
			}
			else if (map[userY, userX] == '*')
			{
			    bag = AddElementBag(bag, ref counter, '*');
			    map[userY, userX] = ' ';
			}

			if (counter == 1)
			{
			    PrintWinningPhrase();
			    break;
			}
		    }
		}
		static char[] AddElementBag(char[] bag, ref int counter, char symbol)
		{
		    char[] arr = new char[bag.Length + 1];
		    for (int i = 0; i < bag.Length; i++)
		    {
			arr[i] = bag[i];
		    }
		    arr[arr.Length - 1] = symbol;
		    bag = arr;
		    counter++;
		    return arr;
		}
		static void ChangeModelPosition(char[,] map, ref int userX, ref int userY, ref char userModel)
		{
		    Console.SetCursorPosition(userX, userY);
		    Console.Write(userModel);

		    var userKey = Console.ReadKey();

		    switch (userKey.Key)
		    {
			case ConsoleKey.UpArrow:
			    if (map[userY - 1, userX] != '#')
				userY--;
			    break;
			case ConsoleKey.DownArrow:
			    if (map[userY + 1, userX] != '#')
				userY++;
			    break;
			case ConsoleKey.RightArrow:
			    if (map[userY, userX + 1] != '#')
				userX++;
			    break;
			case ConsoleKey.LeftArrow:
			    if (map[userY, userX - 1] != '#')
				userX--;
			    break;
			default:
			    break;
		    }
		}
		static void PrintBag(char[,] map, char[] bag)
		{
		    Console.SetCursorPosition(0, map.GetLength(0) + 3);
		    Console.Write("Сумка:");
		    for (int i = 0; i < bag.Length; i++)
		    {
			Console.Write(bag[i] + " ");
		    }
		}
		static void PrintMap(char[,] map)
		{
		    Console.SetCursorPosition(0, 0);
		    for (int i = 0; i < map.GetLength(0); i++)
		    {
			for (int j = 0; j < map.GetLength(1); j++)
			{
			    Console.Write(map[i, j]);
			}
			Console.WriteLine();
		    }
		}
		static void PrintScore(char[,] map, ref int counter)
		{
		    Console.SetCursorPosition(map.GetLength(1) + 7, 0);
		    Console.WriteLine("Score: " + counter);
		}
		static void PrintWinningPhrase()
		{
		    Console.Clear();
		    Console.SetCursorPosition(40, 7);
		    var defualtColor = Console.ForegroundColor;
		    Console.ForegroundColor = ConsoleColor.Green;
		    Console.WriteLine("Вы победили");

		    for (int i = 0; i < 5; i++)
		    {
			Console.WriteLine();
		    }
		    Console.ForegroundColor = defualtColor;
		}
	}
}
