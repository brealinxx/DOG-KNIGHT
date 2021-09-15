using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue",menuName = "Dialogue/Dialogue Date")]
public class DialogueDate_SO : ScriptableObject
{
    public List<DialoguePiece> dialoguePieces = new List<DialoguePiece>();
    public Dictionary<string, DialoguePiece> dialogueIndex = new Dictionary<string, DialoguePiece>();

#if UNITY_EDITOR
    void OnValidate() //在实时更改数据后更新
    {
        dialogueIndex.Clear();
        foreach (var piece in dialoguePieces)
        {
            if (!dialogueIndex.ContainsKey(piece.ID))
                dialogueIndex.Add(piece.ID, piece);
        }
    }
#endif

    public QuestDate_SO GetQuest()
    {
        QuestDate_SO currentQuest = null;
        foreach (var piece in dialoguePieces)
        {
            if(piece.quest!= null)
            {
                currentQuest = piece.quest;
            }
        }

        return currentQuest;
    }
}
