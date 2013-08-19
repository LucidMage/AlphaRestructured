$DialogueMaxOptions = 9;

if (!isObject(DialogueBehaviour))
{
   %template = new BehaviorTemplate(DialogueBehaviour);
   
   %template.friendlyName = "Dialogue";
   %template.description = "Conversation with a sprite";
   
   // addBehaviorField(function name, description of function, keybind, input e.g. "keyboard up" = up arrow key)
   %template.addBehaviorField(selectKey, "Key to bind for selecting a dialogue option", keybind, "keyboard space");
   
   %template.addBehaviorField(dialogue, "What the talking sprite is saying", string, "");
   %template.addBehaviorField(end, "Is there an option to end dialogue", bool, true);
   %template.addBehaviorField(options, "Options the player can select", enum, "CRAP! NO OPTIONS.");
   %template.addBehaviorField(optionCount, "Number of options", int, 0);
}

function DialogueBehaviour::onBehaviorAdd(%this)
{
   if (!isObject(GlobalActionMap))
      return;

   // bindObj(getWord(object.behaviour field, [function parameters excluding %this]), "function name", object)
   GlobalActionMap.bindObj(getWord(%this.selectKey, 0), getWord(%this.selectKey, 1), "selectOption", %this);
}

function DialogueBehaviour::onBehaviorRemove(%this)
{
   if (!isObject(GlobalActionMap))
      return;

   //%this.owner.disableUpdateCallback();

   GlobalActionMap.unbindObj(getWord(%this.useKey, 0), getWord(%this.useKey, 1), %this);
}

//	Setup the dialogue GUI
//	Target = who the owner is talking to, almost always the owner talking to the player
//	Subject = the scriptobject holding the dialogue and options
function DialogueBehaviour::openDialogue(%this, %target, %subject)
{
	echo("Opening Dialogue");
	
	DialogueBox.setVisible(true);
	OptionBox.setVisible(true);
	
	//	Dialogue
	DialogueLabel.setText(%this.owner.displayName);
	DialogueText.setText("Hello" SPC %user.getName() @ ", how are things?");
	
	//	Options
	//OptionBox
	
	if (%this.end == true)
	{
		//OptionBox.
	}
}

//	Text = What the player will say
//	Dialogue = What action selecting this option will trigger,
//				usually another piece of dialogue.
function DialogueBehaviour::addOption(%this, %text, %dialogue)
{
	//	NOTE: Options shouldn't be zero indexed, the option number is the same number key
	//	binded to the option. '0' is reserved for [End Dialogue] which is added else where.
	if (%this.optionCount > $DialogueMaxOptions)
	{
		%this.optionCount++;
	}
	else
	{
		warn("Cannot add" SPC %text SPC "to dialogue" SPC %this SPC "for" SPC %this.owner @ ". Too many options.");
	}
}