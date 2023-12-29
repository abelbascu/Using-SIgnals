using Godot;
using System;

public partial class SubscriberNodeA : CharacterBody2D
{
    public EmitterNode emitterNode;
    public Label AppleStolenAnswer;
    public Timer timer;

    public override void _Ready() {
        timer = GetNode("../delayTimer") as Timer;
        OnNodeReady();
    }

    public async void OnNodeReady() {
        
        //WAYS TO GET A NODE IN THE SCENE THAT MAY NOT BE READY YET
        //OPTION 1:

        do {
            emitterNode = GetNode<EmitterNode>("../EmitterNode");
        } while (!GetNode<EmitterNode>("../EmitterNode").IsInsideTree());

        //OPTION 2.
        //"../EmitterNode" means go up one level in the hierarchy   
        //you can also use "/root/MainScene/EmitterNode", this is the absolute path

        if (GetNode<EmitterNode>("../EmitterNode") == null) {
            timer.Start(0.5);
            await ToSignal(timer, "timeout");
        }

        //after the timeout, we continue. We have waited 0.5secs for the target node to be ready,
        //seems enough but the line below is dangerous as it could fail

        emitterNode = GetNode<EmitterNode>("../EmitterNode");
        emitterNode.StealsAppleFromGrocery += OnKiddoStealsApple;
    }

    public void OnKiddoStealsApple() {
        GetNode<Label>("AppleStolenAnswer").Text = ("You kiddo! I saw what you did. Leave the apple where it was!");
    }
}


//await ToSignal(GetNode<EmitterNode>("EmitterNode"), GetNode<EmitterNode>("EmitterNode").SignalName.Ready);
