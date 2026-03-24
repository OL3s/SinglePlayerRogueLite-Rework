using Godot;
using System;
using Animation;

public partial class Player : CharacterBody2D
{
	[Export] public InputNode PlayerInput; 
	[Export] public float MoveSpeed { get; set; } = 40f;
	[Export] Sprite2D Sprite;
	private SpriteTarget _spriteTarget;

	private double _time;

	public override void _Ready()
	{
		if (PlayerInput == null) throw new ArgumentNullException(nameof(PlayerInput), "PlayerInput is not assigned in the inspector.");
		_spriteTarget = new SpriteTarget(0f, 0f, 0f, Sprite.Scale.X, Sprite.Scale.Y);
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 inputVector = PlayerInput.GetPlayerInput().LeftStick;
		Velocity = inputVector * MoveSpeed;

		MoveAndSlide();
	}

	public override void _Process(double delta)
	{
		// Lerp towards target
		Sprite.Position = new Vector2(
			PositionModifiers.Lerp(Sprite.Position.X, _spriteTarget.X, 0.4f),
			PositionModifiers.Lerp(Sprite.Position.Y, _spriteTarget.Y, 0.4f)
		);
		Sprite.Rotation = PositionModifiers.Lerp(Sprite.Rotation, _spriteTarget.Rotation, 0.4f);
		Sprite.Scale = new Vector2(
			PositionModifiers.Lerp(Sprite.Scale.X, _spriteTarget.ScaleX, 0.4f),
			PositionModifiers.Lerp(Sprite.Scale.Y, _spriteTarget.ScaleY, 0.4f)
		);

		// Apply animation modifiers
		if (Velocity.Length() > 0f)
		{
			_time += delta;
			Sprite.Position -= new Vector2(0f, PositionModifiers.Bounce(_time, 10f, .4f));
			Sprite.Rotation += PositionModifiers.Sway(_time, 10f, 0.04f);
		} 
		else
		{
			_time = 0;
		}
	}
}
