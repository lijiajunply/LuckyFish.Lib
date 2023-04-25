using System.Diagnostics;
using LuckyFish.Lib.FileSystem;

string path = LuckyFish.Lib.Coding.CodePath;
int pos = 0;
int row = 0;
bool isExit = false;
while (true)
{
    if (isExit) return;
    Ranger();
}

void Ranger()
{
    if (!FileServer.IsDir(path))
        FileOperator();
    else
        DicOperator();
    Console.Clear();
}

void FileOperator()
{
    var file = new FileOperation(path);
    Console.WriteLine(file.Name+" in: "+file.Path);
    string[] context = File.ReadAllLines(path);
    for (int i = 0; i < context.Length; i++)
        Console.WriteLine((row == i?"*":" ")+context[i]);
    var key = Console.ReadKey();
    if (key.Key == ConsoleKey.W)
    {
        row--;
        if (row <= 0) row = 0;
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
        path = Path.GetDirectoryName(path) ?? path;
        return;
    }
    if (key.Key == ConsoleKey.E)
    {
        Console.Clear();
        return;
    }
    
    if (key.Key == ConsoleKey.Tab)
        Order();
}

void DicOperator()
{
    var directory = new DirectoryOperation(path);
    var files = directory.GetFileSystems();
    for (int i = 0; i < files.Length; i++)
        Console.WriteLine((pos == i ? "=> ":" ")+files[i].Name);
    var key = Console.ReadKey();
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
    if (key.Key == ConsoleKey.Escape) // exit 退出
    {
        isExit = true;
        return;
    }
    if (key.Key == ConsoleKey.Enter) // 下一级
    {
        path = files[pos].Path;
        return;
    }

    if (key.Key == ConsoleKey.Tab)
        Order();
}

void Order()
{
    Console.WriteLine();
    while (true)
    {
        string? order = Console.ReadLine();
        Process a = new Process();
        if (order == "exit")return;
        a.StartInfo.FileName = OperationSystemInfo.TerminalPath;
        a.StartInfo.UseShellExecute = false;//是否使用操作系统shell启动
        a.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
        a.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
        a.StartInfo.RedirectStandardError = true;//重定向标准错误输出
        a.Start();
        a.StandardInput.WriteLine(order);//指令
        a.StandardInput.Close();
        Console.WriteLine(a.StandardOutput.ReadToEnd());//输出
    }
}