using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatManager : MonoBehaviour
{
    [TextArea(10, 5)]
    public List<string> messages = new List<string>();
    public float messageInterval = 0.8f;
    public bool isChatFinished = false;
    public bool chatStarted = false;
    public Animator chatAnimator;


    [Header("UI")]
    public TextMeshProUGUI chatLog;

    [Header("Audio")]
    public List<AudioClip> audioPerMessage = new List<AudioClip>();
    private AudioSource SFXSource;

    void Start(){
        chatLog.text = "";
        SFXSource = GameObject.FindGameObjectWithTag("SFXSource").GetComponent<AudioSource>();
    }

    void Update(){
        if(chatAnimator.GetCurrentAnimatorStateInfo(0).IsName("Show") && chatAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && !chatStarted){
            StartCoroutine(StartChatting(messages));
            chatStarted = true;
        }
    }

    IEnumerator StartChatting(List<string> messages){
        while(!isChatFinished){
            int messageIndex = 0;
            foreach(string message in messages){
                SFXSource.PlayOneShot(audioPerMessage[messageIndex]);
                foreach(char character in message){
                    chatLog.text += character;
                    yield return new WaitForSeconds(0.065f);
                }

                yield return new WaitForSeconds(messageInterval);
                chatLog.text = "";
                messageIndex++;
            }

            if(messageIndex == messages.Count){
                isChatFinished = true;
            }
        }

        chatAnimator.SetBool("isOpen", false);
    }

}
