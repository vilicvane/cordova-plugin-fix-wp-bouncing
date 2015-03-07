# Cordova Fix-WP-Bouncing Plugin

This is a plugin that tries to fix [Windows Phone bouncing issue](http://stackoverflow.com/questions/21652548/bouncing-when-overflow-set-to-auto-or-scroll-in-wp8-webbrowser-control). It's not a perfect solution but it should work most of the time.

## Install

```sh
cordova plugin add com.wordsbaking.cordova.fix-wp-bouncing
```

## Usage

```javascript
var wrapper = document.getElementById('an-element-that-scrolls');
FixWPBouncing.fix(wrapper);
```

## License

MIT License.