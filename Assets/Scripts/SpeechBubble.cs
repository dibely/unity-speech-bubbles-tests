using UnityEngine;
using TMPro;

public class SpeechBubble : MonoBehaviour {
    public GameObject textMesh;
    private TextMeshPro textMeshPro;

    public string Speech { set { UpdateTextMeshWithSpeechText(value); } }

    private void Awake() {
        textMeshPro = textMesh.GetComponent<TextMeshPro>();
    }

    private void UpdateTextMeshWithSpeechText(string speechText) {
        textMeshPro.SetText(speechText);    
      }
}
