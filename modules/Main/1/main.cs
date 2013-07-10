//  Code called when program starts
function Main::create( %this )
{
   %this.loadPreferences();
   
   // Load Main Scripts
   exec("./global.cs"); // Global Values
   exec("./console.cs");   // Console
   exec("./behaviours/loadList.cs");   // Load Behaviours
   exec("./sprites/loadList.cs");   // Load Sprites

   //exec("./scenewindow.cs");
   exec("./activity.cs");
   exec("./scene.cs");
   exec("./inventory.cs");
   
   //  Load GUI Profiles
   exec("./gui/guiProfiles.cs");   //  Need this to create GUI controls

   CreateSceneWindow();
	
	// Load and configure the console.	exec("./scripts/console.cs");  
	TamlRead("./gui/ConsoleDialog.gui.taml"); // Notice we are just reading in the Taml file, not adding it to the scene  
	GlobalActionMap.bind( keyboard, "tilde", toggleConsole );   // Press '`' to open console
    
    // Load and configure the toolbox.
    //Main.add( TamlRead("./gui/ToolboxDialog.gui.taml") );
    
    ScanForActivities();
    //LoadActivity("Year8");
	
   //CreateScene();
   
   //createNPC("-4 -2");
   //createPlayer("0 -2");
   
   //createSceneWindow(Player);
   // Start sticking camera to player
   //centreOnSprite(Player);

   //  Debug
   //  Enable visualization for "collision", "position", and "aabb"
   //GameScene.setDebugOn("collision", "position", "aabb");
   
   // Initialize the "cannot render" proxy.
   new RenderProxy(CannotRenderProxy)
   {
      Image = "Assets:CannotRender";
   };
   Main.add( CannotRenderProxy );
}

//  Code called when program ends
function Main::destroy( %this )
{
    destroySceneWindow();
}

function Main::loadPreferences( %this )
{
   // Load the default preferences.
   //exec( "./defaults.cs" );
   
   // Load the last session preferences if available.
   if ( isFile("preferences.cs") )
      exec( "preferences.cs" );   
}