using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogPileScript : MonoBehaviour
{
    public int state = 0;

    public List<GameObject> logPileList;

    public bool isFull() {
        return this.state == 6;
    }

    public void storeWood() {
        if(state < 6) {
            state++;
            this.setState();
        }
    }

    public void setState() {
        switch(state) {
            case 0:
                foreach(GameObject log in logPileList) {
                    log.SetActive(false);
                }
                break;
            case 1:
                foreach(GameObject log in logPileList) {
                    log.SetActive(false);
                }
                logPileList[state-1].SetActive(true);
                break;
            case 2:
                foreach(GameObject log in logPileList) {
                    log.SetActive(false);
                }
                logPileList[state-1].SetActive(true);
                break;
            case 3:
                foreach(GameObject log in logPileList) {
                    log.SetActive(false);
                }
                logPileList[state-1].SetActive(true);
                break;
            case 4:
                foreach(GameObject log in logPileList) {
                    log.SetActive(false);
                }
                logPileList[state-1].SetActive(true);
                break;
            case 5:
                foreach(GameObject log in logPileList) {
                    log.SetActive(false);
                }
                logPileList[state-1].SetActive(true);
                break;
            case 6:
                foreach(GameObject log in logPileList) {
                    log.SetActive(false);
                }
                logPileList[state-1].SetActive(true);
                break;
            default:
                break;
        }
    }
}
