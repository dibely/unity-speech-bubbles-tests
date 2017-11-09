using UnityEngine;

public class Thoughts : MonoBehaviour {
    private const float TIME_TO_DISPLAY_MESSAGE = 3.0f;
    private const float TIME_BETWEEN_MESSAGES = 1.0f;

    public GameObject thoughtBubblePrefab;
    public Transform thoughtBubbleTransform;
    private GameObject thoughtBubble = null;
    private string[] thoughts;

    private float messageDisplayTimer = TIME_TO_DISPLAY_MESSAGE;
    private float messageDelayTimer = TIME_BETWEEN_MESSAGES;
    private int messageIndex = 0;

    private void Awake() {
        thoughts = new string[4];
        thoughts[0] = "<size=8><sprite=0></size>";
        thoughts[1] = "<size=8><sprite=1></size>";
        thoughts[2] = "<size=8><sprite=1><sprite=1><sprite=2></size>";
        thoughts[3] = "<size=8><sprite=3></size><voffset=0.5em>x10</voffset>";
    }

    void Update() {

        if (messageDelayTimer > 0.0f) {
            // Reduce the delay timer unitil we reach zero and then display the next message.
            messageDelayTimer -= Time.deltaTime;

            if (messageDelayTimer < 0.0f) {
                CreateThoughtBubbleWithMessage(thoughts[messageIndex]);
            }
        }
        else if (messageDisplayTimer > 0.0f) {
            // Reduce the display timer until we reach zero and then reset and queue up a new message.
            messageDisplayTimer -= Time.deltaTime;

            if (messageDisplayTimer < 0.0f) {
                DestroyThoughtBubble();

                messageDelayTimer = TIME_BETWEEN_MESSAGES;
                messageDisplayTimer = TIME_TO_DISPLAY_MESSAGE;
                messageIndex++;

                if (messageIndex == thoughts.Length) {
                    messageIndex = 0;
                }
            }
        }
    }

    private void CreateThoughtBubbleWithMessage(string message) {
        thoughtBubble = GameObject.Instantiate(thoughtBubblePrefab, thoughtBubbleTransform);

        SpeechBubble sbScript = thoughtBubble.GetComponent<SpeechBubble>();
        sbScript.Speech = message;
    }

    private void DestroyThoughtBubble() {
        Destroy(thoughtBubble);
        thoughtBubble = null;
    }
}
