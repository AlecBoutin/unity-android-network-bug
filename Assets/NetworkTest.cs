using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkTest : MonoBehaviour {
  public GameObject DoneIndicator;

  // Start is called before the first frame update
  void Start() {
    StartCoroutine(Download());
  }

  // Update is called once per frame
  void Update() {

  }

  IEnumerator Download() {
    DoneIndicator.SetActive(false);
    var req = UnityWebRequest.Get("https://files.collective.gg/ugc-cards/p/cards--1837094263.json");
    var op = req.SendWebRequest();
    StartCoroutine(LogProgress(req, op));
    yield return op;
    Debug.Log("Done");
    req.Dispose();
    DoneIndicator.SetActive(true);
  }

  IEnumerator LogProgress(UnityWebRequest req, UnityWebRequestAsyncOperation op) {
    while (!op.isDone) {
      Debug.Log(req.downloadedBytes);
      yield return null;
    }
  }
}
