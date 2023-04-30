namespace LuckyFish.Ranger;

public class FileEdit
{
    /*
     while (true)
    {
        Console.SetCursorPosition(column,row+1);
        
        var key = Console.ReadKey();
        foreach (var s in context)
            Console.WriteLine(s);
        
        #region Home and End

        if (key.Key == ConsoleKey.Home)
        {
            Console.Clear();
            column = 0;
            continue;
        }

        if (key.Key == ConsoleKey.End)
        {
            column = context[row].Length - 1;
            Console.Clear();
            continue;
        }

        #endregion

        #region Move

        if (key.Key == ConsoleKey.UpArrow)
        {
            row--;
            if (row < 0) row = 0;
            Console.Clear();
            continue;
        }

        if (key.Key == ConsoleKey.DownArrow)
        {
            row++;
            if (row >= context.Length)
                row = context.Length - 1;
            Console.Clear();
            continue;
        }

        if (key.Key == ConsoleKey.LeftArrow)
        {
            column--;
            if (column <= 0)
            {
                row--;
                if (row <= 0)
                    row = 0;
                column = context[row].Length - 1;
            }
            Console.Clear();
            continue;
        }

        if (key.Key == ConsoleKey.RightArrow)
        {
            column++;
            if (column >= context[row].Length)
            {
                row++;
                if (row >= context.Length) 
                    row = context.Length - 1;
                column = 0;
            }
            Console.Clear();
            continue;
        }
    
        #endregion

        #region Other

        if (key.Key == ConsoleKey.Q) // Quit
            return;

        if (key.Key == ConsoleKey.Escape) // exit 退出
        {
            isExit = true;
            return;
        }

        if (key.Key == ConsoleKey.Tab)
            Order();

        #endregion

        #region Edit

        if (key.Key == ConsoleKey.Enter)
        {
            string[] newContext = new string[context.Length+1];
            for (int i = 0; i < row-1; i++)
                newContext[i] = context[i];
            newContext[row] = context[row][..column];
            for (int i = 0; i < column; i++)
                newContext[row + 1] += " ";
            newContext[row + 1] += context[row][column..];
            for (int i = row+1; i < context.Length+1; i++)
                newContext[i] = context[i - 1];
            context = newContext;
        }
        else
        {
            context[row].Insert(column, key.KeyChar.ToString());
        }
        #endregion
    }
     */
}