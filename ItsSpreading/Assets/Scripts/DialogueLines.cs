using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueLines
{

    private List<Dialogue> _dialogues = new List<Dialogue>();

    public List<Dialogue> getLinesList()
    {
        _dialogues.Add(new Dialogue( "Finally slipped out of this stupid class. I've got better things to do than to waste my time in there, right Tsuki?" ,1));//0
        _dialogues.Add(new Dialogue( "Woof-Woof!" ,0));//1
        _dialogues.Add(new Dialogue( "Uh, school's pretty quiet. Everyone is in class. Silence feels nice." ,1));//2
        _dialogues.Add(new Dialogue( "Freedom is close, the door is right there." ,1));//3
        _dialogues.Add(new Dialogue( "Wait, was that there before? Scissors, in the middle of the gym?" ,1));//4
        _dialogues.Add(new Dialogue( "Finally slipped out of this stupid class. I've got better things to do than... has school always been this... dull? Uh. " ,1));//5
        _dialogues.Add(new Dialogue( "Wasn't there a door there? There must have been, I'm not crazy..." ,1));//6
        _dialogues.Add(new Dialogue( "What's that up there? A hole? A... vent hole? Maybe this leads somewhere. It's too high to reach. " ,1));//7
        _dialogues.Add(new Dialogue( "Mhh, a box. Maybe I can find something useful to do with this. " ,1));//8
        _dialogues.Add(new Dialogue( "I think I can climb this! Let's see where it leads. C'mon pup." ,1));//9
        _dialogues.Add(new Dialogue( "Where are we? This doesn't make sense. I feel like we were just here a moment ago... were we?" ,2));//10
        _dialogues.Add(new Dialogue( "Things feel weird, I can't put my finger on why. " ,1));//11
        _dialogues.Add(new Dialogue( "Locked. I probably need some type of keys to open these locks. Let's look around. " ,1));//12
        _dialogues.Add(new Dialogue( "I think I see a key in the net, but I can't reach it. Maybe something else could." ,1));//13
        _dialogues.Add(new Dialogue( "Found one!" ,1));//14
        _dialogues.Add(new Dialogue( "Only one other key missing. Good job Tsuki" ,1));//15
        _dialogues.Add(new Dialogue( "Finally found the last one, let's open this door and leave this place. It's giving me the creeps. " ,1));//16
        _dialogues.Add(new Dialogue( "No no no this doesn't make sense. I'm certain we were just here. What's going on. I just want to leave. " ,2));//17
        _dialogues.Add(new Dialogue( "Oh now what the fuck is that. Why is the door up there. This is starting to scare me I just want to leave." ,2));//18
        _dialogues.Add(new Dialogue( "I need to reach that door. Or maybe... maybe I can weigh it down with something? Seems to hold on to nothing." ,1));//19
        _dialogues.Add(new Dialogue( "A ball... Mhh... Let's see if I can find some use to it.  " ,1));//20
        _dialogues.Add(new Dialogue( "It's stuck! Maybe I can put other things on top to make it heavy." ,1));//21
        _dialogues.Add(new Dialogue( "I can't believe it worked. Come on Tsuki we're leaving this creepy ass school. " ,1));//22
        _dialogues.Add(new Dialogue( "Those... things on the wall look out of place. " ,1));//23
        _dialogues.Add(new Dialogue( "Door is blocked again. I need to find a way through." ,3));//24
        _dialogues.Add(new Dialogue( "We're back here, again, and again, and again and.... wait. Tsuki? Tsuki! Can you hear me? Where are you?!" ,2));//25
        _dialogues.Add(new Dialogue( "It's not Tsuki style to run away something's not right. I hope she's fine, please let her be fine." ,3));//26
        _dialogues.Add(new Dialogue( "There's some type of writing on the walls. What does any of that means?!" ,1));//27
        _dialogues.Add(new Dialogue( "Is something... or someone, threatening me?" ,2));//28
        _dialogues.Add(new Dialogue( "Back here again... what a surprise. Sill no traces of Tsuki..." ,2));//29
        _dialogues.Add(new Dialogue( "Another lock? This is pushing it. I need to find the key. " ,1));//30
        _dialogues.Add(new Dialogue( "A dollar bill. Mh. I'll hold on to it, why not. " ,1));//31
        _dialogues.Add(new Dialogue( "I'm honestly kind of getting hungry, why not use this money for something useful." ,1));//32
        _dialogues.Add(new Dialogue( "What the hell... More money?! It doubled it!" ,1));//33
        _dialogues.Add(new Dialogue( "Managed to get this damn key. Now let's get out... I hope." ,1));//34
        _dialogues.Add(new Dialogue( "Something is off. I don't feel good about this. " ,2));//35
        _dialogues.Add(new Dialogue( "What the fuck IS this?! Tsuki is that you?! It can't be, it can't be." ,3));//36
        _dialogues.Add(new Dialogue( "I feel weird... My head hurts and my limbs feel tingly." ,3));//37
        _dialogues.Add(new Dialogue( "I just want to go home with Tsuki, why is all of this happening. " ,3));//38
        _dialogues.Add(new Dialogue( "I need to go on..." ,3));//39
        _dialogues.Add(new Dialogue( "I can't use that." ,1));//40
        _dialogues.Add(new Dialogue( "I don't think that would be useful." ,1));//41
        _dialogues.Add(new Dialogue( "I need to find the key." ,1));//42
        _dialogues.Add(new Dialogue( "I'm so sorry Tsuki I don't know what to do, I don't want this." ,3));//43

        return _dialogues;
    }


}
