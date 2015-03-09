# Cordova Fix-WP-Bouncing Plugin

This is a plugin that tries to fix [Windows Phone bouncing issue](http://stackoverflow.com/questions/21652548/bouncing-when-overflow-set-to-auto-or-scroll-in-wp8-webbrowser-control). It's not a perfect solution but it should work most of the time.

## Install

```sh
cordova plugin add com.wordsbaking.cordova.fix-wp-bouncing
```

## Usage

```css
html {
    -ms-touch-action: none;
    touch-action: none;
}

#an-element-that-scrolls {
    height: 400px;
    overflow-y: auto;
}
```

```javascript
// call fix after deviceready.
var wrapper = document.getElementById('an-element-that-scrolls');
FixWPBouncing.fix(wrapper);
```

### Note

It seems that if your Cordova app is not in fullscreen, it won't work as properly as if it is (it would get some issue with the status bar height). I am not sure whether this is a bug of Cordova or Windows Phone.

## API

```typescript
declare module FixWPBouncing {
    /** when target is a JQuery, it process the first element only. */
    export function fix(target: HTMLElement|JQuery): void;
}
```

## License

MIT License.