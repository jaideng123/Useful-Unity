using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SceneVariable", order = 1)]
public class SceneVariable : VariableScriptableObject<UsableSceneAsset>
{
    public string GetName()
    {
        string[] splitString = currentValue.ScenePath.Split(new char[] { '/' });
        string name = splitString[splitString.Length - 1].Split(new char[] { '.' })[0];
        return name;
    }
    public override string ToString()
    {
        return GetName();
    }
}