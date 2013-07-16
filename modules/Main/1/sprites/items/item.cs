function Item::onAdd(%this)
{
   %this.SceneLayer = 14;
   %this.Size = 0.75;
   
   %this.setBodyType(static);
   
   //%this.createCircleCollisionShape(0.25);
   %this.createPolygonBoxCollisionShape(0.5, 0.5);
   
   %this.setCollisionCallback(true);
   //%this.setFixedAngle(true);
}

function Item::onCollision(%this, %sceneobject, %collisiondetails)
{
   if (%sceneobject.getId() == Player.getId())
   {
      echo("Item made contact with player");
      echo("Player ID" SPC Player.getId());
      echo("Item ID" SPC %this.getId());
      Inventory.AddItem(%this);
      %this.removeFromScene();
   }
}