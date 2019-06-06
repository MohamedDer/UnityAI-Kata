using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    public Text textBox;
    public Animator animator;
    public AudioSource sound;
     //Store all your text in this string array
    string[] goatText = new string[]{
        "Hey ! Vous !",
        "Oui, vous sur les canapés !",
        "L'hiver arrive mais nos villageois ont oublié comment s'y prendre pour récupérer du bois",
        "par chance ils n'ont pas tout oublié. Ils savent ou trouver leurs haches, la forêt ainsi que l'endroit ou entreposer le bois",
        "Aidez-nous à faire le pleins de bois pour chauffer nos maisons !",
        "Si vous acceptez cette mission, nous vous en serions extrêmement reconnaissants !",
        "Indiquez-nous le workflow du bucheronnage !",
        "Selon nos créateurs, nous ne serions qu'une simple machine à état fini.",
        "Je vois bien que vous êtes inquiet et perplexe vous aussi.",
        "Mais ne vous inquiétez pas, nos créateurs vous ont laissé un parchemin pour vous aider.",
        "Il contient toutes les informations et règles dont vous aurez besoin !",
        "Tout est dit, je vous laisse travailler et je vais me mettre à l'abris! Bonne chance !"
        };
    int currentlyDisplayingText = -1;

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
           SkipToNextText();
        }      
    }
    void Awake () {
    }
     //This is a function for a button you press to skip to the next text
    public void SkipToNextText(){
        sound.Play();
        animator.SetBool("speak", true);
        StopAllCoroutines();
        currentlyDisplayingText++;
        //If we've reached the end of the array, do anything you want. I just restart the example text
        if (currentlyDisplayingText>goatText.Length) {
            currentlyDisplayingText=0;
        }
        StartCoroutine(AnimateText());
    }
    //Note that the speed you want the typewriter effect to be going at is the yield waitforseconds (in my case it's 1 letter for every      0.03 seconds, replace this with a public float if you want to experiment with speed in from the editor)
    IEnumerator AnimateText(){
        for (int i = 0; i < (goatText[currentlyDisplayingText].Length+1); i++)
        {
            textBox.text = goatText[currentlyDisplayingText].Substring(0, i);
            yield return new WaitForSeconds(.08f);
        }
        sound.Pause();
        animator.SetBool("speak", false);
    }
}
