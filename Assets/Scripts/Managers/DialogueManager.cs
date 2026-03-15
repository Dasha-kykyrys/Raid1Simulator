
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


    public class DialogueManager : MonoBehaviour
    {
        public static DialogueManager instance;

        [Header("UI")]
        [SerializeField] private TMP_Text npcText;
        [SerializeField] private Transform choicesPanel;
        [SerializeField] private Button choiceButtonPrefab;
        [SerializeField] private Button dialoguePanelButton; // кнопка на панели для клика

        [Header("Настройки печати")]
        [SerializeField] private float lettersPerSecond = 15f; // скорость печати

        private List<Button> currentButtons = new List<Button>();
        private Coroutine typingCoroutine;
        private bool isTyping = false;

        private void Start()
        {
            instance = this;

        }
        public void StartClientDialogue()
        {

        }

        private void UpdateUI(string dialogueText, List<string> choices)
        {

        }

        private IEnumerator TypeText(string fullText)
        {
            isTyping = true;
            npcText.text = "";

            float delay = 1f / lettersPerSecond;
            for (int i = 0; i < fullText.Length; i++)
            {
                npcText.text += fullText[i];
                yield return new WaitForSeconds(delay);
            }

            isTyping = false;
        }

        private void OnPanelClicked()
        {

        }

        private void EndDialogue()
        {

        }
    }
