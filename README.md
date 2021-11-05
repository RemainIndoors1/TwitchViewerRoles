# TwitchViewerRoles
Twitch Viewer Roles Tool for use with LioranBoard and OBS Studio

## Overview

This tool provides an easy way to add or remove permissions for specific users in your chat real-time without having to make any changes in [LioranBoard](https://obsproject.com/forum/resources/lioranboard-stream-deck-animator.862/).

## Socials

### Remain Indoors

My Youtube channel: https://www.youtube.com/c/remainindoors

### Thank you Blondie for the idea

Blondie's Twitch: https://www.twitch.tv/blondierox

## How it works
When you first open the TwitchViewerRoles Tool, select the path to your LioranBoard Receiver folder, and it will create a permission file inside of that folder for the Receiver to read permissions from.

![First Opened](https://www.remainindoors.com/BBC_Pics/FirstOpened.jpg)
![FolderPathSelected](https://www.remainindoors.com/BBC_Pics/FolderPathSelected.jpg)

Next, enter your Twitch channel name like how it appears in your Twitch URL and click search to populate the current list of users in your chat.

![ChannelUsers](https://www.remainindoors.com/BBC_Pics/ChannelUsersPopulated.jpg)

Right click any of the users in the Left-hand side and choose "Add User To Group". a popup window will appear to ask you to Enter or select a Group Name, so enter a new Group Name or select one that already exists, and click on "Accept" to add that user to a Group in the Permissions Tree.

![AddUser](https://www.remainindoors.com/BBC_Pics/AddUser.jpg)
![GroupNameDialog](https://www.remainindoors.com/BBC_Pics/GroupNameDialog.jpg)

You can also right click any group in the Left-hand side and choose "Add All Users To Group" to add all of the users from a group to the Permission tree at once.

![AddAllUsers](https://www.remainindoors.com/BBC_Pics/AddAllUsers.jpg)

In the Permission tree, you can right click any single user and choose "Remove User Permission" to remove them from the group in the Permission Tree.

![RemoveUser](https://www.remainindoors.com/BBC_Pics/RemoveUser.jpg)

Also, in the Permission Tree, you can right click on any group and choose "Export Button Example Json" and use that Json string to create a new button in the LioranBoard Receiver.

![ExportButton](https://www.remainindoors.com/BBC_Pics/ExportButton.jpg)
![ImportJson](https://www.remainindoors.com/BBC_Pics/ImportJson.jpg)

After you create the button, you can right click and choose Edit Commands, and you'll see a "Trigger Button" command inside of an "If Statement".  You can change the Button ID of that command to call some other button, or you can delete the "Trigger Button" command and add your own button commands to make this button work on its own.

![EditCommand](https://www.remainindoors.com/BBC_Pics/EditCommands.jpg)
![EditButton](https://www.remainindoors.com/BBC_Pics/EditButton.jpg)

After you setup a Twitch Trigger for this new button and click "Done" on the LioranBoard Receiver to save your board, you can use the BBCPermission Tool to change permissions for that button in real-time while you're streaming.

![EditButton](https://www.remainindoors.com/BBC_Pics/TwitchTrigger.jpg)

## How to install
You can either download the zip file from the Releases page and extract the TwitchViewerRoles folder to a local drive on your computer, or you can download the latest branch and build it yourself in Visual Studio.

## License
Licensed under the GNU General Public License v3.0
