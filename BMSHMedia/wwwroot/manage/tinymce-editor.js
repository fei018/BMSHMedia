import tinymce from "../tinymce/tinymce.min.js";

function useTinyMce(selector) {

    tinymce.init({
        selector: selector,
        inline: true,
    });
}

