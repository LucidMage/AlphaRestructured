function CreateProfile()
{
   // Create Default Player Character
   %player = new CompositeSprite(Player)
   {
      displayName = "Test";
      class = "Character";
      imageName = "Assets:TD_Wizard_";  // temporary
   };
   
   // Must be different than other characters to stop the player from pushing other characters
   %player.setDefaultDensity(0);
   
   new ScriptObject(Profile)
   {
      password = "guest";
      year = 8;
      gender = "male";
      character = %player;
   };
}