// The closest thing I can find to a class constructor.
// Anything here will overwrite previously defined fields
function Character::onAdd(%this)
{
   %this.direction = $SpriteDirectionDown;   // Used for determining image
   %this.speed = 4;
   %this.state = $SpriteStateWalk;  //$SpriteStateIdle;   // Used for determining image
   
   %this.setBodyType(dynamic);
   
   // Collision Circle, if size not set = size of image
   // (radius, [relative xPos, relative yPos])
   %this.createCircleCollisionShape(0.25, 0, -0.25);
   
   %this.setCollisionCallback(true);   // So onCollision will be called
   %this.setFixedAngle(true); // Stop from rotating on collision
   
   // Sprites, or graphics, the player is composed of
   %this.addSprite();
   %this.setSpriteName("body");
   //%this.setSpriteImage("Assets:PC_Body1");
   //%image = %this.getSpriteImage();
   %image = %this.imageName;
   %this.setSpriteAnimation(%image @ %this.state @ %this.direction);
}

function Character::onCollision(%this, %sceneobject, %collisiondetails)
{
   %this.setLinearVelocity("0 0");
   %this.setAngularVelocity("0");
}