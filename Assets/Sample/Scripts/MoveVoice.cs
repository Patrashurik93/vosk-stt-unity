
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MoveVoice : MonoBehaviour
{
    public VoskSpeechToText VoskSpeechToText;
    public RectTransform RectTransform;

    public Dictionary<string, Vector2> MoveDictionary  = new Dictionary<string, Vector2>()
    {
        {"вправо", new Vector2(100,0)},
        {"вліво", new Vector2(-100,0)},
        {"вверх", new Vector2(0,100)},
        {"вниз", new Vector2(0,-100)},
    };

    void Awake()
    {
        //VoskSpeechToText.OnTranscriptionResult += OnTranscriptionResult;
    }

    private void OnTranscriptionResult(string obj)
    {
        Debug.Log(obj);
        var result = new RecognitionResult(obj);
        for (int i = 0; i < result.Phrases.Length; i++)
        {
            if (MoveDictionary.Any(x => x.Key == result.Phrases[i].Text))
            {
                RectTransform.anchoredPosition += MoveDictionary.GetValueOrDefault(result.Phrases[i].Text);
            }
        }
    }

}
