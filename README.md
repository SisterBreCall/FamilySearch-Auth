
# Unity ECS (Entity Component System) C# FamilySearch Authenticator

- Works with Unity 6 Beta (6000.0.0b12)
- Builds for PC, Mac, and Web Platforms
- Includes callback.html and index.html
- Gets authentication code, access token, id token, and information on current user.
- Decodes JWT id token
- Gets 4 generations of ancestors for current user and creates individual entities for each ancestor.

# How To Setup Project with FamilySearch API Key

1. Open file in project at Assets/Scripts/Systems/CreateFSEntity.cs. (https://github.com/SisterBreCall/FamilySearch-Auth/blob/main/Assets/Scripts/Systems/CreateFSEntity.cs)
2. Set devEnvironment variable to Integration, Beta, or Production.
3. Set clientID variable with FamilySearch API key.
4. If building for web platform, set WebCallbackLocation variable to where the URL is for the callback.html file in your web directory.

# How To Build for Web Platform
1. Under Buld Profiles, under Platforms click Web, and click Switch Platform
2. Click Build
3. Set build directory to where you want the web build to go.
4. Modify index.html in build directory to add variables and function as shown with comments at (https://github.com/SisterBreCall/FamilySearch-Auth/blob/main/index.html)
5. Upload build directory to web server directory.
6. Make sure callback.html is in location for redirect url set by FamilySearch.
