#pragma warning disable 0649  

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ShowTextFiled : MonoBehaviour
{
    [SerializeField] Text text;

    public IEnumerator ShowStorys(string[] strs ,UnityAction<bool> callback)
    {
        int row = 0;
        foreach (var str in strs)
        {
            if (row % 3 == 0)
            {
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                text.text = null;
            }

            for (int i = 0; i < str.Length; i++)
            {
                if (Input.GetMouseButton(0))
                {
                    text.text += str[i];
                    yield return null;
                }
                else
                {
                    text.text += str[i];
                    yield return new WaitForSeconds(0.1f);
                }
            }
            text.text += "\n";
            row++;
        }
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        callback(true);
    }
}
