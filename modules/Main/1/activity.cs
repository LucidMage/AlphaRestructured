Main.ActiveActivity = "";

function LoadActivity( %moduleDefinition )
{
   // Sanity!
   if ( !isObject( %moduleDefinition ) )
   {
      error( "Cannot load toy as the specified toy is not available." );
      return;
   }
   
   // Unload the current activity
   UnloadActivity();
   
   // Create a scene.
   CreateScene();
   
   // Now is a good time to purge any idle assets.
   AssetDatabase.purgeAssets();
   
   // Set current activity
   Main.ActiveActivity = %moduleDefinition;
   
   // Load activity
   if ( !ModuleDatabase.loadExplicit( %moduleDefinition.ModuleId, %moduleDefinition.VersionId ) )
   {
      error( "Failed to load activity '" @ %moduleDefinition.ModuleId @ "'." );
      return;
   }
   
   // Add the scene so it's unloaded when the activty is.
   %moduleDefinition.ScopeSet.add( GameScene );
   
   // Add activity scope-set as a listener.
   GameWindow.addInputListener( %moduleDefinition.ScopeSet );        
}

function UnloadActivity()
{
   // Finish if no activity is loaded
   if ( !isObject(Main.ActiveToy) )
      return;
   
   // Delete any custom controls added by the toy.
   //ToyCustomControls.deleteObjects();
   
   //resetCustomControls();
   
   // Unload the toy.
   if ( !ModuleDatabase.unloadExplicit( Main.ActiveToy.moduleId ) )
   {
      error( "Failed to unload the toy '" @ Main.ActiveToy.ModuleId @ "'." );
   }
   
   // Reset active toy.
   Main.ActiveToy = "";  
}

function ScanForActivities()
{
   %toLoad = 0;  // temp
   
   // Find modules
   %activityModules = ModuleDatabase.findModuleTypes( $ModuleTypeActivity, false );
   
   // Check for an existing set of yeargroups
   if ( !isObject(Activities) )
   {
      new SimSet(Activities);
   }
   
   Activities.clear();
   
   // Get module count
   %moduleCount = getWordCount( %activityModules );
   
   // Add modules
   for ( %i = 0; %i < %moduleCount; %i++ )
   {
      // Get module definition
      %moduleDefinition = getWord( %activityModules, %i );
      
      if (%toLoad == 0)
         %toLoad = %moduleDefinition;
      
      // Add to yeargroup set
      Activities.add( %moduleDefinition );
   }
   
   LoadActivity(%toLoad);
}