function saveBeforeInstallPromptEvent(evt) {
    deferredInstallPrompt = evt;
}

function installPWA(evt) {
    deferredInstallPrompt.prompt();
    evt.srcElement.setAttribute('hidden', true);
    deferredInstallPrompt.userChoice
        .then((choice) => {
            if (choice.outcome === 'accepted') {
                console.log('User accepted the A2HS prompt', choice);
            } else {
                choice.log('User dismisssed the A2HS prompt', choice);
            }
        });
}

function logAppInstalled(evt) {
    console.log('App installed.', evt);
}

let deferredInstallPrompt = null;
installButton.addEventListener('click', installPWA);
window.addEventListener('beforeinstallprompt', saveBeforeInstallPromptEvent);
window.addEventListener('appinstalled', logAppInstalled);