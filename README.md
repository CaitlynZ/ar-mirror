# AR-Mirror Unity Project

## Package

We use Vuforia Engine for AR in this project.
Might need to manually install [Vuforia SDK](https://developer.vuforia.com/downloads/sdk)

- Select and download the "Add Vuforia Engine to a Unity Project or upgrade to the latest version".
- Click on the downloaded file to import into the opened Unity project (like the screenshot below).

  <img width="350" alt="image" src="https://github.com/CaitlynZ/ar-mirror/assets/59945294/dce06080-863a-42e7-bee1-fb07bf2e054a">

## `main` branch

The updated version committed with `Packages/com.ptc.vuforia.engine-10.17.4.tgz` removed (exceed the file size limit).

## process

### randomize hints, only control how many hints shown

- key press on "1", "2", "3" and "4"
  - make the red fail image and the green success invisible
  - show the time with 30 seconds
  - show hints and control how many hints are shown while triggering shuffle
    - the position where hints are shown is randomized
    - current randomize logic: shuffle the list and take as many as needed (from beginning of the list) to display

- key press on "enter"
  - shuffle hints. If you press "enter" when there are hints on the screen, they will change too.

- key press on "5"
  - make the red fail image and the green success invisible
  - show the time with 30 seconds

- key press on "space"
  - pause or re-start the timer

- key press on "0"
  - make hints and timer invisible
  - make the red error image visible

- key press on "s"
  - make hints and timer invisible
  - make the green success image visible
