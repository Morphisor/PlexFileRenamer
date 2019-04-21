window.blazorInterop = {
    localStorage: {
        set: function (key, value) {
            var serializedObject = JSON.stringify(value);
            localStorage.setItem(key, serializedObject);
            return true;
        },
        get: function (key) {
            var stringObj = localStorage.getItem(key);
            return JSON.parse(stringObj);
        }
    },

    sessionStorage: {
        set: function (key, value) {
            var serializedObject = JSON.stringify(value);
            sessionStorage.setItem(key, serializedObject);
            return true;
        },
        get: function (key) {
            var stringObj = sessionStorage.getItem(key);
            return JSON.parse(stringObj);
        }
    },

    utils: {
        triggerNavigation: function (url) {
            window.location.href = url;
            return true;
        },
        getInputFiles: function (inputId) {
            var inputElement = document.getElementById(inputId);
            var result = [];
            for (var i = 0; i < inputElement.files.length; i++) {
                var file = inputElement.files[i];
                result.push(file.name);
            }
            return result;
        },
        downloadFile: function (filename, text) {
            var element = document.createElement('a');
            element.setAttribute('href', 'data:text/plain;charset=utf-8' + encodeURIComponent(text));
            element.setAttribute('download', filename);

            element.style.display = 'none';
            document.body.appendChild(element);

            element.click();

            document.body.removeChild(element);
            return true;
        }
    }
}