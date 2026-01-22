Windows XP-style interactive desktop
===================================

This small demo recreates a Windows XP-like desktop using plain HTML, Tailwind CSS (CDN for quick use) and vanilla JavaScript.

What you get
- A desktop background (Bliss image) with clickable icons: "Mi PC", "Mis Documentos", "Papelera de reciclaje", "Navegador".
- Floating windows with XP-like titlebar (minimize, maximize/restore, close).
- Drag windows by the titlebar, minimize to the taskbar, restore from taskbar, maximize/restore with animation.
- Taskbar with Start button (left) and clock (right). Minimized windows appear in the task area.
- Icon selection effect, keyboard accessibility for icons, and optional short sounds when opening/closing windows.
- Persistence: open windows and their positions/sizes are saved to localStorage and restored on reload.

Files
- index.html — main page
- css/styles.css — extra helpers (Tailwind is loaded from CDN in index.html)
- js/script.js — window and desktop logic

How to run
1. Open `index.html` in your browser (no build step needed). For some browsers you may need to serve via a simple server:

   # PowerShell example
   python -m http.server 8000

   Then open http://localhost:8000 in your browser.

Customizing
- Change apps: edit the `apps` array at the top of `js/script.js` to add/remove or change desktop apps and their content.
- Icons/thumbnails: replace the emoji in the `icon` property or set `content` to include an `<img>` tag with a relative path inside the project.
- Tailwind production: replace the CDN usage with a built `styles.css` if you want to trim unused classes (Tailwind CLI/JIT).

Build Tailwind locally (optional)
--------------------------------
If you prefer to build a local optimized `css/styles.css` instead of using the CDN, the repository includes a basic Tailwind setup.

1. Install Node.js (>=16) and run in the project folder:

   npm install

2. Build once:

   npm run build:css

3. Or run watch during development:

   npm run watch:css

This will generate `css/styles.css` from `src/input.css` using `tailwind.config.cjs`.

Notes: I included `package.json`, `tailwind.config.cjs` and `src/input.css`. I didn't run the build in this environment. Run the commands above locally to produce the compiled CSS.

Next steps you might want
- Add a right-click context menu on the desktop.
- Add a Start menu with pinned/frequently used apps, shutdown/restart options, and submenu items.
- Provide a real file browser (drag/drop files) or wire the "Navegador" app to open links/projects.
- Add sound assets for more realistic XP interaction (current implementation uses WebAudio beep tones).

Known limitations
- The demo uses Tailwind CDN for convenience; for production you should compile Tailwind to reduce file size.
- Windows are not snap-to-edge except maximize; you can add snapping behavior if desired.
- Persistence saves basic geometry only; multi-instance windows and more complex state may need extra handling.

If you want, I can:
- Convert Tailwind CDN to a compiled `styles.css` using Tailwind CLI and add a small build script.
- Add more apps, icons, and sample images inside a new `images/` folder.
- Improve accessibility (aria roles, focus trapping when windows open, keyboard navigation for taskbar/start menu).

Which of the above would you like me to do next?
