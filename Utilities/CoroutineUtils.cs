using System;
using System.Collections;
using UnityEngine;

public static class CoroutineUtils
{
    public static IEnumerator WaitNSecondsThen(float duration, Action action)
    {
        yield return new WaitForSeconds(duration);
        action();
    }

    public static IEnumerator WaitNSecondsUnscaledThen(float duration, Action action)
    {
        yield return new WaitForSecondsRealtime(duration);
        action();
    }

}