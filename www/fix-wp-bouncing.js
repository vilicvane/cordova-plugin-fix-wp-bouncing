/*

    Cordova Fix-WP-Bouncing Plugin
    https://github.com/vilic/cordova-plugin-fix-wp-bouncing

    by VILIC VANE
    https://github.com/vilic

    MIT License

*/

var POINTER_DOWN;

if (navigator.pointerEnabled) {
    POINTER_DOWN = 'pointerdown';
} else if (navigator.msPointerEnabled) {
    POINTER_DOWN = 'MSPointerDown';
}

exports.target = null;

exports.onmanipulationdelta = function () {
    if (!exports.target) {
        return '';
    }

    var target = exports.target;

    var top = target.scrollTop == 0;
    var bottom = target.scrollTop + target.clientHeight == target.scrollHeight;

    return top ? bottom ? 'both' : 'top': bottom ? 'bottom' : '';
};

exports.onmanipulationcompleted = function () {
    exports.target = null;
};

exports.fix = function (target) {
    if (!POINTER_DOWN) {
        return;
    }

    if (!(target instanceof HTMLElement) && target.length) {
        target = target[0];
    }

    target.addEventListener(POINTER_DOWN, function () {
        exports.target = target;
    }, false);
};