using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using UnityEngine.SceneManagement;

/// <summary>
/// see here https://lightbuzz.com/speech-recognition-unity/
/// </summary>
public class SpeechRecognitionEngine : MonoBehaviour
{
    public string[] keywords = new string[] { "sala", "down", "left", "quarto" };
    public ConfidenceLevel confidence = ConfidenceLevel.Medium;
    public float speed = 1;

    public Text results;
    public Image target;

    protected PhraseRecognizer recognizer;
    protected string word = "";



    private void Start()
    {
        if (keywords != null)
        {
            recognizer = new KeywordRecognizer(keywords, confidence);
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
            recognizer.Start();
            Debug.Log( recognizer.IsRunning );
        }

        foreach (var device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
        }
    }

    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        word = args.text;
        results.text = "You said: <b>" + word + "</b>";
    }

    private void Update()
    {


        switch (word)
        {
            case "sala":
                
                SceneManager.LoadScene("sala");
                break;
            case "down":
                
                break;
            case "left":
                
                break;
            case "quarto":
                SceneManager.LoadScene("quarto");
                break;
        }

        Debug.Log("switch: " +word);
        
    }

    private void OnApplicationQuit()
    {
        if (recognizer != null && recognizer.IsRunning)
        {
            recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            recognizer.Stop();
        }
    }
}
