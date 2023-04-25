using Python.Runtime;

namespace LuckyFish.Lib.PythonToNet;

public class PythonFile
{
    public static PyObject AnyToPyObject(object o)
        => o switch
        {
            string s => AnyToPyObject(s),
            int i => AnyToPyObject(i),
            float f => AnyToPyObject(f),
            List<object> l => AnyToPyObject(l),
            _ => PyObject.FromManagedObject(o)
        };

    public static PyObject AnyToPyObject(string s,bool isNet = false) => isNet?s.ToPython():new PyString(s);
    public static PyObject AnyToPyObject(int i,bool isNet = false) => isNet?i.ToPython():new PyInt(i);
    public static PyObject AnyToPyObject(float f,bool isNet = false) => isNet?f.ToPython():new PyFloat(f);
    public static PyObject AnyToPyObject(List<object> l,bool isNet = false) => isNet?l.ToPython():new PyList(l.Select(AnyToPyObject).ToArray());
    private PyModule Scope { get; }

    public PythonFile(string fileName, string dll = "python310.dll")
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