# Twitch Viewer Roles
Twitch Viewer Roles for LioranBoard and OBS Studio

## Overview

This tool provides an easy way to add or remove permissions for specific viewers in your chat to trigger buttons in [LioranBoard](https://obsproject.com/forum/resources/lioranboard-stream-deck-animator.862/), and you can change those permissions real-time without having to make any changes in LioranBoard. 

You can create Roles for groups of viewers and add or remove viewers from those Roles, then export an example button json for any Role you create, and paste that button in LioranBoard.

## Socials

### Remain Indoors

My Youtube channel: https://www.youtube.com/c/remainindoors

### Thank you Blondie for the idea

Blondie's Twitch: https://www.twitch.tv/blondierox

## How it works
When you first open the Twitch Viewer Roles Tool, select the path to your LioranBoard Receiver folder, and it will create a permission file inside of that folder for the Receiver to read permissions from.

![First Opened](https://www.remainindoors.com/BBC_Pics/FirstOpened.jpg)

Next, enter your Twitch channel name like how it appears in your Twitch URL and click search to populate the current list of users in your chat.

![ChannelUsers](https://www.remainindoors.com/BBC_Pics/ChannelUsersPopulated.jpg)

Right click any of the users in the Left-hand side and choose "Add User To Group". a popup window will appear to ask you to Enter or select a Role Name, so enter a new Role Name or select one that already exists, and click on "Accept" to add that user to a Role in the Permissions Tree.


You can right-click any group in the Left-hand side and choose "Add All Users To Role" to add all of the users from a group to the Permission tree at once.


You can also enter a username manually in the text box at the bottom left of the tool.


In the Permission tree, you can right click any single user and choose "Remove User Permission" to remove them from the Role in the Permission Tree.


You can right click any Role in the Permission tree and choose "Delete Role" to delete any existing Role from the Permission Tree and File


Also, in the Permission Tree, you can right click on any Role and choose "Export Button Example Json" and use that Json string to create a new button in the LioranBoard Receiver.


After you create the button, right-click the button in the LioranBoard Receiver and choose "Edit Commands", and you'll see a "Trigger Button" command inside of an "If Statement".  You can change the Button ID of that command to call some other button, or you can delete the "Trigger Button" command and add your own button commands to make this button work on its own.


After you setup a Twitch Trigger for this new button and click "Done" on the LioranBoard Receiver to save your board, you can use the BBCPermission Tool to change permissions for that button in real-time while you're streaming.


## How to install
You can either download the zip file from the Releases page and extract the TwitchViewerRoles folder to a local drive on your computer, or you can download the latest branch and build it yourself in Visual Studio.

## License
Licensed under the GNU General Public License v3.0
