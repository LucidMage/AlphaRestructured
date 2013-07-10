function createPlayer(%position)
{
   //  Create Player
   %player = new CompositeSprite(Player)
   {
      name = "Player";
      class = "Character";
      direction = $SpriteDirectionDown;   // Used for determining image
      imageName = "Assets:TD_Wizard";  // temporary
      inventoryCount = 0;
      speed = 4;
      state = $SpriteStateWalk;//$SpriteStateIdle;   // Used for determining image
      
      Position = %position;
      SceneLayer = 14;
      // Graphics are defined by the sprites added below
      //Animation = "Assets:TD_Wizard_WalkSouth";
      //Image = "Assets:TD_Wizard_CompSprite";
   };
   
   // Sprites, or graphics, the player is composed of
   %player.addSprite();
   %player.setSpriteName("body");
   //%player.setSpriteImage("Assets:PC_Body1");
   //%image = %player.getSpriteImage();
   %image = %player.imageName;
   %player.setSpriteAnimation(%image @ "_" @ %player.state @ %player.direction);

   // Set Behaviours
   %controls = PlayerControlsBehaviour.createInstance();
   %player.addBehavior(%controls);

   // Add to Scene
   gameScene.add(%player);
}

function Player::onAdd(%this)
{
   // Same as Character::onAdd
   %this.setBodyType(dynamic);
   
   // Collision Circle, if size not set = size of image
   // (radius, [relative xPos, relative yPos])
   %this.createCircleCollisionShape(0.25, 0, -0.25);
   
   %this.setCollisionCallback(true);   // So onCollision will be called
   %this.setFixedAngle(true); // Stop from rotating on collision
   
   %inventory = new ScriptObject(Inventory);
}
/*
function Player::onCollision(%this, %sceneobject, %collisiondetails)
{
   //%this.setBodyType(static);
   %this.setLinearVelocity("0 0");
   %this.setAngularVelocity("0");
}*/
/*
function Player::PickUpItem(%this, %item)
{
   %inventory.AddItem(%item);
   Player.inventory[Player.inventoryCount] = %item;
   Player.inventoryCount++;
   
   echo("New Item" SPC %item.getId());
   echo("Item at slot" SPC Player.inventoryCount-- SPC ":" SPC Player.inventory[Player.inventoryCount--]);
   echo("Inventory Count" SPC Player.inventoryCount);
}*/