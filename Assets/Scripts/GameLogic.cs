using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.UI;
using UnityEditor;




public class GameLogic : MonoBehaviour
{


    public CanvasGroup DoorCanvas;
    public CanvasGroup SignCanvas;
    public CanvasGroup DeathCanvas;


    public void FadeInDoor()
    {
        StartCoroutine(FadeCanvasGroup(DoorCanvas, DoorCanvas.alpha, 1));
    }

    public void FadeOutDoor()
    {
        StartCoroutine(FadeCanvasGroup(DoorCanvas, DoorCanvas.alpha, 0));
    }

    public void FadeInSign()
    {
        StartCoroutine(FadeCanvasGroup(SignCanvas, SignCanvas.alpha, 1));
    }

    public void FadeOutSign()
    {
        StartCoroutine(FadeCanvasGroup(SignCanvas, SignCanvas.alpha, 0));
    }

    public void FadeInDeath()
    {
        StartCoroutine(FadeCanvasGroup(DeathCanvas, DeathCanvas.alpha, 1));
    }

    public void FadeOutDeath()
    {
        StartCoroutine(FadeCanvasGroup(DeathCanvas, DeathCanvas.alpha, 0));
    }


    public void ResetAlpha()
    {
        DoorCanvas.alpha = 0;
        SignCanvas.alpha = 0;
        DeathCanvas.alpha = 0;
       
    }

