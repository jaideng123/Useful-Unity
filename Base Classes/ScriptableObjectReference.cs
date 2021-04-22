public abstract class ScriptableObjectReference<T, U> where U : VariableScriptableObject<T>
{
    public bool useConstant = true;
    public T constantValue;

    public U variable;

    public T Value
    {
        get { return useConstant ? constantValue : variable.currentValue; }
    }
}