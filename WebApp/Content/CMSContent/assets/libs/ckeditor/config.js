/**
 * @license Copyright (c) 2003-2017, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function (config) {
    config.height = '25rem';
    // Define changes to default configuration here. For example:
    // config.language = 'fr';
    // config.uiColor = '#AADC6E';
    config.filebrowserBrowseUrl = "/Content/CMSContent/assets/libs/ckfinder/ckfinder.html";
    config.filebrowserImageUrl = "/Content/CMSContent/assets/libs/ckfinder/ckfinder.html?type=Images";
    config.filebrowserFlashUrl = "/Content/CMSContent/assets/libs/ckfinder/ckfinder.html?type=Flash";
    config.filebrowserUploadUrl = "/Content/CMSContent/assets/libs/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files";
    config.filebrowserImageUploadUrl = "/Content/CMSContent/assets/libs/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images";
    config.filebrowserFlashUploadUrl = "/Content/CMSContent/assets/libs/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash";


    //config.allowedContent = true;
    //config.disallowedContent = 'img{width,height}';


    //config.extraPlugins = 'youtube';
    //config.youtube_responsive = true;
    //config.extraPlugins = 'ckeditorfa';
    config.extraPlugins = 'lineheight';
};
