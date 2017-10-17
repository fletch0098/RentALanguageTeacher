/**
 * Basic sample plugin inserting current date and time into CKEditor editing area.
 */

// Register the plugin with the editor.
// http://docs.cksource.com/ckeditor_api/symbols/CKEDITOR.plugins.html
CKEDITOR.plugins.add( 'closeeditor',
{
	// The plugin initialization logic goes inside this method.
	// http://docs.cksource.com/ckeditor_api/symbols/CKEDITOR.pluginDefinition.html#init
	init: function( editor )
	{
		// Define an editor command that inserts a timestamp. 
		// http://docs.cksource.com/ckeditor_api/symbols/CKEDITOR.editor.html#addCommand
		editor.addCommand( 'closeeditor',
			{
				// Define a function that will be fired when the command is executed.
				// http://docs.cksource.com/ckeditor_api/symbols/CKEDITOR.commandDefinition.html#exec
				exec : function( editor )
				{    
				    if (editor)
				        editor.destroy();
				}
			});
		// Create a toolbar button that executes the plugin command. 
		// http://docs.cksource.com/ckeditor_api/symbols/CKEDITOR.ui.html#addButton
		editor.ui.addButton( 'closeeditor',
		{
			// Toolbar button tooltip.
			label: '',
			// Reference to the plugin command name.
			command: 'closeeditor',
			// Button's icon file path.
			icon: this.path + 'images/closeeditor.png'
		} );
	}
} );