using System.Diagnostics;
using LuckyFish.Lib.FileSystem;

string path = LuckyFish.Lib.Coding.CodePath+"\\test.cs";
int pos = 0;
int row = 0;
int column = 0;
bool isExit = false;
while (true)
{
    Console.Clear();
    if (isExit) return;
    Console.WriteLine($"in: {path}");
    if (!FileServer.IsDir(path))
        FileOperator();
    else
        DicOperator();
}

void FileOperator()
{
    string[] context = File.ReadAllLines(path);
    for (int i = 0; i < context.Length; i++)
        Console.WriteLine((row == i ? "*" : " ") + context[i]);
    var key = Console.ReadKey(false);

    #region Home and End

    if (key.Key == ConsoleKey.Home)
    {
        column = 0;
        return;
    }

    if (key.Key == ConsoleKey.End)
    {
        column = context[row].Length - 1;
        return;
    }

    #endregion

    #region Move

    if (key.Key == ConsoleKey.W)
    {
        row--;
        if (row < 0) row = 0;
        return;
    }

    if (key.Key == ConsoleKey.S)
    {
        row++;
        if (row >= context.Length)
            row = context.Length - 1;
        return;
    }

    if (key.Key == ConsoleKey.A)
    {
        column--;
        if (column >= 0) return;
        row--;
        if (row < 0) row = 0;
        column = context[row].Length - 1;
        return;
    }

    if (key.Key == ConsoleKey.D)
    {
        column++;
        if (column < context[row].Length) return;
        row++;
        if (row >= context.Length) row = context.Length - 1;
        column = 0;
        return;
    }
    
    #endregion

    #region Other

    if (key.Key == ConsoleKey.Q) // Quit
    {
        path = Path.GetDirectoryName(path) ?? path;
        return;
    }

    if (key.Key == ConsoleKey.Escape) // exit 退出
    {
        isExit = true;
        return;
    }

    if (key.Key == ConsoleKey.Tab)
        Order();

    #endregion
}

void DicOperator()
{
    var directory = new DirectoryOperation(path);
    var files = directory.GetFileSystems();
    for (int i = 0; i < files.Length; i++)
        Console.WriteLine((pos == i ? "=> " : " ") + files[i].Name);
    var key = Console.ReadKey(false);

    #region Move

    if (key.Key == ConsoleKey.W) // 向上
    {
        pos--;
        if (pos < 0)
            pos = files.Length - 1;
        return;
    }

    if (key.Key == ConsoleKey.S) // 向下
    {
        pos++;
        if (pos >= files.Length)
            pos = 0;
        return;
    }

    #endregion

    #region Choose

    if (key.Key == ConsoleKey.D) // 向右 下一级
    {
        path = files[pos].Path;
        return;
    }

    if (key.Key == ConsoleKey.A)
    {
        path = Path.GetDirectoryName(path) ?? path;
        return;
    }

    if (key.Key == ConsoleKey.Enter) // 下一级
    {
        path = files[pos].Path;
        return;
    }

    #endregion

    #region Other
    
    if (key.Key == ConsoleKey.Escape) // exit 退出
    {
        isExit = true;
        return;
    }

    if (key.Key == ConsoleKey.Tab)
        Order();

    #endregion
}

void Order()
{
    Console.WriteLine();
    while (true)
    {
        string? order = Console.ReadLine();
        Process a = new Process();
        if (order == "exit") return;
        a.StartInfo.FileName = OperationSystemInfo.TerminalPath;
        a.StartInfo.UseShellExecute = false; //是否使用操作系统shell启动
        a.StartInfo.RedirectStandardInput = true; //接受来自调用程序的输入信息
        a.StartInfo.RedirectStandardOutput = true; //由调用程序获取输出信息
        a.StartInfo.RedirectStandardError = true; //重定向标准错误输出
        a.Start();
        a.StandardInput.WriteLine(order); //指令
        a.StandardInput.Close();
        Console.WriteLine(a.StandardOutput.ReadToEnd()); //输出
    }
}