    public IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime = 0.5f)
    {

        float _TimeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _TimeStartedLerping;
        float PercentageComplete = timeSinceStarted / lerpTime;
        while (true)
        {

            timeSinceStarted = Time.time - _TimeStartedLerping;
            PercentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, PercentageComplete);

            cg.alpha = currentValue;

            if (PercentageComplete >= 1) break;

            yield return new WaitForEndOfFrame();
        }
    }

    public Text text;
    public CanvasGroup TextCanvas;


    private enum States
    {
        coldstreet, coldstreet2, coldstreet3, death, goingback, outsidestore, outsidestorefreezing,
        sign, store, exploringstore, firstappearencemephis, talking, ranaway, backagain,
        hungry, thirsty, drankpotion, deal, morning, downstairs, bag, list, outside, sign1, sign2, sign3, sign4

    };

    private States myState;

    public bool bagtoggle;
    public bool visitedgarden;
    public bool visitedcountrylane;
    public bool waited;


    void Start()
    {


        myState = States.coldstreet;

        ResetAlpha();

    }

   
    void Update()
    {

        print(myState);

               
        switch (myState) {
            case States.coldstreet:
                ColdStreetScene();
                break;
            case States.coldstreet2:
                ColdStreet2Scene();
                break;
            case States.coldstreet3:
                ColdStreet3Scene();
                break;
            case States.goingback:
                GoingBack();
                break;
            case States.death:
                DeathScene();
                break;
            case States.outsidestore:
                OutsideStoreScene();
                break;
            case States.sign:
                SignText();
                break;
            case States.outsidestorefreezing:
                OutsideStoreFreezingScene();
                break;
            case States.store:
                StoreScene();
                break;
            case States.ranaway:
                RanOutside();
                break;
            case States.backagain:
                BackonceAgain();
                break;
            case States.exploringstore:
                ExploringScene();
                break;
            case States.firstappearencemephis:
                MephisIntroScene();
                break;
            case States.talking:
                TalkingScene();
                break;
            case States.hungry:
                HungryScene();
                break;
            case States.thirsty:
                ThirstyScene();
                break;
            case States.drankpotion:
                DrankpotionScene();
                break;
            case States.deal:
                DealScene();
                break;
            case States.morning:
                MorningScene();
                break;
            case States.downstairs:
                DownstairsScene();
                break;
            case States.outside:
                OutsideScene();
                break;
    
        }
    }


   

    public void ColdStreetScene()
    {
       

        text.text = "You haven’t eaten in days. You keep walking in search of anything edible " +
                "or valuable you can change for some food. You notice a new shop in the street that’s " +
                "usually busiest at this time, but right now there is not a single soul roaming the streets.  .\n\n" +
                    "Press Up to check it out, or Down to keep searching";
        if (Input.GetKeyDown(KeyCode.UpArrow)) { myState = States.outsidestore; }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) { myState = States.coldstreet2;}

    }
    public void ColdStreet2Scene()
    {
       

        text.text = "You keep walking, still in search of food, but your hope is dwindling. .\n\n" +
                    "Press Up to keep walking, or Down to go back.";
        if (Input.GetKeyDown(KeyCode.UpArrow)) { myState = States.coldstreet3;}
        else if (Input.GetKeyDown(KeyCode.DownArrow)) { myState = States.coldstreet;}
    }

   public void ColdStreet3Scene()
    {

    

        text.text = "You desperately keep searching for food," +
                " or at least a place to spend the night. You " +
                "see the sun setting in the distance and soon the" +
                " cold winter night is hugging you, the cold creeping" +
                " under your clothes and clutching onto your body. Suddenly, a" +
                " faint light is shining up in the distance, it seems to be radiating warmth.." +
                "Press Up to walk towards the light, or Down to go back.";
        if (Input.GetKeyDown(KeyCode.UpArrow)) { myState = States.death; }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) { myState = States.goingback;  }
    }   
   public void GoingBack() {

       text.text = "You decide to go back since there isn't much to lose. You're on the main street again.\n" +
        	"Press Up to check out the store.";
        if (Input.GetKeyDown(KeyCode.UpArrow)) { myState = States.outsidestore; }
    }

    public void DeathScene() {

       
        text.fontSize = 25;
        text.text = "As the white light comes closer and closer, " +
            "your shivers die down and you feel a welcoming warmth" +
            " embracing you. Your mind is wiped clear from any negative" +
            " thoughts and your stomach is free of hunger pangs. " +
            "The further you walk towards this mysterious source of light; " +
            "that brings you utter joy and tranquility just by looking at it, " +
            "the lighter you feel; the less your surroundings matter." +
            "You can't seem to reach it though. You notice a familiar voice calling your name:\n \"" +
            "name.\n" +
            "name!\n" + "\"" +
            "The voice floods your mind with memories of a lost loved one," +
            "for years you yearned to hear it just one more time." +
            "Your heart swells and you are greeted with absolute euphoria." +
            "You begin to run and you laugh, as if nothing in the world matters." +
            "This sound comes straight from your heart.Filling the air with sweet," +
            "innocent tones emitting pure happiness that has been left untraceable" +
            " in most people. Your vision blurs, your feet seem to run on air and your" +
            "ears have long forgotten the sounds of the cold street. You don't mind. " +
            "You keep running. You utter your last breath before leaving everything behind.";
     


    }
   public void OutsideStoreScene() {

        FadeInDoor();

        text.text = "You walk towards the mysterious shop, that, at a second glance," +
            "looks like some sort of antique store." +
            "Click the door to enter, Down to read the sign.";

        if (Input.GetKeyDown(KeyCode.DownArrow)) { myState = States.sign; }

        if (Input.GetButton("DoorButton")) { myState = States.store; }
    }

   public void SignText() {


        FadeInSign();

        text.text = "You look up at the wooden sign which is painted in big, dark red letters." +
            "It says “Mr. M's Marvelous Antequities”. You wonder what the  “M” stands for." +
            "Click the door to enter, press Down to leave.";
         if (Input.GetKeyDown(KeyCode.DownArrow)) { myState = States.coldstreet2; }
        if (Input.GetButton("DoorButton")) { myState = States.store; }

    }

    public void OutsideStoreFreezingScene() {
       
         FadeInDoor();

        text.text = "You decide to go back. " +
            "You're freezing and time seems to be passing slower, " +
            "Click the door to enter";
        if (Input.GetButton("DoorButton")) { myState = States.store; }

    }

   public void StoreScene() {

        text.text = "You enter the shop. " +
            "It feels warm and cozy in here and you see a " +
            "lot of candles dipping the room into a golden light." +
            "Press Up to explore the shop, or Down to Look for the owner.";

        if (Input.GetKeyDown(KeyCode.UpArrow)) { myState = States.exploringstore; }

        else if (Input.GetKeyDown(KeyCode.DownArrow)) { myState = States.firstappearencemephis; }
    }

   public void ExploringScene()

    {

        text.text = "You wander through the shop, noticing it's shelves " +
            "are stacked with obscure objects in jars and a good deal of " +
            "mysterious chests standing around. You pass by an array of " +
            "trinkets and elongated bottles with mysteriously coloured liquids, " +
            "trying not to knock over the towering piles of arranged things, " +
            "wondering how a shop could be so neat yet so eerie." +
            "Press Down to look for the owner.";

        if (Input.GetKeyDown(KeyCode.DownArrow)) { myState = States.firstappearencemephis; }
    }

       public  void MephisIntroScene() {
        text.text = "You search for the shop owner in hopes" +
            " of meeting a kind soul who could at least let you" +
            " spend the night here.\n At the counter farther back" +
            " in the room you notice an older, grumpy looking man" +
            " paying close attention to your actions.\n Your first" +
            " instinct is to run, but your stomach is calling great " +
            "attention to itsself and you know the cold will creep under" +
            " your clothes as soon as you step outside." +
            "Press Up to talk to the owner, or Down to run away.";
       
       if (Input.GetKeyDown(KeyCode.UpArrow)) { myState = States.talking; }

        else if (Input.GetKeyDown(KeyCode.DownArrow)) { myState = States.ranaway; }
    }

   public  void RanOutside() {
        text.text = "You leave, still in search of food, but your hope is dwindling.\n" +
        	"Press Up to return to the store, or Down to keep walking.";

        if (Input.GetKeyDown(KeyCode.UpArrow)) { myState = States.backagain; }

        else if (Input.GetKeyDown(KeyCode.DownArrow)) { myState = States.coldstreet3; }
    }

   public void BackonceAgain() {
        text.text = "Once again you return to the antique store.\n" +
        	"Click the door to enter, or press Down to read the sign.";

         if (Input.GetKeyDown(KeyCode.DownArrow)) { myState = States.sign; }
    }
   public  void HungryScene() {

        text.text = "Mephis gave you a kind smile and reached under " +
        	"counter just to bring forth a little elongated glass, " +
        	"filled with a pearly liquid. He held it in your direction. " +
        	"\"Drink.\" He simply said.";
        //Click the glass.
    }

    public void ThirstyScene() {

       text.text= "\"I know exactly what you need\"," +
             "Memphis said with a knowing smile and reached " +
             "under counter just to bring forth a little elongated " +
             "glass, filled with a pearly liquid. He held it in your " +
             "direction. \"Drink.\" He simply said.";
        //Click the glass.

    }
   public void DrinkingScene() {

    text.text = "Mephisto begins to explain his further plans. \n\"Now, I have a deal for you." +
            " You stay with me and fulfil tasks i give you, and I gift you two meals a day," +
            " as well as a place to sleep until you are old enough to look after yourself.\"\n\n" +
            "A wave of gratitude washes over you in the face of an actual home, but soon you realize " +
            "you have no idea what kind of lies before you. This old man could want anything from you.\n" +
            "You panic a little, considering this guy might as well have bad intentions. You don't know " +
            "if you should listen to his offer or run as fast as you can. ";  

        //Animation: Gulping Sound, Magic Sound and little symbol appearing.
    }

   public void DrankpotionScene() {

        text.text = "The fluid was warm and you noticed a rather distinct taste of " +
            "cinnamon topped rice pudding. \n As you hand him the back the glass you" +
            "realise your hunger has disappeared. Mephisto begins to explain his further plans." +
            " \n\"Now, I have a deal for you.\" +\n \" You stay with me and fulfill tasks i give you," +
            " and I gift you two meals a day,\" +\n \" as well as a place to sleep until you are old " +
            "enough to look after yourself.\"\n\n\" +\n \"A wave of grattitude washes over you in the face" +
            " of an actual home, but soon you realize \" +\n \"you have no idea what kind of lies before you.";
        // Click 'Learn about the deal'
    }
   public void DealScene() {

        text.text = "You calm yourself down, you can always escape him if he seems suspicious.\n" +
            "You decide to give him a reassuring nod. \nSo he begins to explain. \"I will make you my apprentice." +
            " You will be my little thief and get me objects I will tell you about later on.\n" +
            "Your first mission begins tomorrow, but for now we shall rest.\"\n\nWith a finger snip all the" +
            " candles in the shop go out, leaving the one in his hand the only source of light in the room." +
            " He disappears behind the counter into another room and you have trouble catching up trying not" +
            " to knock over anything. Arriving upstairs you see two beds, looking tidy and unused. As soon as" +
            " you get into one of them he blows out the candle you hear a faint \"Goodnight.\"";
        //Press 'Goodnight' -> ''You hear a faint goodnight'' (with if statement)
        // wait 3 seconds, fade into next img
    }
   public void MorningScene() {

        text.text = "You are woken by the bell at the shop door " +
            "ringing cheerfully as another costumer exits.\n";

        //Press Down to go downstairs
    }
   public void DownstairsScene() {

        text.text= "You meet Mr. Mephis at the counter. " +
        	"\"Ah, there you are <<print $name>>. Here, you don't " +
        	"have a lot of time today, since you've taken your sweet time sleeping.\"" +
            " He throws you a rather big apple you happily catch. \n\"I'm sure you" +
            " are curious as to what you have to steal. Before I tell you, I will give " +
            "you this.\" He reaches under the counter and brings out an old-looking leather bag." +
            "\"Take this with you.\"\n\nHe also hands you a wrinkly piece paper, that seems to " +
            "have carried through a few centuries.\n\"Here's a list of the things I need.\"";


        //get the list
        //put list in bag
        //Press down to leave the shop
        //‘You can open your bag with B.' -> bagtoggle
    }
   public void TalkingScene()
    {
        //if everything is collected and you stole the boy's book, play ending 1.
        //if everything is collected and you stole the library's book, play ending 2.
        //if you haven't collected everything, mephis says "are you sure you have everything i
        //told you to get?"
    }
    public void BagToggleState() {
        //open bag -> change img, opacity change of the items if you collected them.
    }
    public void OutsideScene()
    {
        text.text = "You leave the shop and step outside." +
        	" Everything is covered in snow and icicles are sparkling in the sun. \n";
         //return home
        //head north
        //head south
    }

    public void North()
    {
        text.text = "You decide to head north. Soon the houses get fewer and fewer " +
        	"until soon your path is surrounded in fields and high, bare trees.\n\n" +
        	"You come by a crossing, one way leading down a broad country lane and the " +
        	"other leading to garden that, although it was the deepest of winter, was blooming" +
        	"with a rainbow of flowers.\n\n Where do you go? \n";

        /*[[Country lane]] img, pressable button
 [[Garden]] img, pressable button
 [[Wait.]] img, pressable button

 [[Head South]] img, pressable button
 [[Return home.]] img, pressable button
  */
    }

    public void South()
    {
        text.text = 
        "(You went south.)\n" +
        "(You are in the city.)";

    }

    public void Garden()
    {
        //flower stealing game (maybe multiple coloured flowers?? that you 
        //have to press??)
    }

    public void Waiting()
    {
        text.text = "You decide to stay where you are and take in the cold, fresh air." +
        	"\n\n Before you know it, horses are dashing by, covering you in snow that you promptly " +
        	"pat off yourself. \n You notice something shiny in the snow. ";
        //click shiny thing
        text.text = "It's a golden ring. Feeling very lucky you put it in your bag.";
        
    }

   public void CountryLane()
    {
        text.text = "You decide to walk down the country lane. Soon a little boy comes your way,\n" +
        	"he's carrying a book. He gives you a shy smile as you walk past him. You return the smile\n" +
        	"but you remember you're in need of a book. \nWill you take his?\n Press Up to steal his book," +
        	"press Down to keep walking. ";
        //coming across the boy
        //either stealing his book or not
    }

    public void StealBookBoy()
    {
        //steal the book and run away.
    }

    public void DontStealBookBoy()
    {
       text.text="You decide to let the boy continue on with his way \n" +
       	"and soon enough find yourself back at the crossing.";

    }

    public void BusyStreet()
    {
        text.text = "You arrive at a pretty busy street. You see posh people walking around, a boy handing out pamphlets,\n" +
        	"and from time to time a fancy carriage passes by. You look out for anything you need.\n A man passes by and you notice\n" +
        	"him wearing a fancy monocle. Click it to steal it from the man. Press Down to return.";
        //if monocle is clicked, add monocle to bag.
        //if down is pressed, return to South(); 
    }
    public void DarkAlleyway()
    {
        text.text = "You proceed to walk throught the busy street until you decide to bend off\n into a dark " +
        	"alleyway, searching for anything of use. Press Down to return.";
        //blinking ring
        //if ring is clicked, add ring to bag.
        //if down is clicked, return to south.
    }
   public void Blacksmith()
    {
        text.text = "You arrive at the blacksmith's workshop, looking around.\n" +
        	"He doesn't seem to be present in the moment, so you use your opportunity to explore.\n" +
        	"There's a few tools lying around. \n Press Up to inspect them, press Down to leave.";
        //if Up is pressed, show workbench. 
        //if down is pressed, return to South.
    }

   public void Library()
    {
        text.text = "You come across the library. It's known for it's founder, Mr. Goodwin Sharp, \n" +
        	"who, besides being a huge snob and wiseacre, also regularly robbed people of their money\n " +
        	"by manipulating his workers into low payments for hard work and lending money with high interest." +
        	"Press Up to enter the library, press down to keep walking.";
    }

   public void EnterLibrary()
    {
        text.text = "You entered the library. ";
    }


    public void StealLibraryBook()
    {

    }

    public void DontStealLibraryBook()
    {

    }

    public void ReturnHome()
    {

    }

    public void TalkToMephis() {

        }
    public void Ending1()
    {

    }
    public void Ending2()
    {

    }

    public void EnterShop()
    {
        myState = States.store;

    }

}



