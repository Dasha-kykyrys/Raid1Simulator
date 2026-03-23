using UnityEngine;
using System;
using System.Collections.Generic;
using DS.ScriptableObjects;
using DS.Data;

namespace DS
{
    public class DSDialogue : MonoBehaviour
    {
        [SerializeField] private DSDialogueContainerSO dialogueContainer;
        [SerializeField] private DSDialogueGroupSO dialogueGroup;
        [SerializeField] private DSDialogueSO dialogue;

        private DSDialogueSO currentDialogue; // текущий диалог

        // События для UI
        public event Action<string, List<string>> OnDialogueUpdated;
        public event Action OnDialogueEnded;

        // Этот геттер нужен для DialogueManager
        public DSDialogueSO CurrentDialogue => currentDialogue;

        // Пример метода запуска диалога
        public void StartDialogue()
        {
            if (dialogue != null)
            {
                currentDialogue = dialogue;
                ShowDialogue(currentDialogue);
            }
        }

        public void SelectChoice(int index)
        {
            if (currentDialogue == null || currentDialogue.Choices == null || index < 0 || index >= currentDialogue.Choices.Count)
                return;

            var next = currentDialogue.Choices[index].NextDialogue;
            currentDialogue = next;
            ShowDialogue(currentDialogue);
        }

        private void ShowDialogue(DSDialogueSO dialogueToShow)
        {
            if (dialogueToShow == null)
            {
                OnDialogueEnded?.Invoke();
                return;
            }

            List<string> choicesText = new List<string>();
            if (dialogueToShow.Choices != null)
                foreach (var choice in dialogueToShow.Choices)
                    choicesText.Add(choice.Text);

            OnDialogueUpdated?.Invoke(dialogueToShow.Text, choicesText);
        }
    }
}