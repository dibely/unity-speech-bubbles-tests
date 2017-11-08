using UnityEngine;

public class Chat : MonoBehaviour {
    private const float TIME_TO_DISPLAY_MESSAGE = 5.0f;
    private const float TIME_BETWEEN_MESSAGES = 1.0f;

    public GameObject speechBubblePrefab;
    public Transform speechBubbleTransform;
    private GameObject speechBubble = null;
    private string[] speech;

    private float messageDisplayTimer = TIME_TO_DISPLAY_MESSAGE;
    private float messageDelayTimer = TIME_BETWEEN_MESSAGES;
    private int messageIndex = 0;
    
    private void Awake() {
        speech = new string[5];
        speech[0] = "Hi!";
        speech[1] = "How are you?";
        speech[2] = "Nice weather";
        speech[3] = "Got to go";
        speech[4] = "Bye!";
    }

    void Update () {
	
        if(messageDelayTimer > 0.0f) {
            // Reduce the delay timer unitil we reach zero and then display the next message.
            messageDelayTimer -= Time.deltaTime;

            if (messageDelayTimer < 0.0f) {
                CreateSpeechBubbleWithMessage(speech[messageIndex]);
            } 
        }
        else if(messageDisplayTimer > 0.0f) {
            // Reduce the display timer until we reach zero and then reset and queue up a new message.
            messageDisplayTimer -= Time.deltaTime;

            if (messageDisplayTimer < 0.0f) {
                DestroySpeechBubble();

                messageDelayTimer = TIME_BETWEEN_MESSAGES;
                messageDisplayTimer = TIME_TO_DISPLAY_MESSAGE;
                messageIndex++;

                if (messageIndex == 5) {
                    messageIndex = 0;
                }
            }
        }       	
	}

    private void CreateSpeechBubbleWithMessage(string message) {
        speechBubble = GameObject.Instantiate(speechBubblePrefab, speechBubbleTransform);

        SpeechBubble sbScript = speechBubble.GetComponent<SpeechBubble>();
        sbScript.Speech = message;
    }

    private void DestroySpeechBubble() {
        Destroy(speechBubble);
        speechBubble = null;
    }
}
