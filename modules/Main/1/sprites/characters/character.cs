// The closest thing I can find to a class constructor.
// Only takes effect when the sprite is added to the scene, not when it is created.
// Anything here will overwrite previously defined fields
function Character::onAdd(%this)
{
   %this.setBodyType(dynamic);
   
   // Collision Circle, if size not set = size of image
   // (radius, [relative xPos, relative yPos])
   %this.createCircleCollisionShape(0.25, 0, -0.25);
   
   %this.setCollisionCallback(true);   // So onCollision will be called
   %this.setFixedAngle(true); // Stop from rotating on collision
}

function Character::onCollision(%this, %sceneobject, %collisiondetails)
{
   %this.setLinearVelocity("0 0");
   %this.setAngularVelocity("0");
}