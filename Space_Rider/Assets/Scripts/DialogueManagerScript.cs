using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CusteneLevel1 : MonoBehaviour
{
    [System.Serializable]
    public class DialogueLine
    {
        public string speaker;

        [TextArea]
        public string text;
    }

    public DialogueLine[] lines;

    public TMP_Text nameText;
    public TMP_Text dialogueText;

    public Image astronautImage;
    public Image generalImage;

    private int currentLine = 0;

    // COOLDOWN
    private float nextPressTime = 0f;
    public float pressDelay = 0.25f;

    void Start()
    {
        ShowLine();
    }

    void Update()
    {
        if (Time.time < nextPressTime)
            return;

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            nextPressTime = Time.time + pressDelay;

            // SI TODAVIA HAY MAS LINEAS
            if (currentLine < lines.Length - 1)
            {
                NextLine();
            }
            // SI YA ES LA ULTIMA
            else
            {
                EndDialogue();
            }
        }
    }

    void ShowLine()
    {
        DialogueLine line = lines[currentLine];

        string speaker = line.speaker.Trim();

        nameText.text = speaker;
        dialogueText.text = line.text;

        // OSCURECER LOS DOS
        astronautImage.color = new Color(0.5f, 0.5f, 0.5f, 1f);
        generalImage.color = new Color(0.5f, 0.5f, 0.5f, 1f);

        // ASTRONAUTA
        if (speaker == "Astronauta")
        {
            astronautImage.color = Color.white;
            dialogueText.color = Color.white;
        }

        // GENERAL
        else if (speaker == "General")
        {
            generalImage.color = Color.white;
            dialogueText.color = Color.green;
        }
    }

    void NextLine()
    {
        currentLine++;
        ShowLine();
    }

    void EndDialogue()
    {
        SceneManager.LoadScene("LevelSelectorScene");
    }
}