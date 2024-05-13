
function tinymceinit(selector) {
    tinyMCE.init({
        selector: selector,
        menubar: false,
        language: 'zh_CN',
        plugins: 'link code media',
        toolbar: 'undo redo restoredraft | code link media | styleselect formatselect fontselect fontsizeselect | forecolor backcolor bold italic underline',
        setup: function (editor) {
            editor.on('change', function () { editor.save(); });
        },
    });
}