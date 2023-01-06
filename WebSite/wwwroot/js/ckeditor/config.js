/**
 * @license Copyright (c) 2003-2021, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function (config) {

	//config.extraAllowedContent = '*[id](*)';  // remove '[id]', if you don't want IDs for HTML tags
	/*config.autoUpdateElement = false; */
	//config.clipboard_defaultContentType = 'text';
	config.allowedContent = true;
    // allow i tags to be empty (for font awesome)
    CKEDITOR.dtd.$removeEmpty["i"] = false;
   
   
    //   config.pasteFilter.disabled = true;
    //config.copyFormatting_allowRules = true;
    //config.copyFormatting_allowedContexts = true;
    /*config.ignoreEmptyParagraph = false;*/

/*	config.extraPlugins= 'divarea';*/
    /*config.forcePasteAsPlainText= true;*/
    /*config.removePlugins= 'elementspath';*/


    // Define changes to default configuration here. For example:
    // config.language = 'fr';
    // config.uiColor = '#AADC6E';
};
//CKEDITOR.on('instanceReady', function (ev) {
//	ev.editor.pasteFilter.disabled = true;
//});
//CKEDITOR.replace('post_content', {
//	allowedContent: true,
//});

