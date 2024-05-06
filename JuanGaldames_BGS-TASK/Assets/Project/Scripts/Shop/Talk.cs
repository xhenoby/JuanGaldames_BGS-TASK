using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Talk : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    [SerializeField] AudioSource miauSource;
    float textSpeed = 0.05f;
    string[] dialogue;
    int index;
    Action onFinish;
    private void Start()
    {
        ShowDialogue(new string[] { "Hello every nyan", "How are you", "im fine thank you" }, () => gameObject.SetActive(false), 0.1f);
    }
    public void ShowDialogue(string[] dialogue, Action onFinish, float textSpeed)
    {
        gameObject.SetActive(true);

        this.onFinish = onFinish;
        this.dialogue = dialogue;
        this.textSpeed = textSpeed;
        index = 0;

        StopAllCoroutines();
        StartCoroutine(Type());
    }
    IEnumerator Type()
    {
        textMeshProUGUI.text = "";
        for (int character = 0; character < dialogue[index].Length; character++)
        {
            miauSource.pitch = (UnityEngine.Random.Range(1, 1.5f));
            miauSource.PlayOneShot(miauSource.clip);
            textMeshProUGUI.text += dialogue[index][character];
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        if (index < dialogue.Length - 1)
        {
            index++;
            StartCoroutine(Type());
        }
        else
        {
            onFinish?.Invoke();
            gameObject.SetActive(true);
        }
    }
    [ContextMenu("UpdateLine")]
    public void UpdateLine()
    {
        if (textMeshProUGUI.text == dialogue[index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            textMeshProUGUI.text = dialogue[index];
        }
    }
}
