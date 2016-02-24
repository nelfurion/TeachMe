﻿// Initialize editor with custom theme and modules
var fullEditor = new Quill('#full-editor', {
    modules: {
        'authorship': { authorId: 'galadriel', enabled: true },
        'multi-cursor': true,
        'toolbar': { container: '#full-toolbar' },
        'link-tooltip': true
    },
    theme: 'snow'
});

// Add basic editor's author
var authorship = fullEditor.getModule('authorship');
authorship.addAuthor('gandalf', 'rgba(255,153,51,0.4)');

// Add a cursor to represent basic editor's cursor
var cursorManager = fullEditor.getModule('multi-cursor');
cursorManager.setCursor('gandalf', fullEditor.getLength() - 1, 'Gandalf', 'rgba(255,153,51,0.9)');

// Sync basic editor's cursor location
basicEditor.on('selection-change', function (range) {
    if (range) {
        cursorManager.moveCursor('gandalf', range.end);
    }
});

// Update basic editor's content with ours
fullEditor.on('text-change', function (delta, source) {
    if (source === 'user') {
        basicEditor.updateContents(delta);
    }
});

// basicEditor needs authorship module to accept changes from fullEditor's authorship module
basicEditor.addModule('authorship', {
    authorId: 'gandalf',
    color: 'rgba(255,153,51,0.4)'
});

// Update our content with basic editor's
basicEditor.on('text-change', function (delta, source) {
    if (source === 'user') {
        fullEditor.updateContents(delta);
    }
});