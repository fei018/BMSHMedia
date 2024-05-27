
function tinymceinit(selector) {
    tinyMCE.init({
        selector: selector,
        menubar: false,
        language: 'zh_CN',
        plugins: 'link code media',
        toolbar: 'code undo redo restoredraft | cut copy paste pastetext | forecolor backcolor bold italic underline strikethrough fontsizeselect | alignleft aligncenter alignright alignjustify outdent indent | link media',
        setup: function (editor) {
            editor.on('change', function () { editor.save(); });
        },
    });
}