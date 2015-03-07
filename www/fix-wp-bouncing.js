/*

    Cordova Fix-WP-Bouncing Plugin
    https://github.com/vilic/cordova-plugin-fix-wp-bouncing

    by VILIC VANE
    https://github.com/vilic

    MIT License

*/

exports._target = null;
exports._targetStatus = '';

var pointerSupport;
var POINTER_DOWN, POINTER_MOVE, POINTER_UP, POINTER_CANCEL;

if (navigator.pointerEnabled) {
    pointerSupport = true;
    POINTER_DOWN = 'pointerdown';
    POINTER_MOVE = 'pointermove';
    POINTER_UP = 'pointerup';
    POINTER_CANCEL = 'pointercancel';
} else if (navigator.msPointerEnabled) {
    pointerSupport = true;
    POINTER_DOWN = 'MSPointerDown';
    POINTER_MOVE = 'MSPointerMove';
    POINTER_UP = 'MSPointerUp';
    POINTER_CANCEL = 'MSPointerCancel';
} else {
    pointerSupport = false;
}

exports.fix = function (target) {
    if (!(target instanceof HTMLElement) && target.length) {
        target = target[0];
    }

    target.addEventListener(POINTER_DOWN, startUpdating, false);
    target.addEventListener(POINTER_UP, stopUpdating, false);
    target.addEventListener(POINTER_CANCEL, stopUpdating, false);

    function startUpdating() {
        exports._target = target;
        updateTargetStatus();
        target.addEventListener(POINTER_MOVE, updateTargetStatus, false);
    }

    function stopUpdating() {
        exports._target = null;
        exports._targetStatus = '';
        target.removeEventListener(POINTER_MOVE, updateTargetStatus, false);
    }

    function updateTargetStatus() {
        var top = target.scrollTop == 0;
        var bottom = target.scrollTop + target.clientHeight == target.scrollHeight;
        exports._targetStatus = top ? bottom ? 'both' : 'top': bottom ? 'bottom' : '';
    }
};