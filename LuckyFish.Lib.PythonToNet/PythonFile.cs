using Python.Runtime;

namespace LuckyFish.Lib.PythonToNet;

public class PythonFile
{
    private PyModule Scope { get; }
    public PythonFile(string fileName,string dll = "python310.dll")
    {
        Runtime.PythonDLL = dll;
        PythonEngine.Initialize();
        Py.GIL();
        Scope = Py.CreateScope();
        string code = File.ReadAllText(fileName); // 获取code
        var scriptCompiled = PythonEngine.Compile(code, fileName); // 编译
        Scope.Execute(scriptCompiled);
    }
    public PyObject PythonFunctionRunning(string funcName, PyObject[]? args = null)
        => args == null ? Scope.InvokeMethod(funcName) : Scope.InvokeMethod(funcName, args);

    public PyObject PythonClassRunning(string className)
        => Scope.Get(className); // 获取python类实例

    public void Dispose() => Scope.Dispose();
}
