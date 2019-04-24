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
            var blob = new Blob([text], { type: 'text/plain' });
            var url = window.URL.createObjectURL(blob);
            var a = document.createElement('a');
            document.body.appendChild(a);
            a.setAttribute('style', 'display: none');
            a.href = url;
            a.download = filename;
            a.click();
            window.URL.revokeObjectURL(url);
            a.remove();
            
            return true;
        }
    }
}