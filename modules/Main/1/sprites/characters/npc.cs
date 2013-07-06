function createNPC(%position)
{
   //  Create NPC
   %npc = new CompositeSprite()
   {
      //name = "NPC";
      class = "Character";
      direction = $SpriteDirectionDown;   // Used for determining image
      imageName = "Assets:TD_Dwarf";  // temporary
      speed = 4;
      state = $SpriteStateWalk;//$SpriteStateIdle;   // Used for determining image
      
      Position = %position;
      SceneLayer = 14;
   };
   
   // Sprites, or graphics, the player is composed of
   %npc.addSprite();
   %npc.setSpriteName("body");
   //%npc.setSpriteImage("Assets:PC_Body1");
   //%image = %npc.getSpriteImage();
   %image = %npc.imageName;
   %npc.setSpriteAnimation(%image @ %npc.state @ %npc.direction);

   //  Add to Scene
   gameScene.add(%npc);
}