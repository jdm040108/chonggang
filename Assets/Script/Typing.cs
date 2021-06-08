using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Typing : MonoBehaviour
{
    public Text text = null;
    public TMP_Text tmp_text = null;

    public List<string> script = new List<string>();

    private void Start()
    {
        TypingStart(0);
    }

    public void TypingStart(int script_index) => StartCoroutine(CTypingStart(script_index));

    IEnumerator CTypingStart(int script_index)
    {
        for (int i = 0; i <= script[script_index].Length; i++)
        {
            if (text)
                text.text = script[script_index].Substring(0, i);
            if (tmp_text)
                tmp_text.text = script[script_index].Substring(0, i);

            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(1);

        if (script_index + 1 < script.Count)
            TypingStart(script_index + 1);

        yield return null;
    }
}
