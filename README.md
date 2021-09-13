This fork makes for embedding MarkdownViewer in a EditorWindow a bit easier:
* MarkdownViewer.Draw(float contentWidth = float.NaN)
Passing default value results in normal behavior, but passing a value draws view in the specified width.

* MarkdownViewer.drawToolbar { get; set; } = true;
Prevents the toolbar from being drawn if false, true is normal behavior.

# Unity Markdown Viewer (UMV)
> A markdown viewer for unity

UMV is a Unity editor extension for displaying markdown files in the inspector window.

It should _just work_ without any setup or configuration.

## Installation

Clone the repository into the project `Packages` directory

```
cd Packages
git clone https://github.com/gwaredd/UnityMarkdownViewer.git
```

Alternatively import the `.unitypackage` file from the [releases page](https://github.com/gwaredd/UnityMarkdownViewer/releases).

## NB

Please note, I have renamed the `master` branch to `main`. This may affect existing clones.


## Screenshots

### Light Skin

![Screenshot](https://raw.githubusercontent.com/gwaredd/UnityMarkdownViewer/main/Documentation/images/Screenshot_render_v2.png)

### Dark Skin

![Screenshot](https://raw.githubusercontent.com/gwaredd/UnityMarkdownViewer/main/Documentation/images/Screenshot_render_dark.png)

