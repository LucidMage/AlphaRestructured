// The closest thing I can find to a class constructor.
// Anything here will overwrite previously defined fields
function Guide::onAdd(%this)
{
	%this.setup();
}

function Guide::setup(%this)
{
	%this.damping = 20;
	%this.direction = $SpriteDirectionRight;   // Used for determining image
	%this.speed = 4;
	%this.state = $SpriteStateWalk;	// Used for determining image
	%this.positionAdjust = "0 -0.5";
	%this.useRange = 1.5;	// How close does something have to be for the character to use it

	%this.setSize(2);
	%this.setBodyType(dynamic);

	// This effects how characters collide
	%this.setDefaultDensity(1000000);   // Made ridiculously high so characters will not budge
	%this.setDefaultRestitution(0);	//	Bounciness
	%this.setDefaultFriction(0);
	%this.setLinearDamping(%this.damping);	//	How quickly it slows down

	// Collision Circle, if size not set = size of image
	// (radius, [relative xPos, relative yPos])
	//%this.createCircleCollisionShape(0.25, 0, -0.25);
	%this.createPolygonBoxCollisionShape(1, 1, %this.positionAdjust.x, %this.positionAdjust.y);

	%this.setCollisionCallback(true);   // So onCollision will be called
	%this.setFixedAngle(true); // Stop from rotating on collision
	
	%image = %this.imageName;
	%animation = %image @ %this.state @ %this.direction;
	//echo(%animation);
	%this.playAnimation(%animation);
}

function Guide::use(%this, %user)
{
   echo("User:");
   echo(%user);
   echo(%user.getName());
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
	
	DialogueLabel.setText(%this.displayName);
	DialogueText.setText("Hello" SPC %user.getName() @ ", how are things?");
<<<<<<< HEAD
>>>>>>> ddbb0e2a3810c6db81b57699fa9d4c2567cf7d10
=======
>>>>>>> ddbb0e2a3810c6db81b57699fa9d4c2567cf7d10
}