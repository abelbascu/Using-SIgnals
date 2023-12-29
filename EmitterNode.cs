using Godot;
using System;
using System.Collections.Generic;


public partial class EmitterNode : CharacterBody2D
{
    public List<Action> EmitterNodeSignalsDB = new List<Action>();
    public Action StealsAppleFromGrocery;
    public Action ThrowsDogtoTheRoad;
    public Button stealApplebutton;
    public Area2D area2D;


    public override void _Ready() {
        EmitterNodeSignalsDB.Add(StealsAppleFromGrocery);
        EmitterNodeSignalsDB.Add(ThrowsDogtoTheRoad);

        stealApplebutton = GetNode("StealAppleButton") as Button;
        StealsAppleFromGrocery += OnStealsAppleFromGrocery;
        stealApplebutton.Connect("pressed", new Callable(this, nameof(OnPressingtheButton)));
        //area2D = GetNode<Area2D>("Area2D");
        //area2D.MouseEntered += OnStealsAppleFromGrocery;

    }

    public void OnPressingtheButton() {
        GD.Print("button was pressed");
        StealsAppleFromGrocery.Invoke();
    }

    public void OnStealsAppleFromGrocery() {

        GD.Print("Kid steals apple from grocery");
    }
}
