using UnityEngine;
using System.Collections;

public class Interactive : MonoBehaviour
{
    private GameObject deal;

    private GameObject play;

    private GameObject disPlay;

    private GameObject grab;

    private GameObject disGrab;

    private void Start()
    {
        deal = GameObject.Find("DealBtn");
        play = GameObject.Find("PlayBtn");
        disPlay = GameObject.Find("DisPlayBtn");
        grab = GameObject.Find("GrabBtn");
        disGrab = GameObject.Find("DisGrabBtn");

        deal.GetComponent<UIButton>().onClick.Add(new EventDelegate(DealCallBack));
        play.GetComponent<UIButton>().onClick.Add(new EventDelegate(PlayCallBack));
        disPlay.GetComponent<UIButton>().onClick.Add(new EventDelegate(DisPlayCallBack));
        grab.GetComponent<UIButton>().onClick.Add(new EventDelegate(GrabCallBack));
        disGrab.GetComponent<UIButton>().onClick.Add(new EventDelegate(DisGrabCallBack));

        PlayController.Instance.activeButton += ActiveCardButton;

        play.SetActive(false);
        disPlay.SetActive(false);
        grab.SetActive(false);
        disGrab.SetActive(false);
    }

    public void ActiveCardButton(bool canReject)
    {
        play.SetActive(true);
        disPlay.SetActive(true);
        disPlay.GetComponent<UIButton>().isEnabled = canReject;
    }

    public void DealCallBack()
    {
        grab.SetActive(true);
        disGrab.SetActive(true);
        deal.SetActive(false);
    }

    public void PlayCallBack()
    {

    }

    public void DisPlayCallBack()
    {
        PlayController.Instance.Turn();
        play.SetActive(false);
        disPlay.SetActive(false);
    }

    public void GrabCallBack()
    {

    }

    public void DisGrabCallBack()
    {

    }
}
