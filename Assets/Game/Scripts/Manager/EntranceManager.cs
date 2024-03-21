using System.Collections;
using System.Collections.Generic;
using ConversationAsset;
using UnityEngine;

public class EntranceManager : Singleton<EntranceManager>
{
    [SerializeField]
    private SceneTransitionInteractable sceneTransitionInteractable;
    public SceneTransitionInteractable SceneTransitionInteractable { get { return sceneTransitionInteractable; } }
}
