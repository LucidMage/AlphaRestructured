function Transition::onAdd(%this)
{
   %this.setBodyType(static);
   %this.createPolygonBoxCollisionShape(%this.width, %this.height);
   
   %this.setCollisionCallback(true);   // So onCollision will be called
   %this.setFixedAngle(true); // Stop from rotating on collision
}
/*
function Transition::onRemove(%this)
{
   if ($ActivityScene == %this.toScene)
      LoadActivity(Main.ActiveActivity);
}*/

// Change to a different scene when player collides with transition
function Transition::onCollision(%this, %sceneobject, %collisiondetails)
{
   /*
   %scene = new Scene();
   SetScene(%scene);*/
   /*
   SetScene(new Scene());
   new ScriptObject(%this.toScene);*/
}