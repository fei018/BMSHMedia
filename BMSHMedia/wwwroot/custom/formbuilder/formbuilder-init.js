function getFormBuilderOptions() {
    var options = {
        i18n: {
            locale: 'zh-TW',
            extension: '.txt',
            location: '/custom/formbuilder'
        },
        showActionButtons: false,
        disableFields: ['autocomplete', 'button', 'date', 'file', 'hidden', 'number', 'textarea']
    };

    return options;
}

function getFormBuilderOptions(data) {
    var options = {
        i18n: {
            locale: 'zh-TW',
            extension: '.txt',
            location: '/custom/formbuilder'
        },
        showActionButtons: false,
        disableFields: ['autocomplete', 'button', 'date', 'file', 'hidden', 'number', 'textarea'],
        formData: data,
    };

    return options;
}