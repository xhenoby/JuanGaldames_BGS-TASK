using System.Collections;
using UnityEngine;
using TMPro;
using System;

public class Talk : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    [SerializeField] AudioSource talkAudioSource;
    string[] dialogue;
    float textSpeed = 0.05f;
    int index;
    Action onFinish;
    public void ShowDialogue(Action onFinish, float textSpeed, string[] dialogue)
    {
        gameObject.SetActive(true);
        this.onFinish = onFinish;
        this.textSpeed = textSpeed;
        this.dialogue = dialogue;
        index = 0;
        StopAllCoroutines();
        StartCoroutine(Type());
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    IEnumerator Type()
    {
        textMeshProUGUI.text = "";
        for (int character = 0; character < dialogue[index].Length; character++)
        {
            talkAudioSource.pitch = (UnityEngine.Random.Range(1, 1.3f));
            talkAudioSource.PlayOneShot(talkAudioSource.clip);
            textMeshProUGUI.text += dialogue[index][character];
            yield return new WaitForSeconds(textSpeed);
        }
    }

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
            Hide();
        }
    }
}
