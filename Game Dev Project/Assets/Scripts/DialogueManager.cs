using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	GameObject currentlyTalkingTo;
	NPCDialogueHolder dialogueOfCurrentConversation;
	int indexInCurrentConversation;

    public static bool ActivePanel;

    public bool InConversation
    {
        get {
            if (currentlyTalkingTo == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

	public Text npcUIText;
	public Text playerUIText;
	
	void Start () {
		currentlyTalkingTo = null;
		dialogueOfCurrentConversation = null;
		indexInCurrentConversation = 0;
	}

	void Update () {
		/*
			you'll need your own code for when you want to begin a conversation and when you want to advance a conversations.
			always call BeginConversation and pass the GameObject of the npc you're talking to when you start a convo.

			then you need to call AdvanceConversation to go through each line

			when you're done, call EndConversation
		*/


	}

	public void BeginConversation (GameObject npc) {
        ActivePanel = true;
        Debug.Log("talking to: " + npc.name);
		currentlyTalkingTo = npc;
		dialogueOfCurrentConversation = npc.GetComponent<NPCDialogueHolder>();
		indexInCurrentConversation = 0;

        AdvanceConversation();
	}

	public void EndConversation () {
		currentlyTalkingTo = null;
		dialogueOfCurrentConversation = null;
		indexInCurrentConversation = 0;

        ActivePanel = false;
	}

	public void AdvanceConversation () {
		// cheching to make sure we have started a conversation with someone
		if (currentlyTalkingTo != null) {

			/*
				this assumes we read all of the npc dialogue then move to player dialogue
				the if statement checks if we've finished reading all of the strings from the npc dialogue
			*/
			if (indexInCurrentConversation < dialogueOfCurrentConversation.npcDialogueSequence.Length) {
				// in npc dialogue
				DisplayText(dialogueOfCurrentConversation.npcDialogueSequence[indexInCurrentConversation], npcUIText);
				indexInCurrentConversation++;
			}
			else {
				// in player dialogue
				DisplayText(dialogueOfCurrentConversation.playerDialogueSequence[indexInCurrentConversation - dialogueOfCurrentConversation.npcDialogueSequence.Length], playerUIText);
				indexInCurrentConversation++;

			}


            // this check will auto end the conversation when you've reached the end of the strings you have for it.
            if (indexInCurrentConversation == ((dialogueOfCurrentConversation.npcDialogueSequence.Length + dialogueOfCurrentConversation.playerDialogueSequence.Length)))
            {
                Debug.Log("end conversation");
                EndConversation();
            }
        }
		else {
			Debug.Log("We're not currently talking to anyone!");
		}
	}

	public void DisplayText (string line, Text uiText) {
		uiText.text = line;
	}
}