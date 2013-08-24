// The closest thing I can find to a class constructor.
// Anything here will overwrite previously defined fields
function Character::onAdd(%this)
{
	%this.setup();
}

function Character::setup(%this)
{
	%this.damping = 20;
	%this.direction = $SpriteDirectionDown;   // The direction they are facing. Used for determining image
	%this.speed = 4;
	%this.state = $SpriteStateIdle;	// What the sprite is doing. Used for determining image
	%this.positionAdjust = "0 -0.5";
	%this.useRange = 1.5;	// How close does something have to be for the character to use it

	%this.setBodyType(dynamic);

	// This effects how characters collide
	%this.setDefaultDensity(1000000);   // Made ridiculously high so characters will not budge
	%this.setDefaultRestitution(0);	//	Bounciness
	%this.setDefaultFriction(0);
	%this.setLinearDamping(%this.damping);	//	How quickly it slows down

	// Collision Circle, if size not set = size of image
	// (radius, [relative xPos, relative yPos])
	%this.createPolygonBoxCollisionShape(1, 1, %this.positionAdjust.x, %this.positionAdjust.y);

	%this.setCollisionCallback(true);   // So onCollision will be called
	%this.setFixedAngle(true); // Stop from rotating on collision

	// Sprites, or graphics, the character is composed of
	%this.addSprite();
	%this.setSpriteName("head");
	%this.setSpriteSize(2);
	
	%this.addSprite();
	%this.setSpriteName("torso");
	%this.setSpriteSize(2);
	
	%this.addSprite();
	%this.setSpriteName("legs");
	%this.setSpriteSize(2);
	
	%this.updateImages();
}

// Change the images to match the current state
function Character::updateImages(%this)
{
	//	Head
	%this.selectSpriteName("head");

	if (%this.state $= $SpriteStateIdle ||
		%this.state $= $SpriteStateWalk)
	{
		%state = "";
	}
	else
	{
		%state = %this.state;
	}
	
	%animation = %this.getSpriteName() @ %this.gender @ %this.ethnicity @ %state @ %this.direction;
	//echo(%animation);
	%this.setSpriteAnimation("Assets:" @ %animation);
	
	//	Torso
	%this.selectSpriteName("torso");

	if (%this.state $= $SpriteStateIdle ||
		%this.state $= $SpriteStateWalk)
	{
		%state = "";
	}
	else
	{
		%state = %this.state;
	}
		
	%animation = %this.getSpriteName() @ %this.torsoColour @ %state @ %this.direction;
	//echo(%animation);
	%this.setSpriteAnimation("Assets:" @ %animation);
	
	//	Legs
	%this.selectSpriteName("legs");

	if (%this.state $= $SpriteStateIdle ||
		%this.state $= $SpriteStateWalk)
	{
		%state = "";
	}
	else
	{
		%state = %this.state;
	}
		
	%animation = %this.getSpriteName() @ %this.torsoColour @ %state @ %this.direction;
	//echo(%animation);
	%this.setSpriteAnimation("Assets:" @ %animation);
}

function Character::use(%this, %user)
{
<<<<<<< HEAD
	%this.dialogueTree.openDialogue();
=======
   %pos = %this.getPosition();
   %uPos = %user.getPosition();
   
   if (%pos.x < %uPos.x)
      %this.direction = $SpriteDirectionRight;
   else if (%pos.x > %uPos.x)
      %this.direction = $SpriteDirectionLeft;
   
   if (%pos.y < %uPos.y)
      %this.direction = $SpriteDirectionUp;
   else if (%pos.y > %uPos.y)
      %this.direction = $SpriteDirectionDown;
	
	DialogueBox.setVisible(true);
	OptionBox.setVisible(true);
	
	DialogueLabel.Text = %this.displayName;
	DialogueText.Text = "Boring, boring, boring, I am boring. Dooring, mooring, gloring. Why haven't you closed the dialogue box yet? Blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah end.";
>>>>>>> ddbb0e2a3810c6db81b57699fa9d4c2567cf7d10
}

//	Set the character to look 
function Character::faceTarget(%this, %target)
{
	%pos = %this.getPosition();
	%tPos = %target.getPosition();

	if (%pos.x < %tPos.x)
		%this.owner.direction = $SpriteDirectionRight;
	else if (%pos.x > %tPos.x)
		%this.owner.direction = $SpriteDirectionLeft;

	if (%pos.y < %tPos.y)
		%this.owner.direction = $SpriteDirectionUp;
	else if (%pos.y > %tPos.y)
		%this.owner.direction = $SpriteDirectionDown;
	
	%this.updateImages();
}
