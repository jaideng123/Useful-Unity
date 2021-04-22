using UnityEngine;

public abstract class VariableScriptableObject<T> : ScriptableObject
{
    public T defaultValue;
    [SerializeField]
    private T _currentValue;

    public T currentValue
    {
        get { return _currentValue; }
        set { _currentValue = value; }
    }

    private void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
        _currentValue = defaultValue;
    }

    public override string ToString()
    {
        return currentValue.ToString();
    }
}